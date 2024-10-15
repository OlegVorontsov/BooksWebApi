
namespace Books.DataAccess.Repositories
{
    public interface IBooksRepository
    {
        Task<Guid> CreateAsync(Book book);
        Task<Guid> DeleteAsync(Guid id);
        Task<List<Book>> GetAllAsync();
        Task<Guid> UpdateAsync(Guid id, string title, string description, decimal price);
        Task<(Book, string)> GetByIdAsync(Guid id);
    }
}