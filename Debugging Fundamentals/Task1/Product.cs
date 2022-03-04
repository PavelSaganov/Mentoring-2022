﻿namespace Task1
{
    public class Product
    {
        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }

        public double Price { get; set; }

        public override bool Equals(object obj)
        {
            Product productObj = obj as Product;
            if (productObj == null)
                return false;
            else
                return Name.Equals(productObj.Name) && Price.Equals(productObj.Price);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() * Price.GetHashCode() / 12;
        }
    }
}
