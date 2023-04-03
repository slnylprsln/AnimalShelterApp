using CapstoneApp.Models;

namespace CapstoneApp.Services.Interfaces
{
	public interface IShelterServices
	{
		public Task<List<Shelter>> GetShelters();
		public Task<bool> AddShelter(Shelter shelter);
		public Task<bool> EditShelter(Shelter shelter);
		public Task<bool> DeleteShelter(Shelter shelter);
        public Task<Shelter> GetShelterById(int id);
		public Task<Shelter> GetShelterByOwnerId(int ownerId);
		public Task<bool> PerformDonation(Models.Type donationType, int amount, int shelterId);


	}
}
