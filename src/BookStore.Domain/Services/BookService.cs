using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Domain.Interfaces;
using BookStore.Domain.Models;

namespace BookStore.Domain.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        //BookRepository
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        //BookRepository GetAll
        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _bookRepository.GetAll();
        }


        //BookRepository GetById
        public async Task<Book> GetById(int id)
        {
            return await _bookRepository.GetById(id);
        }

        //BookRepository Add Book
        public async Task<Book> Add(Book book)
        {
            if (_bookRepository.Search(b => b.Name == book.Name).Result.Any())
                return null;

            await _bookRepository.Add(book);
            return book;
        }

        //BookRepository Update Book
        public async Task<Book> Update(Book book)
        {
            if (_bookRepository.Search(b => b.Name == book.Name && b.Id != book.Id).Result.Any())
                return null;

            await _bookRepository.Update(book);
            return book;
        }

        //BookRepository Remove/Delete Book
        public async Task<bool> Remove(Book book)
        {
            await _bookRepository.Remove(book);
            return true;
        }

        //BookRepository GetBooksByCategory
        public async Task<IEnumerable<Book>> GetBooksByCategory(int categoryId)
        {
            return await _bookRepository.GetBooksByCategory(categoryId);
        }

        //BookRepository Search
        public async Task<IEnumerable<Book>> Search(string bookName)
        {
            return await _bookRepository.Search(c => c.Name.Contains(bookName));
        }

        //BookRepository SearchBookWithCategory
        public async Task<IEnumerable<Book>> SearchBookWithCategory(string searchedValue)
        {
            return await _bookRepository.SearchBookWithCategory(searchedValue);
        }

        //BookRepository Dispose
        public void Dispose()
        {
            _bookRepository?.Dispose();
        }
    }
}