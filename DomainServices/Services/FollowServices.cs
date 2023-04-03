using AutoMapper;
using Data.IRepositories;
using DomainServices.IServices;
using Dtos;
using Entities;
using ErrorHandling;
using Repositories.IRepositories;
using Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.Services
{
	public class FollowServices : IFollowServices
	{
		private readonly IFollowRepository _FollowRepository;
		private readonly ICatRepository _CatRepository;
		private readonly IDogRepository _DogRepository;
		private readonly static MapperConfiguration config = new(cfg => cfg.AddProfile<Mapping>());
		readonly IMapper mapper = config.CreateMapper();

		public FollowServices(IFollowRepository FollowRepository, IDogRepository DogRepository, ICatRepository CatRepository)
		{
			_FollowRepository = FollowRepository;
			_DogRepository = DogRepository;
			_CatRepository = CatRepository;
		}

		public FollowDto? Read(int Id)
		{
			Follow? read = _FollowRepository.GetById(Id);
			if (read == null)
			{
				throw new NotFoundException("This Follow doesn't exist!");
			}
			else
			{
				FollowDto readDto = mapper.Map<Follow, FollowDto>(read);
				return readDto;
			}
		}

		public void Create(FollowDto toCreate)
		{
			if (toCreate.AnimalType == AnimalType.Kedi)
			{
				var cat = _CatRepository.GetById(toCreate.AnimalId);
				if (cat == null)
				{
                    throw new NotFoundException("This Cat doesn't exist!");
                }
				else
				{
                    var entity = mapper.Map<FollowDto, Follow>(toCreate);
                    _FollowRepository.Add(entity);
                }
            }
			else
			{
                var dog = _DogRepository.GetById(toCreate.AnimalId);
                if (dog == null)
                {
                    throw new NotFoundException("This Dog doesn't exist!");
                }
                else
                {
                    var entity = mapper.Map<FollowDto, Follow>(toCreate);
                    _FollowRepository.Add(entity);
                }
            }
			
		}

		public IEnumerable<FollowDto>? ReadAll()
		{
			var list = _FollowRepository.GetAll();
			if (list == null)
			{
				throw new NotFoundException("Follow List is empty!");
			}
			var listDto = mapper.Map<IEnumerable<Follow>, IEnumerable<FollowDto>>(list);
			return listDto;
		}

		public void Delete(int Id)
		{
			Follow? found = _FollowRepository.GetById(Id);
			if (found == null)
			{
				throw new NotFoundException("This Follow doesn't exist!");
			}
			else
			{
				_FollowRepository.Delete(Id);
			}
		}

        public IEnumerable<FollowDto>? ReadByUserId(int userId)
		{
			var follow = ReadAll();
			List<FollowDto> followsOfUser = new();
			foreach (var item in follow)
			{
				if (item.UserId == userId)
				{
					followsOfUser.Add(item);
				}
			}
			return followsOfUser;
		}

        public IEnumerable<FollowDto>? ReadCatsByUserId(int userId)
        {
            var follow = ReadAll();
            List<FollowDto> followsOfUser = new();
            foreach (var item in follow)
            {
                if (item.UserId == userId && item.AnimalType == AnimalType.Kedi)
                {
                    followsOfUser.Add(item);
                }
            }
            return followsOfUser;
        }

        public IEnumerable<FollowDto>? ReadDogsByUserId(int userId)
        {
            var follow = ReadAll();
            List<FollowDto> followsOfUser = new();
            foreach (var item in follow)
            {
                if (item.UserId == userId && item.AnimalType == AnimalType.Köpek)
                {
                    followsOfUser.Add(item);
                }
            }
            return followsOfUser;
        }
    }
}
