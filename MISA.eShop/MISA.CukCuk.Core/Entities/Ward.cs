using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.eShop.Core.Entities
{
    /// <summary>
    /// Thông tin phường/xã
    /// </summary>
    public class Ward:BaseEntity
    {
        public Guid WardId { get; set; }
        public string WardName { get; set; }
        public Guid DistrictId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
