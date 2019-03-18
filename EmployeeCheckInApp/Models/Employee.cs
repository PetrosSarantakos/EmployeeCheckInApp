
namespace EmployeeCheckInApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            this.Employee_Timesheet = new HashSet<Employee_Timesheet>();
        }
    
        public long Id { get; set; }
        public string Name { get; set; }
        public Nullable<long> Code { get; set; }
        public string Phone { get; set; }
        [DisplayName("Job Position")]
        public string Job_position { get; set; }
        [DisplayName("Company Id")]
        public long Company_id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        [DisplayName("Working Hours Per Day")]
        public int Working_Hours_Per_Day { get; set; }
        public bool Active { get; set; }
        public int Status { get; set; }
        public string Comments { get; set; }
        [DisplayName("Supervised By")]
        public long Supervised_By { get; set; }
        [DisplayName("User Type")]
        public int User_Type { get; set; }
    
        public virtual Companies Companies { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee_Timesheet> Employee_Timesheet { get; set; }
    }
}
