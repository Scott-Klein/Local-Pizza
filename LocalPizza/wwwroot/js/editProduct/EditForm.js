app.component('edit-form', {
    props: {
        itemid: {
            type: Number,
            required: true
        }
    },
    template:
        /*html*/
        `
    <div>
        <form id="editForm" @submit.prevent="SubmitForm" >
            <label for="name">Product Name</label>
            <input id="name" v-model="name" >
            <label for="price">Price ($)</label>
            <input id="price" v-model.number="price">
            <label for="range">Range</label>
            <select id="range" v-model.number="range">
                <option value="0">Traditional</option>
                <option value="1">Premium</option>
                <option value="2">Drink</option>
                <option value="3">Dessert</option>
                <option value="4">Side</option>
                <option value="5">Topping</option>
            </select>

            <label for="description">Description</label>
            <textarea id="description" v-model="description"></textarea>

            <label for="imageFile">Image</label>
            <input type="file" id="imageFile">

            <label>Toppings</label>
            <br>
            <button type="button" class="toppingButton" v-for="(topping, index) in selectedToppings" @mouseover="updateTopping(index)" v-on:click="removeFromPizza(topping)"> {{ this.selectedToppings.get(topping[0]).name }} <span class="cross">X</span></button>
            <br>
            <br>FUCK
            <div class="toppingsList">
                <ul>
                    <li v-for="(topping, index) in availableToppings"> <button type="button" @mouseover="updateTopping(index)" v-on:click="addToPizza(topping)">{{ this.availableToppings.get(topping[0]).name }}</button> </li>
                </ul>
            </div>
            <input type="submit" value="Save">
        </form>
    </div>
    `,
    methods: {
        addToPizza(topping) {
            this.selectedToppings.set(topping[0], topping[1]);
            this.availableToppings.delete(topping[0]);
        },
        updateTopping(index) {
            this.selectedIndex = index;
        },
        removeFromPizza(topping) {
            console.log("removing " + topping[0] + " " + topping[1].name)
            this.availableToppings.set(topping[0], topping[1]);

            this.selectedToppings.delete(topping[0]);

        },
        SubmitForm() {
            //If it isn't a topping, we will handle adding a regular item to the database.
            if (this.range != 5) // 5 is the enum assigned to toppings
            {
                //Stand-in
                console.log("Adding item to database!");
                console.log("Why is this running?")

                let item = {
                    Id: this.itemid,
                    Price: this.price,
                    Name: this.name,
                    Description: this.description,
                    Range: this.range
                }

                fetch('/api/Items', {
                        method: 'POST',
                        headers: {
                            'Content-Type': 'application/json;charset=utf-8'
                        },
                        body: JSON.stringify(item)
                    })
                    .then(response => console.log(response.statusText));
            } else {
                console.log("Adding topping to database!");
                let topping = {
                    Name: this.name,
                    Price: this.price
                }

                fetch('/api/Toppings', {
                        method: 'POST',
                        headers: {
                            'Content-Type': 'application/json;charset=utf-8'
                        },
                        body: JSON.stringify(topping)
                    })
                    .then(response => console.log(response.statusText))
            }
        }
    },
    data() {
        return {
            itemData: null,
            name: null,
            price: 0,
            range: 0,
            description: null,
            availableToppings: [],
            selectedToppings: []
        }
    },
    created() {
        this.availableToppings = new Map();
        this.selectedToppings = new Map();
        //Do API Call here initially
        fetch('/api/items/' + this.itemid).then(Response => Response.json()).then((data) => {
            this.itemData = data;
            this.name = this.itemData.name;
            this.price = this.itemData.price;
            this.range = this.itemData.range;
            this.description = this.itemData.description;
        })

        fetch('/api/Toppings')
            .then(Response => Response.json())
            .then(data => {
                console.log(data);
                data.forEach(topping => {
                    this.availableToppings.set(topping.id, topping);
                });
            })

    }
})