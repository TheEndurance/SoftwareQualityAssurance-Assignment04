function eventHandlers(){
    $("#frmNewCar").submit(frmNewCar_SaveCar);
}
$(document).ready(function(){
    eventHandlers();
});
