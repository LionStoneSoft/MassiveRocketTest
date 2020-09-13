using MassiveRocketTest.Core.Models;
using System.Linq;

namespace MassiveRocketTest.Core.Contracts
{
    public interface IRepository<P> where P : BaseEntity
    {
        IQueryable<P> Collection();
        void Commit();
        void Delete(string Id);
        P Find(string Id);
        void Insert(P p);
        void Update(P p);
    }
}