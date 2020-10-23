using Newtonsoft.Json;
using PlasmaTracker.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace PlasmaTracker.Services
{
    class ApiServices
    {
        public async System.Threading.Tasks.Task<bool> RegisterUserAsync(String email,String password,String confirmPassword)
        {
            var registerModel = new RegisterModel()
            {
                Email = email,
                Password = password,
                ConfirmPassword = confirmPassword
            };
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(registerModel);
            var content=new StringContent(json, Encoding.UTF8, "application/json");
           var response= await httpClient.PostAsync("https://192.168.1.4:45456/api/Account/Register", content);
            return response.IsSuccessStatusCode;
        }
        public async System.Threading.Tasks.Task<bool> LoginUser(String email,String password)
        {
           var keyvalues= new List<KeyValuePair<String, String>>()
            {
            new KeyValuePair<String,String>("username",email),
            new KeyValuePair<String,String>("password",password),
            new KeyValuePair<String,String>("grant_type","password"),
            };
            var request = new HttpRequestMessage(HttpMethod.Post, "https://192.168.1.4:45456/Token");
            request.Content = new FormUrlEncodedContent(keyvalues);
            var httpClient = new HttpClient();
            var response = await httpClient.SendAsync(request);
            var content=response.Content.ReadAsStringAsync();
            return response.IsSuccessStatusCode;
        }
        public async System.Threading.Tasks.Task<List<PlasmaUser>> FindBlood(String location,string bloodType)
        {
            var httpclient = new HttpClient();
            httpclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer","check out");
            var bloodgroupapi = "https://192.168.1.4:45456/api/PlasmaUsers";
          var json= await httpclient.GetStringAsync($"{bloodgroupapi}?bloodgroup={bloodType}&location={location}");
            return JsonConvert.DeserializeObject<List<PlasmaUser>>(json);

        }
        public async System.Threading.Tasks.Task<List<PlasmaUser>> LatestBloodUser(String location, string bloodType)
        {
            var httpclient = new HttpClient();
            httpclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", "check out");
            var bloodgroupapi = "https://192.168.1.4:45456/api/PlasmaUsers";
            var json = await httpclient.GetStringAsync(bloodgroupapi);
            return JsonConvert.DeserializeObject<List<PlasmaUser>>(json);
        }
        public async System.Threading.Tasks.Task<bool> RegisterDonar(PlasmaUser plasmaUser)
        {
            var json = JsonConvert.SerializeObject(plasmaUser);
            var httpclient = new HttpClient();
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            httpclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", "check out");
            var bloodgroupapi = "https://192.168.1.4:45456/api/PlasmaUsers";
            var response = await httpclient.PostAsync(bloodgroupapi,content);
            return response.IsSuccessStatusCode;
        }
    }
}
