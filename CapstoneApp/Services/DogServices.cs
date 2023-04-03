using Newtonsoft.Json;
using CapstoneApp.Models;
using CapstoneApp.Services.Interfaces;
using System.Text;

namespace CapstoneApp.Services
{
	public class DogServices : IDogServices
	{
		public async Task<bool> AddDog(Dog dog)
		{
			using var client = new HttpClient { BaseAddress = new Uri("https://localhost:7229") };
			var url = $"\\Dog";
			var stringContent = new StringContent(JsonConvert.SerializeObject(dog), Encoding.UTF8, "application/json");
			var result = await client.PostAsync(url, stringContent);
			if (result.IsSuccessStatusCode)
			{
				return true;
			}
			else return false;
		}

		public async Task<bool> DeleteDog(Dog dog)
		{
			using var client = new HttpClient { BaseAddress = new Uri("https://localhost:7229") };
			var url = $"\\Dog\\{dog.DogId}";
			var result = await client.DeleteAsync(url);
			if (result.IsSuccessStatusCode)
			{
				return true;
			}
			else return false;
		}

		public async Task<bool> EditDog(Dog dog)
		{
			using var client = new HttpClient { BaseAddress = new Uri("https://localhost:7229") };
			var url = $"\\Dog\\{dog.DogId}";
			var stringContent = new StringContent(JsonConvert.SerializeObject(dog), Encoding.UTF8, "application/json");
			var result = await client.PutAsync(url, stringContent);
			if (result.IsSuccessStatusCode)
			{
				return true;
			}
			else return false;
		}

		public async Task<List<Dog>> GetByShelterId(int shelterId)
		{
			List<Dog> dogs = await GetDogs();
			var shelterDogs = new List<Dog>();
			if (dogs != null)
			{
				foreach (var dog in dogs)
				{
					if (dog.ShelterId == shelterId)
					{
						shelterDogs.Add(dog);
					}
				}
			}
			return shelterDogs;
		}

		public async Task<List<Dog>> GetDogs()
		{
			List<Dog> dogs = null;
			using (var client = new HttpClient { BaseAddress = new Uri("https://localhost:7229") })
			{
				var url = $"\\Dog";
				var result = await client.GetAsync(url);
				if (result.IsSuccessStatusCode)
				{
					string response = await result.Content.ReadAsStringAsync();
					dogs = JsonConvert.DeserializeObject<List<Dog>>(response);
				}
			}
			return dogs;
		}

		public async Task<List<Dog>> GetByOwnerId(int userId)
		{
			var dogs = await GetDogs();
			var ownerDogs = new List<Dog>();
			foreach (var dog in dogs)
			{
				if (dog.UserId == userId)
				{
					ownerDogs.Add(dog);
				}
			}
			return ownerDogs;
		}

		public async Task<Dog> GetDogById(int? id)
		{
			Dog dog = null;
			if (id != null)
			{
				using (var client = new HttpClient { BaseAddress = new Uri("https://localhost:7229") })
				{
					var url = $"\\Dog\\byId\\{id}";
					var result = await client.GetAsync(url);
					if (result.IsSuccessStatusCode)
					{
						string response = await result.Content.ReadAsStringAsync();
						dog = JsonConvert.DeserializeObject<Dog>(response);
					}
				}
			}
			return dog;
		}

		// VACCINATION RELATED FUNCTIONS
		public async Task<List<DogVaccination>> GetVaccinations(int dogId)
		{
			List<DogVaccination> vaccinations = null;
			using (var client = new HttpClient { BaseAddress = new Uri("https://localhost:7229") })
			{
				var url = $"\\Dog\\Vaccination\\{dogId}";
				var result = await client.GetAsync(url);
				if (result.IsSuccessStatusCode)
				{
					string response = await result.Content.ReadAsStringAsync();
					vaccinations = JsonConvert.DeserializeObject<List<DogVaccination>>(response);
				}
			}
			return vaccinations;
		}

		public async Task<bool> AddVaccination(DogVaccination vaccination)
		{
			using var client = new HttpClient { BaseAddress = new Uri("https://localhost:7229") };
			var url = $"\\DogVaccination";
			var stringContent = new StringContent(JsonConvert.SerializeObject(vaccination), Encoding.UTF8, "application/json");
			var result = await client.PostAsync(url, stringContent);
			if (result.IsSuccessStatusCode)
			{
				return true;
			}
			else return false;
		}

		public async Task<bool> EditVaccination(DogVaccination vaccination)
		{
			using var client = new HttpClient { BaseAddress = new Uri("https://localhost:7229") };
			var url = $"\\DogVaccination\\{vaccination.DogVaccinationId}";
			var stringContent = new StringContent(JsonConvert.SerializeObject(vaccination), Encoding.UTF8, "application/json");
			var result = await client.PutAsync(url, stringContent);
			if (result.IsSuccessStatusCode)
			{
				return true;
			}
			else return false;
		}

		public async Task<bool> DeleteVaccination(DogVaccination vaccination)
		{
			using var client = new HttpClient { BaseAddress = new Uri("https://localhost:7229") };
			var url = $"\\DogVaccination\\{vaccination.DogVaccinationId}";
			var result = await client.DeleteAsync(url);
			if (result.IsSuccessStatusCode)
			{
				return true;
			}
			else return false;
		}

		// TESTING RELATED FUNCTIONS
		public async Task<List<DogTesting>> GetTestings(int dogId)
		{
			List<DogTesting> testings = null;
			using (var client = new HttpClient { BaseAddress = new Uri("https://localhost:7229") })
			{
				var url = $"\\Dog\\Testing\\{dogId}";
				var result = await client.GetAsync(url);
				if (result.IsSuccessStatusCode)
				{
					string response = await result.Content.ReadAsStringAsync();
					testings = JsonConvert.DeserializeObject<List<DogTesting>>(response);
				}
			}
			return testings;
		}

		public async Task<bool> AddTesting(DogTesting testing)
		{
			using var client = new HttpClient { BaseAddress = new Uri("https://localhost:7229") };
			var url = $"\\DogTesting";
			var stringContent = new StringContent(JsonConvert.SerializeObject(testing), Encoding.UTF8, "application/json");
			var result = await client.PostAsync(url, stringContent);
			if (result.IsSuccessStatusCode)
			{
				return true;
			}
			else return false;
		}

		public async Task<bool> EditTesting(DogTesting testing)
		{
			using var client = new HttpClient { BaseAddress = new Uri("https://localhost:7229") };
			var url = $"\\DogTesting\\{testing.DogTestingId}";
			var stringContent = new StringContent(JsonConvert.SerializeObject(testing), Encoding.UTF8, "application/json");
			var result = await client.PutAsync(url, stringContent);
			if (result.IsSuccessStatusCode)
			{
				return true;
			}
			else return false;
		}

		public async Task<bool> DeleteTesting(DogTesting testing)
		{
			using var client = new HttpClient { BaseAddress = new Uri("https://localhost:7229") };
			var url = $"\\DogTesting\\{testing.DogTestingId}";
			var result = await client.DeleteAsync(url);
			if (result.IsSuccessStatusCode)
			{
				return true;
			}
			else return false;
		}

		// DISEASE HISTORY RELATED FUNCTIONS
		public async Task<List<DogDiseaseHistory>> GetDiseaseHistory(int dogId)
		{
			List<DogDiseaseHistory> diseaseHistories = null;
			using (var client = new HttpClient { BaseAddress = new Uri("https://localhost:7229") })
			{
				var url = $"\\Dog\\DiseaseHistory\\{dogId}";
				var result = await client.GetAsync(url);
				if (result.IsSuccessStatusCode)
				{
					string response = await result.Content.ReadAsStringAsync();
					diseaseHistories = JsonConvert.DeserializeObject<List<DogDiseaseHistory>>(response);
				}
			}
			return diseaseHistories;
		}

		public async Task<bool> AddDiseaseHistory(DogDiseaseHistory diseaseHistory)
		{
			using var client = new HttpClient { BaseAddress = new Uri("https://localhost:7229") };
			var url = $"\\DogDiseaseHistory";
			var stringContent = new StringContent(JsonConvert.SerializeObject(diseaseHistory), Encoding.UTF8, "application/json");
			var result = await client.PostAsync(url, stringContent);
			if (result.IsSuccessStatusCode)
			{
				return true;
			}
			else return false;
		}

		public async Task<bool> EditDiseaseHistory(DogDiseaseHistory diseaseHistory)
		{
			using var client = new HttpClient { BaseAddress = new Uri("https://localhost:7229") };
			var url = $"\\DogDiseaseHistory\\{diseaseHistory.DogDiseaseHistoryId}";
			var stringContent = new StringContent(JsonConvert.SerializeObject(diseaseHistory), Encoding.UTF8, "application/json");
			var result = await client.PutAsync(url, stringContent);
			if (result.IsSuccessStatusCode)
			{
				return true;
			}
			else return false;
		}

		public async Task<bool> DeleteDiseaseHistory(DogDiseaseHistory diseaseHistory)
		{
			using var client = new HttpClient { BaseAddress = new Uri("https://localhost:7229") };
			var url = $"\\DogDiseaseHistory\\{diseaseHistory.DogDiseaseHistoryId}";
			var result = await client.DeleteAsync(url);
			if (result.IsSuccessStatusCode)
			{
				return true;
			}
			else return false;
		}
	}
}
