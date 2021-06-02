using MISA.CukCuk.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.Core.Entities
{
    public class ServiceResult
    {
        #region Declare

        #endregion

        #region Constructor

        #endregion

        #region Property
        /// <summary>
        /// Dữ liệu hợp lệ
        /// </summary>
        public bool IsValid { get; set; } = true;
        /// <summary>
        /// Dữ liệu trả về
        /// </summary>
        public Object data { get; set; }

        /// <summary>
        /// Message trả về
        /// </summary>
        public List<string> Msg { get; set; } = new List<string>();

        /// <summary>
        /// Mã lỗi trả về
        /// </summary>
        public MISACode MISACode { get; set; }

        /// <summary>
        /// Tổng bản ghi
        /// </summary>
        public int? Total { get; set; }
        #endregion
    }
}
