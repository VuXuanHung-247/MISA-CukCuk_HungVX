using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Core.Interfaces.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<MISAEntity> : ControllerBase
    {
        #region Declare
        IBaseService<MISAEntity> _baseService;
        #endregion

        #region Constructor
        public BaseController(IBaseService<MISAEntity> baseService)
        {
            _baseService = baseService;
        }
        #endregion

        #region Method
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>
        /// HttpCode 200 có dữ liệu trả về;
        /// HttpCode 204 nếu không có dữ liệu
        /// HttpCode 400 Bad Request    
        /// </returns>
        /// CreatedBy: VXHUNG (26/05/2021)
        [HttpGet]
        public IActionResult Get()
        {
            var entities = _baseService.GetEntities();
            if (entities.Count() == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(entities);
            }
        }

        /// <summary>
        /// Lấy dữ liệu theo Id
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns>Thông tin đối tượng chứa Id đó
        /// HttpCode 200 có dữ liệu trả về;
        /// HttpCode 204 nếu không có dữ liệu
        /// HttpCode 400 Bad Request        
        /// HttpCode 500 lỗi Server
        /// </returns>
        /// CreatedBy: VXHUNG (26/05/2021)
        [HttpGet("{entityId}")]
        public IActionResult Get(string entityId)
        {
            var entity = _baseService.GetById(Guid.Parse(entityId));
            if (entity == null)
            {
                return NoContent();
            }
            return Ok(entity);
        }

        /// <summary>
        /// Thêm mới dữ liệu
        /// </summary>
        /// <param name="entity">Thực thể thêm mới</param>
        /// <returns>
        /// HttpCode 200 có dữ liệu trả về; Msg: Thêm mới dữ liệu thành công
        /// HttpCode 400 Bad Request  
        /// HttpCode 500 lỗi Server
        /// </returns>
        /// CreatedBy: VXHUNG (26/05/2021)
        [HttpPost]
        public IActionResult Post([FromBody] MISAEntity entity)
        {
            var result = _baseService.Insert(entity);
            if (result.IsValid == true)
            {
                var data = (int?)result.data;
                if (data > 0)
                {
                    return Ok(result);
                }
                else
                {
                    return NoContent();
                }
            }
            else
            {
                return BadRequest(result);
            }
        }

        /// <summary>
        /// Cập nhật dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="entityId"></param>
        /// <returns>
        /// HttpCode 200: Cập nhật dữ liệu thành công
        /// HttpCode 400 Bad Request    
        /// HttpCode 500 lỗi Server
        /// </returns>
        /// CreatedBy: VXHUNG (26/05/2021)
        [HttpPut]
        public IActionResult Put([FromBody] MISAEntity entity, Guid entityId)
        {
            var result = _baseService.Update(entity, entityId);
            if (result.MISACode == Core.Enums.MISACode.BadRequest)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        /// <summary>
        /// Xóa dữ liệu
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        /// CreatedBy: VXHUNG (26/05/2021)
        [HttpDelete("{entityId}")]
        public IActionResult Delete(Guid entityId)
        {
            var entity = _baseService.Delete(entityId);
            return Ok(entity);
        }
        #endregion
    }
}
