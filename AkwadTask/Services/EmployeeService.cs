using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AkwadTask.Data;

namespace AkwadTask.Services
{
    public interface IEmployeeService
    {
        Task<IList<EmployeeViewModel>> GetAllEmployeesAsync();
        Task<IList<DepartmentViewModel>> GetAllDepartmentsForSelectionAsync();
        Task<IList<JobViewModel>> GetAllJobsForSelectionAsync();
        Task<ResponseViewModel> InsertEmployeeAsync(EmployeeViewModel emp);
        Task<ResponseViewModel> UpdateEmployeeAsync(EmployeeViewModel emp);
        Task<ResponseViewModel> RemoveEmployeeAsync(EmployeeViewModel emp);
    }
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _httpClient;
        public IList<EmployeeViewModel> Employees { get; set; }
        public IList<DepartmentViewModel> Departments { get; set; }
        public IList<JobViewModel> Jobs { get; set; }

        public EmployeeService(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("akwad");
            Departments = new List<DepartmentViewModel>
            {
                new DepartmentViewModel
                {
                    DEPARTMENT_ID = 1,
                    DEPARTMENT_NAME = "Dep1"
                },new DepartmentViewModel
                {
                    DEPARTMENT_ID = 2,
                    DEPARTMENT_NAME = "Dep2"
                },new DepartmentViewModel
                {
                    DEPARTMENT_ID = 3,
                    DEPARTMENT_NAME = "Dep3"
                },
            };
            Jobs = new List<JobViewModel>
            {
                new JobViewModel
                {
                    JOB_ID = 1,
                    DEPARTMENT_ID = 1,
                    JOB_NAME = "job1"
                },
                new JobViewModel
                {
                    JOB_ID = 2,
                    DEPARTMENT_ID = 1,
                    JOB_NAME = "job2"
                },
                new JobViewModel
                {
                    JOB_ID = 3,
                    DEPARTMENT_ID = 1,
                    JOB_NAME = "job3"
                },
                new JobViewModel
                {
                    JOB_ID = 4,
                    DEPARTMENT_ID = 2,
                    JOB_NAME = "job4"
                },
                new JobViewModel
                {
                    JOB_ID = 5,
                    DEPARTMENT_ID = 2,
                    JOB_NAME = "job5"
                },
                new JobViewModel
                {
                    JOB_ID = 6,
                    DEPARTMENT_ID = 2,
                    JOB_NAME = "job6"
                },
            };
            Employees = new List<EmployeeViewModel>
            {
                new EmployeeViewModel
                {
                    EMPLOYEE_DATA_ID = 1,
                    DEPARTMENT_ID = 1,
                    DEPARTMENT_NAME = "Dep1",
                    JOB_ID = 1,
                    JOB_NAME = "job1",
                    FIRST_NAME = "Emp1",
                    LAST_NAME = "emp1",
                    EMPLOYEE_ADDRESS = "alex",
                    EMPLOYEE_MOBILE = "01234567",
                    HIREING_DATE = DateTime.Today,
                    SALARY = 500000,
                    IDNUMBER = 1545959
                },new EmployeeViewModel
                {
                    EMPLOYEE_DATA_ID = 1,
                    DEPARTMENT_ID = 1,
                    DEPARTMENT_NAME = "Dep1",
                    JOB_ID = 1,
                    JOB_NAME = "job1",
                    FIRST_NAME = "Emp1",
                    LAST_NAME = "emp1",
                    EMPLOYEE_ADDRESS = "alex",
                    EMPLOYEE_MOBILE = "01234567",
                    HIREING_DATE = DateTime.Today,
                    SALARY = 500000,
                    IDNUMBER = 1545959
                },new EmployeeViewModel
                {
                    EMPLOYEE_DATA_ID = 2,
                    DEPARTMENT_ID = 1,
                    DEPARTMENT_NAME = "Dep1",
                    JOB_ID = 1,
                    JOB_NAME = "job1",
                    FIRST_NAME = "Emp2",
                    LAST_NAME = "emp2",
                    EMPLOYEE_ADDRESS = "alex",
                    EMPLOYEE_MOBILE = "01234567",
                    HIREING_DATE = DateTime.Today,
                    SALARY = 500000,
                    IDNUMBER = 1545959
                },new EmployeeViewModel
                {
                    EMPLOYEE_DATA_ID = 3,
                    DEPARTMENT_ID = 1,
                    DEPARTMENT_NAME = "Dep1",
                    JOB_ID = 1,
                    JOB_NAME = "job1",
                    FIRST_NAME = "Emp3",
                    LAST_NAME = "emp3",
                    EMPLOYEE_ADDRESS = "alex",
                    EMPLOYEE_MOBILE = "01234567",
                    HIREING_DATE = DateTime.Today,
                    SALARY = 500000,
                    IDNUMBER = 1545959
                },new EmployeeViewModel
                {
                    EMPLOYEE_DATA_ID = 4,
                    DEPARTMENT_ID = 1,
                    DEPARTMENT_NAME = "Dep1",
                    JOB_ID = 1,
                    JOB_NAME = "job1",
                    FIRST_NAME = "Emp4",
                    LAST_NAME = "emp4",
                    EMPLOYEE_ADDRESS = "alex",
                    EMPLOYEE_MOBILE = "01234567",
                    HIREING_DATE = DateTime.Today,
                    SALARY = 500000,
                    IDNUMBER = 1545959
                },new EmployeeViewModel
                {
                    EMPLOYEE_DATA_ID = 5,
                    DEPARTMENT_ID = 1,
                    DEPARTMENT_NAME = "Dep1",
                    JOB_ID = 1,
                    JOB_NAME = "job1",
                    FIRST_NAME = "Emp5",
                    LAST_NAME = "emp5",
                    EMPLOYEE_ADDRESS = "alex",
                    EMPLOYEE_MOBILE = "01234567",
                    HIREING_DATE = DateTime.Today,
                    SALARY = 500000,
                    IDNUMBER = 1545959
                },new EmployeeViewModel
                {
                    EMPLOYEE_DATA_ID = 6,
                    DEPARTMENT_ID = 1,
                    DEPARTMENT_NAME = "Dep1",
                    JOB_ID = 1,
                    JOB_NAME = "job1",
                    FIRST_NAME = "Emp6",
                    LAST_NAME = "emp6",
                    EMPLOYEE_ADDRESS = "alex",
                    EMPLOYEE_MOBILE = "01234567",
                    HIREING_DATE = DateTime.Today,
                    SALARY = 500000,
                    IDNUMBER = 1545959
                },new EmployeeViewModel
                {
                    EMPLOYEE_DATA_ID = 7,
                    DEPARTMENT_ID = 1,
                    DEPARTMENT_NAME = "Dep1",
                    JOB_ID = 1,
                    JOB_NAME = "job1",
                    FIRST_NAME = "Emp7",
                    LAST_NAME = "emp7",
                    EMPLOYEE_ADDRESS = "alex",
                    EMPLOYEE_MOBILE = "01234567",
                    HIREING_DATE = DateTime.Today,
                    SALARY = 500000,
                    IDNUMBER = 1545959
                },new EmployeeViewModel
                {
                    EMPLOYEE_DATA_ID = 8,
                    DEPARTMENT_ID = 1,
                    DEPARTMENT_NAME = "Dep1",
                    JOB_ID = 1,
                    JOB_NAME = "job1",
                    FIRST_NAME = "Emp8",
                    LAST_NAME = "emp8",
                    EMPLOYEE_ADDRESS = "alex",
                    EMPLOYEE_MOBILE = "01234567",
                    HIREING_DATE = DateTime.Today,
                    SALARY = 500000,
                    IDNUMBER = 1545959
                },new EmployeeViewModel
                {
                    EMPLOYEE_DATA_ID = 9,
                    DEPARTMENT_ID = 2,
                    DEPARTMENT_NAME = "Dep2",
                    JOB_ID = 3,
                    JOB_NAME = "job3",
                    FIRST_NAME = "Emp9",
                    LAST_NAME = "emp9",
                    EMPLOYEE_ADDRESS = "alex",
                    EMPLOYEE_MOBILE = "01234567",
                    HIREING_DATE = DateTime.Today,
                    SALARY = 500000,
                    IDNUMBER = 1545959
                }
            };
        }

        private async Task<T> GetDataAsync<T>(bool isPost,string uri , object value = null) where T : class
        {
            T response;
            if (isPost)
            {
                StringContent contentJson = new StringContent(
                    JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");
                var responseMessage = await _httpClient.PostAsync(uri, contentJson);
                responseMessage.EnsureSuccessStatusCode();
                await using var responseStream = await responseMessage.Content.ReadAsStreamAsync();
                response =  await JsonSerializer.DeserializeAsync<T>(responseStream);
            }
            else
            {
                response = await _httpClient.GetFromJsonAsync<T>(uri);
            }

            return response;
        }


        public async Task<IList<EmployeeViewModel>> GetAllEmployeesAsync()
        {
            return await GetDataAsync<IList<EmployeeViewModel>>(false,"Employees/SelectAll");
        }

        public async Task<IList<DepartmentViewModel>> GetAllDepartmentsForSelectionAsync()
        {
            return await GetDataAsync<IList<DepartmentViewModel>>(false,"Departments/DropDownList");
        }

        public async Task<IList<JobViewModel>> GetAllJobsForSelectionAsync()
        {
            return await GetDataAsync<IList<JobViewModel>>(false,"Jobs/DropDownList");
        }

        public async Task<ResponseViewModel> InsertEmployeeAsync(EmployeeViewModel emp)
        {
            var result = await GetDataAsync<ResponseViewModel>(true, "Employees/Insert", emp);
            return result;
        }

        public async Task<ResponseViewModel> UpdateEmployeeAsync(EmployeeViewModel emp)
        {
            return await GetDataAsync<ResponseViewModel>(true,"Employees/Update", emp);
        }

        public async Task<ResponseViewModel> RemoveEmployeeAsync(EmployeeViewModel emp)
        {
            return await GetDataAsync<ResponseViewModel>(true,"Employees/Delete", emp);
        }
    }
}