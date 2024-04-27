namespace ShoppingDALLibrary
{
    public abstract class AbstractRepository<K, T> : IRepository<K, T>
    {
        protected readonly List<T> items = new List<T>(); 
        public virtual T Add(T item)
        {
           
            throw new NotImplementedException("Add method not implemented in AbstractRepository. Implement in derived class.");
        }

        public virtual ICollection<T> GetAll()
        {
            
            return items.ToList(); 
        }

        public abstract T Delete(K key);

        public abstract T GetByKey(K key);

        public abstract T Update(T item);
    }
}
