using CovidApp.Domain.HospitalPatient;
using Microsoft.Azure.Cosmos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CovidApp.Infrastructure.Domain
{
    public class HospitalPatientRepository : IHostpitalPatientRepoistory
    {
        private readonly Container _container;

        public HospitalPatientRepository(string connectionString, string database = "Hospital", string container = "Patients")
        {
            _container = new CosmosClient(connectionString)
                .GetDatabase(database)
                .GetContainer(container);
        }

        public async Task AddAsync(HospitalPatient hospitalPatient)
        {
            await _container.CreateItemAsync<Model>(new Model
            {
                Id = hospitalPatient.Id,
                FirstName = hospitalPatient.FirstName,
                LastName = hospitalPatient.LastName,
                DocumentId = hospitalPatient.DocumentId,
                Age = hospitalPatient.Age,
                CreatedOn = hospitalPatient.CreatedOn,
                Photo = hospitalPatient.Photo
            });
        }

        public async Task<HospitalPatient> GetHospitalPatientAsync(Guid id)
        {
            string query = $@"SELECT * FROM Patients WHERE Patients.id = '{id}'";

            var iterator = _container.GetItemQueryIterator<Model>(query);

            List<Model> matches = new List<Model>();
            while (iterator.HasMoreResults)
            {
                var next = await iterator.ReadNextAsync();
                matches.AddRange(next);
            }

            return matches.Select(c => HospitalPatient.Create(c.Id, c.FirstName, c.LastName, c.Age, c.DocumentId, c.Photo)).SingleOrDefault();
        }

        public async Task<List<HospitalPatient>> GetHostpialPatientsAsync()
        {
            string query = $@"SELECT * FROM Patients";

            var iterator = _container.GetItemQueryIterator<Model>(query);

            List<Model> matches = new List<Model>();
            while (iterator.HasMoreResults)
            {
                var next = await iterator.ReadNextAsync();
                matches.AddRange(next);
            }

            return matches.Select(c => HospitalPatient.Create(c.Id, c.FirstName, c.LastName, c.Age, c.DocumentId, c.Photo)).ToList();
        }

        private class Model
        {
            [JsonProperty(PropertyName = "id")]
            public Guid Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public string DocumentId { get; set; }
            public string Photo { get; set; }
            public DateTime CreatedOn { get; set; }
        }
    }
}