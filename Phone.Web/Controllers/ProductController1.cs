using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Phone.Web.Models;
using Phone.Web.Services.IServices;

namespace Phone.Web.Controllers
{
    public class ProductController1 : Controller
    {
        private readonly IProductService _productService;

        public ProductController1(IProductService productService)
        {
            _productService = productService;
        }


        public async Task<IActionResult>ProductIndex()
        {

            List<ProductDto> list = new();
            var response = await _productService.GetTAllProductsAsync<ResponseDto>();


            if(response!=null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
    }
}
