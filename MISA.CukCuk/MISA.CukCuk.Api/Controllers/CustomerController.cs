using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interfaces.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        #region Declare
        ICustomerService _customerService;
        #endregion

        #region Constructor
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        #endregion


        #region Method
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns> 
        /// HttpCode 200 cos duwx lieeu
        /// 204 nếu không có dữ liệu</returns>
        /// CreatedBy: VXHUNG (25/05/2021)
        [HttpGet]
        public IActionResult Get()
        {
            var customer = _customerService.GetAll();
            if (customer.Count() == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(customer);
            }
        }
        /// <summary>
        /// Lấy dữ liệu theo khóa chính
        /// </summary>
        /// <param name="customerId">Id của bảng dữ liệu</param>
        /// <returns>Thông tin của 1 đối tượng</returns>
        /// CreatedBy:  VXHUNG (25/05/2021)
        [HttpGet("{customerId}")]
        public IActionResult Get(Guid customerId)
        {
            var customer = _customerService.GetById(customerId);
            if (customer == null)
            {
                return NoContent();
            }
            return Ok(customer);
        }

        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="customer">Khách hàng muốn thêm mới</param>
        /// <returns>
        ///  - HttpCode: 200 nếu thêm được dữ liệu
        ///  - Lỗi dữ liệu không hợp lệ : 400 (BadRequest)
        ///  - HttpCode: 500 nếu có lỗi hoặc Exceotion xảy ra trên Server
        /// </returns>
        /// CreatedBy: VXHUNG (25/05/2021)
        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            //var result = _customerService.Insert(customer);
            //if (result.MISACode == Core.Enums.MISACode.NotValid)
            //{
            //    return BadRequest(result.data);
            //}
            //return   Ok(result);
            return null;
        }
        #endregion
    }
}
