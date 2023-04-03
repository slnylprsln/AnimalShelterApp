using AutoMapper;
using Data.IRepositories;
using DomainServices.IServices;
using Dtos;
using Entities;
using ErrorHandling;

namespace DomainServices.Services
{
    public class ShelterServices : IDisposable, IShelterServices
    {
        private readonly IShelterRepository _ShelterRepository;
        private readonly static MapperConfiguration config = new(cfg => cfg.AddProfile<Mapping>());
        readonly IMapper mapper = config.CreateMapper();

        public ShelterServices(IShelterRepository ShelterRepository)
        {
            _ShelterRepository = ShelterRepository;
        }
        public void Create(ShelterDto toCreate)
        {
            var entity = mapper.Map<ShelterDto, Shelter>(toCreate);
            _ShelterRepository.Add(entity);
        }
        public ShelterDto? Read(int Id)
        {
            Shelter? read = _ShelterRepository.GetById(Id);
            if (read == null)
            {
                throw new NotFoundException("This Shelter doesn't exist!");
            }
            else
            {
                ShelterDto readDto = mapper.Map<Shelter, ShelterDto>(read);
                return readDto;
            }
        }
        public IEnumerable<ShelterDto>? ReadAll()
        {
            var list = _ShelterRepository.GetAll();
            if (list == null)
            {
                throw new NotFoundException("Shelter List is empty!");
            }
            var listDto = mapper.Map<IEnumerable<Shelter>, IEnumerable<ShelterDto>>(list);
            return listDto;
        }
        public ShelterDto? Update(ShelterDto theOld, ShelterDto theNew)
        {
            Shelter? found = _ShelterRepository.GetById(theOld.ShelterId);
            if (found == null)
            {
                throw new NotFoundException("This Shelter doesn't exist!");
            }
            else
            {
                if (string.IsNullOrEmpty(theNew.Name)) found.Name = found.Name;
                else found.Name = theNew.Name;
                if (string.IsNullOrEmpty(theNew.UserId.ToString()) || theNew.UserId == 0) found.UserId = found.UserId;
                else found.UserId = theNew.UserId;
                if (string.IsNullOrEmpty(theNew.CertificateNo)) found.CertificateNo = found.CertificateNo;
                else found.CertificateNo = theNew.CertificateNo;
                if (string.IsNullOrEmpty(theNew.City)) found.City = found.City;
                else found.City = theNew.City;
                if (string.IsNullOrEmpty(theNew.Address)) found.Address = found.Address;
                else found.Address = theNew.Address;
                if (string.IsNullOrEmpty(theNew.CatFoodStock.ToString()) || theNew.CatFoodStock == 0) found.CatFoodStock = found.CatFoodStock;
                else found.CatFoodStock = theNew.CatFoodStock;
                if (string.IsNullOrEmpty(theNew.DogFoodStock.ToString()) || theNew.DogFoodStock == 0) found.DogFoodStock = found.DogFoodStock;
                else found.DogFoodStock = theNew.DogFoodStock;
                if (string.IsNullOrEmpty(theNew.RabiesVaccineStock.ToString()) || theNew.RabiesVaccineStock == 0) found.RabiesVaccineStock = found.RabiesVaccineStock;
                else found.RabiesVaccineStock = theNew.RabiesVaccineStock;
                if (string.IsNullOrEmpty(theNew.CombinationVaccineStock.ToString()) || theNew.CombinationVaccineStock == 0) found.CombinationVaccineStock = found.CombinationVaccineStock;
                else found.CombinationVaccineStock = theNew.CombinationVaccineStock;
                if (string.IsNullOrEmpty(theNew.ParvovirusVaccineStock.ToString()) || theNew.ParvovirusVaccineStock == 0) found.ParvovirusVaccineStock = found.ParvovirusVaccineStock;
                else found.ParvovirusVaccineStock = theNew.ParvovirusVaccineStock;
                if (string.IsNullOrEmpty(theNew.DistemperVaccineStock.ToString()) || theNew.DistemperVaccineStock == 0) found.DistemperVaccineStock = found.DistemperVaccineStock;
                else found.DistemperVaccineStock = theNew.DistemperVaccineStock;
                if (string.IsNullOrEmpty(theNew.HepatitisVaccineStock.ToString()) || theNew.HepatitisVaccineStock == 0) found.HepatitisVaccineStock = found.HepatitisVaccineStock;
                else found.HepatitisVaccineStock = theNew.HepatitisVaccineStock;

                _ShelterRepository.Update(found.ShelterId);
                theOld = mapper.Map<Shelter, ShelterDto>(found);
                return theOld;
            }
        }
        public void Delete(int Id)
        {
            Shelter? found = _ShelterRepository.GetById(Id);
            if (found == null)
            {
                throw new NotFoundException("This Shelter doesn't exist!");
            }
            else
            {
                _ShelterRepository.Delete(Id);
            }
        }
        public void Dispose() => _ShelterRepository.Dispose();
    }
}
