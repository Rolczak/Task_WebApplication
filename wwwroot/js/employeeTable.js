var dataTable;

$(document).ready(function () {
    initDataTable();
    $("#name").autocomplete({
        source: "/home/GetAutocompleteNames"
    })


    populateSelect();

    //On change handlers
    $("#name").change(function () {
        dataTable.ajax.reload();
    });
    $("#beginDate").change(function () {
        dataTable.ajax.reload();
    });
    $("#endDate").change(function () {
        dataTable.ajax.reload();
    });
    $("#performanceManager").change(function () {
        dataTable.ajax.reload();
    });

    initDatePickers();
});

function initDataTable() {
    dataTable = $("#tblData").DataTable({
        searching: false,
        "ajax": {
            "url": "/employee",
            "type": "GET",
            "data": function (data) {
                data.nameTerm = $("#name").val();
                data.beginDate = $("#beginDate").val();
                data.endDate = $("#endDate").val();
                data.performanceManagerId = parseInt($("#performanceManager").val());
            }
            
        },
        "columns": [
            { "data": "name", "width": "40%" },
            { "data": "hireDate", "width": "40%" },
            { "data": "performanceManagerName","defaultContent": "None" ,"width": "40%" },
        ]
    });
}

function initDatePickers() {
    $("#flatpickBegin").flatpickr({
        altInput: true,
        altFormat: "F j, Y",
        dateFormat: "Y-m-d",
        wrap: true,
    });

    $("#flatpickEnd").flatpickr({
        altInput: true,
        altFormat: "F j, Y",
        dateFormat: "Y-m-d",
        wrap: true,
    });
}

function populateSelect() {
    $.ajax({
        type: "GET",
        url: "/home/GetManagerList",
        success: function (data) {
            var selectList = $("#performanceManager");
            $.each(data, function () {
                selectList.append($("<option></option>").text(this.text).val(this.value));
            });
        }
    });
}