using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TylerTech.Models;
using TylerTechApp.Data;

namespace TylerTechApp.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly TylerTechAppContext _context;


        public IndexModel(TylerTechAppContext context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get; set; } = default!;
        //public Dictionary<int, string> ManagerNames { get; set; } = new Dictionary<int, string>();

        public SelectList? Managers { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? ManagerName { get; set; }

        public async Task OnGetAsync()
        {
            if (!string.IsNullOrEmpty(ManagerName))
            {
                // Find the selected manager by their FirstName
                var selectedManager = await _context.Employee
                    .Where(m => m.Role == "Director" && (m.FirstName + " " + m.LastName) == ManagerName)
                    .FirstOrDefaultAsync();

                if (selectedManager != null)
                {
                    // Retrieve employees whose ManagerId matches the selected manager's EmployeeId
                    Employee = await _context.Employee
                        .Where(e => e.ManagerId == selectedManager.Id)
                        .ToListAsync();
                }
            }
            else
            {
                Employee = await _context.Employee.ToListAsync();
            }
            //Manager list for dropdown
            Managers = new SelectList(await _context.Employee
                .Where(m => m.Role == "Director")
                .OrderBy(m => m.FirstName)
                .ThenBy(m => m.LastName)
                .Select(m => $"{m.FirstName} {m.LastName}")
                .Distinct()
                .ToListAsync());

            //if (_context.Employee != null)
            //{
            //    Employee = await _context.Employee.ToListAsync();
            //    //ManagerNames = Employee.ToDictionary(e => e.Id, e => $"{e.FirstName} {e.LastName}");

            //}
        }
    }
}
