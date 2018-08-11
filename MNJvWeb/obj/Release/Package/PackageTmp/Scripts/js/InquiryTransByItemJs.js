var item_tbl;
var arr_item = [];
var arr_grid = [];
var grid_tbl;
$(document).ready(function () {
    var _rpt = $('#rpt');
    _rpt.hide();
    getCurrentDate();
    $('#selÀction').select2();
    $('#selGerai').select2();
    $('#selRadio').select2();
    LoadGerai();
    $("#txtPeriodStart").datepicker({
        dateFormat: "dd-mm-yy"
    });
    $("#txtPeriodEnd").datepicker({
        dateFormat: "dd-mm-yy"
    });

    $('#btnFindItem').click(function (e) {
        $('#mdlItem').modal({
            backdrop: 'static'
        });
        LoadItem();
    });

    $('#tblItem tbody').on('click', '#detil', function () {
        var data = item_tbl.row($(this).parents('tr')).data();
        $('#txtItemId').val(data.ITEM_CD);
        $('#txtItemDesc').val(data.ITEM_NM);

        $('#mdlItem').modal('hide');
    });

    $('#txtItemId').on('change', function search(){
       var params = $('#txtItemId').val();
     
        $.ajax({
            url: '/AjaxData/GetSPA02MTWithParam',
            datatype:'json',
            type:'POST',
            data: {parameter:params},
         
            success: function (response) {
                $('#txtItemDesc').val(response.Item_Nm);
            }
        });
    });

    $('#btnViewReport').click(function (e) {
        var _startDate = $('#txtPeriodStart').val();
        var _endDate = $('#txtPeriodEnd').val();
        var _itemId = $('#txtItemId').val();
        var _checked_radio = $('#selRadio').val();
            //$("input[type='radio']:checked").val();
        var _action = $('#selÀction').val();

        if (_startDate != '' && _endDate != '') {
            if (_action == "PRINT") {
                $('#grid').hide();
                document.getElementById("rpt").src = "/Reporting/ViewRptInquiryTransByItem.aspx?param=" + _startDate + "|" + _endDate + "|" + _itemId + "|" + _checked_radio;
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

function LoadGrid() {
    var InquiryTransByItemParm = new Object();
    InquiryTransByItemParm.startDate = $('#txtPeriodStart').val();
    InquiryTransByItemParm.endDate = $('#txtPeriodEnd').val();
    InquiryTransByItemParm.itemCd = $('#txtItemId').val();
    InquiryTransByItemParm.IsProductOrTreatment = $("input[type='radio']:checked").val();

    $.ajax({
        type: 'post',
        url: '/Report/GetInquiryTransByItem',
        data: JSON.stringify(InquiryTransByItemParm),
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
                    { data: "Sw", visible: false },
                    { data: "Tgl" },
                    { data: "ItemNm" },
                    { data: "Qty" },
                    { data: "Amt", "mRender": function (data, type, full) { return CommaFormattedN(data.toString()); } },
                    { data: "Paket", "mRender": function (data, type, full) { return CommaFormattedN(data.toString()); } },
                    { data: "Gift", "mRender": function (data, type, full) { return CommaFormattedN(data.toString()); } },
                    { data: "reimbsemen", "mRender": function (data, type, full) { return CommaFormattedN(data.toString()); } },
                    { data: "promo", "mRender": function (data, type, full) { return CommaFormattedN(data.toString()); } },
                    { data: "total", "mRender": function (data, type, full) { return CommaFormattedN(data.toString()); } },

                    ],
                    fixedHeader: true,

                    "scrollY": "400px",
                    "scrollCollapse": true,
                    "columnDefs": [
       {"className": "dt-center", "targets": [3,4,5,6,7,8,9]}
                    ],
                    dom: 'Bfrtip',
                    buttons: [
         {
             extend: 'excel',
             text: 'Export',
             title: 'Inquiry Transaction By Item',
             exportOptions: {
                 columns:':visible'
             }
         },

                    ],
                    lengthChange: false,
                    paging: false,
                    processing: true,
                    searching: true,
                    "createdRow": function (row, data, dataIndex) {
                        if (data["Sw"] == "2" || data["Sw"] == "3") {
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

function reposition() {
    var modal = $(this),
        dialog = modal.find('.modal-dialog');
    modal.css('display', 'block');

    // Dividing by two centers the modal exactly, but dividing by three
    // or four works better for larger screens.
    dialog.css("margin-top", Math.max(0, ($(window).height() - dialog.height()) / 2));
}
$('.modal').on('show.bs.modal', reposition);
// Reposition when the window is resized
$(window).on('resize', function () {
    $('.modal:visible').each(reposition);
});
// Reposition when a modal is shown

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

function SearchItem(item_cd) {
    var form_data = new FormData();
    form_data.append('parameter', item_cd);
    $.ajax({
        url: '/AjaxData/GetSPA02MTWithParam',
        type: 'GET',
        data: form_data,
        success: function (response) {
            $('#txtItemDesc').val(response.Item_Nm);
        }
    });
}


