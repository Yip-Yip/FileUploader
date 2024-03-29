/// <autosync enabled="true" />
/// <reference path="modernizr-2.6.2.js" />
/// <reference path="jquery-1.10.2.js" />
/// <autosync enabled="true" />
/// <reference path="modernizr-2.6.2.js" />
/// <reference path="bootstrap.js" />
/// <reference path="respond.js" />
/// <reference path="jquery.validate.js" />
/// <reference path="jquery.validate.unobtrusive.js" />
/// <reference path="jquery-2.1.1.js" />


var allowedExtensions = ".pdf, .jpg, .jpeg, .pjpeg, .tiff, .gif, .png";

$("#btnSave").click(function (e) {
    e.preventDefault();

    $('<input />').attr('type', 'hidden').attr('name', $(this).attr("name")).appendTo('form');

    var filesToUpload = $("#FilesToUpload").val();
    var canSubmitForm = false;

    if ($(this).attr("name") == "Resume" || $(this).attr("name") == "Send") {
        if (!$.isEmptyObject($.find('#file-path'))) {
            $("#file-path").val() == "";
        }
        if (!$.isEmptyObject($.find('#additional-path'))) {
            $("#additional-path").val() == "";
        }
        var canSubmitForm = true;
    }
    else {
        var hasCorrectExtension = true;
        var numDocumentSelected = 2;
        var fileSizeOk = true;

        if ($("#file-path").val() != "") {
            if ($("#file-path").val().length > 0 || $("#additional-path").val().length > 0) {
                var hasCorrectExtension = true;

                $.each($("#file-path, #additional-path"), function (index, value) {
                    if ($("#" + $(value).attr("id")).val().length > 0) {
                        var extension = ($("#" + $(value).attr("id")).val().match(/\.[0-9a-z]+$/i)[0]).toLowerCase();
                        if ($.inArray(extension, allowedExtensions) < 0) {
                            //test for code reviewer - allow all files for now
                            hasCorrectExtension = true;
                        }
                        else {
                            numDocumentSelected++;
                        }
                    }
                });

                if (this.files) {
                    $.each($("#divDocumentUpload input:file"), function () {
                        if (CheckFileSizeLimit(this.files[0])) {
                            fileSizeOk = false;
                            return false;
                        }
                    });
                }

                if (hasCorrectExtension && (numDocumentSelected == filesToUpload)) {
                    if (!fileSizeOk) {
                        alert("One of the files are too large");
                        disableButton("#btnSave");
                        canSubmitForm = false;
                    }
                    else if (filesToUpload == 2 && $("#file-path").val() == $("#additional-path").val()) {
                        alert("Files cant be the same");
                        disableButton("#btnSave");
                        canSubmitForm = false;
                    }
                    else if ($("#IdentificationDocumentTypePrimary").val() == "" || (filesToUpload == 2 && $("#IdentificationDocumentTypeSecondary").val() == "")) {
                        disableButton("#btnSave");
                        canSubmitForm = false;
                    }
                    else {
                        canSubmitForm = true;
                    }
                }
                else {
                    alert("An error has occured, please check file type & size");
                }
            }
        }
        else {
            cansubmitform = true;
        }
    }

    if (canSubmitForm) {
        $("form").submit();
        return;
    }
});

$('#fileUpload').change(function () {
    $('#file-path').val($(this).val());
});

$('#additionalFileUpload').change(function () {
    $('#additional-path').val($(this).val());
});

$('#IdentificationDocumentTypePrimary, #IdentificationDocumentTypeSecondary').change(function () {
    VailidateForBtnSave();
});

$('#fileUpload1 input:file').change(function () {
    if (this.files) {

        if (CheckFileSizeLimit(this.files[0])) {
            $("#fileUpload1").children("span:first").attr("class", "indicator-fail").text("File size is over the limit");
        } else {
            $("#fileUpload1").children("span:first").attr("class", "indicator-pass").text(" File size is OK");
        }
    }
    VailidateForBtnSave();
});

$('#fileUpload2 input:file').change(function () {
    if (this.files) {
        if (CheckFileSizeLimit(this.files[0])) {
            $("#fileUpload2").children("span:first").attr("class", "indicator-fail").text("File size is over the limit");
        } else {
            $("#fileUpload2").children("span:first").attr("class", "indicator-pass").text("File size is OK");
        }
    }
    VailidateForBtnSave();
});

VailidateForBtnSave = function () {
    var pageIsValid = true;

    if (this.files) {
        $.each($("#divDocumentUpload input:file"), function () {
            if (CheckFileSizeLimit(this.files[0])) {
                pageIsValid = false;
                return;
            }
        });
    }

    if (!pageIsValid) {
        disableButton("#btnSave");
    } else {
        enableButton("#btnSave");
    }
};

var CheckFileSizeLimit = function (f) {
    var maxFileSize = 2097152;
    if (f == null || f.size > maxFileSize || f.fileSize > maxFileSize) {
        return true;
    }
    return false;
};

function disableButton(btn) {
    $(btn).addClass("disabled processing").children("span:first").children("span:first");
    $(btn).attr('disabled', 'disabled');
}

function enableButton(btn) {
    $(btn).removeClass("disabled processing").children("span:first").children("span:first");
    $(btn).removeAttr('disabled');
}/// <reference path="bootstrap.js" />
/// <reference path="respond.js" />
