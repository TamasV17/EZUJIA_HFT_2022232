using System.Linq;

namespace EZUJIA_HFT_2022232.Repository
{
    public interface IRepository<T> where T : class
    {
        T Read(int id);

        IQueryable<T> ReadAll();

        void Create(T item);

        void Delete(int id);

        void Update(T item);
    }
}