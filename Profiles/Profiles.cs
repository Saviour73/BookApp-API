using AutoMapper;
using BookApp.DTOs.RequestDTOs;
using BookApp.Entities;

namespace BookApp.Profiles
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<BookRequestDTO, Book>();
            CreateMap<Book, BookRequestDTO>();
        }
    }
}
