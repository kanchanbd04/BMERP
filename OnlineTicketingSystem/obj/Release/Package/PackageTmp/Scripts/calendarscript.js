var currentUpdateEvent;
var addStartDate;
var addEndDate;
var globalAllDay;

function updateEvent(event, element) {
    //alert(event.description);

    if ($(this).data("qtip")) $(this).qtip("destroy");

    currentUpdateEvent = event;

    $('#updatedialog').dialog('open');
    $("#eventName").val(event.title);
    $("#eventDesc").val(event.description);
    $("#Color1").val(event.color);
    $("#eventId").val(event.id);
    $("#eventStart").text("" + event.start.toLocaleString());

    if (event.end === null) {
        $("#eventEnd").text("");
    }
    else {
        $("#eventEnd").text("" + event.end.toLocaleString());
    }

    return false;
}

function updateSuccess(updateResult) {
    //alert(updateResult);
}

function deleteSuccess(deleteResult) {
    //alert(deleteResult);
}

function addSuccess(addResult) {
    // if addresult is -1, means event was not added
    //    alert("added key: " + addResult);

    if (addResult != -1) {
        $('#calendar').fullCalendar('renderEvent',
						{
						    title: $("#addEventName").val(),
						    start: addStartDate,
						    end: addEndDate,
						    id: addResult,
						    description: $("#addEventDesc").val(),
						    allDay: globalAllDay,
						    color: $("#addEventColor").val()
						},
						true // make the event "stick"
					);


        $('#calendar').fullCalendar('unselect');
    }
}

function UpdateTimeSuccess(updateResult) {
    //alert(updateResult);
}

function selectDate(start, end, allDay) {

    $('#addDialog').dialog('open');
    $("#addEventStartDate").text("" + start.toLocaleString());
    $("#addEventEndDate").text("" + end.toLocaleString());

    addStartDate = start;
    addEndDate = end;
    globalAllDay = allDay;
    //alert(allDay);
}

function updateEventOnDropResize(event, allDay) {

    //alert("allday: " + allDay);
    var eventToUpdate = {
        id: event.id,
        start: event.start
    };

    if (event.end === null) {
        eventToUpdate.end = eventToUpdate.start;
    }
    else {
        eventToUpdate.end = event.end;
    }

    var endDate;
    if (!event.allDay) {
        endDate = new Date(eventToUpdate.end + 60 * 60000);
        endDate = endDate.toJSON();
    }
    else {
        endDate = eventToUpdate.end.toJSON();
    }

    eventToUpdate.start = eventToUpdate.start.toJSON();
    eventToUpdate.end = eventToUpdate.end.toJSON(); //endDate;
    eventToUpdate.allDay = event.allDay;

    PageMethods.UpdateEventTime(eventToUpdate, UpdateTimeSuccess);
}

function eventDropped(event, dayDelta, minuteDelta, allDay, revertFunc) {
    if ($(this).data("qtip")) $(this).qtip("destroy");

    updateEventOnDropResize(event);
}

function eventResized(event, dayDelta, minuteDelta, revertFunc) {
    if ($(this).data("qtip")) $(this).qtip("destroy");

    updateEventOnDropResize(event);
}

function checkForSpecialChars(stringToCheck) {
    var pattern = /[^A-Za-z0-9 ]/;
    return pattern.test(stringToCheck);
}

function isAllDay(startDate, endDate) {
    var allDay;

    if (startDate.format("HH:mm:ss") == "00:00:00" && endDate.format("HH:mm:ss") == "00:00:00") {
        allDay = true;
        globalAllDay = true;
    }
    else {
        allDay = false;
        globalAllDay = false;
    }

    return allDay;
}

function qTipText(start, end, description) {
    var text;

    if (end !== null)
        text = "<strong>Start:</strong> " + start.format("MM/DD/YYYY hh:mm T") + "<br/><strong>End:</strong> " + end.format("MM/DD/YYYY hh:mm T") + "<br/><br/>" + description;
    else
        text = "<strong>Start:</strong> " + start.format("MM/DD/YYYY hh:mm T") + "<br/><strong>End:</strong><br/><br/>" + description;

    return text;
}

$(document).ready(function () {
               
    // update Dialog
    $('#updatedialog').dialog({
        autoOpen: false,
        width: 470,
        buttons: {
            "update": function () {
                //alert(currentUpdateEvent.title);
                var eventToUpdate = {
                    id: currentUpdateEvent.id,
                    title: $("#eventName").val(),
                    description: $("#eventDesc").val(),
                    color: $("#Color1").val()
                };

                if (checkForSpecialChars(eventToUpdate.title) || checkForSpecialChars(eventToUpdate.description)) {
                    alert("please enter characters: A to Z, a to z, 0 to 9, spaces");
                }
                else {
                    PageMethods.UpdateEvent(eventToUpdate, updateSuccess);
                    $(this).dialog("close");

                    currentUpdateEvent.title = $("#eventName").val();
                    currentUpdateEvent.description = $("#eventDesc").val();
                    $('#calendar').fullCalendar('updateEvent', currentUpdateEvent);
                }

            },
            "delete": function () {

                if (confirm("do you really want to delete this event?")) {

                    PageMethods.deleteEvent($("#eventId").val(), deleteSuccess);
                    $(this).dialog("close");
                    $('#calendar').fullCalendar('removeEvents', $("#eventId").val());
                }
            }
        }
    });

    //add dialog
    $('#addDialog').dialog({
        autoOpen: false,
        width: 470,
        buttons: {
            "Add": function () {
                //alert("sent:" + addStartDate.format("dd-MM-yyyy hh:mm:ss tt") + "==" + addStartDate.toLocaleString());
                var eventToAdd = {
                    title: $("#addEventName").val(),
                    description: $("#addEventDesc").val(),
                    color: $("#addEventColor").val(),
                    start: addStartDate.toJSON(),
                    end: addEndDate.toJSON(),
                    allDay: isAllDay(addStartDate, addEndDate)

                };

                if (checkForSpecialChars(eventToAdd.title) || checkForSpecialChars(eventToAdd.description)) {
                    alert("please enter characters: A to Z, a to z, 0 to 9, spaces");
                }
                else {
                    //alert("sending " + eventToAdd.title);

                    PageMethods.addEvent(eventToAdd, addSuccess);
                    $(this).dialog("close");
                }
            }
        }
    });

    var date = new Date();
    var d = date.getDate();
    var m = date.getMonth();
    var y = date.getFullYear();
    var options = {
        weekday: "long", year: "numeric", month: "short",
        day: "numeric", hour: "2-digit", minute: "2-digit"
    };

    $('#calendar').fullCalendar({

        timezone: 'local',
        height: 550,
        theme: false,
        businessHours: true,
        //editable: true,

        //        customButtons: {
        //            datePickerButton: {
        //                themeIcon:'circle-triangle-s',
        //                click: function () {


        //                    var $btnCustom = $('.fc-datePickerButton-button'); // name of custom  button in the generated code
        //                    $btnCustom.after('<input type="hidden" id="hiddenDate" class="datepicker"/>');

        //                    $("#hiddenDate").datepicker({
        //                        showOn: "button",

        //                        dateFormat:"yy-mm-dd",
        //                        onSelect: function (dateText, inst) {
        //                            $('#calendar').fullCalendar('gotoDate', dateText);
        //                        },
        //                    });

        //                    var $btnDatepicker = $(".ui-datepicker-trigger"); // name of the generated datepicker UI 
        //                    //Below are required for manipulating dynamically created datepicker on custom button click
        //                    $("#hiddenDate").show().focus().hide();
        //                    $btnDatepicker.trigger("click"); //dynamically generated button for datepicker when clicked on input textbox
        //                    $btnDatepicker.hide();
        //                    $btnDatepicker.remove();
        //                    $("input.datepicker").not(":first").remove();//dynamically appended every time on custom button click

        //                }
        //            }
        //        },

        // header
//        header: {
//            //left: 'prev,next today datePickerButton',
//            //left: 'prevYear,prev,next,nextYear today',
//            //center: 'title',
//            //right: 'month,basicWeek'
        //        },

header:false,

//        views: {
//            agendaFourDay: {
//                type: 'listWeek',
//                duration: { days: 7 },
//                buttonText: 'Week'
//            }
//        },
        defaultView: 'month',
        //eventClick: updateEvent,
        selectable: false,
        selectHelper: true,
        select: selectDate,
        editable: false,
        allDaySlot: false,
        displayEventTime: false,
        events: "/JsonResponse.ashx",
        eventDrop: eventDropped,
        eventResize: eventResized,
        eventRender: function (event, element) {
            //alert(event.title);
            //element.find('.fc-title').css("background-color", "#D0E9F5");
            //element.find('.fc-title').css("border-color", "#ADD9ED");
           element.find('.fc-title').css("color", "#000000");
           element.find('.fc-title').css("font-weight", "bold");
           element.find('.fc-title').css("font-size", "11px");
           //element.find('.fc-title').css("font-style", "italic");
           function convertDate(d) {
               var parts = d.split(" ");
               var months = { Jan: "01", Feb: "02", Mar: "03", Apr: "04", May: "05", Jun: "06", Jul: "07", Aug: "08", Sep: "09", Oct: "10", Nov: "11", Dec: "12" };
               return parts[3] + "-" + months[parts[1]] + "-" + parts[2];
           }

            var d = event.start.toString();
           //alert(convertDate(d));
//           var d = new Date();
//           var curr_date = d.getDate();
//           var curr_month = d.getMonth() + 1; //Months are zero based
//           var curr_year = d.getFullYear();
//           //var evnstart = event.start.toDateString("yyyy-MM-dd");
//           alert(curr_year + "-" + curr_month + "-" + curr_date);
           ////// $('#calendar').find('[data-date="' + convertDate(d) + '"]').css("background-color", event.color.toString());
            //$('#calendar').find('[data-date="' + convertDate(d) + '"]').css("margin", "15px");
           //element.find('.fc-title').css("height", "30px");
           //element.find('.fc-title').after("<div style='color:#5E99BD;'>" + event.description + "</div>");
            //element.find('.fc-title').after("<div style='height:35px;'></div>");
//            function hex2rgba(hex, opacity) {
//                //extract the two hexadecimal digits for each color
//                var patt = /^#([\da-fA-F]{2})([\da-fA-F]{2})([\da-fA-F]{2})$/;
//                var matches = patt.exec(hex);

//                //convert them to decimal
//                var r = parseInt(matches[1], 16);
//                var g = parseInt(matches[2], 16);
//                var b = parseInt(matches[3], 16);

//                //create rgba string
//                var rgba = "rgba(" + r + "," + g + "," + b + "," + opacity + ")";

//                //return rgba colour
//                return rgba;
//            }
            element.find('.fc-content').css("background-color", event.color.toString());
            //element.find('.fc-content').css("opacity", "0.5");
            element.find('.fc-content').parent().css("border-color", "#FFFFFF");
            element.find('.fc-content').parent().css("border-width", "2px");
            element.find('.fc-content').parent().css("background-color", event.color.toString());
            //element.find('.fc-title').css("color", "#FFFFFF");
            //element.find('.fc-title').css("position", "absolute");
            element.find('.fc-title').css("opacity", "1");
            element.qtip({
                content: {
                    text: event.description, //qTipText(event.start, event.end, event.description),
                    title: '<strong>' + event.title + '</strong>'
                },
                position: {
                    my: 'bottom left',
                    at: 'top right'
                },
                style: { classes: 'qtip-shadow qtip-rounded qtip-blue' }
            });
        }
    });

    
});
