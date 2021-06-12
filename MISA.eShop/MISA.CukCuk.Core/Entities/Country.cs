using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.eShop.Core.Entities
{
    /// <summary>
    /// Thông tin quốc gia
    /// </summary>
    public class Country:BaseEntity
    {
        public Guid CountryId { get; set; }
        public string CountryName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
