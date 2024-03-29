﻿using AutoMapper;
using EWalletV2.Api.ViewModels.Auth;
using EWalletV2.Api.ViewModels.Transaction;
using EWalletV2.Api.ViewModels.User;
using EWalletV2.Domain.DtoModels.Auth;
using EWalletV2.Domain.DtoModels.Transaction;
using EWalletV2.Domain.DtoModels.User;
using EWalletV2.Api.ViewModels.Transaction;
using EWalletV2.Domain.DtoModels.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EWalletV2.Domain.Entities;

namespace EWalletV2.Api.AutoMapperConfig
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegisterCommand, RegisterDtoCommand>();
            CreateMap<LoginUserAndPassDto, LoginUserAndPassViewModel>();
            CreateMap<UpdateUserCommand, UpdateUserDtoCommand>();
            CreateMap<TransactionDto, TransactionViewModel>();
            CreateMap<RegisterCommand, RegisterDtoCommand>();
            CreateMap<RegisterDtoCommand, UserEntity>();
            CreateMap<TopupDto, TopupViewModel>();
            CreateMap<UserEntity, LoginUserAndPassDto>();
            CreateMap<UserEntity, LoginByCustomerDto>();
            CreateMap<LoginByCustomerDto, LoginByCustomerViewModel>();
        }
        
    }
    
}
