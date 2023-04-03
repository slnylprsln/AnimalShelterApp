using Dtos;

namespace DomainServices.IServices
{
    public interface IShelterServices
    {
        void Create(ShelterDto toCreate);
        ShelterDto? Read(int Id);
        IEnumerable<ShelterDto>? ReadAll();
        ShelterDto? Update(ShelterDto theOld, ShelterDto theNew);
        void Delete(int Id);
    }
}
