using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SimpleAuthentication.Lib.Login;
using SimpleAuthentication.Models;
using System;

namespace SimpleAuthentication.Lib.Filter
{
    public class UserAuthorization : Attribute, IAuthorizationFilter
    {
        UserLogin _userLogin;

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _userLogin = (UserLogin)context.HttpContext.RequestServices.GetService(typeof(UserLogin));
            User user = _userLogin.GetUser();
            if(user == null)
            {
                context.Result = new ContentResult() { Content = "Acesso negado!" };
            }
        }
    }
}
