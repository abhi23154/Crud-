using BookLibraryApi.Models;

namespace BookLibraryApi.Services
{
    public class BookService
    {
        private readonly List<Book> _books = new();

        public List<Book> GetBooks() => _books;

        public Book GetBookById(int id) => _books.FirstOrDefault(b => b.ID == id);

        public void AddBook(Book book)
        {
            _books.Add(book);
            book.ID = _books.Count;
        }

        public void UpdateBook(Book book)
        {
            var existingBook = GetBookById(book.ID);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.PublicationDate = book.PublicationDate;
            }
        }

        public void DeleteBook(int id)
        {
            var bookToDelete = GetBookById(id);
            if (bookToDelete != null)
            {
                _books.Remove(bookToDelete);
            }
        }
    }
}
