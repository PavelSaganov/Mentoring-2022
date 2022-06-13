using System;
using System.Collections.Generic;
using System.Text;
using DatabaseInteractor.Models.Enums;

namespace DatabaseInteractor.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int ProductId { get; set; }
    }
}
