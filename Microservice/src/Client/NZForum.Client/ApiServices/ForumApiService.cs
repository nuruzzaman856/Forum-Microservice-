using IdentityModel.Client;
using Newtonsoft.Json;
using NZForum.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NZForum.Client.ApiServices
{
    public class ForumApiService : IForumApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ForumApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task<IEnumerable<Forum>> GetForums()
        {
            var httpCLient = _httpClientFactory.CreateClient("ForumApiClient");

            var request = new HttpRequestMessage(
                HttpMethod.Get, "api/Forums/all");

            var response = await httpCLient.SendAsync(
                    request,HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var forumList = JsonConvert.DeserializeObject<List<Forum>>(content);

            return forumList;



            // 1 - Get Token from Identity Server, of course we should provide the IS configurations link
            // 2 - Send request to protected API
            // 3 Deserialize object to MovieList

            //var apiClientCredentials = new ClientCredentialsTokenRequest
            //{
            //    Address= "https://localhost:5000/connect/token",
            //    ClientId= "forumClient",
            //    ClientSecret="secret",
            //    Scope= "forumApi"
            //};

            //var client = new HttpClient();
            //var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5000");
            //if (disco.IsError)
            //{
            //    return null;
            //}

            //// 2 Authenticates and get an access token from identity server

            //var tokenResponse = await client.RequestClientCredentialsTokenAsync(apiClientCredentials);
            //if (tokenResponse.IsError)
            //{
            //    return null; 
            //}

            //// 2 Step
            //var apiClient = new HttpClient();
            //apiClient.SetBearerToken(tokenResponse.AccessToken);

            //var response = await apiClient.GetAsync("https://localhost:5001/api/Forums/all");
            //response.EnsureSuccessStatusCode();

            //var content = await response.Content.ReadAsStringAsync();

            //List<Forum> forumList = JsonConvert.DeserializeObject<List<Forum>>(content);
            //return forumList;

        }
        public Task<Forum> CreateForum(Forum Forum)
        {
            throw new NotImplementedException();
        }

        public Task DeleteForum(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Forum> GetForum(string id)
        {
            throw new NotImplementedException();
        }
        public Task<Forum> UpdateForum(Forum Forum)
        {
            throw new NotImplementedException();
        }
    }
}
