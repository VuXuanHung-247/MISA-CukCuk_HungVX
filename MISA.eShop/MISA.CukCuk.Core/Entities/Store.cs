using MISA.eShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.eShop.Core.Entities
{
    /// <summary>
    /// Thông tin cửa hàng
    /// </summary>
    public class Store : BaseEntity
    {
        public Guid StoreId { get; set; }
        public string StoreCode { get; set; }
        public string StoreName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string StoreTaxCode { get; set; }
        public Guid CountryId { get; set; }
        public Guid ProvinceId { get; set; }
        public Guid DistrictId { get; set; }
        public Guid WardId { get; set; }
        public string Street { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
