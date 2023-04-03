using Dtos;

namespace DomainServices.IServices
{
    public interface IDogTestingServices
    {
        void Create(DogTestingDto toCreate);
        DogTestingDto? Read(int Id);
        IEnumerable<DogTestingDto>? ReadAll();
        void Delete(int Id);
        public DogTestingDto? Update(DogTestingDto theOld, DogTestingDto theNew);

	}
}
