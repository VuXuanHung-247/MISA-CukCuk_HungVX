using MISA.CukCuk.Core.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySqlConnector;
using Dapper;
using System.Linq;
using MISA.CukCuk.Core.Entities;
using System.Reflection;
using MISA.CukCuk.Core.Enums;

namespace MISA.CukCuk.Infrastructure.Repository
{
    public class BaseRepository<MISAEntity> : IBaseRepository<MISAEntity> where MISAEntity : BaseEntity
    {
        #region Declare
        protected string _tableName = string.Empty;
        protected string _connectionString = "" +
                                    "Host = 47.241.69.179;" +
                                    "Port = 3306;" +
                                    "Database = MF_FS_CukCuk;" +
                                    "User Id= nvmanh;" +
                                    "Password = 12345678;";
        protected IDbConnection _dbConnection;
        #endregion
        #region Contructor
        public BaseRepository()
        {
            _tableName = typeof(MISAEntity).Name;
            _dbConnection = new MySqlConnection(_connectionString);
        }
        #endregion

        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns></returns>
        /// CreateBy: VXHUNG (26/05/2021)
        public IEnumerable<MISAEntity> GetEntities()
        {
            var entities = _dbConnection.Query<MISAEntity>($"Proc_Get{_tableName}s", commandType: CommandType.StoredProcedure);
            return entities;
        }

        /// <summary>
        /// lấy dữ liệu thực thể theo Id
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        /// CreateBy: VXHUNG (26/05/2021)
        public MISAEntity GetById(Guid entityId)
        {
            var storeName = $"Proc_Get{_tableName}ById";
            DynamicParameters dynamicParameters = new DynamicParameters();
            var storeGetByIdInputParamName = $"@m_{_tableName}Id";
            dynamicParameters.Add(storeGetByIdInputParamName, entityId.ToString());

            var entity = _dbConnection.Query<MISAEntity>(storeName, param: dynamicParameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return entity;
        }

        /// <summary>
        /// Thêm mới dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// CreateBy: VXHUNG (26/05/2021)
        public int Insert(MISAEntity entity)
        {
            var storeName = $"Proc_Insert{_tableName}";
            // Id mới
            typeof(MISAEntity).GetProperty($"{_tableName}Id").SetValue(entity, Guid.NewGuid());
            var storeParam = MappingDbType(entity);
            var rowAffects = _dbConnection.Execute(storeName, param: storeParam, commandType: CommandType.StoredProcedure);
            return rowAffects;
        }

        /// <summary>
        /// Cập nhật dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="entityId"></param>
        /// <returns></returns>
        /// CreateBy: VXHUNG (26/05/2021)
        public int Update(MISAEntity entity, Guid entityId)
        {
            var storeName = $"Proc_Update{_tableName}";
            var storeParam = MappingDbType(entity);
            var rowAffects = _dbConnection.Execute(storeName, param: storeParam, commandType: CommandType.StoredProcedure);
            return rowAffects;
        }

        /// <summary>
        /// Xóa dữ liệu
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        /// CreateBy: VXHUNG (26/05/2021)
        public int Delete(Guid entityId)
        {
            var storeName = $"Proc_Delete{_tableName}ById"; 
             DynamicParameters dynamicParameters = new DynamicParameters();
            var storeGetByIdInputParamName = $"@m_{_tableName}Id";
            dynamicParameters.Add(storeGetByIdInputParamName, entityId.ToString());

            var result = _dbConnection.Execute(storeName, param: dynamicParameters, commandType: CommandType.StoredProcedure);
            return result;

        }



        // Các hàm hỗ trợ dùng chung
        /// <summary>
        /// Lấy dữ liệu theo trường dữ liệu của thực thể 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        ///  CreateBy: VXHUNG (28/05/2021)
        public MISAEntity GetEntityByProperty(MISAEntity entity, PropertyInfo property)
        {
            var propertyName = property.Name;
            var propertyValue = property.GetValue(entity);
            var keyValue = entity.GetType().GetProperty($"{_tableName}Id").GetValue(entity);
            var query = string.Empty;
            if (entity.EntityState == EntityState.AddNew)
                query = $"SELECT * FROM {_tableName} WHERE {propertyName} = '{propertyValue}'";
            else if (entity.EntityState == EntityState.Update)
                query = $"SELECT * FROM {_tableName} WHERE {propertyName} = '{propertyValue}' AND {_tableName}Id <> '{keyValue}'";
            else
                return null;
            var entityReturn = _dbConnection.Query<MISAEntity>(query, commandType: CommandType.Text).FirstOrDefault();
            return entityReturn;
        }

        /// <summary>
        /// Lấy dữ liệu truyền vào
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// CreateBy: VXHUNG (26/05/2021)
        private DynamicParameters MappingDbType(MISAEntity entity)
        {
            var properties = entity.GetType().GetProperties();
            var parameters = new DynamicParameters();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                var propertyType = property.PropertyType;
                if (propertyType == typeof(Guid) || propertyType == typeof(Guid?))
                {
                    parameters.Add($"@m_{propertyName}", propertyValue, DbType.String);
                }
                else if (propertyType == typeof(bool) || propertyType == typeof(bool?))
                {
                    var dbValue = ((bool)propertyValue == true ? 1 : 0);
                    parameters.Add($"@m_{propertyName}", dbValue, DbType.Int32);
                }
                else
                {
                    parameters.Add($"@m_{propertyName}", propertyValue);
                }

            }
            return parameters;
        }
    }
}
