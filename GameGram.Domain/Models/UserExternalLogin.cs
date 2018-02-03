using GameGram.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GameGram.Domain.Models
{
    public class UserExternalLogin : BaseModel
    {
        [Required]
        public Guid? UserId { get; set; }

        public string Key { get; set; }

        public string OpenId { get; set; }

        public virtual User User { get; set; }
    }
}
