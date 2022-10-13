$(document).ready(function () {
   
    $('#submit').click(function () {

        var Username = $("#username").val();
        var Password = $("#pwd").val();
        if (Username == '') { $("#userNameErrMsg").addClass("d-block"); }
        else { $("#userNameErrMsg").removeClass("d-block"); }
        if (Password == '') { $("#passwordErrMsg").addClass("d-block"); }
        else { $("#passwordErrMsg").removeClass("d-block"); }
        if (Username != "" && Password != "") {
            $.ajax({
                url: 'https://localhost:44338/api/Users/authenticate',
                dataType: "json",
                type: "POST",
                contentType: "application/json",
                data: JSON.stringify({
                    username: Username,
                    password: Password
                }),
                beforeSend: function () {
                    $('#spinner').show();
                },
                complete: function () {
                    $('#spinner').hide();
                },
                processData: false,
                success: function (data, textStatus, jQxhr) {
                    alert("User successfully authenticated")
                    sessionStorage.setItem("token", data.token);
                    if (data.role == "manager") {
                        window.location.replace('ManagerHomePage')
                    }
                    else {
                        window.location.replace('EmployeeHomePage')
                    }
                },
                error: function (jqXhr, textStatus, errorThrown) {
                    alert(jqXhr.responseJSON.message)
                }
            });
        }
  
    });

    $('#reset').click(function () {
        $("#username").val('');
        $("#pwd").val('');
    });
});

