using Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.IServices
{
	public interface IFollowServices
	{
		void Create(FollowDto toCreate);
		FollowDto? Read(int Id);
		IEnumerable<FollowDto>? ReadByUserId(int userId);
		IEnumerable<FollowDto>? ReadCatsByUserId(int userId);
		IEnumerable<FollowDto>? ReadDogsByUserId(int userId);
        IEnumerable<FollowDto>? ReadAll();
		void Delete(int Id);
	}
}
