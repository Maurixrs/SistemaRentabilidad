function cargar() {
    if ($('#to').val() == "") {
        document.getElementById("to").value = $('#from').val();
    }
}