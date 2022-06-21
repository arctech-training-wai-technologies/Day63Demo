using Day63Demo.Data.ViewModels;

namespace Day63Demo.Data.Services;

public interface IDepartmentsService
{
    Task<List<DepartmentViewModel>> GetAllAsync();
    Task<DepartmentViewModel?> GetByIdAsync(int id);
    Task CreateAsync(DepartmentViewModel department);
}