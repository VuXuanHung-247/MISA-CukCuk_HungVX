using MISA.eShop.Core.Entities;
using MISA.eShop.Core.Interfaces.IRepository;
using MISA.eShop.Core.Interfaces.IService;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.eShop.Core.Services
{
    public class WardService : BaseService<Ward>, IWardService
    {
        IWardRepository _wardRepository;
        ServiceResult _serviceResult;

        #region Constructor
        public WardService(IWardRepository wardRepository) : base(wardRepository)
        {
            _wardRepository = wardRepository;
            _serviceResult = new ServiceResult();
        }
        #endregion

        //protected override void CustomerValidate(Customer entity)
        //{


        //}
    }
}
