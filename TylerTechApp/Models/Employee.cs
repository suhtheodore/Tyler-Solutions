using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TylerTech.Models
{
    [Table("Employees")]
    public class Employee
    {

        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Role { get; set; }
        [Display(Name = "Manager")]
        public int? ManagerId { get; set; }

    }
}
