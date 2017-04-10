using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snowboard.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Guid ModifiedBy { get; set; }
        [Required]
        [Display(Name = "Имя")]
        [MaxLength(50, ErrorMessage = "Максимальная длинна имени 50 символов")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Телефон")]
        public int Phone { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public User()
        {
            Roles = new List<Role>();
        }
    }
}
