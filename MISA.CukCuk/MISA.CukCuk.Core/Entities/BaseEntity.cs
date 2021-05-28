using MISA.CukCuk.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.Core.Entities
{
    // Dùng để check bắt buộc nhập
    [AttributeUsage(AttributeTargets.Property)]
    public class Required : Attribute
    {
        public string UserMsg = string.Empty;

        public Required(string userMsg = "")
        {
            UserMsg = userMsg;
        }
    }

    // Lấy độ dài Property
    [AttributeUsage(AttributeTargets.Property)]
    public class MaxLength : Attribute
    {
        #region DECLARE
        public int Length = 0;
        public string UserMsg = string.Empty;
        #endregion

        public MaxLength(int maxLength = 0, string userMsg = "")
        {
            Length = maxLength;
            UserMsg = userMsg;
        }

        public string ErrorMaxLength
        {
            get
            {
                if (Length != 0)
                {
                    return UserMsg;
                }
                return null;
            }
        }
    }
    public abstract class BaseEntity
    {
        /// <summary>
        /// Xác định trạng thái thêm hay cập nhật
        /// </summary>
        public EntityState EntityState { get; set; } = EntityState.AddNew;
    }
}
