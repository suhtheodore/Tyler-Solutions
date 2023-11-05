﻿using System.Data;

namespace TylerTech.Models
{
    public class EmployeeRole
    {
        public int EmployeeRoleId { get; set; }
        public int EmployeeId { get; set; }
        public int RoleId { get; set; }
        public Employee Employee { get; set; }
        public Role Role { get; set; }
    }
}
