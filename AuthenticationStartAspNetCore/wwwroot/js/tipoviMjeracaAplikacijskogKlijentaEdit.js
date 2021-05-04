//tipoviMjeracaAplikacijskogKlijentaEditScript
var modal = document.getElementById("exampleModal");

modal.addEventListener("hidden.bs.modal", function () {
    modal.remove();
    //document.getElementsByClassName("modal-backdrop")[0].remove();
    document.getElementById("tipoviMjeracaAplikacijskogKlijentaEditScript").remove();
    let tipoviMjeracaSaPrecnikomScript = document.getElementById("tipoviMjeracaSaPrecnikomScript");
    if (tipoviMjeracaSaPrecnikomScript)
        tipoviMjeracaSaPrecnikomScript.remove();
});

var xhttpTipovaMjeracaSaPrecnikom = null;
document.getElementById("dodajNoviTipMjeracaSaPrecnikom").addEventListener("click", function () {
    if (xhttpTipovaMjeracaSaPrecnikom != null)
        xhttpTipovaMjeracaSaPrecnikom.abort();

    xhttpTipovaMjeracaSaPrecnikom = new XMLHttpRequest();
    xhttpTipovaMjeracaSaPrecnikom.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            document.getElementById("noviTipMjeracaSaPrecnikom").innerHTML = this.response;
            let script2 = document.createElement('script');
            
            script2.src = "/js/tipoviMjeracaSaPrecnikom.js";
            script2.id = "tipoviMjeracaSaPrecnikomScript";
            document.head.appendChild(script2);
        }
    };
    xhttpTipovaMjeracaSaPrecnikom.open("GET", "/TipoviMjeracaSaPrecnikom/Dodaj", true);
    xhttpTipovaMjeracaSaPrecnikom.send(Document);
});
