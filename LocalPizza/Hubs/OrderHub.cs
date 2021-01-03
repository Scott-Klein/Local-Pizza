using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LocalPizza.Core;
using LocalPizza.Data;
using Microsoft.AspNetCore.SignalR;

namespace LocalPizza.Hubs
{
    public class OrderHub : Hub
    {
        private readonly IDataAccess data;

        public OrderHub(IDataAccess data)
        {
            this.data = data;
        }
        public async Task GetOrderUpdates(int id)
        {
            OrderStatus currentStatus = data.GetOrderStatus(id); ;
            var rand = new Random();
            do
            {
                OrderStatus newStatus = (OrderStatus)rand.Next(0, 3);
                //var newStatus = data.GetOrderStatus(id);
                if (newStatus != currentStatus)
                {
                    await Clients.Caller.SendAsync("UpdateStatus", newStatus);
                    currentStatus = newStatus;
                }
                Thread.Sleep(2000);
            } while (currentStatus != OrderStatus.Completed);
            await Clients.Caller.SendAsync("Finished");
        }
    }
}
