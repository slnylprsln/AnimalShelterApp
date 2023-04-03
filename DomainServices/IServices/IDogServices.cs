using Dtos;

namespace DomainServices.IServices
{
    public interface IDogServices
    {
        void Create(DogDto toCreate);
        DogDto? Read(int Id);
        IEnumerable<DogDto>? ReadAll();
        DogDto? Update(DogDto theOld, DogDto theNew);
        void Delete(int Id);
		public List<DogVaccinationDto> GetVaccinations(int dogId);
		public List<DogTestingDto> GetTestings(int dogId);
		public List<DogDiseaseHistoryDto> GetDiseaseHistory(int dogId);
	}
}
