using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.eShop.Core.Entities
{
    /// <summary>
    /// Thông tin tỉnh/thành phố
    /// </summary>
    public class Province:BaseEntity
    {
        public Guid ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public Guid CountryId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
