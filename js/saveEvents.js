function eventHandlers(){
    $("<body>").ready(function(){
        displayCar(createCarFromURL());
    });
}
$(document).ready(function(){
    eventHandlers();
});
