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
    [Route("api/[controller]")]
    [ApiController]
    public class WardController : BaseController<Ward>
    {
        #region Declare
        IWardService _wardService;
        #endregion

        #region Constructor
        public WardController(IWardService wardService) : base(wardService)
        {
            _wardService = wardService;
        }
        #endregion


        #region Method
        #endregion
    }
}
