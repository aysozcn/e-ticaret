using AutoMapper;//Mapper
using ETicaret.Core.DTO;
using ETicaret.Core.ETicaretDatabase;
using ETicaret.Core.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETicaret.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UrunlerController : BaseController
    {
        private readonly IService<Urunler> _service;
        private readonly IMapper _mapper;//AutoMapper için eklenen kütüphanede DI kullanılması için IMapper  kütüphane içinde geliyor.
        readonly IUrunlerService _urunService;

        public UrunlerController(IService<Urunler> service, IMapper mapper,IUrunlerService urunlerService)
        {
            _service = service;
            _mapper = mapper;
            _urunService = urunlerService;
        }


        /// GET api/Urunler/GetUrunlerWithKategori
        [HttpGet("[action]")]//Test için yapıldı
        public async Task<IActionResult> GetUrunlerWithKategori()
        {

            return ResultAPI(await _urunService.GetUrunlerWithKategoriAsync());
        }


        //...api/Urunler/UrunlerIndex
        [HttpGet]
        public async Task<IActionResult> UrunlerIndex()
        {
            var urunler = await _service.GetAllAsyncs();
            var urunlerDTO = _mapper.Map<List<UrunlerDTO>>(urunler);

            //return Ok(urunler);//OK ile Result yaptık
            //return Ok(APIResponseDTO<List<UrunlerDTO>>.Success(200, urunlerDTO));//OK içine DTO yerleştirildi
            //return SelectResponseResult(APIResponseDTO<List<TEntity>>.Success(200, tEntity));//OK yerine BaseController içine SelectResponseResult yaptık

            return ResultAPI(urunlerDTO);//SelectResponseResult için daha efektif olması için BaseController altında ResultAPI Method yaptık. Tentity verecek bütün tablolar için kullanılabilir yaptık

        }

        #region Commant


        //[HttpGet]
        //public async Task<IActionResult> UrunlerList(int id)
        //{
        //    var urunler = await _service.GetAllQuery(k=>k.Id==id).FirstOrDefaultAsync();
        //    var urunlerDTO = _mapper.Map<List<UrunlerDTO>>(urunler);
        //    return Ok(urunlerDTO);
        //    //return Ok(urunler);
        //}


        //[HttpPost]
        //public async Task<IActionResult> UrunlerTableSave(Urunler urunler)
        //{
        //    var save = await _service.AddAsync(urunler);
        //    return Ok(save);
        //    //Bu method bütün Ürünler tabosunu ve bağlı tabloları Swagger da gösterir. Bunun yerine DTO nesnesi kullanarak UrunlerSave methodu yapmak daha güvenlidir ve kontrol edilebilir.

        //}
        #endregion

        /// <summary>
        /// Ürün kayıt işlemi
        /// </summary>
        /// <param name="urunlerDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UrunlerSave(UrunlerDTO urunlerDto)
        {
            //var mapUrunler = _mapper.Map<Urunler>(urunlerDto);
            var urunSave = await _service.AddAsync(_mapper.Map<Urunler>(urunlerDto));
            var mapAdd = _mapper.Map<UrunlerDTO>(urunSave);

            return Ok(mapAdd);
        }

        [HttpPut]
        public async Task<IActionResult> UrunlerUpdate(UrunlerUpdateDTO urunUpdateDTO)
        {
            var getUrun = await _service.GetByIdAsync(urunUpdateDTO.Id);

            if (getUrun != null)
            {
                await _service.UpdateAsync(_mapper.Map(urunUpdateDTO, getUrun));
                //  await _service.UpdateAsync(_mapper.Map<Urunler>(urunUpdateDTO));
            }
            else
            {
                //return NoContent();
                //return Ok(APIResponseDTO<List<UrunlerDTO>>.Fail(200,"ID değeri hatalı"));
                return NoContent();
            }

            return ResultAPI(urunUpdateDTO);
        }
    }
}
