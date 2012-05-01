function RegisterDialog(dialog, dialogContainer, width) {
    $(document).ready(function() {
        $(document).ready(function() {
            $("#" + dialog).dialog({
                autoOpen: false,
                modal: true,
                width: width,
                resizable: false,
                open: function(event, ui) {
                    $(this).parent().appendTo("#" + dialogContainer);
                }
            });
        });
    });
}
function closeDialog(dialog) {
    $("#" + dialog).dialog('close');
}
function openDialog(title, dialog) {
    $("#" + dialog).dialog("option", "title", title);
    $("#" + dialog).dialog('open');
}
function RegisterTabs(isActive) {
    $(function() {
        $("#tabs").tabs();
        if (isActive == '0') {
            $("#tabs-2").hide();
            $("#tabs-3").hide();
            $("#tabs-4").hide();
            $("#tabs-5").hide();
            $("#tabs-6").hide();
            $("#tabs-7").hide();

            $("#tab2").hide();
            $("#tab3").hide();
            $("#tab4").hide();
            $("#tab5").hide();
            $("#tab6").hide();
            $("#tab7").hide();
        }
        else {
            $("#tabs-2").show();
            $("#tabs-3").show();
            $("#tabs-4").show();
            $("#tabs-5").show();
            $("#tabs-6").show();
            $("#tabs-7").show();

            $("#tab2").show();
            $("#tab3").show();
            $("#tab4").show();
            $("#tab5").show();
            $("#tab6").show();
            $("#tab7").show();
        }
    });
}
function RegisterSelectedTabs(number) {
    $(function() {
        $("#tabs").tabs();
        $("#tabs").tabs('option', 'selected', number);
    });
}
function RegisterCommunicationTabs(isActive) {
    $(function() {
        $("#tabs").tabs();
        if (isActive == '0') {
            $("#tabs-2").hide();
            $("#tabs-3").hide();
            $("#tabs-4").hide();

            $("#tab2").hide();
            $("#tab3").hide();
            $("#tab4").hide();
        }
        else {
            $("#tabs-2").show();
            $("#tabs-3").show();
            $("#tabs-4").show();

            $("#tab2").show();
            $("#tab3").show();
            $("#tab4").show();
        }
    });
}
(function($) {
    $.fn.forceNumeric = function() {
        return this.each(function() {
            $(this).keyup(function() {
                if (!/^[0-9]+$/.test($(this).val())) {
                    $(this).val($(this).val().replace(/[^0-9]/g, ''));
                }
            });
        });
    };
})(jQuery);
function NumericOnly(id) {
    $(function() {
        $("#" + id).forceNumeric();
    });
}
function ConfirmStatus(hiddenfield, msg) {
    var hdn = document.getElementById(hiddenfield);
    if (confirm(msg) == true) {
        hdn.value = 'true';
        return true;
    }
    else {
        hdn.value = 'false';
        return false;
    }
}
function FormatDate(id) {
    var date = document.getElementById(id);
    var keycode = 0;
    try { keycode = e.which } catch (c) { };
    try { keycode = e.keyCode } catch (c) { };

    if (keycode == 8 || keycode == 0)
        date.value = '';
    else
        date.value = '';
}
function DateOnly(id) {
    var date = document.getElementById(id);
    var keycode = 0;
    try { keycode = e.which } catch (c) { };
    try { keycode = e.keyCode } catch (c) { };

    if (keycode != 8)
        date.value = '';
}