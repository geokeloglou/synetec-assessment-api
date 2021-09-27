using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SynetecAssessmentApi.Domain;
using SynetecAssessmentApi.Persistence.Database;

namespace SynetecAssessmentApi.Persistence.Repositories
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        Task<int> GetSalarySum();
    }

    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Employee>> GetAll()
        {
            return await _dbSet.Include(employee => employee.Department)
                .AsNoTracking()
                .ToListAsync();
        }

        public override async Task<Employee> GetById(int id)
        {
            return await _dbSet.Include(employee => employee.Department)
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> GetSalarySum()
        {
            return await _dbSet.AsNoTracking().SumAsync(employee => employee.Salary);
        }
    }
}
