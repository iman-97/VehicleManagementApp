using System.Linq;
using VehicleManagement.Core.Models;

namespace VehicleManagement.DataAccess
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> Collection();
        void Commit();
        void Delete(int id);
        T Find(int id);
        void Insert(T item);
        void Update(T item);
    }
}
