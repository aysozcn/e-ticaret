using ETicaret.Core.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.API.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]
    public class BaseController : Controller
    {
        [NonAction]
        public IActionResult SelectResponseResult<TEntity>(APIResponseDTO<TEntity> responseDTO)
        {

            
            switch (responseDTO.StatuCode)
            {
                case 204:

                    return new ObjectResult(null)
                    {
                        StatusCode = responseDTO.StatuCode
                    };

                default:
                    return new ObjectResult(responseDTO)
                    {
                        StatusCode = responseDTO.StatuCode

                    };
                    //break;
            }
        }

        /// <summary>
        /// List döndürür
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="tEntity"></param>
        /// <returns></returns>
        [NonAction]//API Route değildir
        public IActionResult ResultAPI<TEntity>(List<TEntity> tEntity)
        {
            try
            {
                if (tEntity.Count > 0)
                {
                    return SelectResponseResult(APIResponseDTO<List<TEntity>>.Success(200, tEntity));
                    //return Ok(APIResponseDTO<List<UrunlerDTO>>.Success(200, urunlerDTO));
                    //return Ok(urunler);
                }

                else if (tEntity.Count == 0)
                {
                    return SelectResponseResult(APIResponseDTO<TEntity>.Fail(200, "Liste Boş"));
                }
                return SelectResponseResult(APIResponseDTO<TEntity>.Fail(201, "Hata"));
            }
            catch (Exception)
            {
                return SelectResponseResult(APIResponseDTO<List<TEntity>>.Success(204, tEntity));
            }
        }

        /// <summary>
        /// Table döndürür
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="tEntity"></param>
        /// <returns></returns>
        [NonAction]//API Route değildir
        public IActionResult ResultAPI<TEntity>(TEntity tEntity)//Method işlem sonucuda Table döndürmesi için yapıldı
        {
            try
            {
                if (tEntity!=null)
                {
                    return SelectResponseResult(APIResponseDTO<TEntity>.Success(200, tEntity));
                }

                else if (tEntity ==null)
                {
                    return SelectResponseResult(APIResponseDTO<TEntity>.Fail(200, "Liste Boş"));
                }
                return SelectResponseResult(APIResponseDTO<TEntity>.Fail(201, "Hata"));
            }
            catch (Exception)
            {
                return SelectResponseResult(APIResponseDTO<TEntity>.Success(204, tEntity));
            }
        }



    }
}
