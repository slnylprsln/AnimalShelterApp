using AutoMapper;
using Data.IRepositories;
using DomainServices.IServices;
using Dtos;
using Entities;
using ErrorHandling;
using Repositories.Repositories;

namespace DomainServices.Services
{
    public class CatDiseaseHistoryServices : IDisposable, ICatDiseaseHistoryServices
    {
        private readonly ICatDiseaseHistoryRepository _CatDiseaseHistoryRepository;
        private readonly static MapperConfiguration config = new(cfg => cfg.AddProfile<Mapping>());
        readonly IMapper mapper = config.CreateMapper();

        public CatDiseaseHistoryServices(ICatDiseaseHistoryRepository CatDiseaseHistoryRepository)
        {
            _CatDiseaseHistoryRepository = CatDiseaseHistoryRepository;
        }
        public void Create(CatDiseaseHistoryDto toCreate)
        {
			var list = _CatDiseaseHistoryRepository.GetAll();
			var index = 1;
			if (list != null)
			{
				var max = 1;
				foreach (var item in list)
				{
					if (item.CatDiseaseHistoryId > max)
					{
						max = item.CatDiseaseHistoryId;
					}
				}
				index = max + 1;
			}
			toCreate.CatDiseaseHistoryId = index;
			var entity = mapper.Map<CatDiseaseHistoryDto, CatDiseaseHistory>(toCreate);
            _CatDiseaseHistoryRepository.Add(entity);
        }
        public CatDiseaseHistoryDto? Read(int Id)
        {
            CatDiseaseHistory? read = _CatDiseaseHistoryRepository.GetById(Id);
            if (read == null)
            {
                throw new NotFoundException("This CatDiseaseHistory doesn't exist!");
            }
            else
            {
                CatDiseaseHistoryDto readDto = mapper.Map<CatDiseaseHistory, CatDiseaseHistoryDto>(read);
                return readDto;
            }
        }
        public IEnumerable<CatDiseaseHistoryDto>? ReadAll()
        {
            var list = _CatDiseaseHistoryRepository.GetAll();
            if (list == null)
            {
                throw new NotFoundException("CatDiseaseHistory List is empty!");
            }
            var listDto = mapper.Map<IEnumerable<CatDiseaseHistory>, IEnumerable<CatDiseaseHistoryDto>>(list);
            return listDto;
        }
        public CatDiseaseHistoryDto? Update(CatDiseaseHistoryDto theOld, CatDiseaseHistoryDto theNew)
        {
            CatDiseaseHistory? found = _CatDiseaseHistoryRepository.GetById(theOld.CatDiseaseHistoryId);
            if (found == null)
            {
                throw new NotFoundException("This CatDiseaseHistory doesn't exist!");
            }
            else
            {
                if (string.IsNullOrEmpty(theNew.DiseaseName)) found.DiseaseName = found.DiseaseName;
                else found.DiseaseName = theNew.DiseaseName;
                if (string.IsNullOrEmpty(theNew.EndDate.ToString())) found.EndDate = found.EndDate;
                else found.EndDate = theNew.EndDate;


                _CatDiseaseHistoryRepository.Update(found.CatDiseaseHistoryId);
                theOld = mapper.Map<CatDiseaseHistory, CatDiseaseHistoryDto>(found);
                return theOld;
            }
        }
        public void Delete(int Id)
        {
            CatDiseaseHistory? found = _CatDiseaseHistoryRepository.GetById(Id);
            if (found == null)
            {
                throw new NotFoundException("This CatDiseaseHistory doesn't exist!");
            }
            else
            {
                _CatDiseaseHistoryRepository.Delete(Id);
            }
        }
        public void Dispose() => _CatDiseaseHistoryRepository.Dispose();
    }
}
