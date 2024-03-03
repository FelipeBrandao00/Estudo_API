using System.ComponentModel.DataAnnotations;

namespace API_Produtos.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public static implicit operator UserDTO(User user)
        {
            return new UserDTO()
            {
               Name = user.Name,
               Email = user.Email,
               Password = user.Password,
               Type = user.Type,
            };
        }

        public static implicit operator AddUserDTO(User user)
        {
            return new AddUserDTO()
            {
                Name = user.Name,
                Email = user.Email,
                Type = user.Type,
            };
        }

        public static implicit operator User(UserDTO userDTO)
        {
            return new User()
            {
                Name= userDTO.Name,
                Email = userDTO.Email,
                Password = userDTO.Password,
                Type = userDTO.Type,
            };
        }
    }
}
