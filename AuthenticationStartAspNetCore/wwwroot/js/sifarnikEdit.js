
var modal = document.getElementById("exampleModal");

modal.addEventListener("hidden.bs.modal", function () {
    modal.remove();
});