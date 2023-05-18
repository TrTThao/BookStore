$(document).ready(function () {

    $('#btnRegister').on('click', function (e) {
        e.preventDefault();
        var da = $("#frmRegister").serialize();
        $.ajax({
            url: '/Login/Register',
            type: 'POST',
            data: da,
            dataType: 'json',
            success: function (mes) {
                if (mes.status == "1") {
                    alert("Đăng Ký thành công !");
                    location.href = "/Login/Login";
                    return;
                }
                else if (mes.status == "-1") {
                    alert("Mật khẩu không trùng khớp!");
                    return;
                }
                else if (mes.status == "-2") {
                    alert("Username đã tồn tại!");
                    return;
                }
                else {
                    alert("Bạn cần nhập đầy đủ thông tin!");
                    return;
                }
            }
        });
    });

});
