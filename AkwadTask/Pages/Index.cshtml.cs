using AkwadTask.Services;

namespace AkwadTask.Pages
{
    using Data;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class IndexModel : PageModel
    {
        private readonly IEmployeeService _service;
        [BindProperty]public IList<EmployeeViewModel> Employees { get; set; }
        [BindProperty]public IList<DepartmentViewModel> Departments{ get; set; }
        [BindProperty]public IList<JobViewModel> Jobs{ get; set; }

        public IndexModel(IEmployeeService service)
        {
            _service = service;
        }

        public async Task OnGetAsync()
        {
            Employees = await _service.GetAllEmployeesAsync();
            Departments = await _service.GetAllDepartmentsForSelectionAsync();
            Jobs = await _service.GetAllJobsForSelectionAsync();
        }
        

        public async Task<JsonResult> OnPostReadAsync([DataSourceRequest] DataSourceRequest request)
        {
            Employees = await _service.GetAllEmployeesAsync();
            return new JsonResult(await Employees.ToDataSourceResultAsync(request));
        }

        public async Task<JsonResult> OnPostCreateAsync([DataSourceRequest] DataSourceRequest request, EmployeeViewModel emp)
        {
            await _service.InsertEmployeeAsync(emp);
            return new JsonResult(await new[] { emp }.ToDataSourceResultAsync(request, ModelState));
        }

        public async Task<JsonResult> OnPostUpdateAsync([DataSourceRequest] DataSourceRequest request, EmployeeViewModel emp)
        {
            await _service.UpdateEmployeeAsync(emp);

            return new JsonResult(await new[] { emp }.ToDataSourceResultAsync(request, ModelState));
        }

        public async Task<JsonResult> OnPostDestroyAsync([DataSourceRequest] DataSourceRequest request, EmployeeViewModel emp)
        {
            await _service.RemoveEmployeeAsync(emp);

            return new JsonResult(await new[] { emp }.ToDataSourceResultAsync(request, ModelState));
        }

        
        public async Task<JsonResult> OnGetDepartments()
        {
            Departments = await _service.GetAllDepartmentsForSelectionAsync();
            return new JsonResult(Departments);
        }

        public async Task<JsonResult> OnGetJobs(decimal dep)
        {
            Jobs = await _service.GetAllJobsForSelectionAsync();
            if (dep != 0)
            {
                var filteredJobs = Jobs.Where(j => j.DEPARTMENT_ID == dep).ToList();
                return new JsonResult(filteredJobs);
            }
            return new JsonResult(Jobs);
        }
    }
}
