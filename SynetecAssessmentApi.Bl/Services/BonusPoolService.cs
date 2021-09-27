using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using SynetecAssessmentApi.Bl.BonusProvider;
using SynetecAssessmentApi.Bl.Constants;
using SynetecAssessmentApi.Bl.Wrappers;
using SynetecAssessmentApi.Domain;
using SynetecAssessmentApi.Domain.Dtos;
using SynetecAssessmentApi.Persistence.Repositories;

namespace SynetecAssessmentApi.Bl.Services
{
    public interface IBonusPoolService
    {
        Task<ServiceResult<List<EmployeeDto>>> GetAllEmployeesAsync();
        Task<ServiceResult<BonusPoolCalculatorResultDto>> CalculateAsync(CalculateBonusDto request);
    }

    public class BonusPoolService : IBonusPoolService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly IBonusProvider _bonusProvider;

        public BonusPoolService(
            IEmployeeRepository employeeRepository,
            IMapper mapper,
            IBonusProvider bonusProvider)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _bonusProvider = bonusProvider;
        }

        public async Task<ServiceResult<List<EmployeeDto>>> GetAllEmployeesAsync()
        {
            var result = new ServiceResult<List<EmployeeDto>>();

            var employees = await _employeeRepository.GetAll();

            result.Data = _mapper.Map<List<EmployeeDto>>(employees);
            result.Message = ResultMessages.Base.Ok;
            result.StatusCode = (int) HttpStatusCode.OK;

            return result;
        }

        public async Task<ServiceResult<BonusPoolCalculatorResultDto>> CalculateAsync(CalculateBonusDto request)
        {
            var result = new ServiceResult<BonusPoolCalculatorResultDto>();

            //load the details of the selected employee using the Id
            Employee employee = await _employeeRepository.GetById(request.SelectedEmployeeId);

            //checking if employee is null
            if (employee == null)
            {
                result.Success = false;
                result.Message = ResultMessages.Base.BadRequest;
                result.StatusCode = (int) HttpStatusCode.BadRequest;

                return result;
            }

            //get the total salary budget for the company
            int totalSalary = await _employeeRepository.GetSalarySum();

            //calculate the bonus allocation for the employee
            int bonusAllocation =
                _bonusProvider.CalculateBonusAllocation(request.TotalBonusPoolAmount, employee.Salary, totalSalary);

            result.Data = new BonusPoolCalculatorResultDto
            {
                Employee = _mapper.Map<EmployeeDto>(employee),
                Amount = bonusAllocation
            };

            result.Message = ResultMessages.Base.Ok;
            result.StatusCode = (int) HttpStatusCode.OK;

            return result;
        }
    }
}
