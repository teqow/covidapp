using CovidApp.Application.Dtos;
using CovidApp.Domain.HospitalPatient;
using CovidApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidApp.Application
{
    public interface IHospitalPatientService
    {
        Task AddAsync(HospitalPatientModel request);
        Task<List<HospitalPatientsDto>> GetHostpialPatientsAsync();
        Task<HospitalPatientDetailsDto> GetHospitalPatientDetailsAsync(Guid id);
    }

    public class HospitalPatientService : IHospitalPatientService
    {
        private readonly IHostpitalPatientRepoistory _hostpitalPatientRepoistory;
        private readonly IBlobStorageProvider _blobStorageProvider;
        private readonly IAzureTableLogger _azureTableLogger;

        public HospitalPatientService(IHostpitalPatientRepoistory hostpitalPatientRepoistory, IBlobStorageProvider blobStorageProvider, IAzureTableLogger azureTableLogger)
        {
            _hostpitalPatientRepoistory = hostpitalPatientRepoistory;
            _blobStorageProvider = blobStorageProvider;
            _azureTableLogger = azureTableLogger;
        }

        public async Task AddAsync(HospitalPatientModel request)
        {
            var fileName = await _blobStorageProvider.UploadFile(request.Photo);
            var hospitalPatient = HospitalPatient.Create(Guid.NewGuid(), request.FirstName, request.LastName, request.Age, request.DocumentId, fileName);

            await _hostpitalPatientRepoistory.AddAsync(hospitalPatient);

            await _azureTableLogger.LogAsync(new LogEntity
            {
                FirstName = hospitalPatient.FirstName,
                LastName = hospitalPatient.LastName,
                CreatedOn = DateTime.Now,
                Message = "HospitalPatientCreated",
                RowKey = Guid.NewGuid().ToString(),
                PartitionKey = "Log"
            });
        }

        public async Task<HospitalPatientDetailsDto> GetHospitalPatientDetailsAsync(Guid id)
        {
            var hospitalPatient = await _hostpitalPatientRepoistory.GetHospitalPatientAsync(id);

            return new HospitalPatientDetailsDto
            {
                FirstName = hospitalPatient.FirstName,
                LastName = hospitalPatient.LastName,
                Age = hospitalPatient.Age,
                DocumentId = hospitalPatient.DocumentId,
                Photo = Flurl.Url.Combine(hospitalPatient.Photo)
            };
        }

        public async Task<List<HospitalPatientsDto>> GetHostpialPatientsAsync()
        {
            var hospitalPatients = await _hostpitalPatientRepoistory.GetHostpialPatientsAsync();

            return hospitalPatients
                .Select(c => new HospitalPatientsDto
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    DocumentId = c.DocumentId,
                    Id = c.Id
                }).ToList();
        }
    }
}