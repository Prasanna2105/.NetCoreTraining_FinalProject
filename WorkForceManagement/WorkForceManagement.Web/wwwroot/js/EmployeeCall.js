$(document).ready(function () {
    $.ajax({
        url: 'https://localhost:44338/api/Employees/GetEmployees',
        dataType: "json",
        type: "GET",
        headers: { "Authorization": 'Bearer ' + sessionStorage.getItem('token') },
        contentType: "application/json",
        success: function (data, textStatus, error) {
            if (data) {
                let code = ""
                for (let x in data) {
                    code += "<tr>"
                    code += "<td>" + data[x].employee_id + "</td>"
                    code += "<td>" + data[x].employee_name + "</td>"
                    code += "<td>" + data[x].skills + "</td>"
                    code += "<td>" + data[x].experience + "</td>"
                    code += "<td>" + data[x].manager + "</td>"
                    code += "<td>" + data[x].wfm_manager + "</td>"
                    code += "<td> <button class='btn btn-primary' onclick='RequestlockPopup(" + data[x].employee_id + ",\"" + data[x].manager + "\")'> Request Lock </button> </td>"
                    code += "</tr>"
                }
                $("#tdata").html(code)
            }
        },
        error: function (error, textStatus, errorThrown) {
            alert(error.responseJSON.message)
        }
    });
});

function RequestlockPopup(id,manager) {
    $('#empid').text("Please confirm the lock request for " + id + "");
    $('#employeeid').val(id);
    $('#manager').val(manager);
    $('#lockrequestmodal').modal('show');

}

function SendRequest() {
    var reqmessage = $('#requestmsg').val();
    var employeeid = $('#employeeid').val();
    var managername = $('#manager').val();
    $.ajax({
        url: 'https://localhost:44338/api/Softlocks/InsertSoftlock',
        dataType: "json",
        type: "POST",
        headers: { "Authorization": 'Bearer ' + sessionStorage.getItem('token') },
        data: JSON.stringify({
            employee_id: employeeid,
            manager: managername,
            requestmessage: reqmessage
        }),
        contentType: "application/json",
        beforeSend: function () {
            $('#spinner').show();
        },
        complete: function () {
            $('#spinner').hide();
        },
        processData: false,
        success: function (data, textStatus, jQxhr) {
            AlertSuccessMsg("SoftLock Request sent successfully")
        },
        error: function (jqXhr, textStatus, errorThrown) {
            AlertErrorMsg("Error occured while inserting")
        }
    });
    $('#lockrequestmodal').modal('hide');
    $('#requestmsg').val('');
}

function AlertSuccessMsg(msg) {
    $("#SuccessMsg").html(msg);
    $("#SuccessMsg").removeClass('d-none');
    $("#SuccessMsg").addClass('d-block');
    setTimeout(function () {
        $("#SuccessMsg").addClass('d-none');
        $("#SuccessMsg").removeClass('d-block');
        $('#SuccessMsg').fadeOut('fast');
    }, 5000);
}
function AlertErrorMsg(msg) {
    $("#ErrMsg").html(msg);
    $("#ErrMsg").removeClass('d-none');
    $("#ErrMsg").addClass('d-block');
    setTimeout(function () {
        $("#ErrMsg").addClass('d-none');
        $("#ErrMsg").removeClass('d-block');
        $('#ErrMsg').fadeOut('fast');
    }, 5000);
}
