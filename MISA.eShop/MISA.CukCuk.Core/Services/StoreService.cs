using MISA.eShop.Core.Entities;
using MISA.eShop.Core.Services;
using MISA.eShop.Core.Entities;
using MISA.eShop.Core.Interfaces.IRepository;
using MISA.eShop.Core.Interfaces.IService;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.eShop.Core.Services
{
    public class StoreService : BaseService<Store>, IStoreService
    {
        IStoreRepository _storeRepository;
        ServiceResult _serviceResult;

        #region Constructor
        public StoreService(IStoreRepository storeRepository) : base(storeRepository)
        {
            _storeRepository = storeRepository;
            _serviceResult = new ServiceResult();
        }
        #endregion
    }
}
