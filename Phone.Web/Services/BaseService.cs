using Newtonsoft.Json; 
using Phone.Web.Models; 
using Phone.Web.Services.IServices; 
using System.Text; 

namespace Phone.Web.Services
{
    // This class implements the IBaseService interface and provides a base implementation for making HTTP requests
    public class BaseService : IBaseService
    {
        // Public properties of the class
        public ResponseDto responseModel { get; set; } // Contains the response details of the HTTP request
        public IHttpClientFactory httpClient { get; set; } // Provides an instance of HttpClient to send HTTP requests

        // Constructor of the class
        public BaseService(IHttpClientFactory httpClient)
        {
            this.httpClient = httpClient; // Injected instance of IHttpClientFactory
            this.responseModel = new ResponseDto(); // Initialize the response DTO
        }

        // This method sends an HTTP request and returns the response as an object of the specified type T
        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                // Create an instance of HttpClient using the injected IHttpClientFactory
                var client = httpClient.CreateClient("PhoneAPI");

                // Create a new HTTP request message
                HttpRequestMessage message = new HttpRequestMessage();

                // Set the request headers to accept JSON content
                message.Headers.Add("Accept", "application/json");

                // Set the request URI to the API endpoint URL
                message.RequestUri = new Uri(apiRequest.Url);

                // Clear any existing default request headers
                client.DefaultRequestHeaders.Clear();

                // If the API request contains data, serialize it to JSON format and set it as the content of the request message
                if (apiRequest.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),
                        Encoding.UTF8, "application/json");
                }

                // Determine the HTTP method of the request and set the HttpMethod property of the request message accordingly
                HttpResponseMessage apiResponse = null;
                switch (apiRequest.ApiType)
                {
                    case SD.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case SD.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case SD.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                // Send the HTTP request and get the response as an instance of HttpResponseMessage
                apiResponse = await client.SendAsync(message);

                // Read the content of the response message as a string
                var apiContent = await apiResponse.Content.ReadAsStringAsync();

                // Deserialize the JSON response content to an object of the specified type T
                var apiResponseDto = JsonConvert.DeserializeObject<T>(apiContent);

                // Return the deserialized object to the caller
                return apiResponseDto;
            }
            catch (Exception e)
            {
                // If an exception occurs during the execution of the HTTP request, create an instance of ResponseDto with error details
                var dto = new ResponseDto
                {
                    DisplayMessage = "Error",
                    ErrorMessages = new List<string>() { Convert.ToString(e.Message) },
                    IsSuccess = false
                };

                // Serialize the error response DTO to JSON format
                var res = JsonConvert.SerializeObject(dto);

                // Deserialize the JSON response content to an object of the specified type T
                var apiResponseDto = JsonConvert.DeserializeObject<T>(res);

                // Return the deserialized object to the caller
                return apiResponseDto;
            }
        }

        // This method suppresses the finalization of the object

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }


    }
}
