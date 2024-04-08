using Desafio_Core.Enums;

namespace Desafio_Core.Models
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public string Email { get; set; }        
    }
}