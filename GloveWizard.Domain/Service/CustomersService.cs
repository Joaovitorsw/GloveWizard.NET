

using AutoMapper;
using GloveWizard.Data.Contexts.Interfaces;
using GloveWizard.Domain.Constants;
using GloveWizard.Domain.Interfaces.IService;
using GloveWizard.Domain.Models;
using GloveWizard.Domain.Utils.ResponseViewModel;
using GloveWizard.Infrastructure.Entities;
using GloveWizard.Infrastructure.Interfaces;
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

        public async Task<ApiResponse<IList<Costumer>>> GetCustomersAsync()
        {
            IEnumerable<Customers> dataBaseFind = await _unitOfWork.Customers.GetAllAsync();

            if (dataBaseFind.Count() <= 0) return new ApiResponse<IList<Costumer>>(
                new List<Costumer>(),
                ApiMessagesConstant.NotFoundDataAllMessage,
                HttpStatusCode.NotFound
                );

            return new ApiResponse<IList<Costumer>>(_mapper.Map<IEnumerable<Costumer>>(dataBaseFind).ToList(), HttpStatusCode.OK);
        }
        public async Task<ApiResponse<Costumer>> GetByCustomerIdAsync(int id)
        {
            Customers dataBaseFind = await _unitOfWork.Customers.GetByIdAsync(id);


            if (dataBaseFind is null) return new ApiResponse<Costumer>(
                ApiMessagesConstant.NotFoundDataMessage,
                HttpStatusCode.NotFound
                );


            return new ApiResponse<Costumer>(_mapper.Map<Costumer>(dataBaseFind), HttpStatusCode.OK);
        }

        public async Task<ApiResponse<Costumer>> InsertAsync(CostumerRequest costumer)
        {

            Customers response = await _unitOfWork.Customers.AddAsync(_mapper.Map<Customers>(costumer));

            return new ApiResponse<Costumer>(
                _mapper.Map<Costumer>(response),
                ApiMessagesConstant.InsertSuccessMessage,
                HttpStatusCode.OK
                );

        }
        public async Task<ApiResponse<Costumer>> UpdateAsync(Costumer customer)
        {
            Customers dataBaseFind = await _unitOfWork.Customers.GetByIdAsync(customer.CustomerID);


            if (dataBaseFind is null) return new ApiResponse<Costumer>(
                ApiMessagesConstant.NotFoundDataMessage,
                HttpStatusCode.NotFound
                );


            await _unitOfWork.Customers.UpdateAsync(_mapper.Map<Customers>(customer));

            return new ApiResponse<Costumer>(
                customer,
                ApiMessagesConstant.UpdateSuccessMessage,
                HttpStatusCode.OK
                );

        }
        public async Task<ApiResponse<Costumer>> RemoveAsync(int id)
        {
            var dataBaseFind = await _unitOfWork.Customers.GetByIdAsync(id);


            if (dataBaseFind is null) return new ApiResponse<Costumer>(
                ApiMessagesConstant.NotFoundDataMessage,
                HttpStatusCode.NotFound
                );

            await _unitOfWork.Customers.RemoveAsync(id);

            return new ApiResponse<Costumer>(ApiMessagesConstant.RemoveSuccessMessage, HttpStatusCode.OK);

        }

        public async Task<int> CompletedAsync()
        {
            return await _unitOfWork.CompletedAsync();
        }

    }
}













