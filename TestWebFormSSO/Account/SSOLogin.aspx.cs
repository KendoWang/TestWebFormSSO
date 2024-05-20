using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestWebFormSSO.Account
{
    public partial class SSOLogin : System.Web.UI.Page
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var token = Request.QueryString["token"];
                string url = $"https://uaa-sso.one-fit.com/api/ParseToken?data={token}";
                await HandleSSOLoginAsync(url);
            }
            

        }

        private async Task HandleSSOLoginAsync(string url)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var contentStream = await response.Content.ReadAsStreamAsync();
                var json = "";
                using (var reader = new StreamReader(contentStream))
                {
                    json = reader.ReadToEnd();
                }
                var result = JsonConvert.DeserializeObject<LoginResult>(json);

                var model = new LoginViewModel { Name = result.eipid, Password = "DUMMY_PASSWORD" };

                // Simulate a login or redirect here
                // For example, set session variables or redirect to another page
                Session["UserName"] = model.Name;
                Session["Password"] = model.Password;

                Response.Redirect("Index.aspx");
            }
            else
            {
                // Handle error
                Response.Write("SSO 登入失敗");
            }
        }
    }

    public class LoginResult
    {
        public string eipid { get; set; }
    }

    public class LoginViewModel
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}