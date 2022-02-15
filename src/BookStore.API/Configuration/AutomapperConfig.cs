using AutoMapper;
using BookStore.API.Dtos.Book;
using BookStore.API.Dtos.Category;
using BookStore.Domain.Models;

namespace BookStore.API.Configuration
{
    public class AutomapperConfig : Profile
    {

        // books and category Mappings
        public AutomapperConfig()
        {
            CreateMap<Category, CategoryAdd>().ReverseMap();
            CreateMap<Category, CategoryEdit>().ReverseMap();
            CreateMap<Category, CategoryResult>().ReverseMap();
            CreateMap<Book, BookAdd>().ReverseMap();
            CreateMap<Book, BookEdit>().ReverseMap();
            CreateMap<Book, BookResult>().ReverseMap();
        }
    }
}