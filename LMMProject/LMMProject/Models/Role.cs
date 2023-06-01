using System.ComponentModel.DataAnnotations;

namespace LMMProject.Models
{
    public class Role
    {
        [Key]
        public int roleId { get; set; }
        public string roleName { get; set; }
    }
}
