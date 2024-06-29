using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UNIT_OF_WORK.Contract;
using UNIT_OF_WORK.Data;
using UNIT_OF_WORK.DTO;
using UNIT_OF_WORK.Models;

namespace UNIT_OF_WORK.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DriversController : ControllerBase
{
    //private static List<Driver> _drivers = new List<Driver>()
    //{
    //    new Driver()
    //    {
    //        DriverId=1,
    //        Name="Lewis Hamilton",
    //        Team= "Merceded AMG FI",
    //        DriverNumber =44
    //    },
    //     new Driver()
    //    {
    //        DriverId=2,
    //        Name="Izuchukwu Hamilton",
    //        Team= "Danfo AMG FI",
    //        DriverNumber =45
    //    }
    //};
    private readonly IUnitOfWork _unitOfWork;
    public DriversController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {

        return Ok(_unitOfWork.Drivers.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var driver = await _unitOfWork.Drivers.GetByIdAsync(id);
        if (driver == null)
        {
            return NotFound();
        }
        return Ok(driver);
    }

    [HttpPost("post")]
    public async Task<IActionResult> AddDriver([FromBody] Driver driver)
    {
       await _unitOfWork.Drivers.Add(driver);
       await _unitOfWork.CompleteAsync();
        return Ok("saved");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
       var driver = await _unitOfWork.Drivers.GetByIdAsync(id);
        if (driver == null)
        {
            return NotFound();
        }
       await _unitOfWork.Drivers.Delete(driver);
        await _unitOfWork.CompleteAsync();
        return Ok();
    }

    [HttpPatch("update-driver")]
    public async Task<IActionResult> UpdateDriver(DriverDTO driver)
    {
        var existingDriver = await _unitOfWork.Drivers.GetByIdAsync(driver.DriverId);
        if (existingDriver == null)
        {
            return NotFound();
        }
       
        await _unitOfWork.Drivers.Update(existingDriver);
        await _unitOfWork.CompleteAsync();
       
        return NoContent();
    }

}
