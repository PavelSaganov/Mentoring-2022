using DatabaseInteractor.Models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseInteractor.Config.NHibernate
{
    public class CustomerMap : ClassMap<Product>
    {
        public CustomerMap()
        {
            Id(x => x.Id).GeneratedBy.Guid();
            Map(x => x.Height);
            Map(x => x.Width);
            Map(x => x.Weight);
            Map(x => x.Length);
            Map(x => x.Name);
            Map(x => x.Description);
        }
    }

    public class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            Id(x => x.Id).GeneratedBy.Guid();
            Map(x => x.Status);
            Map(x => x.CreatedDate);
            Map(x => x.UpdatedDate);
            Map(x => x.ProductId);
        }
    }
}
