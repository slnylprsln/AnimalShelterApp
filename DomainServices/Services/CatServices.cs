using AutoMapper;
using Data.IRepositories;
using DomainServices.IServices;
using Dtos;
using Entities;
using ErrorHandling;

namespace DomainServices.Services
{
    public class CatServices : IDisposable, ICatServices
    {
        private readonly ICatRepository _CatRepository;
		private readonly ICatVaccinationRepository _CatVaccinationRepository;
		private readonly ICatTestingRepository _CatTestingRepository;
		private readonly ICatDiseaseHistoryRepository _CatDiseaseHistoryRepository;
		private readonly IUserRepository _UserRepository;
        private readonly static MapperConfiguration config = new(cfg => cfg.AddProfile<Mapping>());
        readonly IMapper mapper = config.CreateMapper();

        public CatServices(ICatRepository CatRepository, IUserRepository UserRepository, 
            ICatVaccinationRepository CatVaccinationRepository, ICatTestingRepository CatTestingRepository,
            ICatDiseaseHistoryRepository CatDiseaseHistoryRepository)
        {
            _CatRepository = CatRepository;
            _UserRepository = UserRepository;
            _CatVaccinationRepository = CatVaccinationRepository;
            _CatTestingRepository = CatTestingRepository;
            _CatDiseaseHistoryRepository = CatDiseaseHistoryRepository;
        }
        public CatDto? Read(int Id)
        {
            Cat? read = _CatRepository.GetById(Id);
            if (read == null)
            {
                throw new NotFoundException("This Cat doesn't exist!");
            }
            else
            {
                CatDto readDto = mapper.Map<Cat, CatDto>(read);
                return readDto;
            }
        }
        public void Create(CatDto toCreate)
        {
            User? control = _UserRepository.GetById(toCreate.UserId);
            if (toCreate.UserId == null || (toCreate.UserId != null && control != null))
            {
                var entity = mapper.Map<CatDto, Cat>(toCreate);
                _CatRepository.Add(entity);
            }
            else
            {
                throw new BadRequestException("User doesn't exist!");
            }
        }
        public IEnumerable<CatDto>? ReadAll()
        {
            var list = _CatRepository.GetAll();
            if (list == null)
            {
                throw new NotFoundException("Cat List is empty!");
            }
            var listDto = mapper.Map<IEnumerable<Cat>, IEnumerable<CatDto>>(list);
            return listDto;
        }
        public CatDto? Update(CatDto theOld, CatDto theNew)
        {
            Cat? found = _CatRepository.GetById(theOld.CatId);
            if (found == null)
            {
                throw new NotFoundException("This Cat doesn't exist!");
            }
            else
            {
                if (string.IsNullOrEmpty(theNew.ChipCode)) found.ChipCode = found.ChipCode;
                else found.ChipCode = theNew.ChipCode;
                if (string.IsNullOrEmpty(theNew.Breed)) found.Breed = found.Breed;
                else found.Breed = theNew.Breed;
                if (string.IsNullOrEmpty(theNew.Gender)) found.Gender = found.Gender;
                else found.Gender = theNew.Gender;
                if (string.IsNullOrEmpty(theNew.ShelterId.ToString()) || theNew.ShelterId == 0) found.ShelterId = found.ShelterId;
                else found.ShelterId = theNew.ShelterId;
                if (string.IsNullOrEmpty(theNew.FertilityStatus)) found.FertilityStatus = found.FertilityStatus;
                else found.FertilityStatus = theNew.FertilityStatus;
                if (string.IsNullOrEmpty(theNew.Pregnancy.ToString())) found.Pregnancy = found.Pregnancy;
                else found.Pregnancy = theNew.Pregnancy;
                if (string.IsNullOrEmpty(theNew.OwningDate.ToString())) found.OwningDate = found.OwningDate;
                else found.OwningDate = theNew.OwningDate;

                if (string.IsNullOrEmpty(theNew.UserId.ToString()) || theNew.UserId == 0) found.UserId = found.UserId;
                else 
                {
                    User? control = _UserRepository.GetById((int)theNew.UserId);
                    if (theNew.UserId == null || (theNew.UserId != null && control != null))
                    {
                        found.UserId = theNew.UserId;
                    }
                    else
                    {
                        throw new BadRequestException("User doesn't exist!");
                    }
                } 

                _CatRepository.Update(found.CatId);
                theOld = mapper.Map<Cat, CatDto>(found);
                return theOld;
            }
        }
        public void Delete(int Id)
        {
            Cat? found = _CatRepository.GetById(Id);
            if (found == null)
            {
                throw new NotFoundException("This Cat doesn't exist!");
            }
            else
            {
                _CatRepository.Delete(Id);
            }
        }
        public void Dispose() => _CatRepository.Dispose();
        public List<CatVaccinationDto> GetVaccinations(int catId)
        {
            List<CatVaccinationDto> catVaccinations = new();
            IEnumerable<CatVaccination>? vaccinations = _CatVaccinationRepository.GetAll();
            foreach (var vacc in vaccinations)
            {
                if (vacc.CatId == catId)
                {
                    catVaccinations.Add(mapper.Map<CatVaccinationDto>(vacc));
                }
            }
            return catVaccinations;
		}
		public List<CatTestingDto> GetTestings(int catId)
		{
			List<CatTestingDto> catTestings = new();
			IEnumerable<CatTesting>? testings = _CatTestingRepository.GetAll();
			foreach (var test in testings)
			{
				if (test.CatId == catId)
				{
					catTestings.Add(mapper.Map<CatTestingDto>(test));
				}
			}
			return catTestings;
		}
		public List<CatDiseaseHistoryDto> GetDiseaseHistory(int catId)
		{
			List<CatDiseaseHistoryDto> catDiseaseHistories = new();
			IEnumerable<CatDiseaseHistory>? histories = _CatDiseaseHistoryRepository.GetAll();
			foreach (var history in histories)
			{
				if (history.CatId == catId)
				{
					catDiseaseHistories.Add(mapper.Map<CatDiseaseHistoryDto>(history));
				}
			}
			return catDiseaseHistories;
		}
	}
}
