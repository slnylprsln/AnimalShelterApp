using Newtonsoft.Json;
using CapstoneApp.Models;
using CapstoneApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneApp.Services
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
		public async Task<Shelter> GetShelterByOwnerId(int ownerId)
		{
			Shelter shelter = null;
			List<Shelter> list = await GetShelters();
			foreach (var item in list)
			{
				if (item.UserId == ownerId)
				{
					shelter = item;
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

		public async Task<bool> PerformDonation(Models.Type donationType, int amount, int shelterId)
		{
			Shelter shelter = await GetShelterById(shelterId);
			if (donationType == Models.Type.Kedi_Maması)
			{
				shelter.CatFoodStock += amount;
				var result = await EditShelter(shelter);
				if (result == true)
				{
					return true;
				}
				else return false;
			}
			if (donationType == Models.Type.Köpek_Maması)
			{
				shelter.DogFoodStock += amount;
				var result = await EditShelter(shelter);
				if (result == true)
				{
					return true;
				}
				else return false;
			}
			if (donationType == Models.Type.Kuduz_Aşısı)
			{
				shelter.RabiesVaccineStock += amount;
				var result = await EditShelter(shelter);
				if (result == true)
				{
					return true;
				}
				else return false;
			}
			if (donationType == Models.Type.Kombinasyon_Aşısı)
			{
				shelter.CombinationVaccineStock += amount;
				var result = await EditShelter(shelter);
				if (result == true)
				{
					return true;
				}
				else return false;
			}
			if (donationType == Models.Type.Parvovirüs_Aşısı)
			{
				shelter.ParvovirusVaccineStock += amount;
				var result = await EditShelter(shelter);
				if (result == true)
				{
					return true;
				}
				else return false;
			}
			if (donationType == Models.Type.Distemper_Aşısı)
			{
				shelter.DistemperVaccineStock += amount;
				var result = await EditShelter(shelter);
				if (result == true)
				{
					return true;
				}
				else return false;
			}
			else
			{
				shelter.HepatitisVaccineStock += amount;
				var result = await EditShelter(shelter);
				if (result == true)
				{
					return true;
				}
				else return false;
			}
		}


	}
}
