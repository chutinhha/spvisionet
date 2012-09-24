function RegisterDialog(dialog, dialogContainer, width) {
    $(document).ready(function () {
        $(document).ready(function () {
            $("#" + dialog).dialog({
                autoOpen: false,
                modal: true,
                width: width,
                //position:"center",
                resizable: false,
                open: function (event, ui) {
                    $(this).parent().appendTo("#" + dialogContainer);
                }
            });
        });
    });
}
function closeDialog(dialog) {
    $("#" + dialog).dialog('close');
}
function openDialog(e, title, dialog) {
    evt = e || window.event;
    $("#" + dialog).dialog("option", "title", title);
    $("#" + dialog).dialog('option', 'position', [evt.clientX, evt.clientY]);
    $("#" + dialog).dialog('open');
    $("#" + dialog).dialog('close');
    $("#" + dialog).dialog('open');
}
function FormatNumber(v, prefix) {
    var nStr = document.getElementById(v).value.replace(/,/g, "");
    if (nStr - 0 >= 0) {
        var prefix = prefix || '';
        nStr += '';
        x = nStr.split('.');
        x1 = x[0];
        x2 = x.length > 1 ? '.' + x[1] : '';
        var rgx = /(\d+)(\d{3})/;
        while (rgx.test(x1))
            x1 = x1.replace(rgx, '$1' + ',' + '$2');
        document.getElementById(v).value = prefix + x1 + x2;
    }
    else {
        document.getElementById(v).value = "";
    }
}
function FormatNumberInnerHTML(v, prefix) {
    var nStr = document.getElementById(v).innerHTML.replace(/,/g, "");
    if (nStr - 0 >= 0) {
        var prefix = prefix || '';
        nStr += '';
        x = nStr.split('.');
        x1 = x[0];
        x2 = x.length > 1 ? '.' + x[1] : '';
        var rgx = /(\d+)(\d{3})/;
        while (rgx.test(x1))
            x1 = x1.replace(rgx, '$1' + ',' + '$2');
        document.getElementById(v).innerHTML = prefix + x1 + x2;
    }
    else {
        document.getElementById(v).innerHTML = "";
    }
}
function Total(x1, x2, result) {
    var x1El = document.getElementById(x1).value.replace(/,/g, "");
    var x2El
    try {
        x2El = document.getElementById(x2).value.replace(/,/g, "");
    }
    catch (err) {
        x2El = document.getElementById(x2).innerHTML.replace(/,/g, "");
    }
    var totalResult = 0;
    if (x1El != '' && x2El != '') {
        totalResult = parseFloat(x1El) * parseFloat(x2El);
        document.getElementById(result).value = totalResult;
        FormatNumber(result);
        return;
    }
    else {
        document.getElementById(result).value = 0;
        return;
    }
}
function TotalPembiayaan(x1, x2, x3, result) {
    var x1El = document.getElementById(x1).value.replace(/,/g, "");
    var x2El = document.getElementById(x2).value.replace(/,/g, "");
    var x3El = document.getElementById(x3).value.replace(/,/g, "");
    var totalResult = 0;
    if (x1El != '' && x2El != '' && x3El != '') {
        totalResult = parseFloat(x1El) - parseFloat(x2El) - parseFloat(x3El);
        document.getElementById(result).value = totalResult;
        FormatNumber(result);
        return;
    }
    else {
        document.getElementById(result).value = 0;
        return;
    }
}
function Percentages(x1, x2, result) {
    var x1El = document.getElementById(x1).value.replace(/,/g, "");
    var x2El
    try {
        x2El = document.getElementById(x2).value.replace(/,/g, "");
    }
    catch (err) {
        x2El = document.getElementById(x2).innerHTML.replace(/,/g, "");
    }
    var totalResult = 0;
    if (x1El != '' && x2El != '') {
        totalResult = parseFloat((parseFloat(x1El) / parseFloat(x2El))) * 100;
        document.getElementById(result).value = totalResult;
        FormatNumber(result);
        return;
    }
    else {
        document.getElementById(result).value = 0;
        return;
    }
}
(function ($) {
    $.fn.forceNumeric = function () {
        return this.each(function () {
            $(this).keyup(function () {
                if (!/^[0-9]+$/.test($(this).val())) {
                    $(this).val($(this).val().replace(/[^0-9]/g, ''));
                }
            });
        });
    };
})(jQuery);
function NumericOnly(id) {
    $(function () {
        $("#" + id).forceNumeric();
    });
}
function WewenangDireksi(txt) {
    $(document).ready(function () {
        var search = document.getElementById(txt).value;
        $("#" + txt).autocomplete({ source: '/Common/WewenangDireksi.ashx?Search=' + search + '' });
    });
}
function KomisarisDireksi(txt) {
    $(document).ready(function () {
        var search = document.getElementById(txt).value;
        $("#" + txt).autocomplete({ source: '/Common/KomisarisDireksi.ashx?Search=' + search + '' });
    });
}
function PemegangSaham(txt) {
    $(document).ready(function () {
        var search = document.getElementById(txt).value;
        $("#" + txt).autocomplete({ source: '/Common/PemegangSaham.ashx?Search=' + search + '' });
    });
}
function PemegangSahamPendaftaranPMAPMDN(txt) {
    $(document).ready(function () {
        var search = document.getElementById(txt).value;
        $("#" + txt).autocomplete({ source: '/Common/PemegangSahamPendaftaranPMAPMDN.ashx?Search=' + search + '' });
    });
}
function PemegangSahamPerubahanPMAPMDN(txt) {
    $(document).ready(function () {
        var search = document.getElementById(txt).value;
        $("#" + txt).autocomplete({ source: '/Common/PemegangSahamPerubahanPMAPMDN.ashx?Search=' + search + '' });
    });
}
function Notaris(txt) {
    $(document).ready(function () {
        var search = document.getElementById(txt).value;
        $("#" + txt).autocomplete({ source: '/Common/Notaris.ashx?Search=' + search + '' });
    });
}
function FormatMask(txt, format) {
    jQuery(function ($) {
        $("#" + txt).mask(format);
    });
}