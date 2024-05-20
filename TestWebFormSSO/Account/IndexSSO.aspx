<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndexSSO.aspx.cs" Inherits="TestWebFormSSO.Account.IndexSSO" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SSO 登入</title>
    <script src="../Scripts/bootstrap.bundle.js"></script>
    <style>
        body {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            margin: 0;
            font-family: Arial, sans-serif;
        }

        h1 {
            text-align: center;
            color: red; /* Set the text color to red */
        }
    </style>
</head>
<body>
    <%
        HttpRequest request = HttpContext.Current.Request;

                
                UriBuilder builder = new UriBuilder
                {
                    Scheme = request.Url.Scheme,
                    Host = request.Url.Host,
                    Port = request.Url.IsDefaultPort ? 443 : request.Url.Port,
                    Path = "Account/SSOLogin.aspx"
                };

                // Get the final URL
                string ssoLoginUrl = builder.ToString();
    %>
    <h1>SSO 登入進行中</h1>
    <form id="form1" action="https://uaa-sso.one-fit.com/SSO/SSOCheck" method="post">
        <input type="hidden" name="SysId" value="CDAC19E1-B004-4697-A23C-4578F60F31D9" />
        <input type="hidden" name="SysPassword" value="rvfyUAj52p" />
        <input type="hidden" name="ReturnUrl" value='<% =ssoLoginUrl %>' />
    </form>
    <script src="../Scripts/jquery-3.4.1.min.js"></script>
    <script type="text/javascript">
        // alert('@builder.ToString()');
        $('#form1').submit();
    </script>
</body>
</html>
