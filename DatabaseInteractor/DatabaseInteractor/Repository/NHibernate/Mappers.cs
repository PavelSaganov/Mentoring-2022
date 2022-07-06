using DatabaseInteractor.Models;
using DatabaseInteractor.Models.Enums;
using FluentNHibernate.Mapping;

namespace DatabaseInteractor.Repository.NHibernate
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
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
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Status).CustomType<Status>();
            Map(x => x.CreatedDate);
            Map(x => x.UpdatedDate);
            Map(x => x.ProductId);
        }
    }
}
