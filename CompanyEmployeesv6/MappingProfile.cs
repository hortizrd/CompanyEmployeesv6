﻿using Entities.Models;
using Shared.DTO;
using AutoMapper;
namespace CompanyEmployeesv6
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
             CreateMap<Company, CompanyDto>()
                 .ForMember(c => c.FullAddress,
             opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country)));

            CreateMap<Employee, EmployeeDto>();
            CreateMap<CompanyForCreationDto, Company>();
            CreateMap<EmployeeForCreationDto, Employee>();

        }


    }
}
