using static System.Net.WebRequestMethods;

namespace Phone.Web
{
    public static class SD
    {
        // This property stores the base URL of the API used by the application
        public static string ProductAPIBase { get; set; }
        public static string ShoppingCartAPIBase { get; set; }

        //This enumeration represents the HTTP methods used to interact with the API
        public enum ApiType
        {
            GET,POST, PUT, DELETE
        }

    }
}
