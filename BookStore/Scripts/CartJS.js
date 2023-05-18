
$(document).ready(function () {
    $(".plusx").on('click', function () {
        var btnPlus = $(this);
        var idBook = btnPlus.data('id');
        $("#quantity-" + idBook).val(parseInt($("#quantity-" + idBook).val(), 10) + 1);

    });
    $(".minus").on('click', function () {
        var btnMinus = $(this);
        var idBook = btnMinus.data('idminus');
        if (parseInt($('#quantity-' + idBook).val(), 10) > 1)
            $("#quantity-" + idBook).val(parseInt($("#quantity-" + idBook).val(), 10) - 1);
    });

    $('.btnUpdateCart').on('click', function () {
        var lstBook = $('.txtquantity');
        var CartList = [];
        $.each(lstBook, function (index, item) {
            CartList.push({
                Quantity: $(item).val(),
                Book: { ID: $(item).data('id') }
            });
        });

        $.ajax({
            url: '/Cart/UpdateCart',
            type: 'POST',
            data: { cartModel: JSON.stringify(CartList) },
            DataType: 'json',
            success: function (mes) {
                if (mes.status == true) {
                    location.href='/Cart/Index';
                }
            }
            
        });
    });

});