
var grid_tbl;
var arr_grid = [];
$(document).ready(function () {
    var _rpt = $('#rpt');
    _rpt.hide();
    getCurrentDate();
    $("#txtPeriodStart").datepicker({
        dateFormat: "dd-mm-yy"
    });
    $("#txtPeriodEnd").datepicker({
        dateFormat: "dd-mm-yy"
    });
    

    $('#selBaseOn').select2();
    $('#selÀction').select2();
    $('#selGerai').select2();
    $('#selRadio').select2();

    LoadGerai();

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

function LoadGrid() {
    var InquiryTop10TransParam = new Object();
    InquiryTop10TransParam.startPeriod = $('#txtPeriodStart').val();
    InquiryTop10TransParam.endPeriod = $('#txtPeriodEnd').val();
    InquiryTop10TransParam.type = $('#selRadio').val();
    InquiryTop10TransParam.gerai = $('#selGerai').val();
    InquiryTop10TransParam.basedOn = $('#selBaseOn').val();

    $.ajax({
        type: 'post',
        url: '/Report/GetInquiryTop10Transaction',
        data: JSON.stringify(InquiryTop10TransParam),
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
                    { data: "NO" },
                    { data: "ITEMNM" },
                   
                    { data: "QTY", "mRender": function (data, type, full) { return CommaFormattedN(data.toString()); } },
                    { data: "AMT", "mRender": function (data, type, full) { return CommaFormattedN(data.toString()); } },
                  
                    ],
                    fixedHeader: true,

                    "scrollY": "400px",
                    "scrollCollapse": true,
                    "columnDefs": [
       { "className": "dt-center", "targets": [2, 3 ]}
                    ],
                    dom: 'Bfrtip',
                    buttons: [
         {
             extend: 'excel',
             text: 'Export',
             title: 'TOP 10 Transaction',
             exportOptions: {
                 columns: ':visible'
             }
         },

                    ],
                    lengthChange: false,
                    paging: false,
                    processing: true,
                    searching: true
                  
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