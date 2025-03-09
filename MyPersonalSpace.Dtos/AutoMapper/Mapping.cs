using System;
using AutoMapper;
using MyPersonalSpace.Dtos.Dtos.AboutDtos;
using MyPersonalSpace.Dtos.Dtos.CategoryDtos;
using MyPersonalSpace.Dtos.Dtos.CommentDtos;
using MyPersonalSpace.Dtos.Dtos.ContactDtos;
using MyPersonalSpace.Dtos.Dtos.PostDtos;
using MyPersonalSpace.Dtos.Dtos.PostTagDtos;
using MyPersonalSpace.Dtos.Dtos.TagDtos;
using MyPersonalSpace.Dtos.Dtos.UserDtos;
using MyPersonalSpace.Entities.Concrete;
using static System.Net.Mime.MediaTypeNames;

namespace MyPersonalSpace.Dtos.AutoMapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<CreateCategoryDto, Category>().ReverseMap();
            CreateMap<UpdateCategoryDto, Category>().ReverseMap();
            CreateMap<ResultCategoryDto, Category>().ReverseMap();

            CreateMap<CreateCommentDto, Comment>().ReverseMap();
            CreateMap<UpdateCommentDto, Comment>().ReverseMap();
            CreateMap<ResultCommentDto, Comment>().ReverseMap();

            CreateMap<CreatePostDto, Post>().ReverseMap();
            CreateMap<UpdatePostDto, Post>().ReverseMap();
            CreateMap<ResultPostDto, Post>().ReverseMap();

            CreateMap<CreatePostTagDto, PostTag>().ReverseMap();
            CreateMap<UpdatePostTagDto, PostTag>().ReverseMap();
            CreateMap<ResultPostTagDto, PostTag>().ReverseMap();

            CreateMap<CreateTagDto, Tag>().ReverseMap();
            CreateMap<UpdateTagDto, Tag>().ReverseMap();
            CreateMap<ResultTagDto, Tag>().ReverseMap();

            CreateMap<CreateAboutDto, About>().ReverseMap();
            CreateMap<UpdateAboutDto, About>().ReverseMap();
            CreateMap<ResultAboutDto, About>().ReverseMap();

            CreateMap<CreateContactDto, Contact>().ReverseMap();
            CreateMap<UpdateContactDto, Contact>().ReverseMap();
            CreateMap<ResultContactDto, Contact>().ReverseMap();

            CreateMap<DenemeDto, User>().ReverseMap();
        }
    }
}

