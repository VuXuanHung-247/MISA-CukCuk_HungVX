using MISA.eShop.Core.Entities;
using MISA.eShop.Core.Interfaces.IRepository;
using MISA.eShop.Core.Interfaces.IService;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.eShop.Core.Services
{
    public class ProvinceService : BaseService<Province>, IProvinceService
    {
        IProvinceRepository _provinceRepository;
        ServiceResult _serviceResult;

        #region Constructor
        public ProvinceService(IProvinceRepository provinceRepository) : base(provinceRepository)
        {
            _provinceRepository = provinceRepository;
            _serviceResult = new ServiceResult();
        }
        #endregion

        //protected override void CustomerValidate(Customer entity)
        //{


        //}
    }
}
