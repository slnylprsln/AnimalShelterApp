using AutoMapper;
using Data.IRepositories;
using DomainServices.IServices;
using Dtos;
using Entities;
using ErrorHandling;
using Repositories.Repositories;

namespace DomainServices.Services
{
    public class DogDiseaseHistoryServices : IDisposable, IDogDiseaseHistoryServices
    {
        private readonly IDogDiseaseHistoryRepository _DogDiseaseHistoryRepository;
        private readonly static MapperConfiguration config = new(cfg => cfg.AddProfile<Mapping>());
        readonly IMapper mapper = config.CreateMapper();

        public DogDiseaseHistoryServices(IDogDiseaseHistoryRepository DogDiseaseHistoryRepository)
        {
            _DogDiseaseHistoryRepository = DogDiseaseHistoryRepository;
        }
        public void Create(DogDiseaseHistoryDto toCreate)
        {
			//var list = _DogDiseaseHistoryRepository.GetAll();
			//var index = 1;
			//if (list != null)
			//{
			//	var max = 1;
			//	foreach (var item in list)
			//	{
			//		if (item.DogDiseaseHistoryId > max)
			//		{
			//			max = item.DogDiseaseHistoryId;
			//		}
			//	}
			//	index = max + 1;
			//}
			//toCreate.DogDiseaseHistoryId = index;
			var entity = mapper.Map<DogDiseaseHistoryDto, DogDiseaseHistory>(toCreate);
            _DogDiseaseHistoryRepository.Add(entity);
        }
        public DogDiseaseHistoryDto? Read(int Id)
        {
            DogDiseaseHistory? read = _DogDiseaseHistoryRepository.GetById(Id);
            if (read == null)
            {
                throw new NotFoundException("This DogDiseaseHistory doesn't exist!");
            }
            else
            {
                DogDiseaseHistoryDto readDto = mapper.Map<DogDiseaseHistory, DogDiseaseHistoryDto>(read);
                return readDto;
            }
        }
        public IEnumerable<DogDiseaseHistoryDto>? ReadAll()
        {
            var list = _DogDiseaseHistoryRepository.GetAll();
            if (list == null)
            {
                throw new NotFoundException("DogDiseaseHistory List is empty!");
            }
            var listDto = mapper.Map<IEnumerable<DogDiseaseHistory>, IEnumerable<DogDiseaseHistoryDto>>(list);
            return listDto;
        }
        public DogDiseaseHistoryDto? Update(DogDiseaseHistoryDto theOld, DogDiseaseHistoryDto theNew)
        {
            DogDiseaseHistory? found = _DogDiseaseHistoryRepository.GetById(theOld.DogDiseaseHistoryId);
            if (found == null)
            {
                throw new NotFoundException("This DogDiseaseHistory doesn't exist!");
            }
            else
            {
                if (string.IsNullOrEmpty(theNew.DiseaseName)) found.DiseaseName = found.DiseaseName;
                else found.DiseaseName = theNew.DiseaseName;
                if (string.IsNullOrEmpty(theNew.EndDate.ToString())) found.EndDate = found.EndDate;
                else found.EndDate = theNew.EndDate;


                _DogDiseaseHistoryRepository.Update(found.DogDiseaseHistoryId);
                theOld = mapper.Map<DogDiseaseHistory, DogDiseaseHistoryDto>(found);
                return theOld;
            }
        }
        public void Delete(int Id)
        {
            DogDiseaseHistory? found = _DogDiseaseHistoryRepository.GetById(Id);
            if (found == null)
            {
                throw new NotFoundException("This DogDiseaseHistory doesn't exist!");
            }
            else
            {
                _DogDiseaseHistoryRepository.Delete(Id);
            }
        }
        public void Dispose() => _DogDiseaseHistoryRepository.Dispose();
    }
}
