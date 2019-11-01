using AttendanceManagementSystemCore.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceManagementSystemCore.Infrastructure
{
    public class AttendanceContext : DbContext
    {
        public AttendanceContext() : base("Attendance")
        {
        }
        public DbSet<Student> Students { get; set; }
        
        public DbSet<Grade> Grades { get; set; }

        public DbSet<Division> Divisions { get; set; }

        public DbSet<Medium> Mediums { get; set; }

        public DbSet<AttendanceTable> AttendanceTables { get; set; }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<Teacher> Teachers { get; set; }
    }
}
