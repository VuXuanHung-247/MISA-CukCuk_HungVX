using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interfaces.IService;
using MISA.CukCuk.Core.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using MISA.CukCuk.Core.Exceptions;
using MISA.CukCuk.Core.Enums;

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
                var isValid = ValidateObject(entity);
                // validate thành công thì trả ra:
                if (isValid == true)
                {
                    var rowEffects = _baseRepository.Insert(entity);
                    if (rowEffects == 0)
                    {
                        _serviceResult = new ServiceResult() { data = rowEffects, Msg = { "Thêm mới dữ liệu thất bại !!" }, MISACode = MISACode.BadRequest };
                    }
                    else
                    {
                        _serviceResult = new ServiceResult() { data = rowEffects, Msg = { "Thêm mới dữ liệu thành công !!" }, MISACode = MISACode.Success };
                    }
                    return _serviceResult;
                }
                // nếu validate có lỗi xẩy ra
                else
                {
                    return _serviceResult;
                }
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
                var isValid = ValidateObject(entity);
                // validate thành công thì trả ra:
                if (isValid == true)
                {
                    var rowEffects = _baseRepository.Update(entity, entityId);
                    if (rowEffects == 0)
                    {
                        _serviceResult = new ServiceResult() { data = rowEffects, Msg = { "Cập nhật dữ liệu thất bại !!" }, MISACode = MISACode.BadRequest };
                    }
                    else
                    {
                        _serviceResult = new ServiceResult() { data = rowEffects, Msg = { "Cập nhật dữ liệu thành công !!" }, MISACode = MISACode.Success };
                    }
                    return _serviceResult;
                }
                // nếu validate có lỗi xẩy ra
                else
                {
                    return _serviceResult;
                }
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
        private bool ValidateObject(MISAEntity entity)
        {

            // Lấy ra tất cả các property của class:
            var properties = typeof(MISAEntity).GetProperties();

            foreach (var property in properties)
            {

                var propertyName = property.Name; // Lấy tên thuộc tính
                var propertyValue = property.GetValue(entity); // Lấy giá trị của thuộc tính
                var propertyType = property.GetType(); // Lấy kiểu dữ liệu của thuộc tính

                var propertyRequireds = property.GetCustomAttributes(typeof(Required), true); // Lấy các thuộc tính bắt buộc nhập
                var propertyMaxLengths = property.GetCustomAttributes(typeof(MaxLength), true); // Lấy độ dài cho chép của thuộc tính
                var propertyRangeDateTime = property.GetCustomAttributes(typeof(RangeDateTime), true); // Lấy phạm vi cho phép của thuộc tính Ngày tháng
                var propertyIsDebitAmount = property.GetCustomAttributes(typeof(IsDebitAmount), true); // Lấy giới hạn nhỏ nhất của tiền trong tài khoản
                var propertyRegularDataType = property.GetCustomAttributes(typeof(RegularDataType), true); // Lấy chuẩn định dạng kiểu dữ liệu
                var propertyIsValidEmail = property.GetCustomAttributes(typeof(IsValidEmail), true); // Lấy chuẩn định dạng email

                // Check thông tin bắt buộc nhập:
                if (propertyRequireds.Length > 0)
                {
                    if (propertyValue == null)
                    {
                        var userMsg = (propertyRequireds[0] as Required).UserMsg;
                        if (string.IsNullOrEmpty(userMsg))
                        {
                            userMsg = $"Thông tin {propertyName} không được phép để trống";
                        }
                        _serviceResult.IsValid = false;
                        _serviceResult.Msg.Add(String.Format(userMsg));
                        _serviceResult.MISACode = MISACode.BadRequest;
                        return false;
                    }
                }

                // Check độ dài cho phép của thuộc tính
                if (propertyMaxLengths.Length > 0)
                {
                    // Lấy ra độ dài tối đa cho phép của chuỗi:
                    var maxLength = (propertyMaxLengths[0] as MaxLength).Length;
                    if (propertyValue != null && propertyValue.ToString().Length > maxLength)
                    {
                        var userMsg = (propertyMaxLengths[0] as MaxLength).UserMsg;
                        _serviceResult.IsValid = false;
                        _serviceResult.Msg.Add(String.Format(userMsg));
                        _serviceResult.MISACode = MISACode.BadRequest;
                        return false;
                    }
                }

                // Check trùng dữ liệu ( liên quan đến DB nữa )
                if (property.IsDefined(typeof(IsDuplicate), false))
                {
                    // kiểm tra xem có tồn tại dữ liệu trong DB chưa, nếu có thì thực hiện MsgError
                    var entityDulicate = _baseRepository.GetEntityByProperty(entity, property);
                    if (entityDulicate != null)
                    {
                        var errorMsg = $"Thông tin {propertyName} đã tồn tại";
                        _serviceResult.IsValid = false;
                        _serviceResult.Msg.Add(String.Format(errorMsg));
                        _serviceResult.MISACode = MISACode.BadRequest;
                        return false;
                    }
                }

                // Check phạm vi cho phép của thuộc tính Ngày tháng
                if (propertyRangeDateTime.Length > 0)
                {
                    var minDate = (propertyRangeDateTime[0] as RangeDateTime).MinDate;
                    var maxDate = (propertyRangeDateTime[0] as RangeDateTime).MaxDate;
                    var userMsg = (propertyRangeDateTime[0] as RangeDateTime).UserMsg;

                    int result_1 = DateTime.Compare(Convert.ToDateTime(propertyValue), minDate);
                    int result_2 = DateTime.Compare(Convert.ToDateTime(propertyValue), maxDate);
                    if ((result_1 <= 0 || result_2 >= 0))
                    {
                        if (string.IsNullOrEmpty(userMsg))
                        {
                            userMsg = $"Thông tin {propertyName} phải nắm trong phạm vi từ {minDate} đến {maxDate}";
                        }
                        _serviceResult.IsValid = false;
                        _serviceResult.Msg.Add(String.Format(userMsg));
                        _serviceResult.MISACode = MISACode.BadRequest;
                        return false;
                    }
                }

                // Check số tiền không được nhỏ hơn 1 value nào đó
                if (propertyIsDebitAmount.Length > 0)
                {
                    var debitAmount = (propertyIsDebitAmount[0] as IsDebitAmount).DebitAmount;
                    if (propertyValue != null && Convert.ToDouble(propertyValue) < debitAmount)
                    {
                        var userMsg = (propertyIsDebitAmount[0] as IsDebitAmount).UserMsg;
                        _serviceResult.IsValid = false;
                        _serviceResult.Msg.Add(String.Format(userMsg));
                        _serviceResult.MISACode = MISACode.BadRequest;
                        return false;
                    }
                }

                // Check quy ước nhập nhập dữ liệu tương ứng với từng kiểu dữ liệu
                if (propertyRegularDataType.Length > 0)
                {
                    //DateTime dateTimeType;
                    //if (propertyType != typeof(DateTime) && !DateTime.TryParse(propertyValue.ToString(), out dateTimeType))
                    //{
                    //    _serviceResult.IsValid = false;
                    //    _serviceResult.Msg.Add(String.Format($"Thông tin {propertyName} phải được nhập dưới dạng dd/mm/yyyy "));
                    //    _serviceResult.MISACode = MISACode.BadRequest;
                    //    return false;
                    //}
                    int intType;
                    if (propertyType != typeof(int) && !Int32.TryParse(propertyValue.ToString(), out intType))
                    {
                            _serviceResult.IsValid = false;
                            _serviceResult.Msg.Add(String.Format($"Thông tin {propertyName} chỉ cho phép nhập số"));
                            _serviceResult.MISACode = MISACode.BadRequest;
                            return false;
                    }
                }

                // Check quy ước nhập email
                if (propertyIsValidEmail.Length > 0)
                {
                    var userMsg = (propertyIsValidEmail[0] as IsValidEmail).UserMsg;
                    try
                    {
                        string value = propertyValue.ToString();
                        var email = new System.Net.Mail.MailAddress(value);
                        if (email.Address != value)
                        {
                            if (string.IsNullOrEmpty(userMsg))
                            {
                                userMsg = $"Thông tin {propertyName} phải viết dưới dạng abc@gmail.com";
                            }
                            _serviceResult.IsValid = false;
                            _serviceResult.Msg.Add(String.Format(userMsg));
                            _serviceResult.MISACode = MISACode.BadRequest;
                            return false;
                        }
                    }
                    catch(Exception)
                    {
                        throw new ValidateExceptions(userMsg);
                    }
                   
                }
            }
            return true;
            CustomerValidate(entity);

        }
        protected virtual void CustomerValidate(MISAEntity entity)
        {

        }
        #endregion
    }
}
