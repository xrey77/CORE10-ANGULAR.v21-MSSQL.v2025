using AutoMapper;
using core10_mssql.Entities;
using core10_mssql.Models;
using core10_mssql.Models.dto;

namespace core10_mssql.Helpers;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<User, UserModel>();
        CreateMap<UserRegister, User>();
        CreateMap<UserLogin, User>();
        CreateMap<UserUpdate, User>();
        CreateMap<UserPasswordUpdate, User>();
        CreateMap<Product, ProductModel>();

    }
}