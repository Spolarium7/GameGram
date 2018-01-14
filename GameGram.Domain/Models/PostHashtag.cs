using GameGram.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGram.Domain.Models
{
    public class PostHashtag : BaseModel
    {
        public Guid? PostId { get; set; }

        public string Hashtag { get; set; }

        public virtual Post Post { get; set; }

    }
}
