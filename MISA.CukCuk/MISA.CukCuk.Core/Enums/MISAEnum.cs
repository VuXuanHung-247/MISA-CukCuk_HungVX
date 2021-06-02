using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.Core.Enums
{

    public enum MISACode
    {
        /// <summary>
        /// Dữ liệu hợp lệ
        /// </summary>
        IsValid = 100,

        /// <summary>
        /// Dữ liệu không hợp lệ
        /// </summary>
        BadRequest = 400,

        /// <summary>
        /// Thành công
        /// </summary>
        Success = 200,

        /// <summary>
        /// Lỗi
        /// </summary>
        Exeption = 500,
    }

    public enum EntityState
    {
        AddNew = 1,
        Update = 2,
        Delete = 3
    }

    /// <summary>
    /// Enum giới tính
    /// </summary>
    public enum Gender
    {
        /// <summary>
        /// Nam
        /// </summary>
        Male = 1,

        /// <summary>
        /// Nữ
        /// </summary>
        Female = 0,

        /// <summary>
        /// Không xác định
        /// </summary>
        Other = 2
    }
}
