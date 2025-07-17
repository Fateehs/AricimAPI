using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;

        // Bir kullanıcının birden fazla kovani olabilir
        public ICollection<Hive> Hives { get; set; } = new List<Hive>();
    }
}
