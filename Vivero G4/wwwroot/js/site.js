function enviarEmail() {
    var nombre = $("#nombre").val();
    var email = $("#email").val();
    var consulta = $("#consulta").val();
    if (nombre != "" && email != "" && consulta != "") {
        var cuerpo = "Se ha registrado una nueva consulta de " + nombre + ". Email: " + email + ". \n" + "Consulta enviada: " + consulta;
        $.post("/Home/EnviarMail", { cuerpo: cuerpo }, function (res) {
            alert("Email enviado correctamente.");
            window.location.reload();
        });
    } else {
        alert("Debe completar los datos de envío");
    }
   
}