function appendCart() {
    if (!Validate()) {
        return false;
    }
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
    window.location.href = "/Complete";
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
        const span = document.getElementById('unitSpan');
        span.innerText = unitEl.getAttribute('data-val-range');
        valid = false;
    }
    const streetEl = document.getElementById('CurrentOrder_DeliveryAddress_StreetNumber');
    const minStreet = streetEl.getAttribute('data-val-range-min');
    const maxStreet = streetEl.getAttribute('data-val-range-max');
    const street = streetEl.value;
    if (street > maxStreet || street < minStreet) {
        const span = document.getElementById('streetNoSpan');
        span.innerText = streetEl.getAttribute('data-val-range');
        valid = false;
    }

    const streetNameEl = document.getElementById('CurrentOrder_DeliveryAddress_StreetName');
    const maxLength = streetNameEl.getAttribute('data-val-length-max');
    if (streetNameEl.value.length > maxLength) {
        const span = document.getElementById('streetNameSpan');
        span.innerText = streetNameEl.getAttribute('data-val-length');
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

    const postEl = document.getElementById('CurrentOrder_DeliveryAddress_PostCode');
    const postRegex = postEl.getAttribute('data-val-regex-pattern');
    const rep = new RegExp(postRegex);
    if (!rep.test(postEl.value)) {
        const span = document.getElementById('PostCodeSpan');
        span.innerText = postEl.getAttribute('data-val-regex');
        valid = false;
    }

    const nameEl = document.getElementById('CurrentOrder_Name');
    if (nameEl.value == '') {
        const span = document.getElementById('NameSpan');
        span.innerText = nameEl.getAttribute('data-val-required');
        valid = false;
    }

    const phoneEl = document.getElementById('CurrentOrder_PhoneNumber');
    const phoneRegex = new RegExp("^([0-9]{4} [0-9]{3} [0-9]{3})|(04{1}[0-9]{8})|02{1}[0-9]{8}|0{1}[2-9]{1} [0-9]{4} [0-9]{4}|61 [0-9]{3} [0-9]{3} [0-9]{3}|61[0-9]{9}");
    if (!phoneRegex.test(phoneEl.value)) {
        const span = document.getElementById('PhoneSpan');
        span.innerText = "That is not a valid phone number.";
        valid = false;
    } else {
        const span = document.getElementById('PhoneSpan');
        span.innerText = "";
    }
    return valid;
}