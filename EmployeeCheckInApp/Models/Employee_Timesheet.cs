
namespace EmployeeCheckInApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    
    public partial class Employee_Timesheet
    {
        public long id { get; set; }
        [DisplayName("Entrance Time")]
        public System.DateTime Entrance_Time { get; set; }
        [DisplayName("Exit Time")]
        public System.DateTime Exit_Time { get; set; }
        public decimal Duration { get; set; }
        public bool Automatic_Entrance { get; set; }
        public bool Automatic_Exit { get; set; }
        public string Comments { get; set; }
        public long Emp_Id_Entrance_Commit { get; set; }
        public long Emp_id_Exit_Commit { get; set; }
        [DisplayName("Employee Id")]
        public Nullable<long> Employee_Id { get; set; }
    
        public virtual Employee Employee { get; set; }
    }
}
