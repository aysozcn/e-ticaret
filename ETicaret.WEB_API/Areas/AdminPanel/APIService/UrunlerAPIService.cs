using ETicaret.Core.DTO;
using System.Collections.Generic;

namespace ETicaret.WEB_API.Areas.AdminPanel.APIService
{
    public class UrunlerAPIService
    {

        private readonly HttpClient _httpClient;
        public UrunlerAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        //https://www.sahibinden.com/api
        //https://www.amazon.com.tr/api
        //https://www.trendyol.com.tr/api


        //BaseUrl/api/Urunler/UrunlerIndex
        //http://localhost:5298/api/Urunler/UrunlerIndex
        public async Task<List<UrunlerDTO>> UrunlerList()
        {
            //localhost5447
            //var response = await _httpClient.GetFromJsonAsync<APIResponseDTO<List<UrunlerDTO>>>("192.168.12.45:20//api/Urunler/UrunlerIndex");//hard coded
            var response = await _httpClient.GetFromJsonAsync<APIResponseDTO<List<UrunlerDTO>>>("Urunler");

            return response.Data;
        }

        public async Task<List<GetUrunlerWithKategoriDTO>> UrunlerWithKategori()
        {
            var response = await _httpClient.GetFromJsonAsync<APIResponseDTO<List<GetUrunlerWithKategoriDTO>>>("Urunler/GetUrunlerWithKategori");
            return response.Data;
        }

        public async Task<UrunlerDTO> UrunKaydet(UrunlerDTO urunlerDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("Urunler", urunlerDTO);//PostAsJsonAsync post request ile gideceğim

            if (response.IsSuccessStatusCode == false)
            {
                return null;
            }
            var responseBody = await response.Content.ReadFromJsonAsync<APIResponseDTO<UrunlerDTO>>();

            return responseBody.Data;
        }


    }
}
