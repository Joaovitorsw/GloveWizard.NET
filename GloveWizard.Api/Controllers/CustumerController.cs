

using GloveWizard.Domain.Interfaces.IService;
using GloveWizard.Domain.Models;
using GloveWizard.Domain.Service;
using GloveWizard.Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GloveWizard.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CustumerController : ControllerBase

{

    private readonly CustomersService _customersService;

    public CustumerController(CustomersService customersService)
    {
        _customersService = customersService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var responseViewModel = await _customersService.GetCustomers();
        return StatusCode((int)responseViewModel.StatusCode, responseViewModel);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var responseViewModel = await _customersService.GetByCustomerID(id);

        return StatusCode((int)responseViewModel.StatusCode, responseViewModel);
    }
    [HttpPost]
    public async Task<IActionResult> Add(CustumerRequest custumer)
    {
        var responseViewModel = await _customersService.InsertAsync(custumer);

        return StatusCode((int)responseViewModel.StatusCode, responseViewModel);
    }
    [HttpPut]
    public async Task<IActionResult> Update(Custumer custumer)
    {
        var responseViewModel =  _customersService.Update(custumer);

        return StatusCode((int)responseViewModel.StatusCode, responseViewModel);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var responseViewModel = await _customersService.Remove(id);

        return StatusCode((int)responseViewModel.StatusCode, responseViewModel);
    }


}
