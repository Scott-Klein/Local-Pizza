# Free ASP.Net Core Pizza website template
![alt text](https://github.com/Scott-Klein/Local-Pizza/blob/master/readme/Landing.png?raw=true)
## Introduction

### What is this?
This project is a free template that uses ASP.Net core and Vue.js. With this starter site you can build a menu of items to sell, provide your own descriptions and images, and allow different customisation options for pizzas.
With it you can also get live updates on orders being made so the kitchen can react immediately to the displayed orders and begin working. Once the kitchen is ready to progress an order they can press a button and this will immediately update the customers page showing the progress.

## How to build
If you have windows available feel free to use visual studio community to get started by cloning the repo and opening the .sln file.

### Setup database

To set up the database delete any migrations that you pulled down from the master repo by deleting the LocalPizza.Data/migrations folder first.
Then from the package manager make sure LocalPizza.Data is the default project
type 'Add-Migration' followed by a name for your migration, for example, Add-Migration initial
You can then investigate the migrations folder and inspect the .cs files to find out how exactly the entity framework tools will apply to the database.
Now run Update-Database

If you are not using visual studio or the package manager console you will want to investigate modifying startup.cs and choosing a different database provider.

Now the built in sql server that comes with visual studio should have the database schema correctly transcribed.

## Running the site
You may then run the debugger and view the website with the browser window that appears.

navigate to /admin to begin populating the website with your products.
![alt text](https://github.com/Scott-Klein/Local-Pizza/blob/master/readme/admin.png?raw=true)

## Place an order

### See the menu
![alt text](https://github.com/Scott-Klein/Local-Pizza/blob/master/readme/menu.jpg?raw=true)

### Customise a pizza
![alt text](https://github.com/Scott-Klein/Local-Pizza/blob/master/readme/Detail.png?raw=true)
### Track an order
![alt text](https://github.com/Scott-Klein/Local-Pizza/blob/master/readme/Successful.png?raw=true)
