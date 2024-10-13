using MediatR;
using RepoLayer.Interface.AuthInterface;
using RepoLayer.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Pattern.CQRS.Handler.AuthHandler
{
    public class UserManagerCommand : IRequest<string>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class UserManagerHandler : IRequestHandler<UserManagerCommand, string>
    {
        private readonly IUserManagerRepo _authRepo;
        public UserManagerHandler(IUserManagerRepo authRepo)
        {
            _authRepo = authRepo;
        }
        public async Task<string> Handle(UserManagerCommand request, CancellationToken cancellationToken)
        {
            var creditial = new UserLoginViewModel()
            {
                UserName = request.Username,
                Password = request.Password,
            };
            return await _authRepo.UserLogin(creditial);
        }
    }
}
