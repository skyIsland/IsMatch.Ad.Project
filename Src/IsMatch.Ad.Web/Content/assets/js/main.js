function renderSelect(title, data, callback) {
    var html = '<option value=0>请选择' + title + '</option>';
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
            var html = renderSelect('分类', data);
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
                var html = renderSelect('商品', data, function (d) {
                    return ` data-price="${d.Price}" data-remark="${d.Remark}" `;
                });
                $('#tid').html(html);
            }
        });
    }
}

function getGoodsDetail() {
    $('#num').val(1);
    $('#need').val('');

    var ele = $('#tid');
    var price = ele.find('option:selected').data('price');
    var remark = ele.find('option:selected').data('remark');

    $('#need').val('￥' + price.toFixed(2) + "元").data('price', price);
    $('#alert_frame').html(remark);

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

function queryOrder() {
    var searchtype = $('#searchtype').val();
    var keyword = $('#qq3').val();

    if (!keyword) {
        layer.alert('请先输入内容。', { icon: 2, anim: 6 });
        return;
    }

    $('#submit_query').val('Loading');
    $('#result2').hide();
    $('#list').html('');

    var methodName = "GET";
    var actionUrl = "/Home/GetOrderStatus";
    var actionParamter = { searchtype, keyword };

    doActionNew(methodName, actionUrl, actionParamter, function (data) {
        var status;
        $.each(data, function (i, item) {
            if (item.Status == 1)
                status = '<span class="label label-success">已完成</span>';
            else if (item.Status == 2)
                status = '<span class="label label-warning">处理中</span>';
            else if (item.Status == 3)
                status = '<span class="label label-danger">异常</span>';
            else if (item.Status == 4)
                status = '<font color=red>已退款</font>';
            else
                status = '<span class="label label-primary">待处理</span>';
            $('#list').append('<tr><td>' + item.PlaceOrder + '</td><td>' + item.GoodsName + '</td><td>' + item.Nums + '</td><td class="hidden-xs">' + item.CreateTime + '</td><td>' + status + '</td></tr>');
            if (item.result != null) {
                //if (item.Status == 3) {
                //    $('#list').append('<tr><td colspan=6><font color="red">异常原因：' + item.result + '</font></td></tr>');
                //}
            }
        });
        var addstr = '';
        $('#list').append('<tr><td colspan=6>' + addstr + '</td></tr>');
        if ($(window).width() > 768 && typeof querymode === "undefined") {
            if ($('#list2').length > 0) {
                $('#list2').html($('#list').html());
            } else {
                layer.open({
                    type: 1,
                    shadeClose: true,
                    shade: false,
                    zIndex: 90,
                    area: [";max-width:90%;min-width:800px", ";max-height:100%"],
                    title: '查询订单',
                    skin: 'layui-layer-rim',
                    content: '<div class="table-responsive"><table class="table table-vcenter table-condensed table-striped"><thead><tr><th>下单账号</th><th>商品名称</th><th>数量</th><th class="hidden-xs">购买时间</th><th>状态</th></tr></thead><tbody id="list2">' + $('#list').html() + '</tbody></table></div>'
                });
            }
        } else {
            $("#result2").slideDown();
        }
        $('#submit_query').val('立即查询');
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