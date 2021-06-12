using MISA.eShop.Core.Entities;
using MISA.eShop.Core.Interfaces.IRepository;
using MISA.eShop.Core.Interfaces.IService;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.eShop.Core.Services
{
    public class CountryService : BaseService<Country>, ICountryService
    {
        ICountryRepository _countryRepository;
        ServiceResult _serviceResult;

        #region Constructor
        public CountryService(ICountryRepository countryRepository) : base(countryRepository)
        {
            _countryRepository = countryRepository;
            _serviceResult = new ServiceResult();
        }
        #endregion

        //protected override void CustomerValidate(Customer entity)
        //{
           

        //}
    }
}
