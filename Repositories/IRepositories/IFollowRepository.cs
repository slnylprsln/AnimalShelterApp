using Entities;

namespace Repositories.IRepositories
{
	public interface IFollowRepository
	{
		IEnumerable<Follow>? GetAll();
		Follow? GetById(int Id);
		Follow? GetByUserId(int userId);
		void Add(Follow toAdd);
		void Update(int? Id);
		void Delete(int followId);
	}
}
