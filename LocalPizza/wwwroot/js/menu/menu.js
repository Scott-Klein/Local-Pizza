
const menu = {
    template:
    /*html*/
        `
        <div>
            <customise-form id="customiseForm" v-show="showCustomMenu" :item="selectedPizza" @pizza-push="PizzaPush" @item-push="ItemPush"/>
            <order id="order" :cart="cart"/>

            <div id="pizzaImg" class="menuImgHeading"><h2>Pizza</h2></div>
            <h2 class="MenuHeading">Traditional Range</h2>
            <div class="flexContainer">
                <menu-item v-for="item in traditional" :item="item" @customise="showCustomisePage"/>
            </div>
            <h2 class="MenuHeading">Premium Range</h2>
            <div class="flexContainer">
                <menu-item v-for="item in premium" :item="item" @customise="showCustomisePage"/>
            </div>
            <div id="drinkImg" class="menuImgHeading"><h2>Drinks</h2></div>
            <div class="flexContainer">
                <menu-item v-for="item in drink" :item="item" @customise="showCustomisePage"/>
            </div>
            <div id="sideImg" class="menuImgHeading"><h2>Sides</h2></div>
            <div class="flexContainer">
                <menu-item v-for="item in side" :item="item" @customise="showCustomisePage"/>
            </div>
            <div id="dessertImg" class="menuImgHeading"><h2>Dessert</h2></div>
            <div class="flexContainer">
                <menu-item v-for="item in dessert" :item="item" @customise="showCustomisePage"/>
            </div>
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
            selectedPizza: { name: "noPizza" },
            cart: {
                cartItems: [],
                cartPizzas: []
            }
        }
    },
    methods: {
        PizzaPush(pizza) {
            this.showCustomMenu = false;
            this.cart.cartPizzas.push(pizza);
        },
        ItemPush(item) {
            this.showCustomMenu = false;
            this.cart.cartItems.push(item);
        },
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
        },
        pizzaAdded(item) {
            console.log("Menu has recieved this pizza");
            console.log(item);
        }
    },
    updated() {
        let cart = JSON.stringify(this.cart);
        localStorage.setItem('cart', cart);
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
        //see if we have a cart in local store
        let c = JSON.parse(localStorage.getItem('cart'));
        if (c) {
            this.cart = JSON.parse(localStorage.getItem('cart'));
        }
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
        <div class="menuItem" @click="customiseItem">
            <img class="productImg" :src="'/images/' + this.item.productPicture" />
            <div class="product-name"><h4>{{this.item.name}}</h4></div>
            <div class="product-description"><p>{{this.item.description}}</p></div>
                <button>$ {{this.item.price}} Customise</button>
        </div>
        `
})
//<div class="menuItem">
//    <img class="productImg" :src="'/images/' + this.item.productPicture" />
 //
//    <p>{{this.item.description}}</p>
//    <p><strong>$</strong> {{this.item.price}}</p>
//    <button @click="customiseItem">Add to Cart</button>
//</div>
app.component('order', {
    props: {
        cart: {
            cartItems: [],
            cartPizzas: []
        }
    },
    data() {
        return {
            toppings: [],
            Bases: [ // This needs to be made dynamic at some point soon, okay Scotty boy?
                "Tomato",
                "Barbeque",
                "French Creme"
            ],
            Crusts: [
                "Regular",
                "Thin",
                "Deep"
            ],
      }
    },
    created() {
        fetch('/api/toppingview')
            .then(response => response.json())
            .then(data => this.toppings = data);
    },
    methods: {
        removeItem(i) {
            this.cart.cartItems.splice(i, 1);
        },
        removePizza(i) {
            this.cart.cartPizzas.splice(i, 1);
        },
        ToppingText(id) {
            let topping = this.toppings.find(el => el.id == id);
            if (topping != undefined) {
                return topping.name;
            } else {
                return 'loading...'
            }

        }
    },
    template:
        /*html*/
        `
        <div>
            <p>Pizza Orders:</p>
            <div v-for="(pizza, index) in cart.cartPizzas" >
                <h4>{{pizza.name}}</h4>
                <p>Base: {{this.Bases[pizza.base]}}</p>
                <p>Crust: {{this.Crusts[pizza.base]}}</p>
                <p v-for="topping in pizza.toppings">{{ToppingText(topping)}}</p>
                <button @click="removePizza(index)">X</button>
            </div>
            <p>Item Orders:</p>
            <div v-for="(item, index) in cart.cartItems" >
                <h4>{{item.name}}</h4>
                <h5>qty: {{item.qty}}</h5>
                <button @click="removeItem(index)">X</button>
            </div>
        </div>
        `
})

app.component('customise-form', {
    props: {
        item: Object
    },
    methods: {
        pizzaAdded(pizza) {
            //tell parent to hide the configurator.
            this.$emit('pizza-push', pizza);
        },
        itemAdded(item) {
            this.$emit('item-push',item)
        }
    },
    data() {
        return {
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
            <customise-pizza v-show="isPizza" :item="this.item" @pizza-to-cart="pizzaAdded"/>
            <customise-item v-show="!isPizza" :item="this.item" @cart-item="itemAdded"/>
        </div>
        `
})



app.component('customise-item', {
    props: {
        item: Object
    },
    methods: {
        AddItemToCart() {
            let item = {
                name: this.item.name,
                id: this.item.id,
                qty: this.quantity
            }
            this.$emit('cart-item', item);
        },
        Reduce() {
            if (this.quantity > 1) {
                this.quantity--;
            }
        },
        Increase() {
            this.quantity++;
        }
    },
    data() {
        return {
            quantity: 1,
        }
    },
    template:
        /*html*/
        `
            <div>
                <h2>{{this.item.name}}</h2>
                <p>{{this.item.description}}</p>
                <button @click.prevent="Reduce"> - </button>
                <input type="text" id="quantitySelector" :value="quantity">
                <button @click.prevent="Increase"> + </button>
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
            this.pizza.itemId = this.item.id;
            this.pizza.name = this.item.name;
            let checkedToppings = this.toppings.filter(el => document.getElementById(el.id).checked);
            checkedToppings.forEach(topping => {
                this.pizza.toppings.push(topping.id);
            });
            this.$emit('pizza-to-cart', Object.assign({}, this.pizza));
            this.pizza.toppings = [];
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
        },
        baseSelect(base) {
            this.pizza.base = base;
        },
        crustSelect(crust) {
            this.pizza.crust = crust;
        },
    },
    data() {
        return {
            toppings: [],
            selectedToppings: [],
            pizza: {
                name: "",
                itemId: 5000,
                toppings: [],
                base: 0,
                crust: 0,
            },
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

                let back = this.toppings.filter(el => !document.getElementById(el.id).checked);

                this.toppings = front.concat(back);
                this.itemId = this.item.id;
            }

        }
    },
    computed: {
        //GetCheckedToppings() { //this computed property seems to mutate 'this.items' somehow. Even though reading it seems like it's impossible I have proven that it can.
        //    //Absolutely bizarre!
        //    console.log("Get Checked TOppings")
        //    return this.toppings.filter(el => document.getElementById(el.id).checked);
        //}
    },
    template:
        /*html*/
        `
        <div>
            <div id="form">
                <div id="left-form">
                    <h2 class="lightHeading">{{this.item.name}}</h2>
                    <h2 class="lightHeading">$ {{this.item.price}}</h2>
                    <p>{{this.item.description}}</p>
                    <div class="flex">
                        <div id="itemOrderDetail">
                            <h5>Crust</h5>
                            <p>{{this.pizza.crust}}</p>
                            <h5>Base</h5>
                            <p>{{this.pizza.base}}</p>
                            <h5>Toppings</h5>
                            <p v-for="topping in this.pizza.toppings">{{topping}}</p>
                        </div>
                        <div id="itemOrderImage">
                            <img class="detailImg" :src="'/images/' + this.item.productPicture" />
                        </div>
                    </div>

                    <div id="bottom-form">
                        <h2 id="OrderTotal">Price here</h2>
                        <div id="CartButton"><h3>Add To Cart</h3></div>
                    </div>
                </div>
                <div id="right-form">
                    <h3>Customisations</h3>
                    <form class="customiseForm" @submit.prevent="AddPizzaToCart">
                        <h4><span>1.</span>  Choose Your Crust</h4>
                        <div class="crust">
                            <crust-option crust="0"></crust-option>
                            <crust-option crust="1"></crust-option>
                            <crust-option crust="2"></crust-option>
                        </div>

                        <br/>
                        <h4><span>2.</span>  Choose Your Sauce</h4>
                        <div class="crust">
                            <crust-option crust="3"></crust-option>
                            <crust-option crust="4"></crust-option>
                            <crust-option crust="5"></crust-option>
                        </div>
                        <h4>3.Toppings</h4>
                        <div v-for="topping in toppings">
                            <topping-check :topping="topping"></topping-check>
                        </div>
                        <input type="submit" value="Add to cat">
                    </form>
                </div>
            </div>

        </div>
        `
})
app.component('crust-option', {
    props: {
        crust: String,
        base: String,
    },
    template:
        /*html */
        `
        <div>
            <img :src="'/images/crust' + this.crustNum + '.webp'" />
            <p>{{this.Crusts[crust]}}</p>
        </div>
        `,
    methods: {

    },
    computed: {
        crustNum() {
            return Number(this.crust)
        }
    },

    data() {
        return {
            Crusts: [
                "Regular",
                "Thin",
                "Deep",
                "Tomato",
                "BBQ",
                "French Creme"
            ],
        }
    }
})

app.component('topping-check', {
    props: {
        topping: Object
    },
    template:
        /*html*/
        `
        <div>
            
            <p>{{topping.name}}</p>
        </div>
        `
})

app.mount('#menu');