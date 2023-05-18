$("#btnChooseImage").click(function (e) {
    e.preventDefault();
    var finder = new CKFinder();
    finder.selectActionFunction = function (fileurl) {
        $('#book_ImagePath').val(fileurl);
    }
    finder.popup();
});

$(document).ready(function () {

    $('.btnConfirmOrder').on('click', function (e) {
        e.preventDefault();
        var btn = $(this);
        var id = btn.data("id");
        $.confirm({
            title: 'Xác nhận!',
            content: 'Xác nhận giao hàng!',
            buttons: {
                OK: function () {
                    $.ajax({
                        url: '/Admin/ManageOrder/Confirm',
                        type: 'Post',
                        data: { id: id },
                        dataType: 'json',
                        success: function (mes) {
                            if (mes.status == true) {
                                alert("Xác nhận đơn hàng thành công !");
                                location.href = "/Admin/ManageOrder/Details/" + id;
                            }
                        }
                    });
                },
                cancel: function () {
                }
            }
        });

    });
    $('.btnCancelOrder').on('click', function (e) {
        e.preventDefault();
        var btn = $(this);
        var id = btn.data("id");
        $.confirm({
            title: 'Xác nhận!',
            content: 'Bạn muốn hủy đơn hàng này!',
            buttons: {
                OK: function () {
                    $.ajax({
                        url: '/Admin/ManageOrder/Cancel',
                        type: 'Post',
                        data: { id: id },
                        dataType: 'json',
                        success: function (mes) {
                            if (mes.status == true) {
                                alert("Hủy đơn hàng thành công !");
                                location.href = "/Admin/ManageOrder/Index";
                            }
                        }
                    });
                },
                cancel: function () {
                }
            }
        });

    });

    $('.btnSaveBook').on('click', function (e) {
        e.preventDefault();
        var data = $('.frmEdit').serialize();

        $.ajax({
            url: '/Admin/HomeAdmin/Edit',
            type: 'Post',
            data: data,
            dataType: 'json',
            success: function (mes) {
                if (mes.status == true) {
                    alert("Cập nhật thành công !");
                }
            }
        });
    });

});


$(document).ready(function () {

    $('#addAuthor').on('click', function (e) {
        e.preventDefault();
        $.confirm({
            title: 'Thông Tin!',
            content: '' +
                '<form action="" class="formName">' +
                '<div class="form-group">' +
                '<label>Nhập tên tác giả</label>' +
                '<input type="text" placeholder="Ví dụ: Đoàn Quang Vinh" class="AuthorName form-control" required />' +
                '</div>' +
                '<div class="form-group">' +
                '<label>Nghề nghiệp</label>' +
                '<input type="tel" placeholder="ví dụ: Nhà văn" class="job form-control" required />' +
                '</div>' +
                '</form>',
            buttons: {
                formSubmit: {
                    text: 'Xác nhận',
                    btnClass: 'btn-danger',
                    action: function () {
                        var AuthorName = this.$content.find('.AuthorName').val();
                        var job = this.$content.find('.job').val();
                        if (!AuthorName) {
                            $.alert('Vui lòng nhập tên tác giả');
                            return false;
                        }
                        else if (!job) {
                            $.alert('Vui lòng nhập tên công việc');
                            return false;
                        }
                        else {
                            $.ajax({
                                url: '/Admin/HomeAdmin/AddAuthor',
                                type: 'Post',
                                data: { AuthorName: AuthorName, job: job },
                                dataType: 'json',
                                success: function (mes) {
                                    if (mes.status == true) {
                                        $.confirm({
                                            title: 'Thông báo',
                                            content: 'Thêm thành công !',
                                            buttons: {
                                                'OK': function () {
                                                    location.href = "/Admin/HomeAdmin/CreateNewBook";
                                                }
                                            }
                                        });

                                    }
                                    else {
                                        $.alert({
                                            title: 'Thông báo!',
                                            content: 'Thêm không thành công !',
                                        });
                                        return;
                                    }
                                }

                            });
                        }

                    }
                },
                cancel: function () {
                    //close
                },
            },
            onContentReady: function () {
                // bind to events
                var jc = this;
                this.$content.find('form').on('submit', function (e) {
                    // if the user submits the form by pressing enter in the field.
                    e.preventDefault();
                    jc.$$formSubmit.trigger('click'); // reference the button and click it
                });
            }
        });

    });
    $('#addCategory').on('click', function (e) {
        e.preventDefault();
        $.confirm({
            title: 'Thông Tin!',
            content: '' +
                '<form action="" class="formName">' +
                '<div class="form-group">' +
                '<label>Nhập thể loại</label>' +
                '<input type="text" placeholder="Ví dụ: Tiểu thuyết" class="category form-control" required />' +
                '</div>' +
                '</form>',
            buttons: {
                formSubmit: {
                    text: 'Xác nhận',
                    btnClass: 'btn-danger',
                    action: function () {
                        var category = this.$content.find('.category').val();
                        if (!category) {
                            $.alert('Vui lòng nhập tên thể loại');
                            return false;
                        }
                        else {
                            $.ajax({
                                url: '/Admin/HomeAdmin/AddCategory',
                                type: 'Post',
                                data: { category: category },
                                dataType: 'json',
                                success: function (mes) {
                                    if (mes.status == true) {
                                        $.confirm({
                                            title: 'Thông báo',
                                            content: 'Thêm thành công !',
                                            buttons: {
                                                'OK': function () {

                                                    location.href = "/Admin/HomeAdmin/CreateNewBook";
                                                }
                                            }
                                        });

                                    }
                                    else {
                                        $.alert({
                                            title: 'Thông báo!',
                                            content: 'Thêm không thành công !',
                                        });
                                        return;
                                    }
                                }

                            });
                        }

                    }
                },
                cancel: function () {
                    //close
                },
            },
            onContentReady: function () {
                // bind to events
                var jc = this;
                this.$content.find('form').on('submit', function (e) {
                    // if the user submits the form by pressing enter in the field.
                    e.preventDefault();
                    jc.$$formSubmit.trigger('click'); // reference the button and click it
                });
            }
        });

    });

});