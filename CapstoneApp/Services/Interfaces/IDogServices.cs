using CapstoneApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneApp.Services.Interfaces
{
	public interface IDogServices
	{
		public Task<List<Dog>> GetDogs();
		public Task<bool> AddDog(Dog dog);
		public Task<bool> EditDog(Dog dog);
		public Task<bool> DeleteDog(Dog dog);
		public Task<List<Dog>> GetByShelterId(int shelterId);
		public Task<Dog> GetDogById(int? id);
		public Task<List<Dog>> GetByOwnerId(int userId);

		public Task<List<DogVaccination>> GetVaccinations(int dogId);
		public Task<bool> AddVaccination(DogVaccination vaccination);
		public Task<bool> EditVaccination(DogVaccination vaccination);
		public Task<bool> DeleteVaccination(DogVaccination vaccination);

		public Task<List<DogTesting>> GetTestings(int dogId);
		public Task<bool> AddTesting(DogTesting testing);
		public Task<bool> EditTesting(DogTesting testing);
		public Task<bool> DeleteTesting(DogTesting testing);

		public Task<List<DogDiseaseHistory>> GetDiseaseHistory(int dogId);
		public Task<bool> AddDiseaseHistory(DogDiseaseHistory diseaseHistory);
		public Task<bool> EditDiseaseHistory(DogDiseaseHistory diseaseHistory);
		public Task<bool> DeleteDiseaseHistory(DogDiseaseHistory diseaseHistory);
	}
}
