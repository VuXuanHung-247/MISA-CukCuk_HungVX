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
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        ICustomerRepository _customerRepository;
        ServiceResult _serviceResult;

        #region Constructor
        public CustomerService(ICustomerRepository customerRepository) : base(customerRepository)
        {
            _customerRepository = customerRepository;
            _serviceResult = new ServiceResult();
        }
        #endregion

        protected override void CustomerValidate(Customer entity)
        {
            if(entity is Customer)
            {
                
            }
           
            //// check mã khách hàng k được để trống 
            //if (string.IsNullOrEmpty(entity.CustomerCode))
            //{
            //    throw new Exception("Mã khách hàng không được để trống");
            //}
            //// check thông tin bắt buộc nhập

            //// check trùng mã

          
        }

    }
}
