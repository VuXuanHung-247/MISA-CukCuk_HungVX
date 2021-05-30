using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MISA.CukCuk.Core.Interfaces.IRepository
{
    /// <summary>
    /// Interface base repository
    /// </summary>
    /// <typeparam name="MISAEntity">Kiểu của thực thể</typeparam>
    /// CreatedBy: VXHUNG (26/05/2021)
    public interface IBaseRepository<MISAEntity>
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: VXHUNG (26/05/2021)
        IEnumerable<MISAEntity> GetEntities();

        /// <summary>
        /// Lấy thông tin thực thể theo Id
        /// </summary>
        /// <param name="entityId">Id thực thể</param>
        /// <returns>thực thể có Id tương ứng</returns>
        /// CreatedBy: VXHUNG (26/05/2021)
        MISAEntity GetById(Guid entityId);

        /// <summary>
        /// Thêm mới 
        /// </summary>
        /// <param name="entity">thực thể</param>
        /// <returns>Bản ghi thực thể được thêm mới</returns>
        /// CreatedBy: VXHUNG (26/05/2021)
        int Insert(MISAEntity entity);

        /// <summary>
        /// Cập nhật dữ liệu
        /// </summary>
        /// <param name="entity">thực thể</param>
        /// <param name="entityId">Id thực thể cần cập nhật</param>
        /// <returns></returns>
        /// CreatedBy: VXHUNG (26/05/2021)
        int Update(MISAEntity entity, Guid entityId);

        /// <summary>
        /// Xóa dữ liệu
        /// </summary>
        /// <param name="entityId">Id thực thể cần xóa</param>
        /// <returns></returns>
        /// CreatedBy: VXHUNG (26/05/2021)
        int Delete(Guid entityId);

        /// <summary>
        /// Lấy dữ liệu theo trường dữ liệu của thực thể
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        /// CreatedBy: VXHUNG (28/05/2021)
        MISAEntity GetEntityByProperty(MISAEntity entity, PropertyInfo property);
    }
}
