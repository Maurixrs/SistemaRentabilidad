function traducirmes(param) {
    var mes = param.split("/")[0];
    var anio = param.split("/")[1];
    switch (mes) {
        case "Enero":
            mes = "January/" + anio;
            return mes;

        case "Febrero":
            mes = "February/" + anio;
            return mes;

        case "Marzo":
            mes = "March/" + anio;
            return mes;

        case "Abril":
            mes = "April/" + anio;
            return mes;

        case "Mayo":
            mes = "May/" + anio;
            return mes;

        case "Junio":
            mes = "June/" + anio;
            return mes;

        case "Julio":
            mes = "July/" + anio;
            return mes;

        case "Agosto":
            mes = "August/" + anio;
            return mes;

        case "Septiembre":
            mes = "September/" + anio;
            return mes;

        case "Octubre":
            mes = "October/" + anio;
            return mes;

        case "Noviembre":
            mes = "November/" + anio;
            return mes;

        case "Diciembre":
            mes = "December/" + anio;
            return mes;
        case "":
            mes = "";
            return mes;



    }
}