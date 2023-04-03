using Dtos;

namespace DomainServices.IServices
{
    public interface ICatVaccinationServices
    {
        void Create(CatVaccinationDto toCreate);
        CatVaccinationDto? Read(int Id);
        IEnumerable<CatVaccinationDto>? ReadAll();
        void Delete(int Id);
        public CatVaccinationDto? Update(CatVaccinationDto theOld, CatVaccinationDto theNew);

	}
}
