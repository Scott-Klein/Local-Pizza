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
        //Client web app calls this to get information about their order as it progresses.
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

        //Admin web app calls this to ask for new orders to start pouring to it
        public async Task StartUpdates()
        {
            DataBaseAccess.OrderInsertEvent += Data_OrderInsertEvent;
            //Keep alive for 10 hours.
            await Task.Delay(TimeSpan.FromHours(10));
        }

        public async Task AbortConnection()
        {
            await this.AbortConnection();
        }

        private async Task Data_OrderInsertEvent(object sender, OrderInsertedEventArgs e)
        {
            await Clients.Caller.SendAsync("AddNewOrder", e.Order);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            DataBaseAccess.OrderInsertEvent -= Data_OrderInsertEvent;
            await base.OnDisconnectedAsync(exception);
        }
    }
}
