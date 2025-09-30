using ETicaret.Core.DTO;

namespace ETicaret.WEB_API.Areas.AdminPanel.APIService
{
    public class KategorilerAPIService
    {

        private readonly HttpClient _httpClient;
        public KategorilerAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<List<KategoriDTO>> GetAll()
        {
            var response = await _httpClient.GetFromJsonAsync<APIResponseDTO<List<KategoriDTO>>>("Kategoriler");

            return response.Data;
        }

    }
}
