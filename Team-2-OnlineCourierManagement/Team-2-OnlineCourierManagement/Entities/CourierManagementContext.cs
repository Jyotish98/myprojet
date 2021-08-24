using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Team_2_OnlineCourierManagement.Entities
{
    public class CourierManagementContext : DbContext
    {
        public CourierManagementContext(DbContextOptions<CourierManagementContext>options):base(options)
        {
        }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Consignee> Consignees { get; set; }
        public virtual DbSet<Consigner> Consigners { get; set; }
        public virtual DbSet<Consignment> Consignments { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<DeliveryExecutive> DeliveryExecutives { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           //optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-MCSHB6J;Initial Catalog=Team2Sprint1;Integrated Security=True;");
        }
    }
}
