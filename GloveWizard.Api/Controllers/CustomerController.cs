

using GloveWizard.Domain.Interfaces.IService;
using GloveWizard.Domain.Models;
using GloveWizard.Domain.Utils.ResponseViewModel;
using Microsoft.AspNetCore.Mvc;

namespace GloveWizard.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase

{

    private readonly ICustomersService _customersService;

    public CustomerController(ICustomersService customersService)
    {
        _customersService = customersService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        ApiResponse<IList<Customer>> responseViewModel = await _customersService.GetCustomersAsync();
        return StatusCode((int)responseViewModel.StatusCode, responseViewModel);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        ApiResponse<Customer> responseViewModel = await _customersService.GetByCustomerIdAsync(id);

        return StatusCode((int)responseViewModel.StatusCode, responseViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Add(CustomerRequest customer)
    {
        ApiResponse<Customer> responseViewModel = await _customersService.InsertAsync(customer);

        return StatusCode((int)responseViewModel.StatusCode, responseViewModel);
    }

    [HttpPut]
    public async Task<IActionResult> Update(Customer customer)
    {
        ApiResponse<Customer> responseViewModel = await _customersService.UpdateAsync(customer);

        return StatusCode((int)responseViewModel.StatusCode, responseViewModel);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        ApiResponse<Customer> responseViewModel = await _customersService.RemoveAsync(id);

        return StatusCode((int)responseViewModel.StatusCode, responseViewModel);
    }


}
