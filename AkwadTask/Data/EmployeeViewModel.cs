using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AkwadTask.Data
{
    public class EmployeeViewModel
    {
        [Key]
        [DisplayName("الرقم التعريفي")]
        public decimal EMPLOYEE_DATA_ID { get; set; }
        [Required]
        [DisplayName("اسم الموظف")]
        [RegularExpression("^[\u0621-\u064A0-9 ]+$",ErrorMessage = "لغة الادخال اللغة العربية فقط")]
        public string FIRST_NAME { get; set; }
        [Required]
        [DisplayName("اسم العائلة")]
        [RegularExpression("^[\u0621-\u064A0-9 ]+$",ErrorMessage = "لغة الادخال اللغة العربية فقط")]
        public string LAST_NAME { get; set; }
        [DisplayName("القسم")]
        [UIHint("DepartmentDropDown")]
        public decimal DEPARTMENT_ID { get; set; }
        [DisplayName("الوظيفة")]
        [UIHint("GridForeignKey")]
        public decimal JOB_ID { get; set; }
        [Required]
        [DisplayName("العنوان")]
        [RegularExpression("^[\u0621-\u064A0-9 ]+$",ErrorMessage = "لغة الادخال اللغة العربية فقط")]
        public string EMPLOYEE_ADDRESS { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression("(01)[0-9]{9}",ErrorMessage = "رقم الجوال")]
        [DisplayName("رقم الجوال")]
        public string EMPLOYEE_MOBILE { get; set; }
        [Required]
        [UIHint("Number")]
        [DataType(DataType.Currency)]
        [DisplayName("الراتب")]
        
        [Range(double.Epsilon, double.MaxValue)]
        public decimal SALARY { get; set; }
        [Required]
        [UIHint("Number")]
        [DisplayName("رقم الهوية")]
        [Range(double.Epsilon, double.MaxValue)]
        public decimal IDNUMBER { get; set; }
        [Required]
        [UIHint("Date")]
        [DisplayName("تاريخ التعيين")]
        public DateTime HIREING_DATE { get; set; }
        public DepartmentViewModel Department { get; set; }
        public JobViewModel Job { get; set; }
        [DisplayName("القسم")]
        public string DEPARTMENT_NAME { get; set; }
        [DisplayName("الوظيفة")]
        public string JOB_NAME { get; set; }
    }
}