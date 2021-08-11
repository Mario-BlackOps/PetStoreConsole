using PetStore.Services.Interfaces;
using System.Net.Http;

namespace PetStore.Services.Helpers
{
    public class HttpPetsHandler : IHttpPetsHandler
    {
        private HttpClient _httpClient;

        public HttpPetsHandler( )
        {
            _httpClient = new HttpClient( );
        }

        public string GetSerializedJson( string url, string key )
        {
            SetHeaderKey( key );           

            return _httpClient.GetStringAsync( url ).Result;
        }

        private void SetHeaderKey( string key )
        {
            _httpClient.DefaultRequestHeaders.Add( "api_key", key );
        }
    }
}
