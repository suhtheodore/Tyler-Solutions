using System.ComponentModel.DataAnnotations.Schema;

namespace TylerTech.Models
{
    public class Role
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RoleId { get; set; }
        public string Name { get; set; }
        public List<EmployeeRole> EmployeeRoles { get; set; }
    }
}
