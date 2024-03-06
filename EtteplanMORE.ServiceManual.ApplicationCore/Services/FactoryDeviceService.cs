using EtteplanMORE.ServiceManual.ApplicationCore.Entities;
using EtteplanMORE.ServiceManual.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EtteplanMORE.ServiceManual.ApplicationCore.Services
{
    public class FactoryDeviceService : IFactoryDeviceService
    {
        private readonly ServiceManualDbContext _context;

        public FactoryDeviceService(ServiceManualDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FactoryDevice>> GetAll()
        {
            return await _context.FactoryDevices.ToListAsync();
        }

        public async Task<FactoryDevice> Get(int id)
        {
            return await _context.FactoryDevices.FindAsync(id);
        }
    }
}