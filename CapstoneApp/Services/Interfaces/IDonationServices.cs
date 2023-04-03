using CapstoneApp.Models;

namespace CapstoneApp.Services.Interfaces
{
    public interface IDonationServices
    {
        public Task<List<Donation>> GetDonations();
        public Task<List<Donation>> GetDonationsByUserId(int userId);
        public Task<List<Donation>> GetDonationsByShelterId(int shelterId);
        public Task<List<Donation>> GetApprovedDonationsByShelterId(int shelterId);
		public Task<Donation> GetById(int id);
        public Task<bool> EditDonation(Donation donation);
        public Task<bool> AddDonation(Donation donation);

	}
}
