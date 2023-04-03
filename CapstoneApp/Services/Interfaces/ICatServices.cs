using CapstoneApp.Models;

namespace CapstoneApp.Services.Interfaces
{
	public interface ICatServices
	{
		public Task<List<Cat>> GetCats();
		public Task<bool> AddCat(Cat cat);
		public Task<bool> EditCat(Cat cat);
		public Task<bool> DeleteCat(Cat cat);
		public Task<Cat> GetCatById(int? id);
		public Task<List<Cat>> GetByShelterId(int shelterId); 

		public Task<List<CatVaccination>> GetVaccinations(int catId);
		public Task<bool> AddVaccination(CatVaccination vaccination);
		public Task<bool> EditVaccination(CatVaccination vaccination);
		public Task<bool> DeleteVaccination(CatVaccination vaccination);

		public Task<List<CatTesting>> GetTestings(int catId);
		public Task<bool> AddTesting(CatTesting testing);
		public Task<bool> EditTesting(CatTesting testing);
		public Task<bool> DeleteTesting(CatTesting testing);

		public Task<List<CatDiseaseHistory>> GetDiseaseHistory(int catId);
		public Task<bool> AddDiseaseHistory(CatDiseaseHistory diseaseHistory);
		public Task<bool> EditDiseaseHistory(CatDiseaseHistory diseaseHistory);
		public Task<bool> DeleteDiseaseHistory(CatDiseaseHistory diseaseHistory);
	}
}
