using CapstoneApp.Models;

namespace CapstoneApp.Services.Interfaces
{
    public interface IFollowServices
    {
        public Task<List<Follow>> GetFollows();
        public Task<Follow> GetById(int Id);
        public Task<List<Follow>> GetFollowsByUserId(int userId);
        public Task<List<Cat>> GetCatFollowsByUserId(int userId);
        public Task<List<Dog>> GetDogFollowsByUserId(int userId);
        public Task<bool> AddFollow(Follow follow);
        public Task<bool> DeleteFollow(Follow follow);
    }
}
