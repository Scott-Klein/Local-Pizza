const OrderView = {
    template:
        /*html*/
        `
        <div>
            {{order}}
        </div>
        `,
    data() {
        return {
            order: null
        }
    },
    created() {
        const order = JSON.parse(localStorage.getItem('order'));
        console.log(order);
        this.order = order;
    }
}