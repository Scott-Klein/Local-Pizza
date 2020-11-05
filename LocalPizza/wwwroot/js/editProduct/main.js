const app = Vue.createApp({
    data() {
        return {

            Name: '',
            Price: '',
            Range: '',
            Description: '',
            Image: '',
            selectedToppings: ['Bacon', 'Cheese', 'Beef', 'Chicken', 'Pepperoni'],
            availableToppings: ['Capsicum', 'Tomato', 'Carrot', 'Onion', 'Vegan Cheese', 'Dog Sauce', 'Fish things', 'Cat food'],
            selectedIndex: 0
        }
    },
    template:
        /*html*/
        `
    <div>
        <form id="editForm" @submit.prevent="onSubmit">
            <label for="name">Product Name</label>
            <input id="name" v-model="name">

            <label for="price">Price ($)</label>
            <input id="price" v-model.number="price">

            <label for="range">Range</label>
            <select id="range" v-model.number="range">
                <option value="0">Traditional</option>
                <option value="1">Premium</option>
                <option value="2">Drink</option>
                <option value="3">Dessert</option>
                <option value="4">Side</option>
            </select>

            <label for="description">Description</label>
            <textarea id="description" v-model="description"></textarea>

            <label for="imageFile">Image</label>
            <input type="file" id="imageFile">

            <label>Toppings</label>
            <br>
            <button class="toppingButton" v-for="(topping, index) in selectedToppings" @mouseover="updateTopping(index)" v-on:click="removeFromPizza"> {{ topping }} <span class="cross">X</span></button>
            <br>
            <br>
            <div class="toppingsList">
                <ul>
                    <li v-for="(topping, index) in availableToppings"> <button @mouseover="updateTopping(index)" v-on:click="addToPizza">{{ topping }}</button> </li>
                </ul>
            </div>
            <input type="submit" value="Save">
        </form>
    </div>
        `,
    methods: {
        addToPizza() {

            console.log("Adding " + this.availableToppings[this.selectedIndex])

            this.selectedToppings.push(this.availableToppings[this.selectedIndex]);
            if (this.selectedIndex != 0)
            {
                console.log(this.availableToppings.length)
                this.availableToppings.splice(this.selectedIndex, 1);
                console.log(this.availableToppings.length)
            }
            else
            {
                this.availableToppings.shift();
            }
        },
        updateTopping(index) {
            this.selectedIndex = index;
        },
        removeFromPizza() {
            console.log("Removing " + this.selectedToppings[this.selectedIndex]);

            this.availableToppings.push(this.selectedToppings[this.selectedIndex]);
            if (this.selectedIndex != 0) {
                this.selectedToppings.splice(this.selectedIndex, 1);
            }
            else
            {
                this.selectedToppings.shift();
            }
        }
    }
})