

using GloveWizard.Domain.Interfaces.IService;
using GloveWizard.Domain.Models;
using GloveWizard.Domain.Service;
using GloveWizard.Domain.Utils.ResponseViewModel;
using GloveWizard.Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GloveWizard.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CustumerController : ControllerBase

{

    private readonly ICustomersService _customersService;

    public CustumerController(ICustomersService customersService)
    {
        _customersService = customersService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        ApiResponse<IList<Custumer>> responseViewModel = await _customersService.GetCustomersAsync();
        return StatusCode((int)responseViewModel.StatusCode, responseViewModel);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        ApiResponse<Custumer> responseViewModel = await _customersService.GetByCustomerIdAsync(id);

        return StatusCode((int)responseViewModel.StatusCode, responseViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Add(CustumerRequest custumer)
    {
        ApiResponse<Custumer> responseViewModel = await _customersService.InsertAsync(custumer);

        return StatusCode((int)responseViewModel.StatusCode, responseViewModel);
    }

    [HttpPut]
    public async Task<IActionResult> Update(Custumer custumer)
    {
        ApiResponse<Custumer> responseViewModel = await _customersService.UpdateAsync(custumer);

        return StatusCode((int)responseViewModel.StatusCode, responseViewModel);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        ApiResponse<Custumer> responseViewModel = await _customersService.RemoveAsync(id);

        return StatusCode((int)responseViewModel.StatusCode, responseViewModel);
    }


}
