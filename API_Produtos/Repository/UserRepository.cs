using API_Produtos.Interface;
using API_Produtos.Models;
using API_Produtos.Models.Token;
using System.Security.Cryptography;
using System.Text;

namespace API_Produtos.Repository
{
    public class UserRepository : IUserRepository
    {


        private readonly DatabaseContext _dbContext;

        public UserRepository(DatabaseContext context)
        {
            this._dbContext = context;
        }

        public AddUserDTO addUser(User user)
        {
            string senhaOriginal = user.Password;
            string senhaSHA256 = PasswordSHA256Hash(senhaOriginal);
            user.Password = senhaSHA256;

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            AddUserDTO userDTO = user;
            return userDTO;
        }

        public User GetByEmail(LoginToken login)
        {
            return _dbContext.Users.Where(x => x.Email.ToLower() == login.Email.ToLower() && PasswordSHA256Hash(login.Password) == x.Password).FirstOrDefault();
        }

        public User removeUser(int id)
        {
            var user = GetUserById(id);

            if (user == null) return user;

            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
            return user;
        }

        public User updateUser(UserDTO user, int id)
        {
            var User = GetUserById(id);

            if (User == null) return User;

            if (user.Type != 0) User.Type = user.Type;
            if (!string.IsNullOrEmpty(user.Name)) User.Name = user.Name;
            if (!string.IsNullOrEmpty(user.Email)) User.Email = user.Email;
            if (!string.IsNullOrEmpty(user.Password)) User.Password = PasswordSHA256Hash(user.Password);


            _dbContext.Users.Update(User);
            _dbContext.SaveChanges();
            return User;
        }

        public User GetUserById(int id)
        {
            return _dbContext.Users.Where(x => x.Id == id).FirstOrDefault();
        }

        private string PasswordSHA256Hash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }

                return sb.ToString();
            }
        }
    }
}
