using AutoMapper;
using Data.IRepositories;
using DomainServices.IServices;
using Dtos;
using Entities;
using ErrorHandling;
using Repositories.Repositories;

namespace DomainServices.Services
{
    public class DogServices : IDisposable, IDogServices
    {
        private readonly IDogRepository _DogRepository;
		private readonly IDogVaccinationRepository _DogVaccinationRepository;
		private readonly IDogTestingRepository _DogTestingRepository;
		private readonly IDogDiseaseHistoryRepository _DogDiseaseHistoryRepository;
		private readonly IUserRepository _UserRepository;
        private readonly static MapperConfiguration config = new(cfg => cfg.AddProfile<Mapping>());
        readonly IMapper mapper = config.CreateMapper();

        public DogServices(IDogRepository DogRepository, IUserRepository UserRepository,
			IDogVaccinationRepository DogVaccinationRepository, IDogTestingRepository DogTestingRepository,
			IDogDiseaseHistoryRepository DogDiseaseHistoryRepository)
        {
            _DogRepository = DogRepository;
            _UserRepository = UserRepository;
			_DogVaccinationRepository = DogVaccinationRepository;
			_DogTestingRepository = DogTestingRepository;
			_DogDiseaseHistoryRepository = DogDiseaseHistoryRepository;
		}
        public void Create(DogDto toCreate)
        {
            User? control = _UserRepository.GetById(toCreate.UserId);
            if (toCreate.UserId == null || (toCreate.UserId != null && control != null))
            {
                var entity = mapper.Map<DogDto, Dog>(toCreate);
                _DogRepository.Add(entity);
            }
            else
            {
                throw new BadRequestException("User doesn't exist!");
            }
        }
        public DogDto? Read(int Id)
        {
            Dog? read = _DogRepository.GetById(Id);
            if (read == null)
            {
                throw new NotFoundException("This Dog doesn't exist!");
            }
            else
            {
                DogDto readDto = mapper.Map<Dog, DogDto>(read);
                return readDto;
            }
        }
        public IEnumerable<DogDto>? ReadAll()
        {
            var list = _DogRepository.GetAll();
            if (list == null)
            {
                return null;
            }
            var listDto = mapper.Map<IEnumerable<Dog>, IEnumerable<DogDto>>(list);
            return listDto;
        }
        public DogDto? Update(DogDto theOld, DogDto theNew)
        {
            Dog? found = _DogRepository.GetById(theOld.DogId);
            if (found == null)
            {
                throw new NotFoundException("This Dog doesn't exist!");
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

                _DogRepository.Update(found.DogId);
                theOld = mapper.Map<Dog, DogDto>(found);
                return theOld;
            }
        }
        public void Delete(int Id)
        {
            Dog? found = _DogRepository.GetById(Id);
            if (found == null)
            {
                throw new NotFoundException("This Dog doesn't exist!");
            }
            else
            {
                _DogRepository.Delete(Id);
            }
        }
        public void Dispose() => _DogRepository.Dispose();
		public List<DogVaccinationDto> GetVaccinations(int dogId)
		{
			List<DogVaccinationDto> dogVaccinations = new();
			IEnumerable<DogVaccination>? vaccinations = _DogVaccinationRepository.GetAll();
			foreach (var vacc in vaccinations)
			{
				if (vacc.DogId == dogId)
				{
					dogVaccinations.Add(mapper.Map<DogVaccinationDto>(vacc));
				}
			}
			return dogVaccinations;
		}
		public List<DogTestingDto> GetTestings(int dogId)
		{
			List<DogTestingDto> dogTestings = new();
			IEnumerable<DogTesting>? testings = _DogTestingRepository.GetAll();
			foreach (var test in testings)
			{
				if (test.DogId == dogId)
				{
					dogTestings.Add(mapper.Map<DogTestingDto>(test));
				}
			}
			return dogTestings;
		}
		public List<DogDiseaseHistoryDto> GetDiseaseHistory(int dogId)
		{
			List<DogDiseaseHistoryDto> dogDiseaseHistories = new();
			IEnumerable<DogDiseaseHistory>? histories = _DogDiseaseHistoryRepository.GetAll();
			foreach (var history in histories)
			{
				if (history.DogId == dogId)
				{
					dogDiseaseHistories.Add(mapper.Map<DogDiseaseHistoryDto>(history));
				}
			}
			return dogDiseaseHistories;
		}
	}
}
