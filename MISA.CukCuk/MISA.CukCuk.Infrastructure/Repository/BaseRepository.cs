using MISA.CukCuk.Core.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySqlConnector;
using Dapper;
using System.Linq;
using MISA.CukCuk.Core.Entities;

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
        /// 
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        /// CreateBy: VXHUNG (26/05/2021)
        public MISAEntity GetById(Guid entityId)
        {
            var storeName = $"Proc_Get{_tableName}ById";
            DynamicParameters dynamicParameters = new DynamicParameters();
            var storeGetByIdInputParamName = $"@{_tableName}Id";
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
            var storeGetByIdInputParamName = $"@{_tableName}Id";
            dynamicParameters.Add(storeGetByIdInputParamName, entityId.ToString());

            var result = _dbConnection.Execute(storeName, param: dynamicParameters, commandType: CommandType.StoredProcedure);
            return result;

            //var result = _dbConnection.Execute($"DELETE FROM {_tableName} WHERE {_tableName}Id = '{entityId}'", commandType: CommandType.Text);
            //return result;
        }



        // Các hàm hỗ trợ dùng chung

        /// <summary>
        /// Lấy dữ liệu truyền vào
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
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
