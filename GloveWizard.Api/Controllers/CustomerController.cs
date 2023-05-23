using GloveWizard.Domain.Controllers;
using GloveWizard.Domain.Helpers;
using GloveWizard.Domain.Interfaces.IService;
using GloveWizard.Domain.Models;
using GloveWizard.Domain.Utils.ResponseViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GloveWizard.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class CustomerController : BaseController
{
    private readonly ICustomersService _customersService;

    public CustomerController(ICustomersService customersService, IErrorLogger errorLogger)
        : base(errorLogger)
    {
        _customersService = customersService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        ApiResponse<IList<Customer>> responseViewModel =
            await _customersService.GetCustomersAsync();

        return Response(responseViewModel);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        ApiResponse<Customer> responseViewModel = await _customersService.GetByCustomerIdAsync(id);

        return Response(responseViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Add(CustomerRequest customer)
    {
        ApiResponse<Customer> responseViewModel = await _customersService.InsertAsync(customer);

        return Response(responseViewModel);
    }

    [HttpPut]
    public async Task<IActionResult> Update(Customer customer)
    {
        ApiResponse<Customer> responseViewModel = await _customersService.UpdateAsync(customer);

        return Response(responseViewModel);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        ApiResponse<Customer> responseViewModel = await _customersService.RemoveAsync(id);

        return Response(responseViewModel);
    }
}
