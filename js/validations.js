function doValidate_frmNewCar() {
    var form = $("#frmNewCar");
    form.validate({
        rules: {
            sellerName:{
                required:true
            },
            address:{
                required:true
            },
            city:{
                required:true
            },
            phone:{
                required:true,
                phonenumber:true
            },
            email:{
                required:true,
                email:true
            },
            vehicleMake:{
                required:true
            },
            vehicleModel:{
                required:true
            },
            vehicleYear: {
                required: true
            }
        },
        messages: {
            sellerName:{
                required:"Seller name is required"
            },
            address:{
                required:"Address is required"
            },
            city:{
                required:"City is required"
            },
            phone:{
                required:"Phone number is required",
                phonenumber:"Invalid phone number, allowed formats are 123-123-1234 or (123)123-1234"
            },
            email:{
                required:"Email address is required",
                email:"Invalid email format"
            },
            vehicleMake:{
                required:"Vehicle make is required"
            },
            vehicleModel:{
                required:"Vehicle model is required"
            },
            vehicleYear: {
                required: "Vehicle year is required"
            }
        }
    });
    return form.valid();
}


jQuery.validator.addMethod("phonenumber",
    function(value,element){
        var regex = /^[(]?[0-9]{3}[(-]?[0-9]{3}[-]?[0-9]{4}$/;
        return this.optional(element) || regex.test(value);
    },
    "Valid phone numbers");
