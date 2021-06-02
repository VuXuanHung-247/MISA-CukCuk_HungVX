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

    // Dùng để check độ dài cho phép của thuộc tính
    [AttributeUsage(AttributeTargets.Property)]
    public class MaxLength : Attribute
    {
        public int Length = 0;
        public string UserMsg = string.Empty;

        public MaxLength(int maxLength = 0, string userMsg = "")
        {
            Length = maxLength;
            UserMsg = userMsg;
        }
    }

    // Dùng để check phạm vi cho phép của thuộc tính Ngày tháng
    [AttributeUsage(AttributeTargets.Property)]
    public class RangeDateTime : Attribute
    {
        public DateTime MaxDate { get; }
        public DateTime MinDate { get; }
        public string UserMsg { get; }
        public RangeDateTime(string minDate, string maxDate, string userMsg)
        {
            MaxDate = DateTime.Parse(maxDate);
            MinDate = DateTime.Parse(minDate);
            UserMsg = userMsg;
        }
    }
    // Dùng để check số tiền không được âm
    [AttributeUsage(AttributeTargets.Property)]
    public class IsDebitAmount : Attribute
    {
        public double DebitAmount { get; }
        public string UserMsg { get; }

        public IsDebitAmount(double debitAmount, string userMsg)
        {
            DebitAmount = debitAmount;
            UserMsg = userMsg;
        }
        //public string ErrorDebitAmount
        //{
        //    get
        //    {
        //        if (DebitAmount < 0)
        //            return UserMsg;
        //        else
        //            return null;
        //    }
        //}
    }
        // Dùng để check trùng dữ liệu
        [AttributeUsage(AttributeTargets.Property)]
        public class IsDuplicate : Attribute
        {

        }
        // Khóa chính
        [AttributeUsage(AttributeTargets.Property)]
        public class Primary : Attribute
        {
        }


        public abstract class BaseEntity
        {
            /// <summary>
            /// Xác định trạng thái thêm hay cập nhật
            /// </summary>
            public EntityState EntityState { get; set; } = EntityState.AddNew;
        }
    }
