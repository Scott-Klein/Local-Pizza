using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LocalPizza.Core;
using LocalPizza.Data;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace LocalPizza.Hubs
{
    public class OrderHub : Hub
    {

        //Client web app calls this to get information about their order as it progresses.
        public async Task GetOrderUpdates(int id)
        {
            var data = new DataBaseAccess(PizzaDbFactory.GetPizzaContext());

            OrderStatus currentStatus = await data.GetOrderStatus(id);
            await Clients.Caller.SendAsync("UpdateStatus", currentStatus);
            do
            {
                data = new DataBaseAccess(PizzaDbFactory.GetPizzaContext());
                var newStatus = await data.GetOrderStatus(id);
                if (newStatus != currentStatus)
                {
                    currentStatus = newStatus;
                    await Clients.Caller.SendAsync("UpdateStatus", currentStatus);
                }
                Thread.Sleep(2000);
            } while (currentStatus != OrderStatus.Completed);
            await Clients.Caller.SendAsync("Finished");
        }

        public async Task UpdateStatus(int id)
        {
            var data = new DataBaseAccess(PizzaDbFactory.GetPizzaContext());
            var updated = await data.IncrementStatus(id);
            await Clients.Caller.SendAsync("UpdateOrder", updated);
        }

        public async Task RevertStatus(int id)
        {
            var data = new DataBaseAccess(PizzaDbFactory.GetPizzaContext());
            var updated = await data.RevertStatus(id);
            await Clients.Caller.SendAsync("UpdateOrder", updated);
        }
        public async Task Test()
        {
            await Clients.Caller.SendAsync("TestBack");
        }
        //Admin web app calls this to ask for new orders to start pouring to it
        public async Task StartUpdates()
        {
            DataBaseAccess.OrderInsertEvent += Data_OrderInsertEvent;
        }

        private async Task Data_OrderInsertEvent(object sender, OrderInsertedEventArgs e)
        {
            await Clients.Caller.SendAsync("AddNewOrder", e.Order);
        }

    }
}
