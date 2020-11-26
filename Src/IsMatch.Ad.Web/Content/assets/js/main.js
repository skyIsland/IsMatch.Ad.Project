function renderSelect(data) {
    var html = '<option value=0>请选择</option>';
    data.forEach(p => html += '<option value=' + p.Value + '>' + p.Text + '</option>');
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
}

function getGoods() {
    var categoryId = $('#cid').val();
    var methodName = "GET";
    var actionUrl = "/GoodsManager/GoodsManager/GetList";
    var actionParamter = { categoryId };

    if (categoryId) {
        doActionNew(methodName, actionUrl, actionParamter, function (data) {
            if (data && data.length > 0) {
                var html = renderSelect(data);
                $('#tid').html(html);
            }
        });
    }
}

$(function () {
    getCategory();
});