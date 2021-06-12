using Dapper;
using MISA.eShop.Core.Entities;
using MISA.eShop.Core.Interfaces.IRepository;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MISA.eShop.Infrastructure.Repository
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {

    }
}
