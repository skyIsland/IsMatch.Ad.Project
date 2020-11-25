function renderSelect(data) {
    var html = '';
    data.forEach(p => html += '<option value=' + p.Value + '>' + p.Text + '</option>');
    return html;
}
function getCategory() {
    var methodName = "GET";
    var actionUrl = "/CategoryManager/GetList";
    var actionParamter = {};

    doAction(methodName, actionUrl, actionParamter, function (data) {
        if (data && data.length > 0) {
            var html = renderSelect(data);
            $('#cid').html(html);
        }
    });
}