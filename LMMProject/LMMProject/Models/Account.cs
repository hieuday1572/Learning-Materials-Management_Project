using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMMProject.Models
{
    public class Account
    {
        [Key]
        public string userName { get; set; }

        public string password { get; set; }

        public string image { get; set; }

        public long phone { get; set; }

        public string address { get; set; }

        public int gender { get; set; }

        public string gmail { get; set; }

        public string fullname { get; set; }

        public DateTime birthday { get; set; }

        public bool active { get; set; }

        [ForeignKey("Role")]
        
        public int roleId { get; set; }

        public Role role { get; set; }

        
    }
}
