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
    public class CountryController : BaseController<Country>
    {
        #region Declare
        ICountryService _countryService;
        #endregion

        #region Constructor
        public CountryController(ICountryService countryService) : base(countryService)
        {
            _countryService = countryService;
        }
        #endregion


        #region Method
        #endregion
    }
}
