function renderSelect(data, callback) {
    var html = '<option value=0>请选择</option>';
    data.forEach(p => {
        var attr = (callback && typeof callback == 'function' ? callback(p) : '');
        html += '<option ' + attr + ' value=' + p.Value + '>' + p.Text + '</option>';
    });;
    return html;
}
function getCategory() {
    var methodName = "GET";
    var actionUrl = "/CategoryManager/CategoryManager/GetList";
    var actionParamter = {};

    doActionNew(methodName, actionUrl, actionParamter, function (data) {
        if (data && data.length > 0) {
            var html = renderSelect(data);
            $('#cid').html(html);
            $('#cid').val(0);
        }
    });

    $('#display_price').hide();
    $('#display_num').hide();
    $('#alert_frame').hide();
    $('#display_PlaceOrder').hide();
    $('#display_SerialNumber').hide();
    $('#display_ercode').hide();

}

function getGoods() {
    var categoryId = $('#cid').val();
    var methodName = "GET";
    var actionUrl = "/GoodsManager/GoodsManager/GetList";
    var actionParamter = { categoryId };

    if (categoryId) {
        doActionNew(methodName, actionUrl, actionParamter, function (data) {
            if (data && data.length > 0) {
                var html = renderSelect(data, function (d) {
                    return ` data-price="${d.Price}" data-remark="${d.Remark}" `;
                });
                $('#tid').html(html);
            }
        });
    }
}

function getGoodsDetail() {
    var ele = $('#tid');
    var price = ele.find('option:selected').data('price');
    var remark = ele.find('option:selected').data('remark');

    $('#need').val('￥' + price.toFixed(2) + "元").data('price', price);
    $('#alert_frame').html(remark);
    $('#num').val(1);
    $('#VideoNo').val();

    $('#display_price').show();
    $('#display_num').show();
    $('#alert_frame').show();
    $('#display_PlaceOrder').show();
    $('#display_VideoNo').show();
}

function commit() {
    var GoodsID = $('#tid').val();
    var Nums = $('#num').val();
    var VideoNo = $('#VideoNo').val();
    var PlaceOrder = $('#PlaceOrder').val();

    var obj = { GoodsID, Nums, VideoNo, PlaceOrder };

    var methodName = "POST";
    var actionUrl = "/OrdersManager/OrdersManager/Save";
    var actionParamter = obj;

    doActionNew(methodName, actionUrl, actionParamter, function (data) {
        layer.alert("下单成功", function (index) {
            $('#display_ercode').show();
            $('#display_SerialNumber').html(`您的订单号为：${data}，请及时扫码支付！有疑问请添加小二微信/QQ进行沟通`).show();
            layer.close(index);
        });
    });
}

$(function () {
    getCategory();

    $("#num_add").click(function () {
        var i = parseInt($("#num").val());
        if ($("#need").val() == '') {
            layer.alert('请先选择商品');
            return false;
        }
        //var multi = $('#tid option:selected').attr('multi');
        var count = parseInt($('#tid option:selected').data('count'));
        //if (multi == '0') {
        //    layer.alert('该商品不支持选择数量');
        //    return false;
        //}
        i++;
        $("#num").val(i);
        var price = parseFloat($('#tid option:selected').data('price'));
        //if (prices != '' || prices != 'null') {
        //    var discount = 0;
        //    $.each(prices.split(','), function (index, item) {
        //        if (i >= parseInt(item.split('|')[0])) discount = parseFloat(item.split('|')[1]);
        //    });
        //    price = price - discount;
        //}
        price = price * i;
        count = count * i;
        if (count > 1) $('#need').val('￥' + price.toFixed(2) + "元 ➠ " + count + "个");
        else $('#need').val('￥' + price.toFixed(2) + "元");
    });
    $("#num_min").click(function () {
        var i = parseInt($("#num").val());
        if (i <= 1) {
            layer.msg('最低下单一份哦！');
            return false;
        }
        if ($("#need").val() == '') {
            layer.alert('请先选择商品');
            return false;
        }
        //var multi = $('#tid option:selected').attr('multi');
        //var count = parseInt($('#tid option:selected').attr('count'));
        //if (multi == '0') {
        //    layer.alert('该商品不支持选择数量');
        //    return false;
        //}
        i--;
        if (i <= 0) i = 1;
        $("#num").val(i);
        var price = parseFloat($('#tid option:selected').data('price'));
        var prices = $('#tid option:selected').data('prices');
        if (prices != '' || prices != 'null') {
            var discount = 0;
            $.each(prices.split(','), function (index, item) {
                if (i >= parseInt(item.split('|')[0])) discount = parseFloat(item.split('|')[1]);
            });
            price = price - discount;
        }
        price = price * i;
        count = count * i;
        if (count > 1) $('#need').val('￥' + price.toFixed(2) + "元 ➠ " + count + "个");
        else $('#need').val('￥' + price.toFixed(2) + "元");
    });
});