using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interfaces.IService;
using MISA.CukCuk.Core.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using MISA.CukCuk.Core.Exceptions;

namespace MISA.CukCuk.Core.Services
{
    public class BaseService<MISAEntity> : IBaseService<MISAEntity> where MISAEntity : BaseEntity
    {
        #region Declare
        IBaseRepository<MISAEntity> _baseRepository;
        ServiceResult _serviceResult;
        #endregion

        #region Constructor
        public BaseService(IBaseRepository<MISAEntity> baseRepository)
        {
            _baseRepository = baseRepository;
            _serviceResult = new ServiceResult();
        }
        #endregion

        #region Method
        public IEnumerable<MISAEntity> GetEntities()
        {
            var entities = _baseRepository.GetEntities();
            return entities;
        }

        public MISAEntity GetById(Guid entityId)
        {
            var entity = _baseRepository.GetById(entityId);
            return entity;
        }

        public ServiceResult Insert(MISAEntity entity)
        {
            try
            {
                // Gắn trạng thái - phân biệt validate thêm
                entity.EntityState = Enums.EntityState.AddNew;
                ValidateObject(entity);
                // validate thành công thì trả ra:
                _serviceResult.data = _baseRepository.Insert(entity);
                _serviceResult.Msg = "Thêm mới dữ liệu thành công";
                _serviceResult.MISACode = Enums.MISACode.Success;
                return _serviceResult;
            }
            catch (Exception ex)
            {
                throw new ValidateExceptions(ex.Message);
            }
        }

        public ServiceResult Update(MISAEntity entity, Guid entityId)
        {
            try
            {
                entity.EntityState = Enums.EntityState.Update;
                ValidateObject(entity);
                //Validate(entity);
                _serviceResult.data = _baseRepository.Update(entity, entityId);
                _serviceResult.Msg = "Cập nhật dữ liệu thành công";
                _serviceResult.MISACode = Enums.MISACode.Success;
                return _serviceResult;
            }
            catch (Exception ex)
            {
                throw new ValidateExceptions(ex.Message);

            }
        }
        public ServiceResult Delete(Guid entityId)
        {
            _serviceResult.data = _baseRepository.Delete(entityId);
            return _serviceResult;
        }


        /// <summary>
        /// Hàm xử lý validate, logic chung
        /// </summary>
        /// <param name="entity"></param>
        /// CreatedBy: VXHUNG (26/05/2021)
        private void ValidateObject(MISAEntity entity)
        {
           
            // Lấy ra tất cả các property của class:
            var properties = typeof(MISAEntity).GetProperties();

            foreach (var property in properties)
            {

                var propertyName = property.Name; // Lấy tên thuộc tính

                var propertyValue = property.GetValue(entity); // Lấy giá trị của thuộc tính

                var propertyRequireds = property.GetCustomAttributes(typeof(Required), true); // Lấy các thuộc tính bắt buộc nhập

                var propertyMaxLengths = property.GetCustomAttributes(typeof(MaxLength), true); // Lấy giới hạn độ dài của thuộc tính

                // Check thông tin bắt buộc nhập:
                if (propertyRequireds.Length > 0)
                {
                    if (propertyValue == null)
                    {
                        var userMsg = (propertyRequireds[0] as Required).UserMsg;
                        if(string.IsNullOrEmpty(userMsg))
                        {
                            userMsg = $"Thông tin {propertyName}không được phép để trống";
                        }
                        throw new ValidateExceptions(userMsg);
                    }
                }

                // Check độ dài thuộc tính
                if (propertyMaxLengths.Length > 0)
                {
                    // Lấy ra độ dài tối đa cho phép của chuỗi:
                    var maxLength = (propertyMaxLengths[0] as MaxLength).Length;
                    if (propertyValue != null && propertyValue.ToString().Length > maxLength)
                    {
                        throw new ValidateExceptions((propertyMaxLengths[0] as MaxLength).ErrorMaxLength);
                    }
                }
                // Check trùng dữ liệu ( liên quan đến DB nữa )
                if (property.IsDefined(typeof(IsDuplicate), false))
                {
                    // check trùng dữ liệu:
                    var entityDulicate = _baseRepository.GetEntityByProperty(entity, property);
                    if (entityDulicate != null)
                    {
                        var errorMsg = $"Thông tin {propertyName} đã tồn tại";
                        throw new ValidateExceptions(errorMsg);
                    }
                }
                // ...
            }
            CustomerValidate(entity);

        }
        protected virtual void CustomerValidate(MISAEntity entity)
        {

        }
        #endregion
    }
}
