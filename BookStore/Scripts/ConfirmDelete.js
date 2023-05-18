$('.deleteBook').off('click').on('click', function () {
    var btn = $(this);
    var id = btn.data('id');
    $.confirm({
        title: 'Xóa sản phẩm',
        content: 'Bạn có chắc chắn muốn xóa sản phẩm ' + btn.data('name'),
        buttons: {
            'Đồng ý': function () {
                $.ajax({
                    url: '/Cart/Delete',
                    type: 'Post',
                    data: { id: id },
                    dataType: 'json',
                    success: function (mes) {
                        if (mes.status == true) {
                            location.href = '/Cart/Index';
                        }
                        else {
                            $.alert({
                                title: 'Lỗi!',
                                content: 'Xóa không thành công!',
                            });
                        }
                    }

                });
            },
            somethingElse: {
                text: 'Hủy',
                btnClass: 'btn-blue',
                keys: ['enter', 'shift'],
                action: function () {
                }
            }
        }
    });
});