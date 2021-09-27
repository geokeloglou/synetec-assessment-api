using AutoMapper;
using SynetecAssessmentApi.Domain;
using SynetecAssessmentApi.Domain.Dtos;

namespace SynetecAssessmentApi.Bl.Automapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<Department, DepartmentDto>();
        }
    }
}
