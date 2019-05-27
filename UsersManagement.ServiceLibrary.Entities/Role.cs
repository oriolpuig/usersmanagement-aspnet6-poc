using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsersManagement.ServiceLibrary.Entities
{
    public class Role
    {
        public Role()
        {
            this.Users = new HashSet<User>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
