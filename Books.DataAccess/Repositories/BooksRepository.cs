using Books.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Books.DataAccess.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly BooksDbContext _context;

        public BooksRepository(BooksDbContext context)
        {
            _context = context;
        }
        public async Task<List<Book>> GetAllAsync()
        {
            var bookEntities = await _context.Books.AsNoTracking().ToListAsync();
            var books = bookEntities
                .Select(b => Book.Create(b.Id, b.Title, b.Description, b.Price).Book)
                .ToList();
            return books;
        }
        public async Task<Guid> CreateAsync(Book book)
        {
            var bookEntity = new BookEntity
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Price = book.Price
            };
            await _context.Books.AddAsync(bookEntity);
            await _context.SaveChangesAsync();
            return bookEntity.Id;
        }
        public async Task<Guid> UpdateAsync(Guid id, string title, string description, decimal price)
        {
            await _context.Books
                .Where(b => b.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(b => b.Title, title)
                    .SetProperty(b => b.Description, description)
                    .SetProperty(b => b.Price, price));
            return id;
        }
        public async Task<Guid> DeleteAsync(Guid id)
        {
            await _context.Books
                .Where(b => b.Id == id)
                .ExecuteDeleteAsync();
            return id;
        }
    }
}
