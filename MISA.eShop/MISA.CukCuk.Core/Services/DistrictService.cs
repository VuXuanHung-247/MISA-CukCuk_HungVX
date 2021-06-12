using MISA.eShop.Core.Entities;
using MISA.eShop.Core.Interfaces.IRepository;
using MISA.eShop.Core.Interfaces.IService;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.eShop.Core.Services
{
    public class DistrictService : BaseService<District>, IDistrictService
    {
        IDistrictRepository _districtRepository;
        ServiceResult _serviceResult;

        #region Constructor
        public DistrictService(IDistrictRepository districtRepository) : base(districtRepository)
        {
            _districtRepository = districtRepository;
            _serviceResult = new ServiceResult();
        }
        #endregion

        //protected override void CustomerValidate(Customer entity)
        //{


        //}
    }
}
