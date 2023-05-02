

using AutoMapper;
using GloveWizard.Data.Contexts.Interfaces;
using GloveWizard.Domain.Interfaces.IService;
using GloveWizard.Domain.Models;
using GloveWizard.Domain.Utils.ResponseViewModel;
using GloveWizard.Infrastructure.Entities;
using GloveWizard.Infrastructure.Interfaces.IRepository;
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

        public async Task<ResponseViewModel<List<Custumer>>> GetCustomers()
        {
            var dataBaseFind =  _unitOfWork.Custumers.GetAll();

            var response = _mapper.Map<IEnumerable<Custumer>>(dataBaseFind);

            if(response.Count() <= 0)
            {
                return new ResponseViewModel<List<Custumer>>(response.ToList(), "Não foi possivel encontrar registros ",HttpStatusCode.NotFound);
            }

            return new ResponseViewModel<List<Custumer>>(response.ToList(), HttpStatusCode.OK);
        }
        public async Task<ResponseViewModel<Custumer>> GetByCustomerID(int id)
        {
            var dataBaseFind =  _unitOfWork.Custumers.GetById(id);


            if (dataBaseFind is null) return new ResponseViewModel<Custumer>("Este registro não existe", HttpStatusCode.NotFound);

            var response = _mapper.Map<Custumer>(dataBaseFind);

            return new ResponseViewModel<Custumer>(response, HttpStatusCode.OK);
        }

        public async Task<ResponseViewModel<Custumer>> InsertAsync(CustumerRequest custumer)
        {
            var entity = _mapper.Map<Customers>(custumer);

           var response =  await _unitOfWork.Custumers.Add(entity);

            await _unitOfWork.CompletedAsync();

            var mappedResponse = _mapper.Map<Custumer>(response);




            return new ResponseViewModel<Custumer>(mappedResponse, "Você inseriu este registro com sucesso!", HttpStatusCode.OK);

        }
        public  ResponseViewModel<Custumer> Update(Custumer custumer)
        {
            var dataBaseFind =  _unitOfWork.Custumers.GetById(custumer.CustomerID);


            if (dataBaseFind is null) return new ResponseViewModel<Custumer>("Este registro não existe", HttpStatusCode.NotFound);

            var entity = _mapper.Map<Customers>(custumer);

             _unitOfWork.Custumers.Update(entity);

            return new ResponseViewModel<Custumer>(custumer,"Você atualizou este registro com sucesso!", HttpStatusCode.OK);

        }     public async Task<ResponseViewModel<Custumer>> Remove(int id)
        {
            var dataBaseFind =  _unitOfWork.Custumers.GetById(id);


            if (dataBaseFind is null) return new ResponseViewModel<Custumer>("Este registro não existe", HttpStatusCode.NotFound);

             _unitOfWork.Custumers.Remove(id);
            await _unitOfWork.CompletedAsync();

            return new ResponseViewModel<Custumer>("Você excluiu este registro com sucesso!", HttpStatusCode.OK);

        }

        public async Task<int> CompletedAsync()
        {
            return await _unitOfWork.CompletedAsync();
        }

    }
}













