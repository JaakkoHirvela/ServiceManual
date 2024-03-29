﻿using Microsoft.AspNetCore.Mvc;
using EtteplanMORE.ServiceManual.ApplicationCore.Interfaces;
using EtteplanMORE.ServiceManual.ApplicationCore.Entities;

namespace EtteplanMORE.ServiceManual.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaintenanceTasksController : Controller
    {
        private readonly IMaintenanceTaskService _maintenanceTaskService;

        public MaintenanceTasksController(IMaintenanceTaskService maintenanceTaskService)
        {
            _maintenanceTaskService = maintenanceTaskService;
        }

        /// <summary>
        ///    HTTP GET: api/maintenancetasks/
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<MaintenanceTaskDto>> GetAll()
        {
            return (await _maintenanceTaskService.GetAll())
                .Select(mt =>
                    new MaintenanceTaskDto
                    {
                        Id = mt.Id,
                        FactoryDevice = mt.FactoryDevice,
                        Severity = mt.Severity,
                        Description = mt.Description,
                        RegistrationTime = mt.RegistrationTime,
                        Status = mt.Status
                    }
             );
        }

        /// <summary>
        ///    HTTP GET: api/maintenancetasks/id
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MaintenanceTaskDto>> Get(int id)
        {
            var task = await _maintenanceTaskService.Get(id);

            if (task == null)
                return NotFound();

            return new MaintenanceTaskDto
            {
                Id = task.Id,
                FactoryDevice = task.FactoryDevice,
                Severity = task.Severity,
                Description = task.Description,
                RegistrationTime = task.RegistrationTime,
                Status = task.Status
            };

        }

        /// <summary>
        ///     HTTP POST: api/maintenancetasks/
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MaintenanceTaskDto>> Create(MaintenanceTask newMaintenanceTask)
        {
            var maintenanceTask = new MaintenanceTask
            {
                FactoryDeviceId = newMaintenanceTask.FactoryDeviceId,
                Severity = newMaintenanceTask.Severity,
                Description = newMaintenanceTask.Description,
                RegistrationTime = newMaintenanceTask.RegistrationTime,
                Status = newMaintenanceTask.Status
            };

            await _maintenanceTaskService.Create(maintenanceTask);

            return CreatedAtAction(nameof(Get), new { id = maintenanceTask.Id }, maintenanceTask);
        }

        /// <summary>
        ///     HTTP GET: api/maintenancetasks/bydevice/factoryDeviceId
        /// </summary>
        [HttpGet("bydevice/{factoryDeviceId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<MaintenanceTaskDto>> GetByDevice(int factoryDeviceId)
        {
            return (await _maintenanceTaskService.GetByDevice(factoryDeviceId))
                .Select(mt =>
                    new MaintenanceTaskDto
                    {
                        Id = mt.Id,
                        Severity = mt.Severity,
                        Description = mt.Description,
                        RegistrationTime = mt.RegistrationTime,
                        Status = mt.Status
                    }
                );
        }

        /// <summary>
        ///     HTTP PUT: api/maintenancetasks/id
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, MaintenanceTask updatedMaintenanceTask)
        {
            // Check that the id in the URL matches the id in the body.
            if (id != updatedMaintenanceTask.Id)
            {
                return BadRequest("ID in the URL is different from the ID in the body.");
            }

            var existingTask = await _maintenanceTaskService.Get(id);

            if (existingTask == null)
                return NotFound("The task didn't exist in the database. Use a POST request instead to create new tasks.");

            // Update the existing task's values.
            existingTask.FactoryDeviceId = updatedMaintenanceTask.FactoryDeviceId;
            existingTask.Severity = updatedMaintenanceTask.Severity;
            existingTask.Description = updatedMaintenanceTask.Description;
            existingTask.RegistrationTime = updatedMaintenanceTask.RegistrationTime;
            existingTask.Status = updatedMaintenanceTask.Status;

            await _maintenanceTaskService.Update(existingTask);

            return NoContent();
        }

        /// <summary>
        ///     HTTP DELETE: api/maintenancetasks/id
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            // Check if the task exists.
            var task = await _maintenanceTaskService.Get(id);
            if (task == null)
                return NotFound("The task didn't exist in the database.");

            await _maintenanceTaskService.Delete(id);
            return NoContent();
        }
    }
}
