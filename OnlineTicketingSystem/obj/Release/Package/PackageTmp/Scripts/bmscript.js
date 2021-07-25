
//         <%--<script type="text/javascript">
//    $("[id*=btnDelete]").live("click", function () {

//        $("#dialog").html("Do you really want to delete?");
//        $("#dialog").dialog({
//            title: "Message",
//            buttons: {
//                Yes : function () {
//                    $(this).dialog('close');
//                    __doPostBack('<%= btnDelete.ClientID %>', '');
//                    //document.getElementById("btnModalPopup").click();
//                }, No: function () {
//                    $(this).dialog("close");

//                }
//            },
//            modal: true
//        });
//        return false;
//    });
//</script>--%>
//<%--
//<script type="text/javascript">
//    $(document).ready(function () {
//        $('#btnDelete').live('click', function (e) {

//           

//            var $dialog = $('<div></div>')
//                .html('Do you want to delete?')
//                .dialog({
//                    autoOpen: false,
//                    modal: true,
//                   
//                    title: "Message",

//                    buttons: {
//                        "Close": function () { $dialog.dialog('close'); }
//                    },
//                    close: function (event, ui) {

//                        __doPostBack('<%= btnDelete.ClientID %>', '');
//                    }
//                });
//            $dialog.dialog('open');
//            e.preventDefault();
//        });
//    });
//    </script>--%>

//(function ($) {

//    var namespace;

//    namespace = {
//        something: function() {
//            alert('hello there!');
//        },
//        bodyInfo: function() {
//            alert($('body').attr('id'));
//        },
//        dp_placeholder: function (){
//         $('.bm_academic_datepicker').attr('placeholder', 'DD/MM/YYYY');
//    }
//};

//    window.ns = namespace;

//})(this.jQuery);

$(document).ready(function () {
    $('.bm_academic_datepicker').attr('placeholder', 'DD/MM/YYYY');
    $('._searchbox').attr('placeholder', 'Search...');
    //$('._gridrow').val(10);

    //    $('.bm_am_btn_save').click(function (e) {
    //        var isValid = true;
    //        $('.required').each(function () {
    //            var defaultStyle = true;
    //            if (!$.trim($('.bm_academic_textbox').val())) {
    //                isValid = false;
    //                defaultStyle = false;
    //            }
    //            if (!defaultStyle) {
    //                $(this).css({
    //                    "border": "solid 2px #FF0000"
    //                    //"background": "#FFCECE"
    //                });
    //                // $(this).addClass("required_style");
    //                $(this).find('.label_bg').css({
    //                    //"border": "solid 2px #BFBEBC"
    //                    "background": "#FFCECE"
    //                });
    //            } else {
    //                $(this).css({
    //                    "border": "solid 2px #BFBEBC"
    //                    //"background": "#FFCECE"
    //                });
    //                
    //            }
    //        });

    //        if (!isValid) {
    //            e.preventDefault();
    //            //e.stopPropagation();
    //            //e.stopImmediatePropagation();
    //            return false;
    //            
    //        } else {
    //            //alert("Hi");
    //            //e.preventDefault();
    //            //e.stopPropagation();
    //            //e.stopImmediatePropagation();
    //            return true;
    //        }
    //    });


    
});

//$(function(){
//	$('.bm_academic_datepicker').datepicker({
//		inline: true,
//		//nextText: '&rarr;',
//		//prevText: '&larr;',
//		showOtherMonths: true,
//		dateFormat: 'dd/mm/yy',
//		dayNamesMin: ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat']
//		//showOn: "button",
//		//buttonImage: "img/calendar-blue.png",
//		//buttonImageOnly: true,
//	});
//});

function pageLoad(sender, args) {
    $(function () {
        $('.bm_academic_datepicker').datepicker({
            inline: true,
            //nextText: '&rarr;',
            //prevText: '&larr;',
            showOtherMonths: true,
            dateFormat: 'dd/mm/yy',
            dayNamesMin: ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'],
            changeMonth: true,
			changeYear: true,
            yearRange: 'c-60:c+10'
            //showOn: "button",
            //buttonImage: "img/calendar-blue.png",
            //buttonImageOnly: true,
        });
    });
}

//function fnRequiredStyle(idx) {
//    $("#" + idx).parent().parent(".required").css({ "border": "solid 2px #FF0000" });
//    $("#" + idx).parent().parent(".required").find(".label_bg").css({ "background": "#FFCECE" });
//}
//function fnDefaultStyle(idx) {
//    $("#" + idx).parent().parent(".required").css({ "border": "solid 2px #BFBEBC" });
//    $("#" + idx).parent().parent(".required").find(".label_bg").css({ "background": "#C7EBFC" });
//}

//function fnRequiredStyleList(idx) {
//    $("#" + idx).parent().parent().parent(".required").css({ "border": "solid 2px #FF0000" });
//    $("#" + idx).parent().parent().parent(".required").find(".label_bg").css({ "background": "#FFCECE" });
//}

//function fnDefaultStyleList(idx) {
//    $("#" + idx).parent().parent().parent(".required").css({ "border": "solid 2px #BFBEBC" });
//    $("#" + idx).parent().parent().parent(".required").find(".label_bg").css({ "background": "#C7EBFC" });
//}

function fnRequiredStyle(idx) {
    $("#" + idx).parent().parent().css({ "border": "solid 1px #FF0000" });
    $("#" + idx).parent().parent().find("label").parent().css({ "background": "#FFCECE" });
}

function fnDefaultStyle(idx) {
    $("#" + idx).parent().parent().css({ "border": "solid 1px #BFBEBC" });
    $("#" + idx).parent().parent().find("label").parent().css({ "background": "#C7EBFC" });
}

function fnRequiredStyleList(idx) {
    $("#" + idx).parent().parent().parent().css({ "border": "solid 1px #FF0000" });
    $("#" + idx).parent().parent().siblings().find("label").parent().css({ "background": "#FFCECE" });
}

function fnDefaultStyleList(idx) {
    $("#" + idx).parent().parent().parent().css({ "border": "solid 1px #BFBEBC" });
    $("#" + idx).parent().parent().siblings().find("label").parent().css({ "background": "#C7EBFC" });
}

function fnMendatoryFields(mfso) {
    var isValid = true;
    var mendatoryFields = JSON.parse(mfso);
    var _tabindex;
    $.each(mendatoryFields, function(i, fields) {
        if (fields.prop == "tab") {
            _tabindex = $("#" + fields.id).val();
        }
    });

    $.each(mendatoryFields, function (i, fields) {
    if(_tabindex==fields.tab && fields.tab!="-1"){
        if (fields.prop == "text") {
            if (!$.trim($("#" + fields.id).val())) {
                fnRequiredStyle(fields.id);
                isValid = false;
            } else {
                fnDefaultStyle(fields.id);
            }
        } else if (fields.prop == "combo"){
            if ($.trim($("#" + fields.id).val()) == "[Select]" || $.trim($("#" + fields.id).val()) == "") {
                fnRequiredStyle(fields.id);
                isValid = false;
            } else {
                fnDefaultStyle(fields.id);
            }
        } else if (fields.prop == "listtext") {
            if (!$.trim($("#" + fields.id).val())) {
                fnRequiredStyleList(fields.id);
                isValid = false;
            } else {
                fnDefaultStyleList(fields.id);
            }
        }
}
    });

    return isValid;
}


function fnMendatoryFields1(mfso) {
    var isValid = true;
    var mendatoryFields = JSON.parse(mfso);
    var _tabindex;
//    $.each(mendatoryFields, function (i, fields) {
//        if (fields.prop == "tab") {
//            _tabindex = $("#" + fields.id).val();
//        }
//    });

    $.each(mendatoryFields, function (i, fields) {
        //if (_tabindex == fields.tab && fields.tab != "-1") {
            if (fields.prop == "text") {
                if (!$.trim($("#" + fields.id).val())) {
                    fnRequiredStyle(fields.id);
                    isValid = false;
                } else {
                    fnDefaultStyle(fields.id);
                }
            } else if (fields.prop == "combo") {
                if ($.trim($("#" + fields.id).val()) == "[Select]" || $.trim($("#" + fields.id).val()) == "") {
                    fnRequiredStyle(fields.id);
                    isValid = false;
                } else {
                    fnDefaultStyle(fields.id);
                }
            } else if (fields.prop == "listtext") {
                if (!$.trim($("#" + fields.id).val())) {
                    fnRequiredStyleList(fields.id);
                    isValid = false;
                } else {
                    fnDefaultStyleList(fields.id);
                }
            }
        //}
    });

    return isValid;
}

function fnOpenMEMList(zid, ctlid, filter, ctlid1, ctlid2) {
    //alert(zid + "<br/>" + ctlid + "<br/>" + filter);
    var left = Math.round((screen.width / 2) - (500 / 2));
    var top = Math.round((screen.height / 2) - (500 / 2));
    var openwin = window.open("/forms/academic/zlist/memlist.aspx?zid=" + zid + "&ctlid=" + ctlid + "&filter=" + filter + "&ctlid1=" + ctlid1 + "&ctlid2=" + ctlid2, 'mem', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=450, height=450, top=' + top + ', left=' + left + ', targets=_blank');
    openwin.focus();
}

function fnOpenEMPList(zid, ctlid,ctlid2, filter) {
    //alert(zid + "<br/>" + ctlid + "<br/>" + filter);
    var left = Math.round((screen.width / 2) - (500 / 2));
    var top = Math.round((screen.height / 2) - (500 / 2));
    var openwin = window.open("/forms/academic/zlist/emplist.aspx?zid=" + zid + "&ctlid=" + ctlid + "&ctlid2=" + ctlid2 + "&filter=" + filter, 'emp', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=450, height=450, top=' + top + ', left=' + left + ', targets=_blank');
    openwin.focus();
}

function fnOpenEMPList1(zid, ctlid, filter, ctlid1) {
    //alert(zid + "<br/>" + ctlid);
    var left = Math.round((screen.width / 2) - (500 / 2));
    var top = Math.round((screen.height / 2) - (500 / 2));
    var openwin = window.open("/forms/academic/zlist/emplist1.aspx?zid=" + zid + "&ctlid=" + ctlid + "&filter=" + filter + "&ctlid1=" + ctlid1 , 'emp1', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=450, height=450, top=' + top + ', left=' + left + ', targets=_blank');
    openwin.focus();
}

function fnOpenEMPList2(zid, ctlid, type, filter) {
    //alert(zid + "<br/>" + ctlid + "<br/>" + filter);
    var left = Math.round((screen.width / 2) - (500 / 2));
    var top = Math.round((screen.height / 2) - (500 / 2));
    var openwin = window.open("/forms/academic/zlist/emplist2.aspx?zid=" + zid + "&ctlid=" + ctlid + "&type=" + type + "&filter=" + filter, 'emp2', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=450, height=450, top=' + top + ', left=' + left + ', targets=_blank');
    openwin.focus();
}

function fnOpenUserList1(zid, ctlid, filter, ctlid1) {
    //alert(zid + "<br/>" + ctlid);
    var left = Math.round((screen.width / 2) - (500 / 2));
    var top = Math.round((screen.height / 2) - (500 / 2));
    var openwin = window.open("/forms/academic/zlist/userlist1.aspx?zid=" + zid + "&ctlid=" + ctlid + "&filter=" + filter + "&ctlid1=" + ctlid1, 'userl1', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=450, height=450, top=' + top + ', left=' + left + ', targets=_blank');
    openwin.focus();
}

function fnOpenNationalityList(zid, ctlid, filter) {
    //alert(zid + "<br/>" + ctlid);
    var left = Math.round((screen.width / 2) - (500 / 2));
    var top = Math.round((screen.height / 2) - (500 / 2));
    var openwin = window.open("/forms/academic/zlist/nationalitylist.aspx?zid=" + zid + "&ctlid=" + ctlid + "&filter=" + filter, 'nationality', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=450, height=450, top=' + top + ', left=' + left + ', targets=_blank');
    openwin.focus();
}

function fnOpenTFCCodeList(zid, ctlid, filter, ctlid1, gvid) {
    //alert(zid + "<br/>" + ctlid);
    var left = Math.round((screen.width / 2) - (500 / 2));
    var top = Math.round((screen.height / 2) - (500 / 2));
    var openwin = window.open("/forms/academic/zlist/tfccodelist.aspx?zid=" + zid + "&ctlid=" + ctlid + "&filter=" + filter + "&ctlid1=" + ctlid1 + "&gvid=" + gvid, 'tfccode', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=450, height=450, top=' + top + ', left=' + left + ', targets=_blank');
    openwin.focus();
}

function fnOpenTFCCodeList1(zid, ctlid, filter) {
    //alert(zid + "<br/>" + ctlid);
    var left = Math.round((screen.width / 2) - (500 / 2));
    var top = Math.round((screen.height / 2) - (500 / 2));
    var openwin = window.open("/forms/academic/zlist/tfccodelist1.aspx?zid=" + zid + "&ctlid=" + ctlid + "&filter=" + filter , 'tfccode', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=450, height=450, top=' + top + ', left=' + left + ', targets=_blank');
    openwin.focus();
}

function fnOpenTFCCodeList3(zid, ctlid, filter, ctlid1, gvid) {
    //alert(zid + "<br/>" + ctlid);
    var left = Math.round((screen.width / 2) - (500 / 2));
    var top = Math.round((screen.height / 2) - (500 / 2));
    var openwin = window.open("/forms/academic/zlist/tfccodelist3.aspx?zid=" + zid + "&ctlid=" + ctlid + "&filter=" + filter + "&ctlid1=" + ctlid1 + "&gvid=" + gvid, 'tfccode', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=450, height=450, top=' + top + ', left=' + left + ', targets=_blank');
    openwin.focus();
}

function fnOpenSubjectList(zid, ctlid, filter) {
    //alert(zid + "<br/>" + ctlid);
    var left = Math.round((screen.width / 2) - (500 / 2));
    var top = Math.round((screen.height / 2) - (500 / 2));
    var openwin = window.open("/forms/academic/zlist/subjectlist.aspx?zid=" + zid + "&ctlid=" + ctlid + "&filter=" + filter, 'subject', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=450, height=450, top=' + top + ', left=' + left + ', targets=_blank');
    openwin.focus();
}

function fnOpenCommentsList(zid, ctlid, filter) {
    //alert(zid + "<br/>" + ctlid);
    var left = Math.round((screen.width / 2) - (500 / 2));
    var top = Math.round((screen.height / 2) - (500 / 2));
    var openwin = window.open("/forms/academic/zlist/commentslist.aspx?zid=" + zid + "&ctlid=" + ctlid + "&filter=" + filter, 'comments', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=600, height=450, top=' + top + ', left=' + left + ', targets=_blank');
    openwin.focus();
}

function fnOpenProfessionList(zid, ctlid, filter) {
    //alert(zid + "<br/>" + ctlid);
    var left = Math.round((screen.width / 2) - (500 / 2));
    var top = Math.round((screen.height / 2) - (500 / 2));
    var openwin = window.open("/forms/academic/zlist/professionlist.aspx?zid=" + zid + "&ctlid=" + ctlid + "&filter=" + filter, 'profession', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=450, height=450, top=' + top + ', left=' + left + ', targets=_blank');
    openwin.focus();
}

function fnOpenStudentList(zid, ctlid,ctlid2, xclass, xsession, xname) {
    //alert(zid + "<br/>" + ctlid);
    //alert(xclass + "<br/>" + xsession + "<br/>" + xname);
    var left = Math.round((screen.width / 2) - (500 / 2));
    var top = Math.round((screen.height / 2) - (500 / 2));
    var openwin = window.open("/forms/academic/zlist/studentlist.aspx?zid=" + zid + "&ctlid=" + ctlid + "&ctlid2=" + ctlid2 + "&xclass=" + xclass + "&xsession=" + xsession + "&xname=" + xname, 'student', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=450, height=450, top=' + top + ', left=' + left + ', targets=_blank');
    openwin.focus();
}

function fnOpenStudentList1(zid, ctlid, ctlid2, xclass, xsession,xgroup,xsection, xname) {
    //alert(zid + "<br/>" + ctlid);
    //alert(xclass + "<br/>" + xsession + "<br/>" + xname);
    var left = Math.round((screen.width / 2) - (500 / 2));
    var top = Math.round((screen.height / 2) - (500 / 2));
    var openwin = window.open("/forms/academic/zlist/studentlist1.aspx?zid=" + zid + "&ctlid=" + ctlid + "&ctlid2=" + ctlid2 + "&xclass=" + xclass + "&xsession=" + xsession + "&xgroup=" + xgroup + "&xsection=" + xsection + "&xname=" + xname, 'student1', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=450, height=450, top=' + top + ', left=' + left + ', targets=_blank');
    openwin.focus();
}

function fnOpenStudentList2(zid, ctlid, filter, ctlid1) {
    //alert(zid + "<br/>" + ctlid);
    var left = Math.round((screen.width / 2) - (500 / 2));
    var top = Math.round((screen.height / 2) - (500 / 2));
    var openwin = window.open("/forms/academic/zlist/studentlist2.aspx?zid=" + zid + "&ctlid=" + ctlid + "&filter=" + filter + "&ctlid1=" + ctlid1, 'student2', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=450, height=450, top=' + top + ', left=' + left + ', targets=_blank');
    openwin.focus();
}

function fnOpenStudentList3(zid, ctlid, filter, ctlid1) {
    //alert(zid + "<br/>" + ctlid);
    var left = Math.round((screen.width / 2) - (500 / 2));
    var top = Math.round((screen.height / 2) - (500 / 2));
    var openwin = window.open("/forms/academic/zlist/studentlist3.aspx?zid=" + zid + "&ctlid=" + ctlid + "&filter=" + filter + "&ctlid1=" + ctlid1, 'student3', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=450, height=450, top=' + top + ', left=' + left + ', targets=_blank');
    openwin.focus();
}

function fnOpenStudentList4(zid, ctlid, filter) {
    //alert(zid + "<br/>" + ctlid);
    var left = Math.round((screen.width / 2) - (500 / 2));
    var top = Math.round((screen.height / 2) - (500 / 2));
    var openwin = window.open("/forms/academic/zlist/studentlist4.aspx?zid=" + zid + "&ctlid=" + ctlid + "&filter=" + filter, 'student4', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=450, height=450, top=' + top + ', left=' + left + ', targets=_blank');
    openwin.focus();
}

function fnOpenStudentList5(zid, ctlid,ctlid2, xclass, xsession, xname) {
    //alert(zid + "<br/>" + ctlid);
    //alert(xclass + "<br/>" + xsession + "<br/>" + xname);
    var left = Math.round((screen.width / 2) - (500 / 2));
    var top = Math.round((screen.height / 2) - (500 / 2));
    var openwin = window.open("/forms/academic/zlist/studentlist5.aspx?zid=" + zid + "&ctlid=" + ctlid + "&ctlid2=" + ctlid2 + "&xclass=" + xclass + "&xsession=" + xsession + "&xname=" + xname, 'student', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=450, height=450, top=' + top + ', left=' + left + ', targets=_blank');
    openwin.focus();
}

function fnOpenStudentList6(zid, ctlid, filter, ctlid1) {
    //alert(zid + "<br/>" + ctlid);
    var left = Math.round((screen.width / 2) - (500 / 2));
    var top = Math.round((screen.height / 2) - (500 / 2));
    var openwin = window.open("/forms/academic/zlist/studentlist6.aspx?zid=" + zid + "&ctlid=" + ctlid + "&filter=" + filter + "&ctlid1=" + ctlid1, 'student3', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=450, height=450, top=' + top + ', left=' + left + ', targets=_blank');
    openwin.focus();
}

function fnOpenIssueList(zid, ctlid, filter, ctlid1,xwh,xstdid) {
    //alert(zid + "<br/>" + ctlid);
    var left = Math.round((screen.width / 2) - (500 / 2));
    var top = Math.round((screen.height / 2) - (500 / 2));
    var openwin = window.open("/forms/academic/zlist/issuelist.aspx?zid=" + zid + "&ctlid=" + ctlid + "&filter=" + filter + "&ctlid1=" + ctlid1 + "&xwh=" + xwh + "&xstdid=" + xstdid, 'issuelist', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=450, height=450, top=' + top + ', left=' + left + ', targets=_blank');
    openwin.focus();
}

function fnOpenAuthorList(zid, ctlid, filter, ctlid1) {
    //alert(zid + "<br/>" + ctlid);
    var left = Math.round((screen.width / 2) - (500 / 2));
    var top = Math.round((screen.height / 2) - (500 / 2));
    var openwin = window.open("/forms/academic/zlist/authorlist.aspx?zid=" + zid + "&ctlid=" + ctlid + "&filter=" + filter + "&ctlid1=" + ctlid1, 'student3', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=450, height=450, top=' + top + ', left=' + left + ', targets=_blank');
    openwin.focus();
}

function fnOpenBookList5(zid, ctlid, filter, ctlid1) {
    //alert(zid + "<br/>" + ctlid);
    var left = Math.round((screen.width / 2) - (500 / 2));
    var top = Math.round((screen.height / 2) - (500 / 2));
    var openwin = window.open("/forms/academic/zlist/booklist5.aspx?zid=" + zid + "&ctlid=" + ctlid + "&filter=" + filter + "&ctlid1=" + ctlid1, 'student3', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=450, height=450, top=' + top + ', left=' + left + ', targets=_blank');
    openwin.focus();
}

function fnOpenPubList(zid, ctlid, filter, ctlid1) {
    //alert(zid + "<br/>" + ctlid);
    var left = Math.round((screen.width / 2) - (500 / 2));
    var top = Math.round((screen.height / 2) - (500 / 2));
    var openwin = window.open("/forms/academic/zlist/publist.aspx?zid=" + zid + "&ctlid=" + ctlid + "&filter=" + filter + "&ctlid1=" + ctlid1, 'student3', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=450, height=450, top=' + top + ', left=' + left + ', targets=_blank');
    openwin.focus();
}

function fnImageCapture(zid, xpath, ctlid, ctlid2,_row,page) {
    //alert(_row);
    //alert(zid + "<br/>" + xpath + "<br/>" + ctlid);
    var left = Math.round((screen.width / 2) - (500 / 2));
    var top = Math.round((screen.height / 2) - (500 / 2));
    var openwin = window.open("/forms/academic/zwebcam/webcam.aspx?zid=" + zid + "&xpath=" + xpath + "&ctlid=" + ctlid + "&ctlid2=" + ctlid2 + "&_row=" + _row + "&page=" + page, 'stdcapture', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=450, height=450, top=' + top + ', left=' + left + ', targets=_blank');
    openwin.focus();
}

function fnImageCapture1(zid, xpath, ctlid, ctlid2, _row, page) {
    //alert(_row);
    //alert(zid + "<br/>" + xpath + "<br/>" + ctlid);
    var left = Math.round((screen.width / 2) - (500 / 2));
    var top = Math.round((screen.height / 2) - (500 / 2));
    var openwin = window.open("/forms/academic/zwebcam/webcam1.aspx?zid=" + zid + "&xpath=" + xpath + "&ctlid=" + ctlid + "&ctlid2=" + ctlid2 + "&_row=" + _row + "&page=" + page, 'stdcapture', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=500, height=580, top=' + top + ', left=' + left + ', targets=_blank');
    openwin.focus();
}

function fnOpenItemList(zid, ctlid, filter) {
    //alert(zid + "<br/>" + ctlid);
    var left = Math.round((screen.width / 2) - (500 / 2));
    var top = Math.round((screen.height / 2) - (500 / 2));
    var openwin = window.open("/forms/academic/zlist/itemlist.aspx?zid=" + zid + "&ctlid=" + ctlid + "&filter=" + filter , 'item', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=450, height=450, top=' + top + ', left=' + left + ', targets=_blank');
    openwin.focus();
}

function fnOpenItemList1(zid, ctlid, filter) {
    //alert(zid + "<br/>" + ctlid);
    var left = Math.round((screen.width / 2) - (500 / 2));
    var top = Math.round((screen.height / 2) - (500 / 2));
    var openwin = window.open("/forms/academic/zlist/itemlist1.aspx?zid=" + zid + "&ctlid=" + ctlid + "&filter=" + filter, 'student4', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=450, height=450, top=' + top + ', left=' + left + ', targets=_blank');
    openwin.focus();
}

function fnOpenItemList2(zid, ctlid, filter, ctlid1) {
    //alert(zid + "<br/>" + ctlid);
    var left = Math.round((screen.width / 2) - (500 / 2));
    var top = Math.round((screen.height / 2) - (500 / 2));
    var openwin = window.open("/forms/academic/zlist/itemlist2.aspx?zid=" + zid + "&ctlid=" + ctlid + "&filter=" + filter + "&ctlid1=" + ctlid1, 'itemlist2', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=450, height=450, top=' + top + ', left=' + left + ', targets=_blank');
    openwin.focus();
}


function fnOpenBookList(zid, ctlid, filter) {
    //alert(zid + "<br/>" + ctlid);
    var left = Math.round((screen.width / 2) - (500 / 2));
    var top = Math.round((screen.height / 2) - (500 / 2));
    var openwin = window.open("/forms/academic/zlist/booklist.aspx?zid=" + zid + "&ctlid=" + ctlid + "&filter=" + filter, 'item', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=450, height=450, top=' + top + ', left=' + left + ', targets=_blank');
    openwin.focus();
}

function fnOpenBookList1(zid, ctlid, filter, ctlid1, ctlid2) {
    //alert(zid + "<br/>" + ctlid);
    var left = Math.round((screen.width / 2) - (500 / 2));
    var top = Math.round((screen.height / 2) - (500 / 2));
    var openwin = window.open("/forms/academic/zlist/booklist1.aspx?zid=" + zid + "&ctlid=" + ctlid + "&filter=" + filter + "&ctlid1=" + ctlid1 + "&ctlid2=" + ctlid2, 'chartofacc1', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=450, height=450, top=' + top + ', left=' + left + ', targets=_blank');
    openwin.focus();
}

function fnOpenBookList3(zid, ctlid, filter, ctlid1, ctlid2, ctlid3, ctlid4, ctlid5, ctlid6) {
    //alert(zid + "<br/>" + ctlid);
    var left = Math.round((screen.width / 2) - (500 / 2));
    var top = Math.round((screen.height / 2) - (500 / 2));
    var openwin = window.open("/forms/academic/zlist/booklist3.aspx?zid=" + zid + "&ctlid=" + ctlid + "&filter=" + filter + "&ctlid1=" + ctlid1 + "&ctlid2=" + ctlid2 + "&ctlid3=" + ctlid3 + "&ctlid4=" + ctlid4 + "&ctlid5=" + ctlid5 + "&ctlid6=" + ctlid6, 'booklist3', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=450, height=450, top=' + top + ', left=' + left + ', targets=_blank');
    openwin.focus();
}

function fnOpenBookList4(zid, ctlid, filter, ctlid1, ctlid2, ctlid3, ctlid4, ctlid5) {
    //alert(zid + "<br/>" + ctlid);
    var left = Math.round((screen.width / 2) - (500 / 2));
    var top = Math.round((screen.height / 2) - (500 / 2));
    var openwin = window.open("/forms/academic/zlist/booklist4.aspx?zid=" + zid + "&ctlid=" + ctlid + "&filter=" + filter + "&ctlid1=" + ctlid1 + "&ctlid2=" + ctlid2 + "&ctlid3=" + ctlid3 + "&ctlid4=" + ctlid4 + "&ctlid5=" + ctlid5, 'booklist4', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=450, height=450, top=' + top + ', left=' + left + ', targets=_blank');
    openwin.focus();
}

function fnOpenSupplierList(zid, ctlid, filter, ctlid1, gvid) {
    //alert(zid + "<br/>" + ctlid);
    var left = Math.round((screen.width / 2) - (500 / 2));
    var top = Math.round((screen.height / 2) - (500 / 2));
    var openwin = window.open("/forms/academic/zlist/suplist.aspx?zid=" + zid + "&ctlid=" + ctlid + "&filter=" + filter + "&ctlid1=" + ctlid1 + "&gvid=" + gvid, 'tfccode', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=450, height=450, top=' + top + ', left=' + left + ', targets=_blank');
    openwin.focus();
}

function fnOpenChartofAccounts(zid, ctlid, filter, ctlid1, gvid) {
    //alert(zid + "<br/>" + ctlid);
    var left = Math.round((screen.width / 2) - (500 / 2));
    var top = Math.round((screen.height / 2) - (500 / 2));
    var openwin = window.open("/forms/academic/zlist/chartofaccounts.aspx?zid=" + zid + "&ctlid=" + ctlid + "&filter=" + filter + "&ctlid1=" + ctlid1 + "&gvid=" + gvid, 'chartofacc', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=450, height=450, top=' + top + ', left=' + left + ', targets=_blank');
    openwin.focus();
}


function fnOpenChartofAccounts1(zid, ctlid, filter, ctlid1, ctlid2) {
    //alert(zid + "<br/>" + ctlid);
    var left = Math.round((screen.width / 2) - (500 / 2));
    var top = Math.round((screen.height / 2) - (500 / 2));
    var openwin = window.open("/forms/academic/zlist/chartofaccounts1.aspx?zid=" + zid + "&ctlid=" + ctlid + "&filter=" + filter + "&ctlid1=" + ctlid1 + "&ctlid2=" + ctlid2, 'chartofacc1', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=450, height=450, top=' + top + ', left=' + left + ', targets=_blank');
    openwin.focus();
}

function fnOpenChartofAccountsSub(zid, ctlid, filter, ctlid1, xacc) {
    //alert(zid + "<br/>" + ctlid);
    var left = Math.round((screen.width / 2) - (500 / 2));
    var top = Math.round((screen.height / 2) - (500 / 2));
    var openwin = window.open("/forms/academic/zlist/chartofaccountssub.aspx?zid=" + zid + "&ctlid=" + ctlid + "&filter=" + filter + "&ctlid1=" + ctlid1 + "&xacc=" + xacc, 'chartofaccsub', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=450, height=450, top=' + top + ', left=' + left + ', targets=_blank');
    openwin.focus();
}

function fnOpenChartofAccountsCONT(zid, ctlid, filter, ctlid1, ctlid2) {
    //alert(zid + "<br/>" + ctlid);
    var left = Math.round((screen.width / 2) - (500 / 2));
    var top = Math.round((screen.height / 2) - (500 / 2));
    var openwin = window.open("/forms/academic/zlist/chartofaccounts_cont.aspx?zid=" + zid + "&ctlid=" + ctlid + "&filter=" + filter + "&ctlid1=" + ctlid1 + "&ctlid2=" + ctlid2, 'chartofacc1', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=450, height=450, top=' + top + ', left=' + left + ', targets=_blank');
    openwin.focus();
}

function fnOpenChartofAccountsJV(zid, ctlid, filter, ctlid1, ctlid2) {
    //alert(zid + "<br/>" + ctlid);
    var left = Math.round((screen.width / 2) - (500 / 2));
    var top = Math.round((screen.height / 2) - (500 / 2));
    var openwin = window.open("/forms/academic/zlist/chartofaccounts_jv.aspx?zid=" + zid + "&ctlid=" + ctlid + "&filter=" + filter + "&ctlid1=" + ctlid1 + "&ctlid2=" + ctlid2, 'chartofacc1', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=450, height=450, top=' + top + ', left=' + left + ', targets=_blank');
    openwin.focus();
}

function fnOpenChartofAccounts2(zid, ctlid, filter, ctlid1, ctlid2,ctlid3,xaccusage) {
    //alert(zid + "<br/>" + ctlid);
    var left = Math.round((screen.width / 2) - (500 / 2));
    var top = Math.round((screen.height / 2) - (500 / 2));
    var openwin = window.open("/forms/academic/zlist/chartofaccounts2.aspx?zid=" + zid + "&ctlid=" + ctlid + "&filter=" + filter + "&ctlid1=" + ctlid1 + "&ctlid2=" + ctlid2 + "&ctlid3=" + ctlid3 + "&xaccusage=" + xaccusage, 'chartofacc2', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=450, height=450, top=' + top + ', left=' + left + ', targets=_blank');
    openwin.focus();
}

function fnOpenList(zid, ctlid, filter, xtable, xfield) {
    //alert(zid + "<br/>" + ctlid);
    var left = Math.round((screen.width / 2) - (500 / 2));
    var top = Math.round((screen.height / 2) - (500 / 2));
    var openwin = window.open("/forms/academic/zlist/openlist.aspx?zid=" + zid + "&ctlid=" + ctlid + "&filter=" + filter + "&xtable=" + xtable + "&xfield=" + xfield, 'list', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=450, height=450, top=' + top + ', left=' + left + ', targets=_blank');
    openwin.focus();
}

function fnOpenCommentsBank(zid, ctlid, xclass, xtype) {
    //alert(zid + "<br/>" + ctlid);
    var left = Math.round((screen.width / 2) - (500 / 2));
    var top = Math.round((screen.height / 2) - (500 / 2));
    var openwin = window.open("/forms/academic/zlist/commentsbank.aspx?zid=" + zid + "&ctlid=" + ctlid + "&xclass=" + xclass + "&xtype=" + xtype, 'comments', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=600, height=450, top=' + top + ', left=' + left + ', targets=_blank');
    openwin.focus();
}

function fnOpenPayScale(zid, ctlid, filter, ctlid1, gvid) {
    //alert(zid + "<br/>" + ctlid);
    var left = Math.round((screen.width / 2) - (500 / 2));
    var top = Math.round((screen.height / 2) - (500 / 2));
    var openwin = window.open("/forms/academic/zlist/payscale.aspx?zid=" + zid + "&ctlid=" + ctlid + "&filter=" + filter + "&ctlid1=" + ctlid1 + "&gvid=" + gvid, 'chartofacc', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=450, height=450, top=' + top + ', left=' + left + ', targets=_blank');
    openwin.focus();
}

function fnOpenPayCode(zid, ctlid, filter, ctlid1, gvid) {
    //alert(zid + "<br/>" + ctlid);
    var left = Math.round((screen.width / 2) - (500 / 2));
    var top = Math.round((screen.height / 2) - (500 / 2));
    var openwin = window.open("/forms/academic/zlist/paycode.aspx?zid=" + zid + "&ctlid=" + ctlid + "&filter=" + filter + "&ctlid1=" + ctlid1 + "&gvid=" + gvid, 'chartofacc', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=450, height=450, top=' + top + ', left=' + left + ', targets=_blank');
    openwin.focus();
}

function fnOpenPayCodeAdv(zid, ctlid, filter, ctlid1, gvid) {
    //alert(zid + "<br/>" + ctlid);
    var left = Math.round((screen.width / 2) - (500 / 2));
    var top = Math.round((screen.height / 2) - (500 / 2));
    var openwin = window.open("/forms/academic/zlist/paycodeadv.aspx?zid=" + zid + "&ctlid=" + ctlid + "&filter=" + filter + "&ctlid1=" + ctlid1 + "&gvid=" + gvid, 'chartofacc', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no, width=450, height=450, top=' + top + ', left=' + left + ', targets=_blank');
    openwin.focus();
}



function update(updatestr, ctlid) {
    //alert("Hi");
    var c_id = document.getElementById(ctlid);
    c_id.value = updatestr;
    c_id.focus();
    return false;
}

function update8(updstr, ctlid) {
    //alert("Hi");
    var c_id = document.getElementById(ctlid);
    c_id.value = updstr;
   c_id.focus();
    return false;
}

function update9(updstr, updstr1, updstr2, ctlid, ctlid1, ctlid2) {
    //alert("Hi");
    var c_id1 = document.getElementById(ctlid1);
    c_id1.value = updstr1;

    var c_id2 = document.getElementById(ctlid2);
    c_id2.value = updstr2;

    var c_id = document.getElementById(ctlid);
    c_id.value = updstr;
    c_id.focus();

  
    return false;
}



function update10(updstr, updstr1, updstr2, updstr3, ctlid, ctlid1, ctlid2, ctlid3) {
    //alert("Hi");
    var c_id1 = document.getElementById(ctlid1);
    c_id1.innerHTML = updstr1;

    var c_id2 = document.getElementById(ctlid2);
    c_id2.value = updstr2;

    var c_id3 = document.getElementById(ctlid3);
    c_id3.value = updstr3;

    var c_id = document.getElementById(ctlid);
    c_id.value = updstr;
    c_id.focus();


    return false;
}

function update11(updstr, updstr1, updstr2, updstr3, updstr4, updstr5, updstr6, ctlid, ctlid1, ctlid2, ctlid3, ctlid4, ctlid5, ctlid6) {
    //alert(updstr6 + " " + ctlid6);
    var c_id1 = document.getElementById(ctlid1);
    c_id1.innerHTML = updstr1;

    var c_id1 = document.getElementById(ctlid1);
    c_id1.value = updstr1;

    var c_id2 = document.getElementById(ctlid2);
    c_id2.value = updstr2;

    var c_id3 = document.getElementById(ctlid3);
    c_id3.value = updstr3;

    var c_id4 = document.getElementById(ctlid4);
    c_id4.value = updstr4;

    var c_id5 = document.getElementById(ctlid5);
    c_id5.value = updstr5;

    var c_id6 = document.getElementById(ctlid6);
    c_id6.value = updstr6;


    var c_id = document.getElementById(ctlid);
    c_id.value = updstr;
    c_id.focus();


    return false;
}

function update12(updstr, updstr1, updstr2, updstr3, updstr4, updstr5, ctlid, ctlid1, ctlid2, ctlid3, ctlid4, ctlid5) {
    //alert(updstr6 + " " + ctlid6);
    var c_id1 = document.getElementById(ctlid1);
    c_id1.innerHTML = updstr1;

    var c_id1 = document.getElementById(ctlid1);
    c_id1.value = updstr1;

    var c_id2 = document.getElementById(ctlid2);
    c_id2.value = updstr2;

    var c_id3 = document.getElementById(ctlid3);
    c_id3.value = updstr3;

    var c_id4 = document.getElementById(ctlid4);
    c_id4.value = updstr4;

    var c_id5 = document.getElementById(ctlid5);
    c_id5.value = updstr5;

    var c_id = document.getElementById(ctlid);
    c_id.value = updstr;
    c_id.focus();


    return false;
}

function update5(updatestr, ctlid, updatestr1, ctlid1) {
    //alert("Hi");
    //alert(updatestr + " - " + ctlid + "<br/>" + updatestr1 + " - " + ctlid1);
    var c_id = document.getElementById(ctlid);
    var c_id1 = document.getElementById(ctlid1);
    c_id.value = updatestr;
    c_id1.innerHTML = updatestr1;
    return false;
}

function update51(updatestr, ctlid, updatestr1, ctlid1, updatestr2, ctlid2) {
    //alert("Hi");
    //alert(updatestr + " - " + ctlid + "<br/>" + updatestr1 + " - " + ctlid1);
    var c_id = document.getElementById(ctlid);
    var c_id1 = document.getElementById(ctlid1);
    var c_id2 = document.getElementById(ctlid2);
    c_id.value = updatestr;
    c_id1.innerHTML = updatestr1;
    c_id2.value = updatestr2;
    return false;
}

function update7(updatestr, ctlid, updatestr1, ctlid1, gvid,gvval) {
    //alert("Hi");
    //alert(updatestr + " - " + ctlid + "<br/>" + updatestr1 + " - " + ctlid1);
    var c_id = document.getElementById(ctlid);
    var c_id1 = document.getElementById(ctlid1);
    //var gvid_ = document.getElementById(gvid);

    c_id.value = updatestr;
    c_id1.innerHTML = updatestr1;

    //alert(gvid);
    var jsonobj = eval('(' + gvval + ')');

    

    var checkBox = null;
    var textBox = null;
    $("[id*=" + gvid + "] tr").each(function () {
        checkBox = $(this).find("input[id*='selbiz']");
        textBox = $(this).find("input[id*='xamount']");
        checkBox.attr('checked', false);
        textBox.val("");
      
    });

    $("[id*="+ gvid +"] tr").each(function () {
        checkBox = $(this).find("input[id*='selbiz']");
        textBox = $(this).find("input[id*='xamount']");
        //alert($(this).find("td:nth-child(2)").html());
        var v = $(this).find("td:nth-child(2)").html();
        //checkBox.attr('checked', true);
        //textBox.val("1000");
        for (i in jsonobj) {
            if (jsonobj[i]["xtype"] == v) {
                checkBox.attr('checked', true);
                textBox.val(jsonobj[i]["xamount"]);
            }

        }

    });

    return false;
}

function update2(updatestr, updatestr2, ctlid, ctlid2) {
    //alert("Hi");
    var c_id = document.getElementById(ctlid);
    c_id.value = updatestr;
    var std2 = document.getElementById(ctlid2);
    std2.value = updatestr2;
    $("[id$='_row_global']").val(updatestr2);
    document.getElementById(ctlid).focus();
    //alert(updatestr2);
    //alert($("#<%= _student.ClientID%>").val(updatestr2));
    return false;
}

function update3(updatestr, ctlid, ctlid2) {
    //alert(updatestr + " " + ctlid);
    var c_id2 = document.getElementById(ctlid2);
    c_id2.value = updatestr;
    var str = updatestr.substring(1);
    $("[id$='" + ctlid + "']").attr("src", str);
    return false;
}


function update4(updatestr, updatestr2, ctlid, ctlid2) {
    //alert("Hi");
    var c_id = document.getElementById(ctlid);
    c_id.value = updatestr;
    var std2 = document.getElementById(ctlid2);
    std2.value = updatestr2;
    //alert(updatestr2);
    //alert($("#<%= _student.ClientID%>").val(updatestr2));
    return false;
}

//Function for grid navigation with keyboard arrow button
function enter(obj, event) {
    //                alert("hi");
    var tr = obj.parentNode.parentNode;
    //alert(tr);
    // alert(event.keyCode);
    if (event.keyCode == 40) //Down 
    {
        if (tr.rowIndex < tr.parentNode.rows.length - 1)
            tr.parentNode.rows[tr.rowIndex + 1].cells[obj.parentNode.cellIndex].children[0].focus();
        tr.parentNode.rows[tr.rowIndex + 1].cells[obj.parentNode.cellIndex].children[0].select();
        return;
    }
    if (event.keyCode == 37) //Left 
    {
        if (obj.parentNode.cellIndex > 0)
            tr.parentNode.rows[tr.rowIndex].cells[obj.parentNode.cellIndex - 1].children[0].focus();
        tr.parentNode.rows[tr.rowIndex].cells[obj.parentNode.cellIndex - 1].children[0].select();
        return;

    }
    if (event.keyCode == 39) //Right 
    {
        if (obj.parentNode.cellIndex < tr.cells.length - 1)
            tr.parentNode.rows[tr.rowIndex].cells[obj.parentNode.cellIndex + 1].children[0].focus();
        tr.parentNode.rows[tr.rowIndex].cells[obj.parentNode.cellIndex + 1].children[0].select();
        return;

    }
    if (event.keyCode == 38) //Up 
    {
        if (tr.rowIndex > 1)
            tr.parentNode.rows[tr.rowIndex - 1].cells[obj.parentNode.cellIndex].children[0].focus();
        tr.parentNode.rows[tr.rowIndex - 1].cells[obj.parentNode.cellIndex].children[0].select();
        return;

    }
}

$.date = function (dateObject) {
    var month = new Array();
    month[0] = "January";
    month[1] = "February";
    month[2] = "March";
    month[3] = "April";
    month[4] = "May";
    month[5] = "June";
    month[6] = "July";
    month[7] = "August";
    month[8] = "September";
    month[9] = "October";
    month[10] = "November";
    month[11] = "December";

    var da1 = new Array();
    da1[0] = "Sunday";
    da1[1] = "Monday";
    da1[2] = "Tuesday";
    da1[3] = "Wednesday";
    da1[4] = "Thursday";
    da1[5] = "Friday";
    da1[6] = "Saturday";


    var d = new Date(dateObject);
    var da = da1[d.getDay()];
    var day = d.getDate();
    var months = month[d.getMonth()];
    var year = d.getFullYear();
    if (day < 10) {
        day = "0" + day;
    }
    //if (month < 10) {
    //    month = "0" + month;
    //}
    var date = da + ", " + months + " " + day + ", " + year;

    return date;
};


$.confirmmsg = function (msg,title) {

    $('<div title=' + title + '></div>').html(msg)
        .dialog({
            modal:true,
            buttons: {
                "Yes": function () {

                    $(this).dialog("close");
                    return "yes";
                },
                "No": function() {

                    $(this).dialog("close");
                    return "no";
                }
            }
        });

    
};











    
         
         
         
         
         




        