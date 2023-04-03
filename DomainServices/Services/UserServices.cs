using AutoMapper;
using Data.IRepositories;
using DomainServices.IServices;
using Dtos;
using Entities;
using ErrorHandling;

namespace DomainServices.Services
{
    public class UserServices : IDisposable, IUserServices
    {
        private readonly IUserRepository _UserRepository;
        private readonly static MapperConfiguration config = new(cfg => cfg.AddProfile<Mapping>());
        readonly IMapper mapper = config.CreateMapper();
        private readonly static UserValidator _validator = new();

        public UserServices(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;
        }
        public void Create(UserDto toCreate)
        {
            var entity = mapper.Map<UserDto, User>(toCreate);
            var validResult = _validator.Validate(entity);
            if (validResult.IsValid)
            {
                entity.UserId = null;
                string? hashedPassword = SecurePasswordHasher.Hash(entity.Password);
                entity.Password = hashedPassword;

                var list = _UserRepository.GetAll();
                if (list == null || (list != null && _UserRepository.GetByUsername(entity.Username) == null))
                {
                    _UserRepository.Add(entity);
                }
                else
                {
                    throw new BadRequestException("This username exists, please choose another one!");
                }
            }
            else
            {
                throw new BadRequestException("The User couldn't be validated!");
            }
        }
        public UserDto? Read(int Id)
        {
            User? read = _UserRepository.GetById(Id);
            if (read == null)
            {
                throw new NotFoundException("This User doesn't exist!");
            }
            else
            {
                UserDto readDto = mapper.Map<User, UserDto>(read);
                return readDto;
            }
        }
        public UserDto? ReadByUsername(string username)
        {
            User? entity = _UserRepository.GetByUsername(username);
            if (entity == null)
            {
                throw new NotFoundException($"The username {username} was not found");
            }
            else
            {
                var dto = mapper.Map<User, UserDto>(entity);
                return dto;
            }
        }
        public IEnumerable<UserDto>? ReadAll()
        {
            var list = _UserRepository.GetAll();
            if (list == null)
            {
                throw new NotFoundException("User List is empty!");
            }
            var listDto = mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(list);
            return listDto;
        }
        public UserDto? Update(UserDto theOld, UserDto theNew)
        {
            User? found = _UserRepository.GetById(theOld.UserId);
            if (found == null)
            {
                throw new NotFoundException("This User doesn't exist!");
            }
            else
            {
                if (string.Compare(theOld.Username,theNew.Username) == 0 || 
                    (string.Compare(theOld.Username, theNew.Username) != 0 && _UserRepository.GetByUsername(theNew.Username) == null))
                {
					if (string.IsNullOrEmpty(theNew.Username)) found.Username = found.Username;
					else found.Username = theNew.Username;
					if (string.IsNullOrEmpty(theNew.Name)) found.Name = found.Name;
					else found.Name = theNew.Name;
					if (string.IsNullOrEmpty(theNew.Surname)) found.Surname = found.Surname;
					else found.Surname = theNew.Surname;
					if (string.IsNullOrEmpty(theNew.Password) || string.Compare(theNew.Password,found.Password) == 0) found.Password = found.Password;
					else
					{
						var hashedPassword = SecurePasswordHasher.Hash(theNew.Password);
						found.Password = hashedPassword;
					}
					if (string.IsNullOrEmpty(theNew.City)) found.City = found.City;
					else found.City = theNew.City;
					if (string.IsNullOrEmpty(theNew.Address)) found.Address = found.Address;
					else found.Address = theNew.Address;
					if (string.IsNullOrEmpty(theNew.PhoneNumber)) found.PhoneNumber = found.PhoneNumber;
					else found.PhoneNumber = theNew.PhoneNumber;
					if (string.IsNullOrEmpty(theNew.Email)) found.Email = found.Email;
					else found.Email = theNew.Email;
					if (string.IsNullOrEmpty(theNew.RoleId.ToString()) || theNew.RoleId == found.RoleId) found.RoleId = found.RoleId;
					else found.RoleId = theNew.RoleId;

					_UserRepository.Update(found.UserId);
					theOld = mapper.Map<User, UserDto>(found);
					return theOld;
				}
                else
                {
					throw new BadRequestException("This username exists, please choose another one!");
				}
            }
        }
        public void Delete(int Id)
        {
            User? found = _UserRepository.GetById(Id);
            if (found == null)
            {
                throw new NotFoundException("This User doesn't exist!");
            }
            else
            {
                _UserRepository.Delete(Id);
            }
        }
        public void Dispose() => _UserRepository.Dispose();
    }
}
