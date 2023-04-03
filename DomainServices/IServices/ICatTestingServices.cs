using Dtos;

namespace DomainServices.IServices
{
    public interface ICatTestingServices
    {
        void Create(CatTestingDto toCreate);
        CatTestingDto? Read(int Id);
        IEnumerable<CatTestingDto>? ReadAll();
        void Delete(int Id);
        public CatTestingDto? Update(CatTestingDto theOld, CatTestingDto theNew);

	}
}
