using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.eShop.Core.Entities
{
    /// <summary>
    /// Thông tin quận/huyện
    /// </summary>
    public class District : BaseEntity
    {
        public Guid DistrictId { get; set; }
        public string DistrictName { get; set; }
        public Guid ProvinceId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
