function appendCart() {
    Validate();
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

    return;
    fetch("/api/Order", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(order)
    }).
        then(response => {
            console.log(response);
            return response.json();
        })
        .then(data => {
            SaveOrderToStorage(data);
        })
}

function SaveOrderToStorage(order) {
    localStorage.setItem('order', JSON.stringify(order));
    localStorage.removeItem('cart');
    //window.location.href = "/Complete";
}

function Validate() {
    //validate unit
    let valid = true;
    console.log("Fuck shit")
    const unitEl = document.getElementById('CurrentOrder_DeliveryAddress_Unit');
    const minUnit = unitEl.getAttribute('data-val-range-min');
    const maxUnit = unitEl.getAttribute('data-val-range-max');
    const unit = unitEl.value;
    if (unit > maxUnit || unit < minUnit) {
        //error and don't submit the json.
        console.log("Bad unit")
        valid = false;
    }
    const streetEl = document.getElementById('CurrentOrder_DeliveryAddress_StreetNumber');
    const minStreet = streetEl.getAttribute('data-val-range-min');
    const maxStreet = streetEl.getAttribute('data-val-range-max');
    const street = streetEl.value;
    if (street > maxStreet || street < minStreet) {
        valid = false;
    }

    const streetNameEl = document.getElementById('CurrentOrder_DeliveryAddress_StreetName');
    const maxLength = streetNameEl.getAttribute('data-val-length-max');
    if (streetNameEl.value.length > maxLength) {
        valid = false;
    }

    const suburbEl = document.getElementById('CurrentOrder_DeliveryAddress_Suburb');
    const suburbRegex = suburbEl.getAttribute('data-val-regex-pattern');
    const re = new RegExp(suburbRegex);
    if (!re.test(suburbEl.value)) {
        //throw up the error message.
        const span = document.getElementById('SuburbSpan');
        span.innerText = suburbEl.getAttribute('data-val-regex');
        valid = false;
    }
    else {
        const span = document.getElementById('SuburbSpan');
        span.innerText = suburbEl.getAttribute('data-val-regex');
        valid = false;
    }

}