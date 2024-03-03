using API_Produtos.Interface;
using API_Produtos.Models;
using API_Produtos.Models.Token;
using API_Produtos.Repository;

namespace API_Produtos.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public AddUserDTO addUser(UserDTO user)
        {
            return _userRepository.addUser(user);
        }

        public User GetByEmail(LoginToken login)
        {
            return _userRepository.GetByEmail(login);
        }

        public User removeUser(int id)
        {
            return _userRepository.removeUser(id);
        }

        public User updateUser(UserDTO user, int id)
        {
           return _userRepository.updateUser(user, id);
        }
    }
}
