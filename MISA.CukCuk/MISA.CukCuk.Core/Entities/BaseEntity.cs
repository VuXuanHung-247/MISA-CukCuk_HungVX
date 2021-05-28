using MISA.CukCuk.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.Core.Entities
{
    public abstract class BaseEntity
    {
        /// <summary>
        /// Xác định trạng thái thêm hay cập nhật
        /// </summary>
        public EntityState CustomerState { get; set; } = EntityState.AddNew;
    }
}
