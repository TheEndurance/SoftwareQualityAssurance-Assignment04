function createJDUrl(make, model, year) {
    return "http://www.jdpower.com/cars/" + make + "/" + model + "/" + year;
};

var getUrlParameter = function getUrlParameter(sParam) {
    var sPageURL = decodeURIComponent(window.location.search.substring(1)).replace(/\+/g, " "),
        sURLVariables = sPageURL.split('&'),
        sParameterName,
        i;
        console.log(sPageURL);

    for (i = 0; i < sURLVariables.length; i++) {
        sParameterName = sURLVariables[i].split('=');

        if (sParameterName[0] === sParam) {
            return sParameterName[1] === undefined ? true : sParameterName[1];
        }
    }
};

function frmNewCar_SaveCar(e) {
    if (doValidate_frmNewCar()) {
        var form = e.target;
        var jsonForm = concatObjectArray($(form).serializeArray());
        var listOfCars = localStorage.getItem("cars");
        if (listOfCars) {
            listOfCars = JSON.parse(listOfCars);
            listOfCars.cars.push(jsonForm);
        } else {
            listOfCars = {cars: []};
            listOfCars.cars.push(jsonForm);
        }
        listOfCars = JSON.stringify(listOfCars)
        localStorage.setItem("cars", listOfCars);
        displayCar(jsonForm);

    } else {
        e.preventDefault();
        console.error("Validation error!");
    }
}

function displayCar(car){
    var html = "<p>Seller name: <span id='sellerName'>"+car.sellerName+"</span></p>" +
        "<p>Address: <span id='address'>"+car.address+"</span></p>" +
        "<p>City: <span id='city'>"+car.city+"</span></p>" +
        "<p>Phone: <span id='phone'>"+car.phone+"</span></p>" +
        "<p>Email address: <span id='email'>"+car.email+"</span></p>" +
        "<p>Vehicle make: <span id='vehicleMake'>"+car.vehicleMake+"</span></p>" +
        "<p'>Vehicle model: <span id='vehicleModel'>"+car.vehicleModel+"</span></p>" +
        "<p>Vehicle year: <span id='vehicleYear'>"+car.vehicleYear+"</span></p>";
    $("#displayCar")
        .html(html)
        .append($('<a>', {
            id: "JDLink",
            text: createJDUrl(car.vehicleMake, car.vehicleModel, car.vehicleYear),
            href: createJDUrl(car.vehicleMake, car.vehicleModel, car.vehicleYear)
        }));
}

function createCarFromURL(){
    var car = {};
    car.sellerName = getUrlParameter("sellerName");
    car.address = getUrlParameter("address");
    car.city = getUrlParameter("city");
    car.phone = getUrlParameter("phone");
    car.email = getUrlParameter("email");
    car.vehicleMake = getUrlParameter("vehicleMake");
    car.vehicleModel = getUrlParameter("vehicleModel");
    car.vehicleYear = getUrlParameter("vehicleYear");
    return car;
}

function body_loadCars() {
    var listOfCars = JSON.parse(localStorage.getItem("cars"));
    if (listOfCars) {
        $.each(listOfCars.cars, function (index, element) {
            $("#links").append($('<a>', {
                text: createJDUrl(element.vehicleMake, element.vehicleModel, element.vehicleYear),
                href: createJDUrl(element.vehicleMake, element.vehicleModel, element.vehicleYear)
            })).append($('<br>'));
        });
    }
}

function concatObjectArray(arrayOfFormObjects) {
    var returnArray = {};
    for (var i = 0; i < arrayOfFormObjects.length; i++) {
        returnArray[arrayOfFormObjects[i]['name']] = arrayOfFormObjects[i]['value'];
    }
    return returnArray;
}

