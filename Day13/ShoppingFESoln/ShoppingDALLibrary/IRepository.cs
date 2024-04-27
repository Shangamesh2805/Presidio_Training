using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public interface IRepository<K, T>
    {
       
        Task<T> AddAsync(T item); 
        Task<T> GetByKeyAsync(K key); 
        Task<ICollection<T>> GetAllAsync();
        Task<T> UpdateAsync(T item);
        Task<T> DeleteAsync(K key);
    }
}
