using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KendoUI_Web_App.Controllers
{
    public class EmployeesController : Controller
    {
        readonly Data.NorthwindEntities _context = new Data.NorthwindEntities();
        // GET: Employees
        public ActionResult Index(int? id)
        {
            var employees = _context.Employees
                .Where(emp => id.HasValue ? emp.ReportsTo == id : emp.ReportsTo == null)
                .Select(emp => new

                    {
                        id = emp.EmployeeID,
                        Name = emp.FirstName + " " + emp.LastName,
                        hasChildren = emp.Employees1.Any()
                });
            return this.Json(employees, JsonRequestBehavior.AllowGet);
        }
    }
}