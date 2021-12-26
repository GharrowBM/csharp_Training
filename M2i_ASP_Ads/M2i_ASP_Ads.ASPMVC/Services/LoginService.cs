using M2i_ASP_Ads.Repositories;
using M2iASP_Ads.Classes;

namespace M2i_ASP_Ads.ASPMVC.Services
{
    public class LoginService
    {
        private IRepository<User> _utilisateurRepository;
        private User _loggedUser;
        private IHttpContextAccessor _accessor;

        public LoginService(IRepository<User> utilisateurRepository, IHttpContextAccessor accessor)
        {
            _utilisateurRepository = utilisateurRepository;
            _accessor = accessor;
        }

        public bool Login(string login, string password)
        {
            _loggedUser = _utilisateurRepository.SerchOne(u => u.UserName == login && u.Password == password);
            if (_loggedUser != null)
            {
                _accessor.HttpContext.Session.SetString("isLogged", "true");
                return true;
            }
            return false;
        }

        public bool Logout()
        {
            if (IsLogged())
            {
                _accessor.HttpContext.Session.SetString("isLogged", "false");
                _loggedUser = null;
                return true;
            }

            return false;
        }

        public bool IsLogged()
        {
            if (bool.TryParse(_accessor.HttpContext.Session.GetString("isLogged"), out bool isLogged))
            {
                if (isLogged)
                {
                    return true;
                }
            }
            return false;
        }

        public User CurrentUser()
		{
            return _loggedUser;
		}
    }
}
