using Dtos;

namespace DomainServices.IServices
{
    public interface IDogDiseaseHistoryServices
    {
        void Create(DogDiseaseHistoryDto toCreate);
        DogDiseaseHistoryDto? Read(int Id);
        IEnumerable<DogDiseaseHistoryDto>? ReadAll();
        DogDiseaseHistoryDto? Update(DogDiseaseHistoryDto theOld, DogDiseaseHistoryDto theNew);
        void Delete(int Id);
    }
}
