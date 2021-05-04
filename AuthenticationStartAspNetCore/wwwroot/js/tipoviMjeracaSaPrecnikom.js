var forma = document.getElementById("frmTipoviMjeracaSaPrecnikom");
forma.addEventListener("submit", (function (e) {
    e.preventDefault();

    let url = forma.getAttribute("action");
    var request = new XMLHttpRequest();
    request.open('POST', url, true);
    let obj = JSON.stringify(serializeForm(forma));
    console.log(obj);
    request.onreadystatechange = function () {
        if (request.readyState == 4 && request.status == 200) {
        }
        else if (request.readyState == 4 && request.status >= 400) {
        }
    }

    request.setRequestHeader('Content-Type', 'application/json; charset=UTF-8');
    request.send(obj);

}));
document.getElementById("btnSnimiTipMjeracaSaPrecnikom").addEventListener("click", function () {
    document.getElementById("btnSubmitFormTipMjeracaSaPrecnikom").click();
});
var serializeForm = function (form) {
    var obj = {};
    var formData = new FormData(form);
    for (var key of formData.keys()) {
        obj[key] = formData.get(key);
    }

    return obj;
};