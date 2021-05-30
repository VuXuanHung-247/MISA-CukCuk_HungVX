﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.Core.Entities
{
    /// <summary>
    /// Thông tin khách hàng
    /// </summary>
    /// CreateBy: VXHUNG(24/05/2021)
    public class Customer:BaseEntity
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        [Primary]
        public Guid CustomerId { get; set; }
        /// <summary>
        /// Mã khách hàng
        /// </summary>
        [IsDuplicate]
        [Required("Mã khách hàng không được phép để trống")]
        [MaxLength(20,"Mã khách hàng không quá 20 kýt tự")]
        public string CustomerCode { get; set; }
        /// <summary>
        /// Tên khách hàng
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Họ khách hàng
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Họ tên đầy đủ khách hàng
        /// </summary>
        [Required("Họ tên khách hàng không được phép để trống")]
        [MaxLength(100, "Tên nhân viên không được quá 100 kí tự")]
        public string FullName { get; set; }
        /// <summary>
        /// Giới tính
        /// </summary>
        public int? Gender { get; set; }
        /// <summary>
        /// Địa chỉ
        /// </summary>
        [MaxLength(50, "Địa chỉ không được quá 50 kí tự")]
        public string Address { get; set; }
        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime DateOfBirth { get; set; }
        /// <summary>
        /// Email khách hàng
        /// </summary>
        [MaxLength(50, "Email không được quá 50 kí tự")]
        public string Email { get; set; }
        /// <summary>
        /// Số điện thoại khách hàng
        /// </summary>
        [IsDuplicate]
        [MaxLength(20, "Số điện thoại không được quá 20 kí tự")]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Mã Nhóm khách hàng
        /// </summary>
        public Guid? CustomerGroupId { get; set; }
        /// <summary>
        /// Số ghi nợ
        /// </summary>
        public double? DebitAmout { get; set; }
        /// <summary>
        /// Số thẻ
        /// </summary>
        public string MemberCardCode { get; set; }
        /// <summary>
        /// Tên công ty
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// Mã công ty
        /// </summary>
        public string CompanyTaxCode { get; set; }
        /// <summary>
        /// Tình trạng
        /// </summary>
        public int? IsStopFollow { get; set; }
        /// <summary>
        /// Ghi chú
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// Người tạo
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Ngày sửa
        /// </summary>
        public DateTime ModifiedDate { get; set; }
        /// <summary>
        /// Người sửa
        /// </summary>
        public string ModifiedBy { get; set; }
        
    }
}
