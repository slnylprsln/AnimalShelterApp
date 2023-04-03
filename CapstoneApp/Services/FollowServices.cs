using CapstoneApp.Models;
using CapstoneApp.Services.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace CapstoneApp.Services
{
    public class FollowServices : IFollowServices
    {
        public async Task<bool> AddFollow(Follow follow)
        {
            using var client = new HttpClient { BaseAddress = new Uri("https://localhost:7229") };
            var url = $"\\Follow";
            var stringContent = new StringContent(JsonConvert.SerializeObject(follow), Encoding.UTF8, "application/json");
            var result = await client.PostAsync(url, stringContent);
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            else return false;
        }

        public async Task<bool> DeleteFollow(Follow follow)
        {
            using var client = new HttpClient { BaseAddress = new Uri("https://localhost:7229") };
            var url = $"\\Follow\\{follow.FollowId}";
            var result = await client.DeleteAsync(url);
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            else return false;
        }

        public async Task<Follow> GetById(int Id)
        {
            Follow follow = null;
            using (var client = new HttpClient { BaseAddress = new Uri("https://localhost:7229") })
            {
                var url = $"\\Follow\\byId\\{Id}";
                var result = await client.GetAsync(url);
                if (result.IsSuccessStatusCode)
                {
                    string response = await result.Content.ReadAsStringAsync();
                    follow = JsonConvert.DeserializeObject<Follow>(response);
                }
            }
            return follow;
        }

        public async Task<List<Cat>> GetCatFollowsByUserId(int userId)
        {
            List<Follow> list = await GetFollows();
            List<Cat> cats = new();
            foreach (var item in list)
            {
                if (item.UserId == userId && item.AnimalType == AnimalType.Kedi)
                {
                    Cat cat = await GetCatById(item.AnimalId);
                    cats.Add(cat);
                }
            }
            return cats;
        }

        public async Task<List<Dog>> GetDogFollowsByUserId(int userId)
        {
            List<Follow> list = await GetFollows();
            List<Dog> dogs = new();
            foreach (var item in list)
            {
                if (item.UserId == userId && item.AnimalType == AnimalType.Köpek)
                {
                    Dog dog = await GetDogById(item.AnimalId);
                    dogs.Add(dog);
                }
            }
            return dogs;
        }

        public async Task<List<Follow>> GetFollows()
        {
            List<Follow> follows = null;
            using (var client = new HttpClient { BaseAddress = new Uri("https://localhost:7229") })
            {
                var url = $"\\Follow";
                var result = await client.GetAsync(url);
                if (result.IsSuccessStatusCode)
                {
                    string response = await result.Content.ReadAsStringAsync();
                    follows = JsonConvert.DeserializeObject<List<Follow>>(response);
                }
            }
            return follows;
        }

        public async Task<List<Follow>> GetFollowsByUserId(int userId)
        {
            List<Follow> list = await GetFollows();
            foreach (var item in list)
            {
                if (item.UserId == userId)
                {
                    list.Add(item);
                }
            }
            return list;
        }

        // CAT SERVICE
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

        // DOG SERVICE
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
    }
}
