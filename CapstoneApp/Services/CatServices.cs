using Newtonsoft.Json;
using CapstoneApp.Models;
using CapstoneApp.Services.Interfaces;
using System.Text;

namespace CapstoneApp.Services
{
	public class CatServices : ICatServices
	{
		public async Task<bool> AddCat(Cat cat)
		{
			using var client = new HttpClient { BaseAddress = new Uri("https://localhost:7229") };
			var url = $"\\Cat";
			var stringContent = new StringContent(JsonConvert.SerializeObject(cat), Encoding.UTF8, "application/json");
			var result = await client.PostAsync(url, stringContent);
			if (result.IsSuccessStatusCode)
			{
				return true;
			}
			else return false;
		}

		public async Task<bool> DeleteCat(Cat cat)
		{
			using var client = new HttpClient { BaseAddress = new Uri("https://localhost:7229") };
			var url = $"\\Cat\\{cat.CatId}";
			var result = await client.DeleteAsync(url);
			if (result.IsSuccessStatusCode)
			{
				return true;
			}
			else return false;
		}

		public async Task<bool> EditCat(Cat cat)
		{
			using var client = new HttpClient { BaseAddress = new Uri("https://localhost:7229") };
			var url = $"\\Cat\\{cat.CatId}";
			var stringContent = new StringContent(JsonConvert.SerializeObject(cat), Encoding.UTF8, "application/json");
			var result = await client.PutAsync(url, stringContent);
			if (result.IsSuccessStatusCode)
			{
				return true;
			}
			else return false;
		}

		public async Task<List<Cat>> GetByShelterId(int shelterId)
		{
			var cats = await GetCats();
			var shelterCats = new List<Cat>();
			foreach (var cat in cats)
			{
				if (cat.ShelterId == shelterId)
				{
					shelterCats.Add(cat);
				}
			}
			return shelterCats;
		}

		public async Task<List<Cat>> GetCats()
		{
			List<Cat> cats = null;
			using (var client = new HttpClient { BaseAddress = new Uri("https://localhost:7229") })
			{
				var url = $"\\Cat";
				var result = await client.GetAsync(url);
				if (result.IsSuccessStatusCode)
				{
					string response = await result.Content.ReadAsStringAsync();
					cats = JsonConvert.DeserializeObject<List<Cat>>(response);
				}
			}
			return cats;
		}

		public async Task<Cat> GetCatById(int? id)
		{
			Cat cat = null;
			if (id != null)
			{
				using (var client = new HttpClient { BaseAddress = new Uri("https://localhost:7229") })
				{
					var url = $"\\Cat\\byId\\{id}";
					var result = await client.GetAsync(url);
					if (result.IsSuccessStatusCode)
					{
						string response = await result.Content.ReadAsStringAsync();
						cat = JsonConvert.DeserializeObject<Cat>(response);
					}
				}
			}
			return cat;
		}

		public async Task<List<Cat>> GetByOwnerId(int userId)
		{
			var cats = await GetCats();
			var ownerCats = new List<Cat>();
			foreach (var cat in cats)
			{
				if (cat.UserId == userId)
				{
					ownerCats.Add(cat);
				}
			}
			return ownerCats;
		}

		// VACCINATION RELATED FUNCTIONS
		public async Task<List<CatVaccination>> GetVaccinations(int catId)
		{
			List<CatVaccination> vaccinations = null;
			using (var client = new HttpClient { BaseAddress = new Uri("https://localhost:7229") })
			{
				var url = $"\\Cat\\Vaccination\\{catId}";
				var result = await client.GetAsync(url);
				if (result.IsSuccessStatusCode)
				{
					string response = await result.Content.ReadAsStringAsync();
					vaccinations = JsonConvert.DeserializeObject<List<CatVaccination>>(response);
				}
			}
			return vaccinations;
		}

		public async Task<bool> AddVaccination(CatVaccination vaccination)
		{
			using var client = new HttpClient { BaseAddress = new Uri("https://localhost:7229") };
			var url = $"\\CatVaccination";
			vaccination.CatVaccinationId = 0;
			var stringContent = new StringContent(JsonConvert.SerializeObject(vaccination), Encoding.UTF8, "application/json");
			var result = await client.PostAsync(url, stringContent);
			if (result.IsSuccessStatusCode)
			{
				return true;
			}
			else return false;
		}

		public async Task<bool> EditVaccination(CatVaccination vaccination)
		{
			using var client = new HttpClient { BaseAddress = new Uri("https://localhost:7229") };
			var url = $"\\CatVaccination\\{vaccination.CatVaccinationId}";
			var stringContent = new StringContent(JsonConvert.SerializeObject(vaccination), Encoding.UTF8, "application/json");
			var result = await client.PutAsync(url, stringContent);
			if (result.IsSuccessStatusCode)
			{
				return true;
			}
			else return false;
		}

		public async Task<bool> DeleteVaccination(CatVaccination vaccination)
		{
			using var client = new HttpClient { BaseAddress = new Uri("https://localhost:7229") };
			var url = $"\\CatVaccination\\{vaccination.CatVaccinationId}";
			var result = await client.DeleteAsync(url);
			if (result.IsSuccessStatusCode)
			{
				return true;
			}
			else return false;
		}
		// TESTING RELATED FUNCTIONS
		public async Task<List<CatTesting>> GetTestings(int catId)
		{
			List<CatTesting> testings = null;
			using (var client = new HttpClient { BaseAddress = new Uri("https://localhost:7229") })
			{
				var url = $"\\Cat\\Testing\\{catId}";
				var result = await client.GetAsync(url);
				if (result.IsSuccessStatusCode)
				{
					string response = await result.Content.ReadAsStringAsync();
					testings = JsonConvert.DeserializeObject<List<CatTesting>>(response);
				}
			}
			return testings;
		}

		public async Task<bool> AddTesting(CatTesting testing)
		{
			using var client = new HttpClient { BaseAddress = new Uri("https://localhost:7229") };
			var url = $"\\CatTesting";
			testing.CatTestingId = 0;
			var stringContent = new StringContent(JsonConvert.SerializeObject(testing), Encoding.UTF8, "application/json");
			var result = await client.PostAsync(url, stringContent);
			if (result.IsSuccessStatusCode)
			{
				return true;
			}
			else return false;
		}

		public async Task<bool> EditTesting(CatTesting testing)
		{
			using var client = new HttpClient { BaseAddress = new Uri("https://localhost:7229") };
			var url = $"\\CatTesting\\{testing.CatTestingId}";
			var stringContent = new StringContent(JsonConvert.SerializeObject(testing), Encoding.UTF8, "application/json");
			var result = await client.PutAsync(url, stringContent);
			if (result.IsSuccessStatusCode)
			{
				return true;
			}
			else return false;
		}

		public async Task<bool> DeleteTesting(CatTesting testing)
		{
			using var client = new HttpClient { BaseAddress = new Uri("https://localhost:7229") };
			var url = $"\\CatTesting\\{testing.CatTestingId}";
			var result = await client.DeleteAsync(url);
			if (result.IsSuccessStatusCode)
			{
				return true;
			}
			else return false;
		}


		// DISEASE HISTORY RELATED FUNCTIONS
		public async Task<List<CatDiseaseHistory>> GetDiseaseHistory(int catId)
		{
			List<CatDiseaseHistory> diseaseHistories = null;
			using (var client = new HttpClient { BaseAddress = new Uri("https://localhost:7229") })
			{
				var url = $"\\Cat\\DiseaseHistory\\{catId}";
				var result = await client.GetAsync(url);
				if (result.IsSuccessStatusCode)
				{
					string response = await result.Content.ReadAsStringAsync();
					diseaseHistories = JsonConvert.DeserializeObject<List<CatDiseaseHistory>>(response);
				}
			}
			return diseaseHistories;
		}

		public async Task<bool> AddDiseaseHistory(CatDiseaseHistory diseaseHistory)
		{
			using var client = new HttpClient { BaseAddress = new Uri("https://localhost:7229") };
			var url = $"\\CatDiseaseHistory";
			diseaseHistory.CatDiseaseHistoryId = 0;
			var stringContent = new StringContent(JsonConvert.SerializeObject(diseaseHistory), Encoding.UTF8, "application/json");
			var result = await client.PostAsync(url, stringContent);
			if (result.IsSuccessStatusCode)
			{
				return true;
			}
			else return false;
		}

		public async Task<bool> EditDiseaseHistory(CatDiseaseHistory diseaseHistory)
		{
			using var client = new HttpClient { BaseAddress = new Uri("https://localhost:7229") };
			var url = $"\\CatDiseaseHistory\\{diseaseHistory.CatDiseaseHistoryId}";
			var stringContent = new StringContent(JsonConvert.SerializeObject(diseaseHistory), Encoding.UTF8, "application/json");
			var result = await client.PutAsync(url, stringContent);
			if (result.IsSuccessStatusCode)
			{
				return true;
			}
			else return false;
		}

		public async Task<bool> DeleteDiseaseHistory(CatDiseaseHistory diseaseHistory)
		{
			using var client = new HttpClient { BaseAddress = new Uri("https://localhost:7229") };
			var url = $"\\CatDiseaseHistory\\{diseaseHistory.CatDiseaseHistoryId}";
			var result = await client.DeleteAsync(url);
			if (result.IsSuccessStatusCode)
			{
				return true;
			}
			else return false;
		}
	}
}
