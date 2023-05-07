

using AutoMapper;
using GloveWizard.Data.Contexts.Interfaces;
using GloveWizard.Domain.Constants;
using GloveWizard.Domain.Interfaces.IService;
using GloveWizard.Domain.Models;
using GloveWizard.Domain.Utils.ResponseViewModel;
using GloveWizard.Infrastructure.Entities;
using System.Net;

namespace GloveWizard.Domain.Service
{
    public class CustomersService : ICustomersService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CustomersService(
            IUnitOfWork unitOfWork,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IList<Customer>>> GetCustomersAsync()
        {
            IEnumerable<Customers> dataBaseFind = await _unitOfWork.Customers.GetAllAsync();

            if (dataBaseFind.Count() <= 0) return new ApiResponse<IList<Customer>>(
                new List<Customer>(),
                ApiMessagesConstant.NotFoundDataAllMessage,
                HttpStatusCode.NotFound
                );

            return new ApiResponse<IList<Customer>>(_mapper.Map<IEnumerable<Customer>>(dataBaseFind).ToList(), HttpStatusCode.OK);
        }
        public async Task<ApiResponse<Customer>> GetByCustomerIdAsync(int id)
        {
            Customers dataBaseFind = await _unitOfWork.Customers.GetByIdAsync(id);


            if (dataBaseFind is null) return new ApiResponse<Customer>(
                ApiMessagesConstant.NotFoundDataMessage,
                HttpStatusCode.NotFound
                );


            return new ApiResponse<Customer>(_mapper.Map<Customer>(dataBaseFind), HttpStatusCode.OK);
        }

        public async Task<ApiResponse<Customer>> InsertAsync(CustomerRequest customer)
        {

            Customers response = await _unitOfWork.Customers.AddAsync(_mapper.Map<Customers>(customer));

            return new ApiResponse<Customer>(
                _mapper.Map<Customer>(response),
                ApiMessagesConstant.InsertSuccessMessage,
                HttpStatusCode.OK
                );

        }
        public async Task<ApiResponse<Customer>> UpdateAsync(Customer customer)
        {
            Customers dataBaseFind = await _unitOfWork.Customers.GetByIdAsync(customer.CustomerID);


            if (dataBaseFind is null) return new ApiResponse<Customer>(
                ApiMessagesConstant.NotFoundDataMessage,
                HttpStatusCode.NotFound
                );


            await _unitOfWork.Customers.UpdateAsync(_mapper.Map<Customers>(customer));

            return new ApiResponse<Customer>(
                customer,
                ApiMessagesConstant.UpdateSuccessMessage,
                HttpStatusCode.OK
                );

        }
        public async Task<ApiResponse<Customer>> RemoveAsync(int id)
        {
            var dataBaseFind = await _unitOfWork.Customers.GetByIdAsync(id);


            if (dataBaseFind is null) return new ApiResponse<Customer>(
                ApiMessagesConstant.NotFoundDataMessage,
                HttpStatusCode.NotFound
                );

            await _unitOfWork.Customers.RemoveAsync(id);

            return new ApiResponse<Customer>(ApiMessagesConstant.RemoveSuccessMessage, HttpStatusCode.OK);

        }

        public async Task<int> CompletedAsync()
        {
            return await _unitOfWork.CompletedAsync();
        }

    }
}













