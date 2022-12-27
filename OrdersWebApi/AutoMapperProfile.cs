using Application.Order.Commands.CreateOrder;
using Application.Order.Commands.UpdateOrder;
using Application.User.Commands.CreateUser;
using Application.User.Commands.UpdateUser;
using AutoMapper;
using OrdersWebApi.DTOs.Order;
using OrdersWebApi.DTOs.User;

namespace OrdersWebApi
{
    public sealed class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateUserDTO, CreateUserCommand>();
            CreateMap<UpdateUserDTO, UpdateUserCommand>();

            CreateMap<CreateOrderDTO, CreateOrderCommand>();
            CreateMap<UpdateOrderDTO, UpdateOrderCommand>();
        }
    }
}
