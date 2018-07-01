﻿using Resmap.API.Models;
using Resmap.Domain;
using System;

namespace Resmap.API
{
    public static class AutomapperCfg
    {
        public static void GetCfg()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                // Mapping other entities
                cfg.CreateMap<Employee, EmployeeDto>()
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
                cfg.CreateMap<Relation, RelationDto>();
                cfg.CreateMap<RelationForCreationDto, Relation>();
                cfg.CreateMap<EmployeeForCreationDto, Employee>();
                cfg.CreateMap<AddressDto, Address>();
                cfg.CreateMap<NoteDto, Note>();
                cfg.CreateMap<ContactDto, Contact>();
                cfg.CreateMap<RelationTagDto, RelationTag>();
                cfg.CreateMap<TagDto, Tag>();
                cfg.CreateMap<Project, ProjectDto>();

                // Mapping events
                cfg.CreateMap<Event, EventDto>()
                    .ForMember(dest => dest.Start, opt => opt.ResolveUsing(src => {
                        var dt = (DateTime)src.Start; return dt.ToShortDateString();
                    }))
                    .ForMember(dest => dest.End, opt => opt.ResolveUsing(src => {
                        var dt = (DateTime)src.End; return dt.ToShortDateString();
                    }));

                cfg.CreateMap<EmployeeEvent, EmployeeEventDto>();
                cfg.CreateMap<EventForCreationDto, EmployeeEvent>();
                cfg.CreateMap<EventForCreationDto, CarEvent>();

                // mapping resources for events
                cfg.CreateMap<Car, ResourceCarDto>()
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.NumberPlate} {src.Model}"));
                cfg.CreateMap<Employee, ResourceEmployeeDto>()
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
            });
        }
    }
}