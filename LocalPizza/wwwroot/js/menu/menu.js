
const menu = {
    template:
    /*html*/
        `
        <div>
            <customise-form id="customiseForm" v-show="showCustomMenu" :item="selectedPizza"/>
            <p v-for="item in products">{{item}}</p>
            <menu-item v-for="item in products" :item="item" @customise="showCustomisePage"/>
        </div>
        `,
    data() {
        return {
            products: [],
            traditional: [],
            premium: [],
            drink: [],
            dessert: [],
            side: [],
            topping: [],
            randomNum: 5,
            showCustomMenu: false,
            selectedPizza: {name: "noPizza"}
        }
    },
    methods: {
        showCustomisePage(item) {
            console.log("Customising pizza named " + item.name);
            this.selectedPizza = item;
            this.showCustomMenu = !this.showCustomMenu;
            //setTimeout(() => { this.showCustomMenu = false; }, 2000);
        }
    },
    created() {
        //Need to pull all of the menu items out.
        fetch('api/menu')
            .then(Response => Response.json())
            .then(data => this.products = data)
            .then(console.log(this.products[1]))
    }
}




const app = Vue.createApp(menu)

//I will register all of my components here.
app.component('menu-item', {
    props: {
        item: Object
    },
    methods: {
        customiseItem() {
            //this should spawn a new customiser in front of everything else.
            this.$emit('customise', this.item);
        }
    },
    template:
        /*html*/
        `
        <div class="menuItem">
            <h4>{{this.item.name}}</h4>
            <p>{{this.item.description}}</p>
            <p><strong>$</strong> {{this.item.price}}</p>
            <img class="productImg" :src="'/images/' + this.item.productPicture" />
            <button @click="customiseItem">Add to Cart</button>
        </div>
        `
})

app.component('customise-form', {
    props: {
        item: Object
    },
    updated() {
        console.log("item was updated");
        console.log(this.item.name)
    },
    template:
        /*html*/
        `
        <div>
        <h2>{{this.item.name}}</h2>
            <form class="customiseForm" @submit.prevent="AddPizzaToCart">
                <h4>Crust</h4>
                <label for="regular">Regular</label>
                <input type="radio" id="regular" name="crust" value="regular">
                <label for="thin">Thin</label>
                <input type="radio" id="thin" name="crust" value="thin">
                <label for="deep">Deep Pan</label>
                <input type="radio" id="deep" name="crust" value="deep">
                <br/>
                <h4>2.Choose Your Sauce</h4>
                <label for="tomato">Tomato</label>
                <input type="radio" id="tomato" name="sauce" value="tomato">
                <label for="bbq">BBQ</label>
                <input type="radio" id="bbq" name="sauce" value="bbq">
                <label for="frenchCreme">French Creme</label>
                <input type="radio" id="frenchCreme" name="sauce" value="frenchCreme">
                <br/>
                <h4>3.Toppings</h4>
                <div v-for="topping in item.toppings">
                    <input type="checkbox" :id="topping.id" :name="topping.id" :value="topping.id">
                    <label :for="topping.id">{{topping.name}}</label><br>
                </div>
            </form>
        </div>
        `
})



app.mount('#menu');