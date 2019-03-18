using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmployeeCheckInApp.Models;

namespace EmployeeCheckIn.Controllers
{
    public class HomeController : Controller
    {
        private ERSEntities db = new ERSEntities();
        public List<Employee_Timesheet> Workers()
        {
            var wor = db.Employee_Timesheet.Include(w => w.Employee);
            return wor.ToList();
        }

        public ActionResult Index()
        {
            return View(Workers());
        }

        [HttpPost]
        public ActionResult Index(long? code)
        {
            var min = SqlDateTime.MinValue.Value;
            Employee_Timesheet et = new Employee_Timesheet
            {
                Entrance_Time = min,
                Exit_Time = min
            };
            Employee employee = new Employee();
            employee = db.Employee.SingleOrDefault(x=>x.Code==code);
            if(employee!=null)
            {
                et.Employee_Id = employee.Id;
                et = db.Employee_Timesheet.SingleOrDefault(e => e.Employee_Id == et.Employee_Id);
                if (et.Entrance_Time == min && et.Exit_Time == min)
                {
                    et.Entrance_Time = DateTime.Now;
                }
                else if(et.Entrance_Time != min && et.Exit_Time == min)
                {
                    et.Exit_Time = DateTime.Now;
                }
                else if(et.Entrance_Time != min && et.Exit_Time != min)
                {
                    et.Entrance_Time = DateTime.Now;
                    et.Exit_Time = min;
                }
                et.Automatic_Entrance = true;
                et.Automatic_Exit = true;
                et.Comments = $"Employee code: {code}";
                if (et.Exit_Time < et.Entrance_Time)
                {
                    et.Duration = 0;
                }
                else
                {
                    var hours = (et.Exit_Time - et.Entrance_Time).TotalHours;
                    et.Duration = Convert.ToDecimal(hours);
                }
                et.Emp_Id_Entrance_Commit = 0;
                et.Emp_id_Exit_Commit = 0;
                var test = db.Employee_Timesheet.FirstOrDefault(x=>x.Employee_Id==et.Employee_Id);
                if (test == null)
                {
                    db.Employee_Timesheet.Add(et);
                    db.SaveChanges();
                }
                else
                {
                    var ts = db.Employee_Timesheet.FirstOrDefault(x => x.Employee_Id == et.Employee_Id);

                    ts.Entrance_Time = et.Entrance_Time;
                    ts.Exit_Time = et.Exit_Time;
                    db.SaveChanges();
                }
            }
            else{
                return View("Error");
            }
            return View(Workers());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Employee Check-In by Petros Sarantakos";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Petros Sarantakos";

            return View();
        }
    }
}