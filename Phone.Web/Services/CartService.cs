﻿using Phone.Web.Models;
using Phone.Web.Services.IServices;

namespace Phone.Web.Services
{
    public class CartService : BaseService, ICartService
    {
        private readonly IHttpClientFactory _clientFactory;

        
        public CartService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }




        public async Task<T> AddToCartAsync<T>(CartDto cartDto, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = cartDto,
                Url = SD.ShoppingCartAPIBase + "/api/controller/AddCart",
                AccessToken = token
            });

        }

        public async Task<T> GetCartByUserIdAsnyc<T>(string userId, string token = null)
            {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ShoppingCartAPIBase + "/api/controller/GetCart/" + userId,
                AccessToken = token
            });
        }

        public async Task<T> RemoveFromCartAsync<T>(int cartId, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = cartId,
                Url = SD.ShoppingCartAPIBase + "/api/controller/RemoveCart",
                AccessToken = token
            });
        }

        public async  Task<T> UpdateCartAsync<T>(CartDto cartDto, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = cartDto,
                Url = SD.ShoppingCartAPIBase + "/api/controller/UpdateCart",
                AccessToken = token
            });
        }
    }
}
