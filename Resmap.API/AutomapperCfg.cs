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
                    .ForMember(dto => dto.Department, opt => opt.MapFrom(src => src.Department.Title))
                    .ForMember(dto => dto.JobTitle, opt => opt.MapFrom(src => src.JobTitle.Title))
                    .ForMember(dto => dto.Subcontractor, opt => opt.MapFrom(src => src.Subcontractor.Title))
                    .ForMember(dest => dest.FullName,
                        opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));                     
                cfg.CreateMap<EmployeeForUpdateDto, Employee>();
                cfg.CreateMap<EmployeeForCreationDto, Employee>();

                // Mapping Relation
                cfg.CreateMap<Relation, RelationDto>()
                    .ForMember(dto => dto.Tags, opt => opt.MapFrom(
                            src => src.Tags.Select(t => t.Tag).ToList()));
                cfg.CreateMap<RelationForUpdateDto, Relation>();
                cfg.CreateMap<RelationForCreationDto, Relation>()
                    .ForMember(dto => dto.Tags, opt => opt.Ignore());
                cfg.CreateMap<RelationForUpdateDto, Relation>()
                    .ForMember(dto => dto.Tags, opt => opt.Ignore());
                
                // Mapping Project
                cfg.CreateMap<ProjectTagDto, ProjectTag>();
                cfg.CreateMap<Project, ProjectDto>()         
                    .ForMember(dto => dto.Client, opt => opt.MapFrom(src => src.Client.Title))
                    .ForMember(dto => dto.Tags, opt => opt.MapFrom(
                        src => src.Tags.Select(t => t.Tag).ToList()));                    
                cfg.CreateMap<ProjectForCreationDto, Project>()
                    .ForMember(dto => dto.Tags, opt => opt.Ignore());   
                cfg.CreateMap<ProjectForUpdateDto, Project>()
                    .ForMember(dto => dto.Tags, opt => opt.Ignore());

                // Mapping shared entities
                cfg.CreateMap<AddressDto, Address>();
                cfg.CreateMap<AddressForCreationDto, Address>();
                cfg.CreateMap<NoteDto, Note>();
                cfg.CreateMap<JobTitleDto, JobTitle>();
                cfg.CreateMap<DepartmentDto, Department>();
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

                cfg.CreateMap<EmployeeEvent, EmployeeEventDto>()
                    .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.Title))
                    .ForMember(dest => dest.BarColor, opt => opt.MapFrom(src => src.Status.Color))
                    .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Project.Title));
                cfg.CreateMap<EmployeeEventForCreationDto, EmployeeEvent>();
                cfg.CreateMap<CarEventForCreationDto, CarEvent>();
                cfg.CreateMap<EventForCreationDto, CarEvent>();

                cfg.CreateMap<CarEvent, CarEventDto>()
                    .ForMember(dest => dest.Text, opt =>
                        opt.MapFrom(src => $"{src.Employee.FirstName} {src.Employee.LastName}"));

                // mapping resources for events
                cfg.CreateMap<Car, ResourceCarDto>()
                    .ForMember(dest => dest.Name, opt => 
                        opt.MapFrom(src => $"{src.NumberPlate} {src.Model}"));                
                cfg.CreateMap<Employee, ResourceEmployeeDto>()
                    .ForMember(dest => dest.JobTitle, opt => opt.MapFrom(src => src.JobTitle.Title))
                    .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department.Title))                    
                    .ForMember(dest => dest.Name, 
                        opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
            });
        }
    }
}
