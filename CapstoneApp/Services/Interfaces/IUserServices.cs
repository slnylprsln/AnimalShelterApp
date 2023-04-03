using CapstoneApp.Models;

namespace CapstoneApp.Services.Interfaces
{
    public interface IUserServices
    {
        public Task<User> AuthenticateUser(LoginModel loginModel);
        public Task<(bool IsSuccess, string ErrorMessage)> RegisterUser(RegistrationModel registrationModel);
        public Task<List<User>> GetUsers();
		public Task<User> GetUserById(int? id);
		public Task<bool> AddUser(User user);
        public Task<bool> EditUser(User user);
		public Task<bool> EditUser(int id);
		public Task<bool> DeleteUser(User user);
	}
}
