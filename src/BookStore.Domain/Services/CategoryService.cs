using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Domain.Interfaces;
using BookStore.Domain.Models;

namespace BookStore.Domain.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBookService _bookService;

        public CategoryService(ICategoryRepository categoryRepository, IBookService bookService)
        {
            _categoryRepository = categoryRepository;
            _bookService = bookService;
        }

        //_categoryRepository GetAll
        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _categoryRepository.GetAll();
        }

        //_categoryRepository GetById
        public async Task<Category> GetById(int id)
        {
            return await _categoryRepository.GetById(id);
        }

        //_categoryRepository Add
        public async Task<Category> Add(Category category)
        {
            if (_categoryRepository.Search(c => c.Name == category.Name).Result.Any())
                return null;

            await _categoryRepository.Add(category);
            return category;
        }

        //_categoryRepository Update
        public async Task<Category> Update(Category category)
        {
            if (_categoryRepository.Search(c => c.Name == category.Name && c.Id != category.Id).Result.Any())
                return null;

            await _categoryRepository.Update(category);
            return category;
        }

        //_categoryRepository Remove
        public async Task<bool> Remove(Category category)
        {
            var books = await _bookService.GetBooksByCategory(category.Id);
            if (books.Any()) return false;

            await _categoryRepository.Remove(category);
            return true;
        }

        //_categoryRepository Search
        public async Task<IEnumerable<Category>> Search(string categoryName)
        {
            return await _categoryRepository.Search(c => c.Name.Contains(categoryName));
        }

        //_categoryRepository Dispose
        public void Dispose()
        {
            _categoryRepository?.Dispose();
        }
    }
}