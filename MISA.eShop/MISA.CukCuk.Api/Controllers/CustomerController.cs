using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.eShop.Core.Entities;
using MISA.eShop.Core.Interfaces.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.eShop.Api.Controllers
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
