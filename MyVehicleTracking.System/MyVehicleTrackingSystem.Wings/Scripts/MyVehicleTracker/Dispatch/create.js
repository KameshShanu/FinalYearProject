﻿// Global Variables
var client;
var companyAddress;
var vehicleLicensePlateNumber;
var quantity;
var vehicleDeliveryType;
var driver;
var helper;
var dispatchDate;

$(function () {
    $(".date").datepicker({
        autoclose: true,
        todayHighlight: true,
        startDate: "today"
    }).datepicker('update', new Date());
});

$("#DispatchDate").change(function () {
    if ($(".DispatchDate").val() != '') {
        $(".errDispatchDate").hide();
    }
    dispatchDate = $(this).val();
});

$("#Client_OperationType").change(function () {
    client = $("#Client_OperationType option:selected").text();
    $.ajax({
        type: "GET",
        url: "/Dispatch/GetClientDetails/" + $("#Client_OperationType").val(),
        contentType: "application/json",
        dataType: "json",
        success: function (client) {
            $('#ClientRate').val(client.clientCommission);
            $('#DriverCommissionRate').val(client.driverCommission);
            $('#PorterCommissionRate').val(client.porterCommission);
            $('#CompanyAddress').val(client.companyAddress);
            companyAddress = client.companyAddress;
        },
        error: function (error) {
            console.log(error);
        }
    });
})

$("#VehiclePlateNumber").change(function () {
    vehicleLicensePlateNumber = $("#VehiclePlateNumber option:selected").text(),
    $.ajax({
        type: "GET",
        url: "/Dispatch/GetVehicleDetails/" + $("#VehiclePlateNumber").val(),
        contentType: "application/json",
        dataType: "json",
        success: function (vehicle) {
            $('#Quantity').val(vehicle.quantity);
            $('#VehicleDeliveryType').val(vehicle.deliveryType);
            quantity = vehicle.quantity;
            vehicleDeliveryType = vehicle.deliveryType;
        },
        error: function (error) {
            console.log(error);
        }
    });
})

$('#DriverName_Grade').change(function () {
    driver = $("#DriverName_Grade option:selected").text();
});

$("#HelperName").change(function () {
    helper = $("#HelperName option:selected").text();
})

//Modal-Content.
function exampleModal() {
    if ($('#createForm').valid()) {
        $('#previewModal').modal('show');
        $('#clientModalElement').html(client);
        $('#companyAddressModalElement').html(companyAddress);
        $('#vehicleLicensePlateNumberModalElement').html(vehicleLicensePlateNumber);
        $('#quantityModalElement').html($('#Quantity').val());
        $('#vehicleDeliveryTypeModalElement').html(vehicleDeliveryType);
        $('#driverModalElement').html(driver);
        $('#helperModalElement').html(helper);
        $('#dispatchDateModalElement').html(dispatchDate);
    }
}