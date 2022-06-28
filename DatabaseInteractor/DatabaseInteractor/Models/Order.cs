using System;
using System.Collections.Generic;
using System.Text;
using DatabaseInteractor.Models.Enums;

namespace DatabaseInteractor.Models
{
    public class Order : AbstractEntity
    {
        public virtual Status Status { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime UpdatedDate { get; set; }
        public virtual int ProductId { get; set; }
    }
}
