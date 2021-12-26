using M2i_ASP_Ads.Repositories;
using M2iASP_Ads.Classes;

namespace M2i_ASP_Ads.ASPMVC.Services
{
    public class FavoriteService
    {
        private IRepository<Offer> _adsRepository;
        IRepository<User> _usersRepository;
        private IHttpContextAccessor _contextAccessor;

        public FavoriteService(IRepository<Offer> adsRepository, IRepository<User> userRepository,IHttpContextAccessor contextAccessor)
        {
            _adsRepository = adsRepository;
            _usersRepository = userRepository;
            _contextAccessor = contextAccessor;
        }

        private string GetStringFromFavList(List<Offer> favorites)
		{
            string favoritesString = String.Empty;
            int[] favoritesIds = new int[favorites.Count];

            for (int i = 0; i < favorites.Count; i++)
			{
                favoritesIds[i] = favorites[i].Id;
			}

            return string.Join(",", favoritesIds);
		}

        public List<Offer> GetFavorites(User user)
        {
            _contextAccessor.HttpContext.Session.SetString("favorites", GetStringFromFavList(user.Favorites));

            return user.Favorites ;
        }

        public List<Offer> AddFavorite(User user, int id)
        {
            user.Favorites.Add(_adsRepository.SerchOne(o=>o.Id == id));
            _usersRepository.Save(user);

            _contextAccessor.HttpContext.Session.SetString("favoriteOffers", GetStringFromFavList(user.Favorites));

            return user.Favorites;
        }

        public List<Offer> RemoveFavorite(User user, int id)
        {
            user.Favorites.Remove(_adsRepository.SerchOne(o => o.Id == id));
            _usersRepository.Save(user);

            _contextAccessor.HttpContext.Session.SetString("favoriteOffers", GetStringFromFavList(user.Favorites));

            return user.Favorites;
        }
    }
}
