using RepoLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoLayer.Interface.AuthInterface
{
    public interface IUserManagerRepo
    {
        Task<string> UserLogin(UserLoginViewModel userCredentials);
        public Task<ForgotPasswordViewModel> UserForgotPassword(string email);

        public Task<bool> ResetPassword(ResetPasswordViewModel model, string email);
    }
}
