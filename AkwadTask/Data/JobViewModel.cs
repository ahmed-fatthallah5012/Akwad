namespace AkwadTask.Data
{
    public class JobViewModel
    {
        public decimal JOB_ID { get; set; }
        public decimal DEPARTMENT_ID { get; set; }
        public string JOB_NAME { get; set; }
        public DepartmentViewModel Department { get; set; }
    }
}