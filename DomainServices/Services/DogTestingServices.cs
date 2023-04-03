using AutoMapper;
using Data.IRepositories;
using DomainServices.IServices;
using Dtos;
using Entities;
using ErrorHandling;
using Repositories.Repositories;

namespace DomainServices.Services
{
    public class DogTestingServices : IDisposable, IDogTestingServices
    {
        private readonly IDogTestingRepository _DogTestingRepository;
        private readonly static MapperConfiguration config = new(cfg => cfg.AddProfile<Mapping>());
        readonly IMapper mapper = config.CreateMapper();

        public DogTestingServices(IDogTestingRepository DogTestingRepository)
        {
            _DogTestingRepository = DogTestingRepository;
        }
        public void Create(DogTestingDto toCreate)
        {
			//var list = _DogTestingRepository.GetAll();
			//var index = 1;
			//if (list != null)
			//{
			//	var max = 1;
			//	foreach (var item in list)
			//	{
			//		if (item.DogTestingId > max)
			//		{
			//			max = item.DogTestingId;
			//		}
			//	}
			//	index = max + 1;
			//}
			//toCreate.DogTestingId = index;
			var entity = mapper.Map<DogTestingDto, DogTesting>(toCreate);
            _DogTestingRepository.Add(entity);
        }
        public DogTestingDto? Read(int Id)
        {
            DogTesting? read = _DogTestingRepository.GetById(Id);
            if (read == null)
            {
                throw new NotFoundException("This DogTesting doesn't exist!");
            }
            else
            {
                DogTestingDto readDto = mapper.Map<DogTesting, DogTestingDto>(read);
                return readDto;
            }
        }
        public IEnumerable<DogTestingDto>? ReadAll()
        {
            var list = _DogTestingRepository.GetAll();
            if (list == null)
            {
                throw new NotFoundException("DogTesting List is empty!");
            }
            var listDto = mapper.Map<IEnumerable<DogTesting>, IEnumerable<DogTestingDto>>(list);
            return listDto;
        }
        public void Delete(int Id)
        {
            DogTesting? found = _DogTestingRepository.GetById(Id);
            if (found == null)
            {
                throw new NotFoundException("This DogTesting doesn't exist!");
            }
            else
            {
                _DogTestingRepository.Delete(Id);
            }
        }
		public DogTestingDto? Update(DogTestingDto theOld, DogTestingDto theNew)
		{
			DogTesting? found = _DogTestingRepository.GetById(theOld.DogTestingId);
			if (found == null)
			{
				throw new NotFoundException("This DogTesting doesn't exist!");
			}
			else
			{
				if (string.IsNullOrEmpty(theNew.Name)) found.Name = found.Name;
				else found.Name = theNew.Name;
				if (string.IsNullOrEmpty(theNew.TestDate.ToString())) found.TestDate = found.TestDate;
				else found.TestDate = theNew.TestDate;
				if (string.IsNullOrEmpty(theNew.TestResult)) found.TestResult = found.TestResult;
				else found.TestResult = theNew.TestResult;

				_DogTestingRepository.Update(found.DogTestingId);
				theOld = mapper.Map<DogTesting, DogTestingDto>(found);
				return theOld;
			}
		}
		public void Dispose() => _DogTestingRepository.Dispose();
    }
}
