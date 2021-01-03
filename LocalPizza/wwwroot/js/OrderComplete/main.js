const OrderView = {
    template:
        /*html*/
        `
        <div>
            <button type="button" @click="clearData">Clear order data</button>
            <h4>Order number: {{order.id}}</h4>
            <div v-for="item in order.orderItems">
                <h5>{{item.item.name}}</h5>
                <p>Quantity : {{item.quantity}}</p>
                <p>Price : $ {{item.quantity * item.item.price}}</p>
            </div>
            <p>{{AddressLine[0]}}</p>
            <p>{{AddressLine[1]}}</p>
            <p>RequestedDelivery Time: {{order.requestDeliveryTime}}</p>
            <p>Delivery Instructions: {{order.deliveryInstructions}}</p>
            <p>Name: {{order.name}}</p>
            <p>Phone: {{order.phone}}</p>
            <p>Status: {{this.StatusEnum[order.status]}}</p>
        </div>
        `,
    data() {
        return {
            order: null,
            StatusEnum: {
                0: "Created",
                1: "Preparing",
                2: "Out for Delivery",
                3: "Delivered"
            },
            connection: {}
        }
    },
    created() {
        const order = JSON.parse(localStorage.getItem('order'));
        console.log(order);
        this.order = order;
        this.connection = new signalR.HubConnectionBuilder().withUrl('/ordershub').build();

        this.connection.on("UpdateStatus", this.UpdateStatus);
        this.connection.start().then(() => {
            this.connection.invoke("GetOrderUpdates", this.order.id);
        });
    },
    methods: {
        clearData() {
            localStorage.removeItem('order');
            window.location.href = "/Menu";
        },
        UpdateStatus(newStatus) {
            this.order.status = newStatus;
        }
    },
    computed: {
        AddressLine() {
            const addr = this.order.deliveryAddress;
            let result = ['', '', ''];
            if (addr.unit != undefined && addr.unit != null) {
                result[0] += addr.unit + "/" + addr.streetNumber + " " + addr.streetName;
            }
            result[1] += addr.suburb + " " + addr.postCode;
            result[1] = result[1].toUpperCase();
            return result;
        }
    }
}

const app = Vue.createApp(OrderView);

app.mount('#app')