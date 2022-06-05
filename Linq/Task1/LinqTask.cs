using System;
using System.Collections.Generic;
using System.Linq;
using Task1.DoNotChange;

namespace Task1
{
    public static class LinqTask
    {
        public static IEnumerable<Customer> Linq1(IEnumerable<Customer> customers, decimal limit)
        {
            return customers.Where(c => c.Orders.Sum(o => o.Total) > limit);
        }

        public static IEnumerable<(Customer customer, IEnumerable<Supplier> suppliers)> Linq2(
            IEnumerable<Customer> customers,
            IEnumerable<Supplier> suppliers
        )
        {
            if (customers is null || suppliers is null)
                throw new ArgumentNullException();

            throw new NotImplementedException();

            //var a = customers.Join(suppliers,
            //    c => (c.Country, c.Country),
            //    s => (s.City, s.Country),
            //    (c, s) => new KeyValuePair<Customer, IEnumerable<Supplier>>()
            //    {

            //    });

            //return a;
        }

        public static IEnumerable<(Customer customer, IEnumerable<Supplier> suppliers)> Linq2UsingGroup(
            IEnumerable<Customer> customers,
            IEnumerable<Supplier> suppliers
        )
        {
            if (customers is null || suppliers is null)
                throw new ArgumentNullException();

            throw new NotImplementedException();
        }

        public static IEnumerable<Customer> Linq3(IEnumerable<Customer> customers, decimal limit)
        {
            if (customers is null)
                throw new ArgumentNullException();

            return customers.Where(c => c.Orders.Any(o => o.Total > limit));
        }

        public static IEnumerable<(Customer customer, DateTime dateOfEntry)> Linq4(
            IEnumerable<Customer> customers
        )
        {
            if (customers is null)
                throw new ArgumentNullException();

            return customers
                .Select((c, date) =>
            {
                if (!c.Orders.Any())
                    return (null, DateTime.MinValue);

                var d = c.Orders.Min(o => o.OrderDate);
                return (customers.
                    FirstOrDefault(cust => cust.Orders.
                    FirstOrDefault(o => o.OrderDate == d) != null), d);
            });
        }

        public static IEnumerable<(Customer customer, DateTime dateOfEntry)> Linq5(
            IEnumerable<Customer> customers
        )
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<Customer> Linq6(IEnumerable<Customer> customers)
        {
            if (customers is null)
                throw new ArgumentNullException();

            return customers.Where(c =>
                !c.PostalCode.All(symbol => Char.IsDigit(symbol))
                || string.IsNullOrWhiteSpace(c.Region)
                || (!c.Phone.Contains('(') || !c.Phone.Contains(')')));
        }

        public static IEnumerable<Linq7CategoryGroup> Linq7(IEnumerable<Product> products)
        {
            //if (products is null)
            //    throw new ArgumentNullException();

            //products.GroupBy(p => p.Category)
            //    .Select(p => new Linq7CategoryGroup()
            //    {
            //        Category = p.Key,
            //        UnitsInStockGroup = new List<Linq7UnitsInStockGroup>()
            //        {
            //            Prices = products
            //                .Where(pr => pr.Category == p.Key)
            //                .Select(pr => pr.UnitPrice),
            //            UnitsInStock = p.Count(),
            //        }
            //    };


            /* example of Linq7result

             category - Beverages
	            UnitsInStock - 39
		            price - 18.0000
		            price - 19.0000
	            UnitsInStock - 17
		            price - 18.0000
		            price - 19.0000
             */

            throw new NotImplementedException();
        }

        public static IEnumerable<(decimal category, IEnumerable<Product> products)> Linq8(
            IEnumerable<Product> products,
            decimal cheap,
            decimal middle,
            decimal expensive
        )
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<(string city, int averageIncome, int averageIntensity)> Linq9(
            IEnumerable<Customer> customers
        )
        {
            throw new NotImplementedException();
        }

        public static string Linq10(IEnumerable<Supplier> suppliers)
        {
            if (suppliers is null)
                throw new ArgumentNullException();

            var result = string.Empty;
            suppliers.OrderBy(s => s.Country.Length)
                .ThenBy(s => s.Country)
                .GroupBy(s => s.Country)
                .Select(s => result += s.Key).ToList();

            return result;
        }
    }
}