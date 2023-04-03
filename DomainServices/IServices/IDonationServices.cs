using Dtos;

namespace DomainServices.IServices
{
    public interface IDonationServices
    {
        void Create(DonationDto toCreate);
        DonationDto? Read(int Id);
        IEnumerable<DonationDto>? ReadAll();
        DonationDto? Update(DonationDto theOld, DonationDto theNew);
        void Delete(int Id);
    }
}
