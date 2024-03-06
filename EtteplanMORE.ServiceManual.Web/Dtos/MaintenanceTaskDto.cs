namespace EtteplanMORE.ServiceManual.ApplicationCore.Entities
{
    public class MaintenanceTaskDto
    {
        public int Id { get; set; }
        // Related factory device.
        public FactoryDevice? FactoryDevice { get; set; }
        public Severity Severity { get; set; }
        public DateTime RegistrationTime { get; set; }
        public string? Description { get; set; }
        public Status Status { get; set; }

    }
}
