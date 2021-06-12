using MISA.eShop.Core.Interfaces.IRepository;
using MISA.eShop.Infrastructure.Repository;
using MISA.eShop.Core.Entities;
using MISA.eShop.Core.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.eShop.Infrastructure.Repository
{
    public class StoreRepository : BaseRepository<Store>, IStoreRepository
    {
    }
}
