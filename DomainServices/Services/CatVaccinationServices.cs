using AutoMapper;
using Data.IRepositories;
using DomainServices.IServices;
using Dtos;
using Entities;
using ErrorHandling;
using Repositories.Repositories;

namespace DomainServices.Services
{
    public class CatVaccinationServices : IDisposable, ICatVaccinationServices
    {
        private readonly ICatVaccinationRepository _CatVaccinationRepository;
        private readonly static MapperConfiguration config = new(cfg => cfg.AddProfile<Mapping>());
        readonly IMapper mapper = config.CreateMapper();

        public CatVaccinationServices(ICatVaccinationRepository CatVaccinationRepository)
        {
            _CatVaccinationRepository = CatVaccinationRepository;
        }
        public void Create(CatVaccinationDto toCreate)
        {
			var list = _CatVaccinationRepository.GetAll();
			var index = 1;
			if (list != null)
			{
				var max = 1;
				foreach (var item in list)
				{
					if (item.CatVaccinationId > max)
					{
						max = item.CatVaccinationId;
					}
				}
				index = max + 1;
			}
			toCreate.CatVaccinationId = index;
			var entity = mapper.Map<CatVaccinationDto, CatVaccination>(toCreate);
            _CatVaccinationRepository.Add(entity);
        }
        public CatVaccinationDto? Read(int Id)
        {
            CatVaccination? read = _CatVaccinationRepository.GetById(Id);
            if (read == null)
            {
                throw new NotFoundException("This CatVaccination doesn't exist!");
            }
            else
            {
                CatVaccinationDto readDto = mapper.Map<CatVaccination, CatVaccinationDto>(read);
                return readDto;
            }
        }
        public IEnumerable<CatVaccinationDto>? ReadAll()
        {
            var list = _CatVaccinationRepository.GetAll();
            if (list == null)
            {
                throw new NotFoundException("CatVaccination List is empty!");
            }
            var listDto = mapper.Map<IEnumerable<CatVaccination>, IEnumerable<CatVaccinationDto>>(list);
            return listDto;
        }
        public void Delete(int Id)
        {
            CatVaccination? found = _CatVaccinationRepository.GetById(Id);
            if (found == null)
            {
                throw new NotFoundException("This CatVaccination doesn't exist!");
            }
            else
            {
                _CatVaccinationRepository.Delete(Id);
            }
        }
		public CatVaccinationDto? Update(CatVaccinationDto theOld, CatVaccinationDto theNew)
		{
			CatVaccination? found = _CatVaccinationRepository.GetById(theOld.CatVaccinationId);
			if (found == null)
			{
				throw new NotFoundException("This CatVaccination doesn't exist!");
			}
			else
			{
				if (string.IsNullOrEmpty(theNew.Name)) found.Name = found.Name;
				else found.Name = theNew.Name;
				if (string.IsNullOrEmpty(theNew.VaccinationDate.ToString())) found.VaccinationDate = found.VaccinationDate;
				else found.VaccinationDate = theNew.VaccinationDate;
				if (string.IsNullOrEmpty(theNew.VaccinationExpiryDate.ToString())) found.VaccinationExpiryDate = found.VaccinationExpiryDate;
				else found.VaccinationExpiryDate = theNew.VaccinationExpiryDate;

				_CatVaccinationRepository.Update(found.CatVaccinationId);
				theOld = mapper.Map<CatVaccination, CatVaccinationDto>(found);
				return theOld;
			}
		}
		public void Dispose() => _CatVaccinationRepository.Dispose();
    }
}
