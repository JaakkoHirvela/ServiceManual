using Microsoft.EntityFrameworkCore;

namespace EtteplanMORE.ServiceManual.ApplicationCore.Entities
{
    public class ServiceManualDbContext : DbContext
    {
        public ServiceManualDbContext(DbContextOptions<ServiceManualDbContext> options)
            : base(options)
        {
        }

        public DbSet<FactoryDevice> FactoryDevices { get; set; }
        public DbSet<MaintenanceTask> MaintenanceTasks { get; set; }
    }
}
