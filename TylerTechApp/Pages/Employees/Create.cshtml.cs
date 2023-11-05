using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TylerTech.Models;
using TylerTechApp.Data;

namespace TylerTechApp.Pages.Employees
{
    public class CreateModel : PageModel
    {
        private readonly TylerTechAppContext _context;

        public CreateModel(TylerTechAppContext context)
        {
            _context = context;
        }

        public List<SelectListItem> ManagerList { get; set; }
        [BindProperty]
        public int? SelectedManagerName { get; set; }

        public IActionResult OnGet()
        {
            //Get list of managers for dropdown
            ManagerList = _context.Employee
        .Where(e => e.Role == "Director")
        .Select(e => new SelectListItem { Value = e.Id.ToString(), Text = $"{e.FirstName} {e.LastName}" })
        .ToList();


            return Page();
        }

        [BindProperty]
        public Employee Employee { get; set; } = default!;
        [BindProperty]
        public int? EmployeeId { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Employee == null || Employee == null)
            {
                return Page();
            }

            if (_context.Employee.Any(e => e.Id == Employee.Id))
            {
                ModelState.AddModelError("Employee.Id", "Employee ID already exists.");
                return Page();
            }

            //Find employee by Name of selected Manager
            //var selectedManager = _context.Employee
            //    .FirstOrDefault(e => e.Role == "Director" && (e.FirstName + " " + e.LastName) == SelectedManagerName);

            //if (selectedManager != null)
            //{
            //    Employee.ManagerId = selectedManager.Id;
            //}
            //Employee.Id = EmployeeId.Value;
            Employee.ManagerId = SelectedManagerName;

            _context.Employee.Add(Employee);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
