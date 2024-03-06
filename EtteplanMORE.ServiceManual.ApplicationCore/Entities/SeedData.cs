using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Linq;

namespace EtteplanMORE.ServiceManual.ApplicationCore.Entities
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider, string factoryDevicesSeedFilePath, string maintenanceTasksSeedFilePath)
        {
            using var context = new ServiceManualDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ServiceManualDbContext>>());

            // Look for any factory devices.
            if (!context.FactoryDevices.Any())
            {
                // Read the factory devices from the provided seed file into the db.
                using (StreamReader reader = new StreamReader(factoryDevicesSeedFilePath))
                {
                    // Skip the header line.
                    reader.ReadLine();

                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] values = line.Split(',');


                        var factoryDevice = new FactoryDevice
                        {
                            Name = values[0],
                            Year = int.Parse(values[1]),
                            Type = values[2]
                        };

                        context.FactoryDevices.Add(factoryDevice);
                    }
                }
                context.SaveChanges();
            }

            // Look for any maintenance tasks.
            if (!context.MaintenanceTasks.Any())
            {
                // Read the maintenance tasks from the provided seed file into the db.
                using (StreamReader reader = new StreamReader(maintenanceTasksSeedFilePath))
                {
                    // Skip the header line.
                    reader.ReadLine();

                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] values = line.Split(',');


                        var maintenanceTask = new MaintenanceTask
                        {
                            FactoryDeviceId = int.Parse(values[0]),
                            Severity = (Severity)Enum.Parse(typeof(Severity), values[1]),
                            RegistrationTime = DateTime.Parse(values[2]),
                            Description = values[3],
                            Status = (Status)Enum.Parse(typeof(Status), values[4]),
                        };

                        context.MaintenanceTasks.Add(maintenanceTask);
                    }
                }
                context.SaveChanges();
            }
            return;
        }
    }
}
