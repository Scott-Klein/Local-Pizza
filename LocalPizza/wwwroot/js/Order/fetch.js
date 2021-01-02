function appendCart() {
    let order = {
        DeliveryAddress: {
            Unit: document.getElementById('CurrentOrder_DeliveryAddress_Unit').value,
            StreetNumber: document.getElementById('CurrentOrder_DeliveryAddress_StreetNumber').value,
            StreetName: document.getElementById('CurrentOrder_DeliveryAddress_StreetName').value,
            Suburb: document.getElementById('CurrentOrder_DeliveryAddress_Suburb').value,
            PostCode: document.getElementById('CurrentOrder_DeliveryAddress_PostCode').value,
        },
        PhoneNumber: document.getElementById('CurrentOrder_PhoneNumber').value,
        Name: document.getElementById('CurrentOrder_Name').value,
        DeliveryInstructions: document.getElementById('CurrentOrder_DeliveryInstructions').value,
        RequestDelivery: document.getElementById('CurrentOrder_RequestDelivery').value,
        OrderItems: JSON.parse(localStorage.getItem('cart'))

    };

    fetch("/api/Order", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(order)
    }).
        then(response => {
            return response.json();
        })
        .then(data => {
            SaveOrderToStorage(data);
        })
}

function SaveOrderToStorage(order) {
    localStorage.setItem('order', JSON.stringify(order));
    localStorage.removeItem('cart');
    window.location.href = "/Complete";
}