using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseInteractor.Models
{
    public abstract class AbstractEntity
    {
        public virtual int Id { get; set; }
    }
}
