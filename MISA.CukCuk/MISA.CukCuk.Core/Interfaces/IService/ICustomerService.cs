using MISA.CukCuk.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.Core.Interfaces.IService
{
    public interface ICustomerService
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu 
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: VXHUNG (25/05/2021)
        IEnumerable<Customer> GetAll();

        /// <summary>
        /// Lấy thông tin của khach hang theo Id
        /// </summary>
        /// <param name="customerId">Id khach hang</param>
        /// <returns>Khach hang có id tương ứng</returns>
        /// CreatedBy: VXHUNG (25/5/2021)
        Customer GetById(Guid customerId);

        /// <summary>
        /// Thêm mới Khach hang
        /// </summary>
        /// <param name="customer">Khach hang</param>
        /// <returns>Số bản ghi thêm mới bản db</returns>
        /// CreatedBy: VXHUNG (25/5/2021)
        int Insert(Customer customer);

        /// <summary>
        /// Cập nhật thông tin Khach hang
        /// </summary>
        /// <param name="customer">Khach hang</param>
        /// <param name="customerId">Id KH</param>
        /// <returns>Số bản ghi được update trong db</returns>
        /// CreatedBy: VXHUNG (25/5/2021)
        int Update(Customer customer, Guid customerId);

        /// <summary>
        /// Xoá KH
        /// </summary>
        /// <param name="customerId">Id KH</param>
        /// <returns>Số bản ghi đã xoá tỏng db</returns>
        /// CreatedBy: VXHUNG (25/5/2021)
        int Delete(Guid customerId);

    }
}
