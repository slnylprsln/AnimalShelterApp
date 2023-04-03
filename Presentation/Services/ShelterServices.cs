using Newtonsoft.Json;
using Presentation.Models;
using Presentation.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Services
{
	public class ShelterServices : IShelterServices
	{
		public async Task<List<Shelter>> GetShelters()
		{
			List<Shelter> shelters = null;
			using (var client = new HttpClient { BaseAddress = new Uri("https://localhost:7229") })
			{
				var url = $"\\Shelter";
				var result = await client.GetAsync(url);
				if (result.IsSuccessStatusCode)
				{
					string response = await result.Content.ReadAsStringAsync();
					shelters = JsonConvert.DeserializeObject<List<Shelter>>(response);
				}
			}
			return shelters;
		}
        public async Task<Shelter> GetShelterById(int id)
        {
            Shelter shelter = null;
            using (var client = new HttpClient { BaseAddress = new Uri("https://localhost:7229") })
            {
                var url = $"\\Shelter\\byId\\{id}";
                var result = await client.GetAsync(url);
                if (result.IsSuccessStatusCode)
                {
                    string response = await result.Content.ReadAsStringAsync();
                    shelter = JsonConvert.DeserializeObject<Shelter>(response);
                }
            }
            return shelter;
        }

        public async Task<bool> AddShelter(Shelter shelter)
		{
			using var client = new HttpClient { BaseAddress = new Uri("https://localhost:7229") };
			var url = $"\\Shelter";
			var stringContent = new StringContent(JsonConvert.SerializeObject(shelter), Encoding.UTF8, "application/json");
			var result = await client.PostAsync(url, stringContent);
			if (result.IsSuccessStatusCode)
			{
				return true;
			}
			else return false;
		}

		public async Task<bool> EditShelter(Shelter shelter)
		{
			using var client = new HttpClient { BaseAddress = new Uri("https://localhost:7229") };
			var url = $"\\Shelter\\{shelter.ShelterId}";
			var stringContent = new StringContent(JsonConvert.SerializeObject(shelter), Encoding.UTF8, "application/json");
			var result = await client.PutAsync(url, stringContent);
			if (result.IsSuccessStatusCode)
			{
				return true;
			}
			else return false;
		}
		public async Task<bool> DeleteShelter(Shelter shelter)
		{
			using var client = new HttpClient { BaseAddress = new Uri("https://localhost:7229") };
			var url = $"\\Shelter\\{shelter.ShelterId}";
			var result = await client.DeleteAsync(url);
			if (result.IsSuccessStatusCode)
			{
				return true;
			}
			else return false;
		}
	}
}
