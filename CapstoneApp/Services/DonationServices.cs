using CapstoneApp.Models;
using CapstoneApp.Services.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace CapstoneApp.Services
{
    public class DonationServices : IDonationServices
    {
        public async Task<bool> AddDonation(Donation donation)
        {
            using var client = new HttpClient { BaseAddress = new Uri("https://localhost:7229") };
            var url = $"\\Donation";
            var stringContent = new StringContent(JsonConvert.SerializeObject(donation), Encoding.UTF8, "application/json");
            var result = await client.PostAsync(url, stringContent);
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            else return false;
        }

        public async Task<Donation> GetById(int id)
        {
            Donation donation = null;
            using (var client = new HttpClient { BaseAddress = new Uri("https://localhost:7229") })
            {
                var url = $"\\Donation\\byId\\{id}";
                var result = await client.GetAsync(url);
                if (result.IsSuccessStatusCode)
                {
                    string response = await result.Content.ReadAsStringAsync();
                    donation = JsonConvert.DeserializeObject<Donation>(response);
                }
            }
            return donation;
        }

        public async Task<List<Donation>> GetDonations()
        {
            List<Donation> donations = null;
            using (var client = new HttpClient { BaseAddress = new Uri("https://localhost:7229") })
            {
                var url = $"\\Donation";
                var result = await client.GetAsync(url);
                if (result.IsSuccessStatusCode)
                {
                    string response = await result.Content.ReadAsStringAsync();
                    donations = JsonConvert.DeserializeObject<List<Donation>>(response);
                }
            }
            return donations;
        }

        public async Task<bool> EditDonation(Donation donation)
        {
            using var client = new HttpClient { BaseAddress = new Uri("https://localhost:7229") };
            var url = $"\\Donation\\{donation.DonationId}";
            var stringContent = new StringContent(JsonConvert.SerializeObject(donation), Encoding.UTF8, "application/json");
            var result = await client.PutAsync(url, stringContent);
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            else return false;
        }

        public async Task<List<Donation>> GetDonationsByShelterId(int shelterId)
        {
            var donations = await GetDonations();
            var shelterDonations = new List<Donation>();
            foreach (var donation in donations)
            {
                if (donation.ShelterId == shelterId)
                {
                    shelterDonations.Add(donation);
                }
            }
            return shelterDonations;
        }

		public async Task<List<Donation>> GetApprovedDonationsByShelterId(int shelterId)
		{
			var donations = await GetDonations();
			var shelterDonations = new List<Donation>();
			foreach (var donation in donations)
			{
				if (donation.ShelterId == shelterId && donation.Verification == true)
				{
					shelterDonations.Add(donation);
				}
			}
			return shelterDonations;
		}

		public async Task<List<Donation>> GetDonationsByUserId(int userId)
        {
            var donations = await GetDonations();
            var userDonations = new List<Donation>();
            foreach (var donation in donations)
            {
                if (donation.UserId == userId)
                {
                    userDonations.Add(donation);
                }
            }
            return userDonations;
        }

        
    }
}
