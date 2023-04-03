using AutoMapper;
using Data.IRepositories;
using DomainServices.IServices;
using Dtos;
using Entities;
using ErrorHandling;
using Repositories.IRepositories;
using Repositories.Repositories;

namespace DomainServices.Services
{
    public class DonationServices : IDonationServices
    {
        private readonly IDonationRepository _DonationRepository;
        private readonly static MapperConfiguration config = new(cfg => cfg.AddProfile<Mapping>());
        readonly IMapper mapper = config.CreateMapper();

        public DonationServices(IDonationRepository DonationRepository)
        {
            _DonationRepository = DonationRepository;
        }

        public DonationDto? Read(int Id)
        {
            Donation? read = _DonationRepository.GetById(Id);
            if (read == null)
            {
                throw new NotFoundException("This Donation doesn't exist!");
            }
            else
            {
                DonationDto readDto = mapper.Map<Donation, DonationDto>(read);
                return readDto;
            }
        }

        public DonationDto? Update(DonationDto theOld, DonationDto theNew)
        {
            Donation? found = _DonationRepository.GetById(theOld.DonationId);
            if (found == null)
            {
                throw new NotFoundException("This Donation doesn't exist!");
            }
            else
            {
                if (theNew.VerifiedYet == null && theNew.VerifiedYet == found.VerifiedYet) found.VerifiedYet = found.VerifiedYet;
                else found.VerifiedYet = theNew.VerifiedYet;
                if (theNew.Verification == null && theNew.Verification == found.Verification) found.Verification = found.Verification;
                else found.Verification = theNew.Verification;

                _DonationRepository.Update(found.DonationId);
                theOld = mapper.Map<Donation, DonationDto>(found);
                return theOld;
            }
        }


        public void Create(DonationDto toCreate)
        {
            var entity = mapper.Map<DonationDto, Donation>(toCreate);
            _DonationRepository.Add(entity);
        }

        public IEnumerable<DonationDto>? ReadAll()
        {
            var list = _DonationRepository.GetAll();
            if (list == null)
            {
                throw new NotFoundException("Donation List is empty!");
            }
            var listDto = mapper.Map<IEnumerable<Donation>, IEnumerable<DonationDto>>(list);
            return listDto;
        }

        public void Delete(int Id)
        {
            Donation? found = _DonationRepository.GetById(Id);
            if (found == null)
            {
                throw new NotFoundException("This Donation doesn't exist!");
            }
            else
            {
                _DonationRepository.Delete(Id);
            }
        }
    }
}
