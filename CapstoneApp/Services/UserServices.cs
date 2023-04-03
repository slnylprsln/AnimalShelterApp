using Newtonsoft.Json;
using CapstoneApp.Models;
using CapstoneApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneApp.Services
{
    public class UserServices : IUserServices
    {
        public async Task<User> AuthenticateUser(LoginModel loginModel)
        {
            string response;
            User content = new();
            using (var client = new HttpClient { BaseAddress = new Uri("https://localhost:7229") })
            {

                var url = $"\\UserLogin\\{loginModel.Username}\\{loginModel.Password}";
                var result = await client.GetAsync(url);

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    response = await result.Content.ReadAsStringAsync();
                    content = JsonConvert.DeserializeObject<User>(response);

                    User user = new()
                    {
                        UserId = content.UserId,
                        Username = content.Username,
                        Name = content.Name,
                        Surname = content.Surname,
                        Email = content.Email,
                        Address = content.Address,
                        PhoneNumber = content.PhoneNumber,
                        City = content.City,
                        Password = content.Password,
                        RoleId = 3
                    };
                }
            }
            return content;
        }


        public async Task<(bool IsSuccess, string ErrorMessage)> RegisterUser(RegistrationModel registrationModel)
        {
            string errorMessage = string.Empty;
            bool isSuccess = false;
            using (var client = new HttpClient { BaseAddress = new Uri("https://localhost:7229") })
            {
                var url = $"\\User";
                var stringContent = new StringContent(JsonConvert.SerializeObject(registrationModel), Encoding.UTF8, "application/json");
                var result = await client.PostAsync(url, stringContent);

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    isSuccess = true;
                }
                else
                {
                    errorMessage = await result.Content.ReadAsStringAsync();
                }
            }
            return (isSuccess, errorMessage);
        }


        public async Task<List<User>> GetUsers()
        {
            List<User> users = null;
            using (var client = new HttpClient { BaseAddress = new Uri("https://localhost:7229") })
            {
                var url = $"\\User";
                var result = await client.GetAsync(url);
                if (result.IsSuccessStatusCode)
                {
                    string response = await result.Content.ReadAsStringAsync();
                    users = JsonConvert.DeserializeObject<List<User>>(response);
                }
            }
            return users;
        }
		public async Task<User> GetUserById(int? id)
		{
			User user = null;
            if (id != null)
            {
				using (var client = new HttpClient { BaseAddress = new Uri("https://localhost:7229") })
				{
					var url = $"\\User\\byId\\{id}";
					var result = await client.GetAsync(url);
					if (result.IsSuccessStatusCode)
					{
						string response = await result.Content.ReadAsStringAsync();
						user = JsonConvert.DeserializeObject<User>(response);
					}
				}
			}
			return user;
		}

		public async Task<bool> AddUser(User user)
        {
            using var client = new HttpClient { BaseAddress = new Uri("https://localhost:7229") };
            var url = $"\\User";
            var stringContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            var result = await client.PostAsync(url, stringContent);
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            else return false;
        }

        public async Task<bool> EditUser(User user)
        {
            using var client = new HttpClient { BaseAddress = new Uri("https://localhost:7229") };
            var url = $"\\User\\{user.UserId}";
            var stringContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            var result = await client.PutAsync(url, stringContent);
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            else return false;
        }
		public async Task<bool> EditUser(int id)
		{
            var user = await GetUserById(id);
			using var client = new HttpClient { BaseAddress = new Uri("https://localhost:7229") };
			var url = $"\\User\\{id}";
			var stringContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
			var result = await client.PutAsync(url, stringContent);
			if (result.IsSuccessStatusCode)
			{
				return true;
			}
			else return false;
		}
		public async Task<bool> DeleteUser(User user)
        {
            using var client = new HttpClient { BaseAddress = new Uri("https://localhost:7229") };
            var url = $"\\User\\{user.UserId}";
            var result = await client.DeleteAsync(url);
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            else return false;
        }
    }
}
