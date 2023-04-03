using Presentation.Models;

namespace Presentation.Services.Interfaces
{
	public interface ICatServices
	{
		public Task<List<Cat>> GetCats();
		public Task<bool> AddCat(Cat cat);
		public Task<bool> EditCat(Cat cat);
		public Task<bool> DeleteCat(Cat cat);
		public Task<List<Cat>> GetByShelterId(int shelterId); 
		public Task<List<CatVaccination>> GetVaccinations(int catId);
		public Task<List<CatTesting>> GetTestings(int catId);
		public Task<List<CatDiseaseHistory>> GetDiseaseHistory(int catId);

	}
}
