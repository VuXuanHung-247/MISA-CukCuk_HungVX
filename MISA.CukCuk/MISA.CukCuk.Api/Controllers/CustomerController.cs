using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interfaces.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class CustomerController : BaseController<Customer>
    {
        #region Declare
        ICustomerService _customerService;
        #endregion

        #region Constructor
        public CustomerController(ICustomerService customerService):base(customerService)
        {
            _customerService = customerService;
        }
        #endregion


        #region Method
        #endregion
    }
}
