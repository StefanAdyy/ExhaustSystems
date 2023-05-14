using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class User: BaseEntity
    {
        public int? Id { get; set; } = null;
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt{ get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Role Role { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
