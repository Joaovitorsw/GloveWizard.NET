

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

        public async Task<ApiResponse<IList<Custumer>>> GetCustomersAsync()
        {
            IEnumerable<Customers> dataBaseFind = await _unitOfWork.Custumers.GetAllAsync();

            if (dataBaseFind.Count() <= 0) return new ApiResponse<IList<Custumer>>(
                new List<Custumer>(),
                ApiMessagesConstant.NotFoundDataAllMessage,
                HttpStatusCode.NotFound
                );

            return new ApiResponse<IList<Custumer>>(_mapper.Map<IEnumerable<Custumer>>(dataBaseFind).ToList(), HttpStatusCode.OK);
        }
        public async Task<ApiResponse<Custumer>> GetByCustomerIdAsync(int id)
        {
            Customers dataBaseFind = await _unitOfWork.Custumers.GetByIdAsync(id);


            if (dataBaseFind is null) return new ApiResponse<Custumer>(
                ApiMessagesConstant.NotFoundDataMessage,
                HttpStatusCode.NotFound
                );
            

            return new ApiResponse<Custumer>(_mapper.Map<Custumer>(dataBaseFind), HttpStatusCode.OK);
        }

        public async Task<ApiResponse<Custumer>> InsertAsync(CustumerRequest custumer)
        {

            Customers response = await _unitOfWork.Custumers.AddAsync(_mapper.Map<Customers>(custumer));

            return new ApiResponse<Custumer>(
                _mapper.Map<Custumer>(response),
                ApiMessagesConstant.InsertSucessMessage,
                HttpStatusCode.OK
                );

        }
        public async Task<ApiResponse<Custumer>> UpdateAsync(Custumer custumer)
        {
            Customers dataBaseFind = await _unitOfWork.Custumers.GetByIdAsync(custumer.CustomerID);


            if (dataBaseFind is null) return new ApiResponse<Custumer>(
                ApiMessagesConstant.NotFoundDataMessage,
                HttpStatusCode.NotFound
                );


            await _unitOfWork.Custumers.UpdateAsync(_mapper.Map<Customers>(custumer));

            return new ApiResponse<Custumer>(
                custumer,
                ApiMessagesConstant.UpdateSucessMessage,
                HttpStatusCode.OK
                );

        }
        public async Task<ApiResponse<Custumer>> RemoveAsync(int id)
        {
            var dataBaseFind = await _unitOfWork.Custumers.GetByIdAsync(id);


            if (dataBaseFind is null) return new ApiResponse<Custumer>(
                ApiMessagesConstant.NotFoundDataMessage,
                HttpStatusCode.NotFound
                );

            await _unitOfWork.Custumers.RemoveAsync(id);

            return new ApiResponse<Custumer>(ApiMessagesConstant.RemoveSucessMessage, HttpStatusCode.OK);

        }

        public async Task<int> CompletedAsync()
        {
            return await _unitOfWork.CompletedAsync();
        }

    }
}













