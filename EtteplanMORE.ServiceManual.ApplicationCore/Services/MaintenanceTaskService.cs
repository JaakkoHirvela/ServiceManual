using EtteplanMORE.ServiceManual.ApplicationCore.Entities;
using EtteplanMORE.ServiceManual.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EtteplanMORE.ServiceManual.ApplicationCore.Services
{
    /// <summary>
    /// A service for fetching maintenance tasks from the database.
    /// The maintenance tasks are presented firstly by their severity and secondly based on
    /// their registration time, per the requirements.
    /// </summary>
    public class MaintenanceTaskService : IMaintenanceTaskService
    {
        private readonly ServiceManualDbContext _context;

        public MaintenanceTaskService(ServiceManualDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MaintenanceTask>> GetAll()
        {
            return await _context.MaintenanceTasks
                .Include(mt => mt.FactoryDevice)
                .OrderBy(mt => mt.Severity)
                .ThenBy(mt => mt.RegistrationTime)
                .ToListAsync();
        }

        public async Task<MaintenanceTask> Get(int id)
        {
            return await _context.MaintenanceTasks
                .Include(mt => mt.FactoryDevice)
                .FirstOrDefaultAsync(mt => mt.Id == id);
        }

        public async Task<IEnumerable<MaintenanceTask>> GetByDevice(int deviceId)
        {
            return await _context.MaintenanceTasks
                .Where(mt => mt.FactoryDeviceId == deviceId)
                .OrderBy(mt => mt.Severity)
                .ThenBy(mt => mt.RegistrationTime)
                .ToListAsync();
        }

        public async Task Create(MaintenanceTask maintenanceTask)
        {
            _context.MaintenanceTasks.Add(maintenanceTask);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Update(MaintenanceTask maintenanceTask)
        {
            var foundTask = await _context.MaintenanceTasks.AnyAsync(mt => mt.Id == maintenanceTask.Id);

            if (!foundTask)
                return false;

            _context.MaintenanceTasks.Update(maintenanceTask);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task Delete(int id)
        {
            MaintenanceTask maintenanceTask = await _context.MaintenanceTasks.FindAsync(id);
            _context.MaintenanceTasks.Remove(maintenanceTask);
            await _context.SaveChangesAsync();
        }
    }
}
