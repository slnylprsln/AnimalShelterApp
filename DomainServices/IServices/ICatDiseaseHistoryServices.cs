using Dtos;

namespace DomainServices.IServices
{
    public interface ICatDiseaseHistoryServices
    {
        void Create(CatDiseaseHistoryDto toCreate);
        CatDiseaseHistoryDto? Read(int Id);
        IEnumerable<CatDiseaseHistoryDto>? ReadAll();
        CatDiseaseHistoryDto? Update(CatDiseaseHistoryDto theOld, CatDiseaseHistoryDto theNew);
        void Delete(int Id);
    }
}
