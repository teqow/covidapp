using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CovidApp.Domain.HospitalPatient
{
    public interface IHostpitalPatientRepoistory
    {
        Task AddAsync(HospitalPatient hospitalPatient);
        Task<List<HospitalPatient>> GetHostpialPatientsAsync();
        Task<HospitalPatient> GetHospitalPatientAsync(Guid id);
    }
}
