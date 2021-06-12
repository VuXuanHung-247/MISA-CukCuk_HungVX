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
    public class DistrictController : BaseController<District>
    {
        #region Declare
        IDistrictService _districtService;
        #endregion

        #region Constructor
        public DistrictController(IDistrictService districtService) : base(districtService)
        {
            _districtService = districtService;
        }
        #endregion


        #region Method
        #endregion
    }
}
