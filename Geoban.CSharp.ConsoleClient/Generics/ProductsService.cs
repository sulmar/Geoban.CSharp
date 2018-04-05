using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geoban.CSharp.ConsoleClient.Generics
{
    public abstract class Base
    {
        public int Id { get; set; }
    }

    public class Product : Base
    {
        public string Name { get; set; }
    }

    public class Customer : Base
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        private string color;
        public string Color
        {
            get => color;

            set => color = value;
        }

    }

    //public class ProductsService
    //{
    //    private IList<Product> products = new List<Product>();

    //    public void Add(Product product)
    //    {
    //        products.Add(product);
    //    }

    //    public IList<Product> Get()
    //    {
    //        return products;
    //    }
    //}

    //public class CustomersService
    //{
    //    private IList<Customer> customers = new List<Customer>();

    //    public void Add(Customer customer)
    //    {
    //        customers.Add(customer);
    //    }

    //    public IList<Customer> Get()
    //    {
    //        return customers;
    //    }
    //}

    public interface IItemsService<TItem>
    {
        IList<TItem> Get();
        TItem Get(int id);
        void Add(TItem item);
        void Remove(int id);
    }

    public interface ICustomersService : IItemsService<Customer>
    {
        IList<Customer> Get(string name);
    }

    public interface IProductsService : IItemsService<Product>
    {

    }

    public class CustomersService : ItemsService<Customer>
    {
        public IList<Customer> Get(string name)
        {
            return items.Where(c => c.LastName == name).ToList();
        }

        public override void Remove(int id)
        {
        }
    }

    public class ProductsService : ItemsService<Product>
    {

    }

    public class Order : Base
    {
        public string OrderNumber { get; set; }

        public Order()
        {

        }

        public Order(string orderNumber)
        {

        }
    }

    public class OrdersService : ItemsService<Order>
    {
    }

    public class ItemsService<TItem>
        where TItem : Base, new()
    {
        protected IList<TItem> items = new List<TItem>();

        public virtual void Add(TItem item) => items.Add(item);

        public virtual TItem Create() => new TItem();

        public virtual IEnumerable<TItem> Get() => items;

        public virtual TItem Get(int id)
        {
            return items.FirstOrDefault(item => item.Id == id);
        }

        public virtual void Remove(int id)
        {
            var item = Get(id);

            items.Remove(item);


        }
    }

    //public class ItemsService
    //{
    //    private IList<object> items = new List<object>();

    //    public void Add(object item)
    //    {
    //        items.Add(item);
    //    }

    //    public IList<object> Get()
    //    {
    //        return items;
    //    }

    //    public object Get(int id)
    //    {

    //    }
    //}

}
