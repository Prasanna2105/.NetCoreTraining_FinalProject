$(document).ready(function () {
    $.ajax({
        url: 'https://localhost:44338/api/Softlocks/GetSoftlocks',
        dataType: "json",
        type: "GET",
        headers: { "Authorization": 'Bearer ' + sessionStorage.getItem('token') },
        contentType: "application/json",
        success: function (data, textStatus, error) {
            if (data) {
                let code = "";
                for (let x in data) {
                    code += "<tr>"
                    code += "<td>" + data[x].employee_id + "</td>"
                    code += "<td>" + data[x].employee_name + "</td>"
                    code += "<td>" + data[x].manager + "</td>"
                    code += "<td>" + data[x].requestmessage + "</td>"
                    code += "<td>" + data[x].managerstatus + "</td>"
                    code += "<td>" + data[x].reqdate + "</td>"
                    code += "<td> <button class='btn btn-primary' onclick = 'ViewDetails(" + data[x].lockid + ")'> View Details </button> </td> </tr>"
                }
                $('#tdata').html(code)
            }
        },
        error: function (error, textStatus, errorThrown) {
            alert(error.responseJSON.message)
        }
    });
});

function ViewDetails(id) {
   
    $.ajax({
        url: 'https://localhost:44338/api/Softlocks/GetSoftLocksById?lockid='+id+'',
        type: "GET",
        cache: false,
        contentType: "application/json",
        headers: { "Authorization": 'Bearer ' + sessionStorage.getItem('token') },
        beforeSend: function () {
            $('#spinner').show();
        },
        complete: function () {
            $('#spinner').hide();
        },
        processData: false,
        success: function (data) {
            if (data != null) {
                $('#lockid').val(data.lockid);
                $('#empid').val(data.employee_id);
                $('#empname').val(data.employee_name);
                $('#manager').val(data.manager);
                $('#requestmsg').val(data.requestmessage);
                $('#softlockrequestmodal').modal('show');
            }
        },
        error: function (e) {
            alert("Error in getting the data")
        }
    });
}

function RequestConfirmation() {
    var employeeid = $('#empid').val();
    var lockid = $('#lockid').val();
    var employeename = $('#empname').val();
    var manager = $('#manager').val();
    var reqmsg = $('#requestmsg').val();
    var status = $('#status option:selected').val();
    $.ajax({
        url: 'https://localhost:44338/api/Softlocks/UpdateSoftlockStatus',
        dataType: "json",
        type: "POST",
        headers: { "Authorization": 'Bearer ' + sessionStorage.getItem('token') },
        data: JSON.stringify({
            lockid: lockid,
            employee_id: employeeid,
            employee_name: employeename,
            manager: manager,
            requestmessage: reqmsg,
            managerstatus: status
        }),
        contentType: "application/json",
        beforeSend: function () {
            $('#spinner').show();
        },
        complete: function () {
            $('#spinner').hide();
        },
        processData: false,
        success: function (result) {
            AlertSuccessMsg("SoftLock Status Updated successfully")
        },
        error: function (e) {
            AlertErrorMsg("Error occured in updating")
        }       
    });
    $('#softlockrequestmodal').modal('hide');
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

