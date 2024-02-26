using Mapster;
using PizzaProject.API.Models.Requests;
using PizzaProject.Application.Addresses;
using PizzaProject.Application.Pizzas;
using PizzaProject.Application.Users;
using PizzaProject.Domain.Entity;
using System;

namespace PizzaProject.API.Infrastructure.Mappings
{
    public static class MapsterConfiguration
    {
        public static void RegisterMaps(this IServiceCollection services)
        {
            TypeAdapterConfig<PizzaCreateModel, RankHistoryRequestModel>
                .NewConfig()
                .TwoWays();

            TypeAdapterConfig<Pizza, PizzaResponseModel>
                .NewConfig()
                .TwoWays();

            TypeAdapterConfig<AddressCreateModel, AddressRequestModel>
                .NewConfig()
                .TwoWays();

            TypeAdapterConfig<Address, AddressResponseModel>
                .NewConfig()
                .TwoWays();

            TypeAdapterConfig<AddressUpdateModel, AddressRequestModel>
                .NewConfig()
                .TwoWays();

            TypeAdapterConfig<UserCreateModel, UserRequestModel>
                .NewConfig()
                .TwoWays();

            TypeAdapterConfig<User, UserResponseModel>
                .NewConfig()
                .TwoWays();

            //TypeAdapterConfig<PersonCreateModel, PersonRequestModel>
            //.NewConfig()
            //.Map(dest => dest.PersonIdentifier, src => src.Identifier)
            //.TwoWays();

            //TypeAdapterConfig<PersonRequestModel, Person>
            //.NewConfig()
            //.Map(dest => dest.Identifier, src => src.PersonIdentifier)
            //.TwoWays();

            //TypeAdapterConfig<PersonRequestModel, PersonResponseModel>
            //.NewConfig()
            //.TwoWays();
        }
    }
}
