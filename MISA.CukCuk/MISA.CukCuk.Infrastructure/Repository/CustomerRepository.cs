using Dapper;
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interfaces.IRepository;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MISA.CukCuk.Infrastructure.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        protected string _connectionString = "" +
                                     "Host = 47.241.69.179;" +
                                     "Port = 3306;" +
                                     "Database = MF_FS_CukCuk;" +
                                     "User Id= nvmanh;" +
                                     "Password = 12345678;";
        protected IDbConnection _dbConnection;
        #region Constructor
        public CustomerRepository()
        {
            _dbConnection = new MySqlConnection(_connectionString);
        }
        #endregion
        /// <summary>
        /// Lấy tất cả dữ liệu
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Customer> GetAll()
        {
            var customer = _dbConnection.Query<Customer>("Proc_GetCustomers", commandType: CommandType.StoredProcedure);
            return customer;
        }

        public Customer GetById(Guid customerId)
        {
            var storeName = $"Proc_GetCustomerById";
            DynamicParameters dynamicParameters = new DynamicParameters();
            var InputParamName = $"@m_CustomerId";
            dynamicParameters.Add(InputParamName, customerId.ToString());

            var customer = _dbConnection.Query<Customer>(storeName, param: dynamicParameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return customer;
        }
        public int Insert(Customer customer)
        {
            var storeName = $"Proc_InsertCustomer";
            var storeParam = MappingDbType(customer);
            var rowAffects = _dbConnection.Execute(storeName, param: storeParam, commandType: CommandType.StoredProcedure);
            return rowAffects;
        }

        public int Update(Customer customer, Guid customerId)
        {
            throw new NotImplementedException();
        }
        public int Delete(Guid customerId)
        {
            throw new NotImplementedException();
        }



        ///<summary>
        /// hàm lấy dữ liệu chung
        /// </summary>
        private DynamicParameters MappingDbType(Customer customer)
        {
            var properties = customer.GetType().GetProperties();
            var parameters = new DynamicParameters();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(customer);
                var propertyType = property.PropertyType;
                if (propertyType == typeof(Guid) || propertyType == typeof(Guid?))
                {
                    parameters.Add($"@{propertyName}", propertyValue, DbType.String);
                }
                else if (propertyType == typeof(bool) || propertyType == typeof(bool?))
                {
                    var dbValue = ((bool)propertyValue == true ? 1 : 0);
                    parameters.Add($"@{propertyName}", dbValue, DbType.Int32);
                }
                else
                {
                    parameters.Add($"@{propertyName}", propertyValue);
                }

            }
            return parameters;
        }


    }
}
