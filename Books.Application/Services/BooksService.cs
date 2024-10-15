using Books.DataAccess.Repositories;

namespace Books.Application.Services
{
    public class BooksService : IBooksService
    {
        private readonly IBooksRepository _booksRepository;

        public BooksService(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }
        public async Task<List<Book>> GetAllBooks()
        {
            return await _booksRepository.GetAllAsync();
        }
        public async Task<Guid> CreateBook(Book book)
        {
            return await _booksRepository.CreateAsync(book);
        }
        public async Task<Guid> UpdateBook(Guid id, string title, string description, decimal price)
        {
            return await _booksRepository.UpdateAsync(id, title, description, price);
        }
        public async Task<Guid> DeleteBook(Guid id)
        {
            return await _booksRepository.DeleteAsync(id);
        }
        public async Task<(Book, string)> GetBook(Guid id)
        {
            return await _booksRepository.GetByIdAsync(id);
        }
    }
}
