using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseInteractor.Models
{
    public class Product : AbstractEntity
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual int Weight { get; set; }
        public virtual int Height { get; set; }
        public virtual int Width { get; set; }
        public virtual int Length { get; set; }
    }
}
