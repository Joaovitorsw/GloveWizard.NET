

using GloveWizard.Domain.Interfaces.IService;
using GloveWizard.Domain.Models;
using GloveWizard.Domain.Utils.ResponseViewModel;
using Microsoft.AspNetCore.Mvc;

namespace GloveWizard.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CostumerController : ControllerBase

{

    private readonly ICustomersService _customersService;

    public CostumerController(ICustomersService customersService)
    {
        _customersService = customersService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        ApiResponse<IList<Costumer>> responseViewModel = await _customersService.GetCustomersAsync();
        return StatusCode((int)responseViewModel.StatusCode, responseViewModel);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        ApiResponse<Costumer> responseViewModel = await _customersService.GetByCustomerIdAsync(id);

        return StatusCode((int)responseViewModel.StatusCode, responseViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Add(CostumerRequest costumer)
    {
        ApiResponse<Costumer> responseViewModel = await _customersService.InsertAsync(costumer);

        return StatusCode((int)responseViewModel.StatusCode, responseViewModel);
    }

    [HttpPut]
    public async Task<IActionResult> Update(Costumer costumer)
    {
        ApiResponse<Costumer> responseViewModel = await _customersService.UpdateAsync(costumer);

        return StatusCode((int)responseViewModel.StatusCode, responseViewModel);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        ApiResponse<Costumer> responseViewModel = await _customersService.RemoveAsync(id);

        return StatusCode((int)responseViewModel.StatusCode, responseViewModel);
    }


}
