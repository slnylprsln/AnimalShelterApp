using Dtos;

namespace DomainServices.IServices
{
    public interface ICatServices
    {
        void Create(CatDto toCreate);
        CatDto? Read(int Id);
        IEnumerable<CatDto>? ReadAll();
        CatDto? Update(CatDto theOld, CatDto theNew);
        void Delete(int Id);
        public List<CatVaccinationDto> GetVaccinations(int catId);
		public List<CatTestingDto> GetTestings(int catId);
		public List<CatDiseaseHistoryDto> GetDiseaseHistory(int catId);
	}
}
