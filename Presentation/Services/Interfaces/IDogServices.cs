using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Services.Interfaces
{
	public interface IDogServices
	{
		public Task<List<Dog>> GetDogs();
		public Task<bool> AddDog(Dog dog);
		public Task<bool> EditDog(Dog dog);
		public Task<bool> DeleteDog(Dog dog);
		public Task<List<Dog>> GetByShelterId(int shelterId);
		public Task<List<DogVaccination>> GetVaccinations(int dogId);
		public Task<List<DogTesting>> GetTestings(int dogId);
		public Task<List<DogDiseaseHistory>> GetDiseaseHistory(int dogId);
	}
}
