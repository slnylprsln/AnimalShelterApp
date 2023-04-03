using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepositories
{
    public interface IDonationRepository
    {
        IEnumerable<Donation>? GetAll();
        Donation? GetById(int Id);
        void Add(Donation toAdd);
        void Delete(int Id);
        void Update(int? Id);
        void Dispose(bool disposing);
        void Dispose();
    }
}
