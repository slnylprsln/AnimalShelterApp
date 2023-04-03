using AutoMapper;
using Data.IRepositories;
using DomainServices.IServices;
using Dtos;
using Entities;
using ErrorHandling;
using Repositories.Repositories;

namespace DomainServices.Services
{
    public class DogVaccinationServices : IDisposable, IDogVaccinationServices
    {
        private readonly IDogVaccinationRepository _DogVaccinationRepository;
        private readonly static MapperConfiguration config = new(cfg => cfg.AddProfile<Mapping>());
        readonly IMapper mapper = config.CreateMapper();

        public DogVaccinationServices(IDogVaccinationRepository DogVaccinationRepository)
        {
            _DogVaccinationRepository = DogVaccinationRepository;
        }
        public void Create(DogVaccinationDto toCreate)
        {
			//var list = _DogVaccinationRepository.GetAll();
   //         var index = 1;
   //         if (list != null)
   //         {
			//	var max = 1;
			//	foreach (var item in list)
			//	{
			//		if (item.DogVaccinationId > max)
			//		{
			//			max = item.DogVaccinationId;
			//		}
			//	}
   //             index = max + 1;
			//}
			//toCreate.DogVaccinationId = index;
			var entity = mapper.Map<DogVaccinationDto, DogVaccination>(toCreate);
            _DogVaccinationRepository.Add(entity);
        }
        public DogVaccinationDto? Read(int Id)
        {
            DogVaccination? read = _DogVaccinationRepository.GetById(Id);
            if (read == null)
            {
                throw new NotFoundException("This DogVaccination doesn't exist!");
            }
            else
            {
                DogVaccinationDto readDto = mapper.Map<DogVaccination, DogVaccinationDto>(read);
                return readDto;
            }
        }
        public IEnumerable<DogVaccinationDto>? ReadAll()
        {
            var list = _DogVaccinationRepository.GetAll();
            if (list == null)
            {
                throw new NotFoundException("DogVaccination List is empty!");
            }
            var listDto = mapper.Map<IEnumerable<DogVaccination>, IEnumerable<DogVaccinationDto>>(list);
            return listDto;
        }
        public void Delete(int Id)
        {
            DogVaccination? found = _DogVaccinationRepository.GetById(Id);
            if (found == null)
            {
                throw new NotFoundException("This DogVaccination doesn't exist!");
            }
            else
            {
                _DogVaccinationRepository.Delete(Id);
            }
        }
		public DogVaccinationDto? Update(DogVaccinationDto theOld, DogVaccinationDto theNew)
		{
			DogVaccination? found = _DogVaccinationRepository.GetById(theOld.DogVaccinationId);
			if (found == null)
			{
				throw new NotFoundException("This DogVaccination doesn't exist!");
			}
			else
			{
				if (string.IsNullOrEmpty(theNew.Name)) found.Name = found.Name;
				else found.Name = theNew.Name;
				if (string.IsNullOrEmpty(theNew.VaccinationDate.ToString())) found.VaccinationDate = found.VaccinationDate;
				else found.VaccinationDate = theNew.VaccinationDate;
				if (string.IsNullOrEmpty(theNew.VaccinationExpiryDate.ToString())) found.VaccinationExpiryDate = found.VaccinationExpiryDate;
				else found.VaccinationExpiryDate = theNew.VaccinationExpiryDate;
                
				_DogVaccinationRepository.Update(found.DogVaccinationId);
				theOld = mapper.Map<DogVaccination, DogVaccinationDto>(found);
				return theOld;
			}
		}
		public void Dispose() => _DogVaccinationRepository.Dispose();
    }
}
