using API_Produtos.Models;
using API_Produtos.Models.Token;

namespace API_Produtos.Interface
{
    public interface IUserRepository
    {
        public AddUserDTO addUser(User user);
        public User updateUser(UserDTO user, int id);
        public User removeUser(int id);
        public User GetByEmail(LoginToken login);
        public User GetUserById(int id);
    }
}
