using DocumentFormat.OpenXml.Wordprocessing;
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Exceptions;
using MISA.CukCuk.Core.Interfaces.IRepository;
using MISA.CukCuk.Core.Interfaces.IService;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.Core.Services
{
    public class CustomerService : BaseEntity, ICustomerService
    {
        ICustomerRepository _customerRepository;
        ServiceResult _serviceResult;

        #region Constructor
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
            _serviceResult = new ServiceResult();
        }
        #endregion

        public IEnumerable<Customer> GetAll()
        {
            var customer = _customerRepository.GetAll();
            return customer;
        }

        public Customer GetById(Guid customerId)
        {
            var customer = _customerRepository.GetById(customerId);
            return customer;
        }

        public int Insert(Customer customer)
        {
            throw new NotImplementedException();
        }

        public int Update(Customer customer, Guid customerId)
        {
            throw new NotImplementedException();
        }
        public int Delete(Guid customerId)
        {
            throw new NotImplementedException();
        }
        
    }
}
