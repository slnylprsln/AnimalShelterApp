using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Services.Interfaces
{
	public interface IShelterServices
	{
		public Task<List<Shelter>> GetShelters();
		public Task<bool> AddShelter(Shelter shelter);
		public Task<bool> EditShelter(Shelter shelter);
		public Task<bool> DeleteShelter(Shelter shelter);
        public Task<Shelter> GetShelterById(int id);
    }
}
