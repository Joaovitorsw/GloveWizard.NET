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

    /// <summary>
    /// Lista os clientes e os contatos vinculados.
    /// </summary>
    /// <response code="200">Retorna todos clientes e os contatos vinculados cadastrados</response>
    /// <response code="401">Não autorizado</response>
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
    {
        ApiResponse<PaginationResponse<IEnumerable<Customer>>> responseViewModel =
            await _customersService.GetCustomersAsync(filter);

        return Response(responseViewModel);
    }

    /// <summary>
    /// Busca um cliente pelo id os contatos vinculados.
    /// </summary>
    /// <response code="200">Um cliente e os contatos vinculados</response>
    /// <response code="401">Não autorizado</response>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        ApiResponse<Customer> responseViewModel = await _customersService.GetByCustomerIdAsync(id);

        return Response(responseViewModel);
    }

    /// <summary>
    /// Cadastra um cliente pelo id os contatos vinculados.
    /// </summary>
    /// <response code="200">Inseree um cliente e os contatos vinculados</response>
    /// <response code="401">Não autorizado</response>
    [HttpPost]
    public async Task<IActionResult> Add(CustomerRequest customer)
    {
        ApiResponse<Customer> responseViewModel = await _customersService.InsertAsync(customer);

        return Response(responseViewModel);
    }

    /// <summary>
    /// Atualiza um cliente pelo id os contatos vinculados.
    /// </summary>
    /// <response code="200">Atualiza o cliente e os contatos vinculados</response>
    /// <response code="401">Não autorizado</response>
    [HttpPut]
    public async Task<IActionResult> Update(Customer customer)
    {
        ApiResponse<Customer> responseViewModel = await _customersService.UpdateAsync(customer);

        return Response(responseViewModel);
    }

    /// <summary>
    /// Remove um cliente pelo id os contatos vinculados.
    /// </summary>
    /// <response code="200">Remove o cliente e os contatos vinculados</response>
    /// <response code="401">Não autorizado</response>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        ApiResponse<Customer> responseViewModel = await _customersService.RemoveAsync(id);

        return Response(responseViewModel);
    }
}
