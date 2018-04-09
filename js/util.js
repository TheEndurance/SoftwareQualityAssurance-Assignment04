function createJDUrl(make, model, year) {
    return "http://www.jdpower.com/cars/" + make + "/" + model + "/" + year;
}

function frmNewCar_SaveCar(e) {
    e.preventDefault();
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
        console.error("Validation error!");
    }
}

function displayCar(car){
    var html = "<p>Seller name: "+car.sellerName+"</p>" +
                "<p>Address: "+car.address+"</p>" +
                "<p>City: "+car.city+"</p>" +
                "<p>Phone: "+car.phone+"</p>" +
                "<p>Email address: "+car.email+"</p>" +
                "<p>Vehicle make: "+car.vehicleMake+"</p>" +
                "<p>Vehicle model: "+car.vehicleModel+"</p>" +
                "<p>Vehicle year: "+car.vehicleYear+"</p>";
    $("#displayCar")
        .html(html)
        .append($('<a>', {
        text: createJDUrl(car.vehicleMake, car.vehicleModel, car.vehicleYear),
        href: createJDUrl(car.vehicleMake, car.vehicleModel, car.vehicleYear)
    }));
    $("#successMessage").removeClass("hidden");
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

