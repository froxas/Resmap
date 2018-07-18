using Resmap.API.Models;
using Resmap.Domain;
using System;
using System.Linq;

namespace Resmap.API
{
    public static class AutomapperCfg
    {
        public static void GetCfg()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                // Mapping Employee
                cfg.CreateMap<Employee, EmployeeDto>()
                    .ForMember(dest => dest.FullName, 
                        opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
                cfg.CreateMap<EmployeeForCreationDto, Employee>();
                
                // Mapping Relation
                cfg.CreateMap<Relation, RelationDto>();
                cfg.CreateMap<RelationForCreationDto, Relation>();

                // Mapping Project
                cfg.CreateMap<ProjectTagDto, ProjectTag>();
                cfg.CreateMap<Project, ProjectDto>()
                    .ForMember(dto => dto.Tags, opt => opt.MapFrom(
                        src => src.ProjectTags.Select(t => t.Tag).ToList()));

                cfg.CreateMap<ProjectForCreationDto, Project>();
                cfg.CreateMap<ProjectForUpdateDto, Project>();


                // Mapping shared entities
                cfg.CreateMap<AddressDto, Address>();
                cfg.CreateMap<AddressForCreationDto, Address>();
                cfg.CreateMap<NoteDto, Note>();
                cfg.CreateMap<ContactDto, Contact>();                
                cfg.CreateMap<TagDto, Tag>();                   
                
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
                    .ForMember(dest => dest.Name, opt => 
                        opt.MapFrom(src => $"{src.NumberPlate} {src.Model}"));
                cfg.CreateMap<Employee, ResourceEmployeeDto>()
                    .ForMember(dest => dest.Name, 
                        opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
            });
        }
    }
}
