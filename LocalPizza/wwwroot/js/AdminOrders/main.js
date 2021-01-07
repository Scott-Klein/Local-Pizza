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
                    {{order}}
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
        this.connection.on("RefreshOrder", this.RefreshOrder);
        this.connection.on("AddNewOrder", this.AddNewOrder);
        this.connection.start().then(() => {
            this.connection.invoke("StartUpdates");
            window.addEventListener("beforeunload", (e) => {
                this.connection.invoke("AbortConnection");
                alert("Hello! I am an alert box!");
            });
        });
    },
    data() {
        return {
            orders: [],
            connection: {}
        }
    },
    methods: {
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
        RefreshOrder(order) {
            for (let i = 0; i < order.length; i++) {
                if (orders[i].id == order.id) {
                    orders[i] = order;
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