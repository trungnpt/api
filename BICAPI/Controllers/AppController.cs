using BICAPI.Attributes;
using BICAPI.Common;
using BICAPI.Common.Exceptions;
using BICAPI.Common.SQLManager;
using BICAPI.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace BICAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SystemAuthen]
    public class AppController : ControllerBase
    {
        /// <summary>
        /// Lấy danh sách người dùng
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("get")]
        public async Task<IActionResult> GetData([FromBody] nguoi_dung model)
        {
            BaseResponse<IEnumerable<nguoi_dung>> response = new BaseResponse<IEnumerable<nguoi_dung>>();
            
            //Lấy ra nhiều bản ghi
            ISqlRepository<nguoi_dung> _repository = new SqlRepository<nguoi_dung>();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("ma", model.ma);  //Nếu có param
            var data = await _repository.ExcuteManyAsync("PNGUOI_DUNG_LKE", parameters);
            response.body = data;

            //ISqlRepository<nguoi_dung> _repository = new SqlRepository<nguoi_dung>();
            //DynamicParameters parameters = new DynamicParameters();
            //parameters.Add("id", 1);
            //nguoi_dung lstNguoiDung = new nguoi_dung();
            /////List<don_vi> lstDonVi = new List<don_vi>();
            //await _repository.ExcuteMultipleAsync("PMULTUPLE_TABLE", parameters, action => {
            //    lstNguoiDung = action.Read<nguoi_dung>().FirstOrDefault();
            //    lstNguoiDung.ds_don_vi = action.Read<don_vi>().ToList();
            //});


            //ISqlRepository<nguoi_dung> _repository = new SqlRepository<nguoi_dung>();
            //DynamicParameters parameters = new DynamicParameters();
            //parameters.Add("ma", model.ma);
            //parameters.Add("ten", model.ten);
            //var data = await _repository.ExcuteNoneQueryAsync("PNGUOI_DUNG_NH", parameters);

            return Ok(response);
        }
    }
}
