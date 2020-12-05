function AddPrimaryBackgroudToElementById(s) {
    var btn = document.getElementById(s);
    btn.setAttribute("class", 'btn-primary btn btn-default');
    btn.setAttribute("style", 'width: 160px;');
}

function show_Toast(m) {
    toastr.success(m);
}
function show_ToastDelete(m) {
    toastr.info(m);
}