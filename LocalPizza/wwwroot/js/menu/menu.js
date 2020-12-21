
const menu = {
    template:
    /*html*/
        `
        <div>
            <customise-form id="customiseForm" v-show="showCustomMenu" :item="selectedPizza"/>
            <p v-for="item in products">{{item}}</p>
            <h2>Traditional Menu</h2>
            <menu-item v-for="item in traditional" :item="item" @customise="showCustomisePage"/>
            <h2>Premium Menu</h2>
            <menu-item v-for="item in premium" :item="item" @customise="showCustomisePage"/>
            <h2>Drink Menu</h2>
            <menu-item v-for="item in drink" :item="item" @customise="showCustomisePage"/>
            <h2>Side Menu</h2>
            <menu-item v-for="item in side" :item="item" @customise="showCustomisePage"/>
            <h2>Dessert Menu</h2>
            <menu-item v-for="item in dessert" :item="item" @customise="showCustomisePage"/>
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
        sortMenu() {
            if (this.products.length > 0) {
                console.log("Running Menu Sorter")
                console.log(this.products.length);
                this.products.forEach(product => {
                switch (product.range) {
                    case 0: //Traditonal
                        this.traditional.push(product);
                        break;
                    case 1: //Premium
                        this.premium.push(product);
                        break;
                    case 2: //Drink
                        this.drink.push(product);
                        break;
                    case 3: //Dessert
                        this.dessert.push(product);
                        break;
                    case 4: //side
                        this.side.push(product);
                        break;
                    case 5: //topping
                        //This is a big error if this case occurs
                        console.log("Topping has somehow come out of a menu. Debug: menu.js> menu > methods > sortMenu().")
                        break;
                }
            });
            }

            //console.log("Traditionals: " + traditional.length)
        },
        showCustomisePage(item) {
            this.selectedPizza = item;
            this.showCustomMenu = !this.showCustomMenu;
            //setTimeout(() => { this.showCustomMenu = false; }, 2000);
        }
    },
    created() {
        //Need to pull all of the menu items out.
        fetch('api/menu')
            .then(Response => Response.json())
            .then(data => {
                this.products = data;
            })
            .then(() => {
                this.sortMenu();
            })
    },
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

    },
    methods: {
        AddPizzaToCart() {
            console.log("Pizza added... NOT");
        }
    },
    computed: {
        isPizza() {
            return this.item.range < 2 ? true : false;
        }
    },
    template:
        /*html*/
        `
        <div>
            <customise-pizza v-show="isPizza" :item="this.item"/>
            <customise-item v-show="!isPizza" :item="this.item"/>
        </div>
        `
})

app.component('customise-item', {
    props: {
        item: Object
    },
    methods: {
        AddItemToCart() {
            console.log(" WARNING: Item adding to cart not implemented");
        }
    },
    template:
        /*html*/
        `
            <div>
                <h2>{{this.item.name}}</h2>
                <p>{{this.item.description}}</p>
                <button @click.prevent="AddItemToCart">Add To Cart!</button>
            </div>
        `
})

app.component('customise-pizza', {
    props: {
        item: Object
    },
    methods: {
        AddPizzaToCart() {
            console.log(" WARNING: Pizza adding to cart not implemented");
        },
        ResetCheckBoxes() {
            //uncheck all the boxes

            this.toppings.forEach(element => {
                let check = document.getElementById(element.id);
                if (check != undefined) {
                    document.getElementById(element.id).checked = false;
                }

            })
        },
        ToppingChecked(index) {
            let el = this.toppings[index];
            if (document.getElementById(el.id).checked) {
                return true;
            } else {
                return false;
            }
        }
    },
    data() {
        return {
            toppings: [],
            initialised: false,
            itemId: 5000
        }
    },
    created() {
        fetch('/api/toppingview')
            .then(response => response.json())
            .then(data => this.toppings = data);
    },
    updated() {
        if (this.item.toppings != undefined)
        {
            this.ResetCheckBoxes();

            //check every box of each default topping.
            this.item.toppings.forEach(element => {
                document.getElementById(element.id).checked = true;
            });
            if (this.itemId != this.item.id) {
                let front = this.toppings.filter(el => document.getElementById(el.id).checked);
                front.forEach(element => {
                    console.log(element.name)
                });
                let back = this.toppings.filter(el => !document.getElementById(el.id).checked);
                this.toppings = front.concat(back);
                this.itemId = this.item.id;
            }

        }
    },
    computed: {
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
                <div v-for="topping in toppings">
                    <input type="checkbox" :id="topping.id" :name="topping.id" :value="topping.id">
                    <label :for="topping.id">{{topping.name}}</label><br>
                </div>
            </form>
        </div>
        `
})


app.mount('#menu');