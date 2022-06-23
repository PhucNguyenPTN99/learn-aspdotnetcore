using System.Collections.Generic;
using Meeting.Core.Entities.Common;

namespace Meeting.Core.Entities
{
    public class Category : DateEntity, ISoftDelete
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
        
        public bool IsDeleted { get; set; }
    }
}
