$('.btnCheckout').off('click').on('click', function () {

    $.confirm({
        title: 'Thông Tin!',
        content: '' +
            '<form action="" class="formName">' +
            '<div class="form-group">' +
            '<label>Nhập địa chỉ nhận hàng</label>' +
            '<input type="text" placeholder="Ví dụ: Tiến Thinh- Mê Linh- Hà Nội" class="address form-control" required />' +
            '</div>' +
            '<div class="form-group">' +
            '<label>Nhập số điện thoại</label>' +
            '<input type="tel" placeholder="ví dụ: 0348840032" class="phone form-control" required />' +
            '</div>' +
            '<div class="form-group">' +
            '<label>Ghi chú</label>' +
            '<input type="textarea" placeholder="bạn có lưu ý gì khi giao hàng không?" class="note form-control" />' +
            '</div>' +
            '</form>',
        buttons: {
            formSubmit: {
                text: 'Xác nhận',
                btnClass: 'btn-danger',
                action: function () {
                    var address = this.$content.find('.address').val();
                    var phone = this.$content.find('.phone').val();
                    var note = this.$content.find('.note').val();
                    if (!address) {
                        $.alert('Vui lòng nhập địa chỉ');
                        return false;
                    }
                    else if (!phone) {
                        $.alert('Vui lòng nhập số điện thoại');
                        return false;
                    }
                    else {
                        $.ajax({
                            url: '/Cart/Checkout',
                            type: 'Post',
                            data: { address: address, phone: phone, note: note },
                            dataType: 'json',
                            success: function (mes) {
                                if (mes.status == true) {
                                    $.confirm({
                                        title: 'Thông báo',
                                        content: 'Đặt hàng thành công !',
                                        buttons: {
                                            'OK': function () {
                                                $.ajax({
                                                    url: '/Cart/DeleteCart',
                                                    type: 'GET',
                                                    success: function () {
                                                        location.href = '/Home/Index';
                                                    }
                                                });
                                                
                                                
                                            }
                                        }
                                    });
                                   
                                }
                                else {
                                    $.alert({
                                        title: 'Thông báo!',
                                        content: 'Thanh toán không thành công.</br> Bạn cần chọn sản phẩm để có thể thanh toán !',
                                    });
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