using AutoMapper;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Cat, CatDto>().ReverseMap();
            CreateMap<CatDiseaseHistory, CatDiseaseHistoryDto>().ReverseMap();
            CreateMap<CatTesting, CatTestingDto>().ReverseMap();
            CreateMap<CatVaccination, CatVaccinationDto>().ReverseMap();
            CreateMap<Dog, DogDto>().ReverseMap();
            CreateMap<DogDiseaseHistory, DogDiseaseHistoryDto>().ReverseMap();
            CreateMap<DogTesting, DogTestingDto>().ReverseMap();
            CreateMap<DogVaccination, DogVaccinationDto>().ReverseMap();
            CreateMap<Shelter, ShelterDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Donation, DonationDto>().ReverseMap();
            CreateMap<Follow, FollowDto>().ReverseMap();
        }
	}
}
