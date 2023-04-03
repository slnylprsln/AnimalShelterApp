using Dtos;

namespace DomainServices.IServices
{
    public interface IUserServices
    {
        void Create(UserDto toCreate);
        UserDto? Read(int Id);
        UserDto? ReadByUsername(string username);
        IEnumerable<UserDto>? ReadAll();
        UserDto? Update(UserDto theOld, UserDto theNew);
        void Delete(int Id);
    }
}
