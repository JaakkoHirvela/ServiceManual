using System.Linq;
using EtteplanMORE.ServiceManual.ApplicationCore.Interfaces;
using EtteplanMORE.ServiceManual.ApplicationCore.Services;
using EtteplanMORE.ServiceManual.ApplicationCore.Entities;
using Xunit;

namespace EtteplanMORE.ServiceManual.UnitTests.ApplicationCore.Services.FactoryDeviceServiceTests
{
    /* TODO: Implement tests with some mocking framework for example.
     *
    public class FactoryDeviceGet
    {
        private readonly ServiceManualDbContext _context;
    }
    [Fact]
    public async void AllCars()
    {
        IFactoryDeviceService Mock<IFactoryDeviceService> = new FactoryDeviceService();

        var fds = (await factoryDeviceService.GetAll()).ToList();

        Assert.NotNull(fds);
        Assert.NotEmpty(fds);
        Assert.Equal(3, fds.Count);
    }

    [Fact]
    public async void ExistingCardWithId()
    {
        IFactoryDeviceService FactoryDeviceService = new FactoryDeviceService();
        int fdId = 1;

        var fd = await FactoryDeviceService.Get(fdId);

        Assert.NotNull(fd);
        Assert.Equal(fdId, fd.Id);
    }

    [Fact]
    public async void NonExistingCardWithId()
    {
        IFactoryDeviceService FactoryDeviceService = new FactoryDeviceService();
        int fdId = 4;

        var fd = await FactoryDeviceService.Get(fdId);

        Assert.Null(fd);
    }
}
*/
}