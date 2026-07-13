using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHub.Domain.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
