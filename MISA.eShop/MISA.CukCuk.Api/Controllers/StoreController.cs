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
    public class StoreController : BaseController<Store>
    {
        #region Declare
        IStoreService _storeService;
        #endregion

        #region Constructor
        public StoreController(IStoreService storeService) : base(storeService)
        {
            _storeService = storeService;
        }
        #endregion


        #region Method
        #endregion
    }
}
