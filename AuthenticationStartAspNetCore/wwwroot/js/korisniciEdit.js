
var modal = document.getElementById("exampleModal");
var forma = document.getElementById("forma");

modal.addEventListener("hidden.bs.modal", function () {
    modal.remove();
    //document.getElementsByClassName("modal-backdrop")[0].remove();
    document.getElementById("korisniciEditScript").remove();
});
forma.addEventListener("submit", (function (e) {
    e.preventDefault();

    let url = forma.getAttribute("action");
    let redirectUrl = "/" + url.split("/")[1];
    var request = new XMLHttpRequest();
    request.open('POST', url, true);

    request.onreadystatechange = function () {
        if (request.readyState == 4 && request.status == 200) {
            if (redirectUrl != "/Authentication")
                window.location = redirectUrl;
            else
                window.location.reload();    
            
                
        }
        else if (request.readyState == 4 && request.status >= 400) {
            let errorElements = document.getElementsByClassName("error");
            for (element of errorElements)
                element.innerHtml = "";
            let errorText = request.responseText;

            if (errorText.startsWith("Lozinka"))
                document.getElementById("errorPassword").innerHTML = errorText;
            else if (errorText.startsWith("Email"))
                document.getElementById("errorEmail").innerHTML = errorText;
            else if (errorText.startsWith("Korisničko"))
                document.getElementById("errorUsername").innerHTML = errorText;
        }
    }

    request.setRequestHeader('Content-Type', 'application/json; charset=UTF-8');
    request.send(JSON.stringify(serializeForm(forma)));

}));
document.getElementById("btnSnimi").addEventListener("click", function () {
    document.getElementById("btnSubmitForm").click();
});
var serializeForm = function (form) {
    var obj = {};
    var formData = new FormData(form);
    obj["KorisnickeUlogeIds"] = formData.getAll("KorisnickeUlogeIds");
    for (var key of formData.keys()) {
        if (key !="KorisnickeUlogeIds")
            obj[key] = formData.get(key);
    }

    return obj;
};