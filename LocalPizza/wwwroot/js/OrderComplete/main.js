const OrderView = {
    template:
        /*html*/
        `
        <div id="grid-container">
            <div>
                <order-tracker :status="this.order.status" @clear-data="this.clearData()"></order-tracker>
                <order-data :order="this.order"></order-data>
            </div>
            <order-items :order="this.order"></order-items>

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


app.component('order-tracker',
    {
        props: {
            status: Number
        },
        computed: {
            dashArray() {
                let statusPercent = this.status / 3;
                return  (statusPercent * 534) + ", 534";
            },
            circleClass() {
                switch (this.status) {
                    case 0:
                        return "circle-chart__circle created"
                    case 1:
                        return "circle-chart__circle preparing"
                    case 2:
                        return "circle-chart__circle delivery"
                    case 3:
                        this.$emit('clear-data');
                        return "circle-chart__circle finished"
                    default:
                        break;
                }
            },
            dot() {
                let offset = 40;
                return offset + this.status * 40;
            }
        },
        template:
            /*html*/
            `
            <div id="order-tracker" class="order-pane">
                <div id="order-circle">
                    <h2>Order Tracker</h2>
                    <svg class="circle-chart" viewbox="0 0 180 180" width="180" height="180" xmlns="http://www.w3.org/2000/svg">
                        <circle :class="this.circleClass" stroke="#ffffff" stroke-width="6"  stroke-linecap="round" fill="none" cx="90" cy="90" r="85" />
                        <circle :class="this.circleClass" stroke="#fff0" stroke-width="6"  stroke-linecap="round" fill="#ffffff3a" cx="90" cy="90" r="55" />
                        <text class="large-svg-text" x="56" y ="98" fill="white">60</text>
                        <text class="small-svg-text" x="58" y ="123" fill="white">Minutes</text>

                    </svg>
                    <svg height="30" width="200">
                        <circle :cx="this.dot" cy="15" r="9" stroke="#fff0" stroke-width="2" fill="#fff"/>
                        <circle cx="40" cy="15" r="9" stroke="#fff0" stroke-width="2" fill="#fff4"/>
                        <circle cx="80" cy="15" r="9" stroke="#fff0" stroke-width="2" fill="#fff4"/>
                        <circle cx="120" cy="15" r="9" stroke="#fff0" stroke-width="2" fill="#fff4"/>
                        <circle cx="160" cy="15" r="9" stroke="#fff0" stroke-width="2" fill="#fff4"/>
                    </svg>
                    <p id="status-indicator">{{this.StatusEnum[this.status]}}</p>
                </div>
            </div>
            `,
        data() {
            return {
                StatusEnum: {
                    0: "Created",
                    1: "Preparing",
                    2: "Out for Delivery",
                    3: "Delivered"
                }
            }
        }
    }
)

app.component('order-data', {
    props: {
        order: Object
    },
    template:
        /*html*/
        `
        <div id="order-data" class="order-pane">
            <h2>Delivery details</h2>
            <p>Requested Delivery Time: {{order.requestDeliveryTime}}</p>
            <p>Delivery Instructions:<br>{{order.deliveryInstructions}}</p>
            <p>Name: {{order.name}}</p>
            <p>Phone: {{order.phone}}</p>
        </div>
        `
})

app.component('order-items', {
    props: {
        order: Object
    },
    template:
    /*html*/
        `
        <div id="order-items" class="order-pane">
            <h2>Your Order</h2>
            <div class="order-grid" v-for="item in order.orderItems">
                <p>{{item.item.name}}</p>
                <p>Quantity : {{item.quantity}}</p>
                <p> $ {{item.quantity * item.item.price}}</p>
            </div>
        </div>
        `
})

app.mount('#app')


            //<h4>Order number: {{order.id}}</h4>
            //<div v-for="item in order.orderItems">
            //    <h5>{{item.item.name}}</h5>
            //    <p>Quantity : {{item.quantity}}</p>
            //    <p>Price : $ {{item.quantity * item.item.price}}</p>
            //</div>
            //<p>{{AddressLine[0]}}</p>
            //<p>{{AddressLine[1]}}</p>
            //<p>RequestedDelivery Time: {{order.requestDeliveryTime}}</p>
            //<p>Delivery Instructions: {{order.deliveryInstructions}}</p>
            //<p>Name: {{order.name}}</p>
            //<p>Phone: {{order.phone}}</p>
            //<p>Status: {{this.StatusEnum[order.status]}}</p>
            //<button type="button" @click="clearData">Clear order data</button>