using AutoMapper;
using Data.IRepositories;
using DomainServices.IServices;
using Dtos;
using Entities;
using ErrorHandling;
using Repositories.Repositories;

namespace DomainServices.Services
{
    public class CatTestingServices : IDisposable, ICatTestingServices
    {
        private readonly ICatTestingRepository _CatTestingRepository;
        private readonly static MapperConfiguration config = new(cfg => cfg.AddProfile<Mapping>());
        readonly IMapper mapper = config.CreateMapper();

        public CatTestingServices(ICatTestingRepository CatTestingRepository)
        {
            _CatTestingRepository = CatTestingRepository;
        }
        public void Create(CatTestingDto toCreate)
        {
			var list = _CatTestingRepository.GetAll();
			var index = 1;
			if (list != null)
			{
				var max = 1;
				foreach (var item in list)
				{
					if (item.CatTestingId > max)
					{
						max = item.CatTestingId;
					}
				}
				index = max + 1;
			}
			toCreate.CatTestingId = index;
			var entity = mapper.Map<CatTestingDto, CatTesting>(toCreate);
            _CatTestingRepository.Add(entity);
        }
        public CatTestingDto? Read(int Id)
        {
            CatTesting? read = _CatTestingRepository.GetById(Id);
            if (read == null)
            {
                throw new NotFoundException("This CatTesting doesn't exist!");
            }
            else
            {
                CatTestingDto readDto = mapper.Map<CatTesting, CatTestingDto>(read);
                return readDto;
            }
        }
        public IEnumerable<CatTestingDto>? ReadAll()
        {
            var list = _CatTestingRepository.GetAll();
            if (list == null)
            {
                throw new NotFoundException("CatTesting List is empty!");
            }
            var listDto = mapper.Map<IEnumerable<CatTesting>, IEnumerable<CatTestingDto>>(list);
            return listDto;
        }
        public void Delete(int Id)
        {
            CatTesting? found = _CatTestingRepository.GetById(Id);
            if (found == null)
            {
                throw new NotFoundException("This CatTesting doesn't exist!");
            }
            else
            {
                _CatTestingRepository.Delete(Id);
            }
        }
		public CatTestingDto? Update(CatTestingDto theOld, CatTestingDto theNew)
		{
			CatTesting? found = _CatTestingRepository.GetById(theOld.CatTestingId);
			if (found == null)
			{
				throw new NotFoundException("This CatTesting doesn't exist!");
			}
			else
			{
				if (string.IsNullOrEmpty(theNew.Name)) found.Name = found.Name;
				else found.Name = theNew.Name;
				if (string.IsNullOrEmpty(theNew.TestDate.ToString())) found.TestDate = found.TestDate;
				else found.TestDate = theNew.TestDate;
				if (string.IsNullOrEmpty(theNew.TestResult)) found.TestResult = found.TestResult;
				else found.TestResult = theNew.TestResult;

				_CatTestingRepository.Update(found.CatTestingId);
				theOld = mapper.Map<CatTesting, CatTestingDto>(found);
				return theOld;
			}
		}
		public void Dispose() => _CatTestingRepository.Dispose();
    }
}
