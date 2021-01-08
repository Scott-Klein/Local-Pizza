const ordersControl = {
    template:
        /*html*/
        `
        <div>
            <h4>Orders Control</h4>
            <order-table></order-table>
        </div>
        `
}

const app = Vue.createApp(ordersControl);

app.component('order-table', {
    template:
        /*html*/
        `
        <div>
            <table>
                <tr v-for="order in orders">
                    <td>{{order.id}}</td>
                    <td>{{order.name}}</td>
                    <td>{{order.phone}}</td>
                    <td>{{order.name}}</td>
                    <td>{{this.StatusEnum[order.status]}}</td>
                    <td><button type="button" @click="ProgressOrder(order.id)">Progress Order</button></td>
                </tr>
            </table>
        </div>
        `,
    created() {
        fetch("/api/order").then(Response => Response.json())
            .then(data => {
                this.orders = data.sort(this.SortById);

        })
        this.connection = new signalR.HubConnectionBuilder().withUrl('/ordershub').build();
        this.connection.on("UpdateOrder", this.UpdateOrder);
        this.connection.on("AddNewOrder", this.AddNewOrder);
        this.connection.on("TestBack", this.TestBack);
        this.connection.start().then(() => {
            this.connection.invoke("StartUpdates");
        });
    },
    data() {
        return {
            orders: [],
            connection: {},
            StatusEnum: {
                0: "Created",
                1: "Preparing",
                2: "Out for Delivery",
                3: "Delivered"
            },
        }
    },
    methods: {
        TestBack() {
            console.log("tested hub okay");
        },
        ProgressOrder(id) {
            console.log("Invoking update order status");
            this.connection.invoke("UpdateStatus", id);
        },
        OnTabClose(e) {
            this.connection.invoke("AbortConnection");
        },
        SortById(a, b) {
            if (a.id < b.id) {
                return 1;
            } else if (a.id > b.id) {
                return -1;
            } else {
                if (a.status > b.status) {
                    return 1;
                } else if (a.status < b.status) {
                    return -1;
                } else {
                    return 0;
                }
            }
        },
        UpdateOrder(order) {
            console.log("Updating order");
            console.log("order status " + this.StatusEnum[order.status]);
            for (let i = 0; i < this.orders.length; i++) {
                if (this.orders[i].id == order.id) {
                    this.orders[i] = order;
                    console.log("Changed an order in the array (or tried to)")
                }
            }
        },
        AddNewOrder(order) {
            console.log("Pushing order")
            this.orders.push(order);
            this.orders = this.orders.sort(this.SortById);
        }
    }
})

app.mount('#app')