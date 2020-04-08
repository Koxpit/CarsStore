using CarsStore.Interfaces;
using CarsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsStore.Data.Repository
{
    public class OrderRepository : IAllOrders
    {
        private readonly CarsStoreContext carsStoreContext;
        private readonly ShopCart shopCart;
        public OrderRepository(CarsStoreContext carsStoreContext, ShopCart shopCart)
        {
            this.carsStoreContext = carsStoreContext;
            this.shopCart = shopCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            carsStoreContext.Order.Add(order);

            carsStoreContext.SaveChanges();

            var items = shopCart.ListShopItems;

            foreach(var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    CarId = el.Car.Id,
                    OrderId = order.Id,
                    Price = el.Car.Price
                };
                carsStoreContext.OrderDetail.Add(orderDetail);
            }
            
            carsStoreContext.SaveChanges();
        }
    }
}
