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
            throw new NotImplementedException();
        }


        private void ValidateObject(MISAEntity entity)
        {
            // Validate với các trường thông tin bắt buộc nhập:

            // Lấy ra tất cả các property của class:
            var properties = typeof(MISAEntity).GetProperties();

            foreach (var property in properties)
            {

                // Lấy tên thuộc tính
                var propertyName = property.Name;

                // Lấy ra giá trị của thuộc tính
                var propertyValue = property.GetValue(entity);

                // Thuộc tính bắt buộc nhập
                var propertyRequireds = property.GetCustomAttributes(typeof(Required), true);

                // Độ dài giới hạn của thuộc tính
                var propertyMaxLengths = property.GetCustomAttributes(typeof(MaxLength), true);

                // Xác định xem property nào không được phếp để trống, bắt buộc nhập (MISAREquired)
                if (propertyRequireds.Length > 0)
                {
                    if (propertyValue == null)
                    {
                        throw new ValidateExceptions($"Không tìm thấy giá trị của trường [{propertyName}]");
                    }

                    // Lấy ra câu thông báo tùy chọn: về dữ liệu không được để trống
                    var userMsg = (propertyRequireds[0] as Required).UserMsg;

                    if (string.IsNullOrEmpty(userMsg))
                    {
                        userMsg = $"[{propertyName}]";
                        if (string.IsNullOrEmpty(propertyValue.ToString()))
                        {
                            var errorMsg = $"Thông tin {userMsg} không được phép để trống";
                            throw new ValidateExceptions(errorMsg);
                        }
                    }

                    if (string.IsNullOrEmpty(propertyValue.ToString()))
                    {
                        var errorMsg = $"{userMsg}";
                        throw new ValidateExceptions(errorMsg);
                    }
                }

                // Msg về giới hạn độ dài của thuộc tính
                if (propertyMaxLengths.Length > 0)
                {
                    // Lấy ra độ dài tối đa cho phép của chuỗi:
                    var maxLength = (propertyMaxLengths[0] as MaxLength).Length;
                    if (propertyValue != null && propertyValue.ToString().Length > maxLength)
                    {
                        throw new ValidateExceptions((propertyMaxLengths[0] as MaxLength).ErrorMaxLength);
                    }
                }
                // Check trùng dữ liệu
                // ...
            }

        }
        #endregion
    }
}
