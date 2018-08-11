var arr_theraphis = [];
var grid_tbl;
var arr_grid = [];
var arr_item = [];
var arr_cust = [];
var item_tbl;
var cust_tbl;
$(document).ready(function () {
    var _rpt = $('#rpt');
    _rpt.hide();

    $("#txtPeriodStart").datepicker({
        dateFormat: "dd-mm-yy"
    });
    $("#txtPeriodEnd").datepicker({
        dateFormat: "dd-mm-yy"
    });
    
    getCurrentDate();

    $('#selTheraphis').select2();
    $('#selTransType').select2();
    $('#selPayment').select2();
    $('#selAction').select2();
    $('#selGerai').select2();
    $('#selCardName').select2();

    LoadTheraphis();
    LoadGerai();
    LoadTransType();
    LoadPaymentType();

    $('#tblItem tbody').on('click', '#detil', function () {
        var data = item_tbl.row($(this).parents('tr')).data();
        $('#txtItemId').val(data.ITEM_CD);
        $('#txtItemDesc').val(data.ITEM_NM);

        $('#mdlItem').modal('hide');
    });

    $('#tblCust tbody').on('click', '#detil', function () {
        var data = cust_tbl.row($(this).parents('tr')).data();
        $('#txtCustomer').val(data.CUS_CD);
        $('#txtCustDesc').val(data.CUS_NM);

        $('#mdlCust').modal('hide');
    });

    $('#btnViewReport').click(function (e) {
        var _startDate = $('#txtPeriodStart').val();
        var _endDate = $('#txtPeriodEnd').val();
        var _therapis = $('#selTheraphis').val();
        var _gerai = $('#selGerai').val();
        var _action = $('#selÀction').val();

        if (_startDate != '' && _endDate != '') {
            if (_action == "PRINT") {
                $('#grid').hide();
                document.getElementById("rpt").src = "/Reporting/ViewRptInquiryTransByTheraphis.aspx?param=" + _startDate + "|" + _endDate + "|" + _therapis + "|" + _gerai;
                _rpt.show();
            }
            else {
                _rpt.hide();
                LoadGrid();
            }
        }
        else {
            alert('Please complete Date start and Date end parameters');
        }


    });

    $('#btnFindItem').click(function (e) {
        $('#mdlItem').modal({
            backdrop: 'static'
        });
        LoadItem();
    });

    $('#btnFindCustomer').click(function (e) {
        $('#mdlCust').modal({
            backdrop: 'static'
        });
        LoadCustomer();
    });
});

function getCurrentDate() {
    var today = new Date();
    var dd = today.getDate();
    if (dd < 10)
        dd = '0' + dd;
    var mm = today.getMonth() + 1;
    if (mm < 10)
        mm = '0' + mm;
    var yy = today.getFullYear();

    $('#txtPeriodStart').val(dd + '-' + mm + '-' + yy);
    $('#txtPeriodEnd').val(dd + '-' + mm + '-' + yy);
}

function LoadTheraphis() {

    $.ajax({
        url: '/AjaxData/GetSPA03MT',
        type: 'GET',

        success: function (response) {
            arr_theraphis = response.Data;
            $("#selTheraphis").select2({
                data: arr_theraphis
            });
        }
    });
}

function LoadGerai() {

    var arr_gerai = [];
    $.ajax({
        url: '/AjaxData/GetGerai',
        type: 'GET',

        success: function (response) {
            arr_gerai = response.Data;
            $("#selGerai").select2({
                data: arr_gerai
            });
        }
    });
}

function LoadTransType() {

    var arr_TransType = [];
    $.ajax({
        url: '/AjaxData/GetTransType',
        type: 'GET',

        success: function (response) {
            arr_TransType = response.Data;
            $("#selTransType").select2({
                data: arr_TransType
            });
        }
    });
}

function LoadPaymentType() {

    var arr_PaymentType = [];
    $.ajax({
        url: '/AjaxData/GetPaymentType',
        type: 'GET',

        success: function (response) {
            arr_PaymentType = response.Data;
            $("#selPayment").select2({
                data: arr_PaymentType
            });
        }
    });
}

function LoadGrid() {
    var InquiryTranByTherapisParm = new Object();
    InquiryTranByTherapisParm.startDate = $('#txtPeriodStart').val();
    InquiryTranByTherapisParm.endDate = $('#txtPeriodEnd').val();
    InquiryTranByTherapisParm.therapis = $('#selTheraphis').val();
    InquiryTranByTherapisParm.gerai = $('#selGerai').val();

    $.ajax({
        type: 'post',
        url: '/Report/GetInquiryTransByTheraphis',
        data: JSON.stringify(InquiryTranByTherapisParm),
        datatype: 'json',
        contentType: "application/json; charset=utf-8",
        async: "true",
        success: function (result) {
            if (result.Status == "success") {
                $('#grid').show();
                arr_grid = result.Data;
                grid_tbl = $('#gridResult').DataTable({
                    data: arr_grid,
                    "ordering": false,

                    destroy: true,
                    columns: [
                    { data: "SW", visible: false },
                    { data: "TGL" },
                    { data: "TYPE_NM" },
                    { data: "EMP_NM" },
                    { data: "TO_AMT", "mRender": function (data, type, full) { return CommaFormattedN(data.toString()); } },
                    { data: "PAKET", "mRender": function (data, type, full) { return CommaFormattedN(data.toString()); } },
                    { data: "GIFT", "mRender": function (data, type, full) { return CommaFormattedN(data.toString()); } },
                    { data: "TOTAL", "mRender": function (data, type, full) { return CommaFormattedN(data.toString()); } },

                    { data: "KOMISI", "mRender": function (data, type, full) { return CommaFormattedN(data.toString()); } },

                    ],
                    fixedHeader: true,

                    "scrollY": "400px",
                    "scrollCollapse": true,
                    "columnDefs": [
       { "className": "dt-center", "targets": [4, 5, 6, 7] }
                    ],
                    dom: 'Bfrtip',
                    buttons: [
         {
             extend: 'excel',
             text: 'Export',
             title: 'Inquiry Transaction By Theraphis',
             exportOptions: {
                 columns: ':visible'
             }
         },

                    ],
                    lengthChange: false,
                    paging: false,
                    processing: true,
                    searching: true,
                    "createdRow": function (row, data, dataIndex) {
                        if (data["SW"] == "2" || data["SW"] == "3") {
                            $(row).addClass('red');

                        }
                    }
                });
            }
            else {
                alert(result.ErrMsg);
            }
        }
    });
}

function CommaFormattedN(amount) {
    var commadec = "";
    amount = amount.replace(/,/g, "");
    if (amount.indexOf(".") > -1) {
        commadec = "." + amount.split(".")[1];
        amount = amount.split(".")[0];
    }
    var delimiter = ",";
    var i = parseInt(amount);

    if (isNaN(i)) { return ''; }

    var origi = i;  // store original to check sign
    i = Math.abs(i);

    var minus = '';
    if (origi < 0) { minus = '-'; } // sign based on original

    var n = new String(i);
    var a = [];

    while (n.length > 3) {
        var nn = n.substr(n.length - 3);
        a.unshift(nn);
        n = n.substr(0, n.length - 3);
    }

    if (n.length > 0) { a.unshift(n); }

    n = a.join(delimiter);

    amount = minus + n;

    return amount;
}

function LoadItem() {
    $.ajax({
        url: '/AjaxData/GetSPA02MT',
        type: 'GET',
        data: { Name: name },
        success: function (response) {
            arr_item = response.Data;
            item_tbl = $('#tblItem').DataTable({
                data: arr_item,
                destroy: true,
                columns: [
                { data: "ITEM_CD" },
                { data: "ITEM_NM" },
                { data: "HARGA" },
                { data: "STOCK" },
                {
                    data: "ITEM_CD", "width": "50px", "render": function (data) {
                        return '<a id="detil" data-toggle="tooltip" data-placement="bottom" title="View Detail"><i class="fa fa-hand-rock-o" aria-hidden="true"></i></a>';
                    }
                }
                ],
                processing: true,
                searching: true,
            });


        }
    });
}

function LoadCustomer() {
    $.ajax({
        url: '/AjaxData/GetSPA05MT',
        type: 'GET',    
        success: function (response) {
            arr_cust = response.Data;
            cust_tbl = $('#tblCust').DataTable({
                data: arr_cust,
                destroy: true,
                columns: [
                { data: "CUS_CD" },
                { data: "CUS_NM" },
                { data: "ENTER_DT" },
                { data: "ADDR" },
                {
                    data: "CUS_CD", "width": "50px", "render": function (data) {
                        return '<a id="detil" data-toggle="tooltip" data-placement="bottom" title="View Detail"><i class="fa fa-hand-rock-o" aria-hidden="true"></i></a>';
                    }
                }
                ],
                processing: true,
                searching: true,
            });


        }
    });
}