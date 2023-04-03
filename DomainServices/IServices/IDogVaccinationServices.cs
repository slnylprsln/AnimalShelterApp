using Dtos;

namespace DomainServices.IServices
{
    public interface IDogVaccinationServices
    {
        void Create(DogVaccinationDto toCreate);
        DogVaccinationDto? Read(int Id);
        IEnumerable<DogVaccinationDto>? ReadAll();
        void Delete(int Id);
        public DogVaccinationDto? Update(DogVaccinationDto theOld, DogVaccinationDto theNew);

	}
}
