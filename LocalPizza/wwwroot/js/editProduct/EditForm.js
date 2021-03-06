app.component('edit-form', {
    props: {
        itemid: {
            type: Number,
        },
        proprange: {
            type: Number,
        }
    },
    template:
        /*html*/
        `
    <div>
        <form id="editForm" @submit.prevent="SubmitForm" enctype="multipart/form-data">
            <label for="name">Product Name</label>
            <input id="name" v-model="name" >
            <label for="price">Price ($)</label>
            <input id="price" v-model.number="price">
            <label for="range">Range</label>
            <select id="range" v-model.number="range" @change="ChangedSelection">
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
            <div id="toppingsForm" v-show="showToppings">
                <label>Toppings</label>
                <br>
                <button type="button" class="toppingButton" v-for="(topping, index) in selectedToppings" v-on:click="removeFromPizza(topping)"> {{ this.selectedToppings.get(topping[0]).name }} <span class="cross">X</span></button>
                <br>
                <div class="toppingsList">
                    <ul>
                        <li v-for="(topping, index) in availableToppings"> <button type="button" v-on:click="addToPizza(topping)">{{ this.availableToppings.get(topping[0]).name }}</button> </li>
                    </ul>
                </div>
            </div>


            <input type="submit" value="Save">
            <p id="message" class="display">Database Updated!</p>
        </form>
    </div>
    `,
    methods: {
        ChangedSelection() {
            if (this.range > 1)
            {
                //lets hide the toppings okay.
                console.log("Hide the toppings")
                this.showToppings = false;
            }
            else {
                this.showToppings = true;
            }
        },
        addToPizza(topping) {
            this.selectedToppings.set(topping[0], topping[1]);
            this.availableToppings.delete(topping[0]);
        },
        removeFromPizza(topping) {
            console.log("removing " + topping[0] + " " + topping[1].name)
            this.availableToppings.set(topping[0], topping[1]);

            this.selectedToppings.delete(topping[0]);
        },
        ConvertToArray(inMap) {
            let array = new Array();
            let it = inMap[Symbol.iterator]();
            for (const element of it) {
                array.push(inMap.get(element[0]).id);
            }

            return array;
        },
        DisplayUpdatedMessage()
        {
            document.getElementById('message').classList.add('showBriefly');
            setTimeout(function () {
                document.getElementById('message').classList.remove('showBriefly');
            }, 6000);
        },
        PostToppings(id)
        {
            fetch('/api/Toppings/' + id, {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json;charset=utf-8'
                    },
                    body: JSON.stringify(this.ConvertToArray(this.selectedToppings))
                })
                .then(response => console.log("Toppings response: " + response.statusText));
        },
        FetchItem(id)
        {
            fetch('/api/items/' + id).then(Response => Response.json()).then((data) => {
                this.itemData = data;
                this.name = this.itemData.name;
                this.price = this.itemData.price;
                this.range = this.itemData.range;
                if (this.range < 2)
                {
                    this.showToppings = true;
                }
                else
                {
                    this.showToppings = false;
                }
                this.description = this.itemData.description;
                this.itemData.toppingsList.forEach(topping => {
                    this.selectedToppings.set(topping.id, topping);
                });

            }).then(() => {
                fetch('/api/Toppings')
                    .then(Response => Response.json())
                    .then(data => {
                        data.forEach(topping =>
                        {
                            if (!this.selectedToppings.has(topping.id))
                            {
                                this.availableToppings.set(topping.id, topping);
                            }
                        });
                    })
            })
        },
        UploadImage(id)
        {
            if (document.getElementById('imageFile').files.length == 1)
            {
                const selectedFile = document.getElementById('imageFile').files[0];
                const formData = new FormData();
                formData.append('image', selectedFile);
                fetch('/api/ProductImage?id=' + id + '&range=' + this.range, {
                    method: 'POST',
                    body: formData
                }).then(response => console.log(response.status));
            }
        },
        SubmitForm() {
            //If it isn't a topping, we will handle adding a regular item to the database.
            let id;
            if (this.range != 5) // 5 is the enum assigned to toppings
            {
                let item = {
                    Id: this.itemid,
                    Price: this.price,
                    Name: this.name,
                    Description: this.description,
                    Range: this.range,
                }

                fetch('/api/Items', {
                        method: 'POST',
                        headers: {
                            'Content-Type': 'application/json;charset=utf-8'
                        },
                        body: JSON.stringify(item)
                    })
                    .then(response => {
                        console.log(item);
                        if (this.itemid = 0 || this.itemid == undefined)
                        {
                            console.log("Item id is!")
                            console.log(this.itemid);
                            response.json().then(data => {
                                returnedId = data.id;
                                this.UploadImage(returnedId);
                                this.PostToppings(data.id);
                            })
                        }
                        else
                        {
                            this.PostToppings(this.itemid);
                            this.UploadImage(this.itemid);
                        }

                    });
            } else {
                console.log("Adding topping to database!");

                let topping = {
                    Id: this.itemid,
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
                    .then(response => response.json().then(data => {
                        this.UploadImage(data.id);
                    }))
            }
            this.DisplayUpdatedMessage();
        },
        FetchTopping(id)
        {
            fetch('/api/Toppings/' + id).then(Response => Response.json()).then((data) => {
                this.itemData = data;
                this.name = this.itemData.name;
                this.price = this.itemData.price;
                this.range = this.proprange;
                this.showToppings = false;
            })
        }
    },
    data() {
        return {
            showToppings: true,
            itemData: null,
            name: null,
            price: 0,
            range: 0,
            description: null,
            availableToppings: [],
            selectedToppings: [],
            returnedId: 0
        }
    },
    created() {
        console.log("dammit" + this.itemid + " " + this.proprange)
        this.availableToppings = new Map();
        this.selectedToppings = new Map();
        if (this.itemid != undefined) {
            //Do API Call here initially
            if (this.proprange != 5)
            {
                this.FetchItem(this.itemid);
            }
            else
            {
                this.FetchTopping(this.itemid);
            }
        } else // else this is a new item that we will add.
        {
            fetch('/api/Toppings')
                .then(Response => Response.json())
                .then(data => {
                    data.forEach(topping => {
                            this.availableToppings.set(topping.id, topping);
                    });
                })
        }
    }
})