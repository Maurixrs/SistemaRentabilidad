function valfecha() {
    if ($('#wdate').val().trim() == '') {
        $('#wdate').siblings('span.text-danger').html('Requerido');
    } else {
        //$('#wdate').siblings('span.text-danger').html('');
        var options3 = {};
        options3.url = '@Url.Action("ExistePlanilla", "Worksheets")';
        options3.type = "GET";
        options3.data = { "fecha": $("#wdate").val() };
        options3.dataType = "json";
        options3.success = function (data) {
            if (data) {
                $('#wdate').siblings('span.text-danger').html('Período existente.');
                valf = 1;
            } else {
                $('#wdate').siblings('span.text-danger').html('');
                valf = 0;
            };

        };
        $.ajax(options3);
    }
}

function itextarea() {
    $('textarea').each(function () {
        autosize(this);
        this.style.display = '';
        autosize.update(this);
    });
}

function valdescb(x) {
    if (x.value.trim() == "" || x.value == null) {

        $(x).siblings('span.text-danger').html('Requerido.');

    } else {
        $(x).siblings('span.text-danger').html('');
    };
}


function valamoub(x) {
    if (x.value.trim() == "" || x.value == null) {
        $(x).siblings('span.text-danger').html('Requerido.');

    } else {
        if (x.value.trim() == 0) {
            $(x).siblings('span.text-danger').html('Debe ser mayor a 0.');
        } else {
            $(x).siblings('span.text-danger').html('');
        }
    };
}



function arraysamountsedit() {
    itemsi = [];
    itemsiamounts = [];
    itemsc = [];
    itemscamounts = [];
    itemsg = [];
    itemsgamounts = [];
    itemso = [];
    itemsoamounts = [];

    $("input[name='ing_Amount']").map(function () { itemsiamounts.push(parseFloat(this.value)) });
    $("input[name='cos_Amount']").map(function () { itemscamounts.push(parseFloat(this.value)) });
    $("input[name='gas_Amount']").map(function () { itemsgamounts.push(parseFloat(this.value)) });
    $("input[name='otr_Amount']").map(function () { itemsoamounts.push(parseFloat(this.value)) });

}

function arraysedit() {
    itemsi = [];
    itemsidescriptions = [];
    itemsicomments = [];
    itemsiamounts = [];

    itemsc = [];
    itemscdescriptions = [];
    itemsccomments = [];
    itemscamounts = [];

    itemsg = [];
    itemsgdescriptions = [];
    itemsgcomments = [];
    itemsgamounts = [];

    itemso = [];
    itemsodescriptions = [];
    itemsocomments = [];
    itemsoamounts = [];
    $("textarea[name='ing_SheetDescription']").map(function () { itemsidescriptions.push((this.value)) });
    $("textarea[name='ing_Comments']").map(function () { itemsicomments.push((this.value)) });
    $("input[name='ing_Amount']").map(function () { itemsiamounts.push(parseFloat(this.value)) });

    $("textarea[name='cos_SheetDescription']").map(function () { itemscdescriptions.push((this.value)) });
    $("textarea[name='cos_Comments']").map(function () { itemsccomments.push((this.value)) });
    $("input[name='cos_Amount']").map(function () { itemscamounts.push(parseFloat(this.value)) });

    $("textarea[name='gas_SheetDescription']").map(function () { itemsgdescriptions.push((this.value)) });
    $("textarea[name='gas_Comments']").map(function () { itemsgcomments.push((this.value)) });
    $("input[name='gas_Amount']").map(function () { itemsgamounts.push(parseFloat(this.value)) });

    $("textarea[name='otr_SheetDescription']").map(function () { itemsodescriptions.push((this.value)) });
    $("textarea[name='otr_Comments']").map(function () { itemsocomments.push((this.value)) });
    $("input[name='otr_Amount']").map(function () { itemsoamounts.push(parseFloat(this.value)) });


    for (i = 0; i < itemsidescriptions.length; i++) {

        itemsi.push({
            SheetDescription: itemsidescriptions[i],
            Comments: itemsicomments[i],
            Amount: itemsiamounts[i],
            SheetType: 0

        });
    }

    for (i = 0; i < itemscdescriptions.length; i++) {

        itemsc.push({
            SheetDescription: itemscdescriptions[i],
            Comments: itemsccomments[i],
            Amount: itemscamounts[i],
            SheetType: 1

        });
    }
    for (i = 0; i < itemsgdescriptions.length; i++) {

        itemsg.push({
            SheetDescription: itemsgdescriptions[i],
            Comments: itemsgcomments[i],
            Amount: itemsgamounts[i],
            SheetType: 2

        });
    }
    for (i = 0; i < itemsodescriptions.length; i++) {

        itemso.push({
            SheetDescription: itemsodescriptions[i],
            Comments: itemsocomments[i],
            Amount: itemsoamounts[i],
            SheetType: 3

        });
    }
}

function calcing() {
    ting = 0;
    $.each(itemsiamounts, function () { ting += parseFloat(this) || 0; });
    $('#toting').html(ting.toFixed(2));
}

function calccos() {
    tcos = 0;
    $.each(itemscamounts, function () { tcos += parseFloat(this) || 0; });
    $('#totcos').html(tcos.toFixed(2));

}

function calcgas() {
    tgas = 0;
    $.each(itemsgamounts, function () { tgas += parseFloat(this) || 0; });
    $('#totgas').html(tgas.toFixed(2));
}

function calcotr() {
    totr = 0;
    $.each(itemsoamounts, function () { totr += parseFloat(this) || 0; });
    $('#tototr').html(totr.toFixed(2));

}

function calculogral() {
    arraysamountsedit();
    tgral = 0;
    $.each(itemsiamounts, function () { tgral += parseFloat(this) || 0; });
    $.each(itemsoamounts, function () { tgral += parseFloat(this) || 0; });
    $.each(itemsgamounts, function () { tgral -= parseFloat(this) || 0; });
    $.each(itemscamounts, function () { tgral -= parseFloat(this) || 0; });
    document.getElementById("wtotal").value = tgral.toFixed(2);
}


function borrarfilaingb(row) {
    var a = $(row).closest('td').siblings(':first-child').text();

    toastr.warning("-" + a + "-<br/>Eliminado.", "Ingreso:");
    row.closest('tr').remove();
    arraysamountsedit();
    calcing();
    calccos();
    calcgas();
    calcotr();
    calculogral();
}


function borrarfilacosb(row) {
    var a = $(row).closest('td').siblings(':first-child').text();
    toastr.warning("-" + a + "-<br/>Eliminado.", "Costo:");
    row.closest('tr').remove();
    arraysamountsedit();
    calcing();
    calccos();
    calcgas();
    calcotr();
    calculogral();
}


function borrarfilagasb(row) {
    var a = $(row).closest('td').siblings(':first-child').text();
    toastr.warning("-" + a + "-<br/>Eliminado.", "Gasto:");
    row.closest('tr').remove();
    arraysamountsedit();
    calcing();
    calccos();
    calcgas();
    calcotr();
    calculogral();
}

function borrarfilaotrb(row) {
    var a = $(row).closest('td').siblings(':first-child').text();

    toastr.warning("-" + a + "-<br/>Eliminado.", "Otro ingreso:");
    row.closest('tr').remove();
    arraysamountsedit();
    calcing();
    calccos();
    calcgas();
    calcotr();
    calculogral();
}

function renewi() {
    orderItemsi = [];
    orderItemsidescriptions = [];
    orderItemsicomments = [];
    orderItemsiamounts = [];

    $("textarea[id='ing_SheetDescriptionz']").map(function () { orderItemsidescriptions.push((this.value)) });
    $("textarea[id='ing_Commentsz']").map(function () { orderItemsicomments.push((this.value)) });
    $("input[id='ing_Amountz']").map(function () { orderItemsiamounts.push(parseFloat(this.value)) });

    for (i = 0; i < orderItemsidescriptions.length; i++) {

        orderItemsi.push({
            SheetDescription: orderItemsidescriptions[i],
            Comments: orderItemsicomments[i],
            Amount: orderItemsiamounts[i],
            SheetType: 0

        });
    }

}
function renewc() {


    orderItemsc = [];
    orderItemscdescriptions = [];
    orderItemsccomments = [];
    orderItemscamounts = [];

    $("textarea[id='cos_SheetDescriptionz']").map(function () { orderItemscdescriptions.push((this.value)) });
    $("textarea[id='cos_Commentsz']").map(function () { orderItemsccomments.push((this.value)) });
    $("input[id='cos_Amountz']").map(function () { orderItemscamounts.push(parseFloat(this.value)) });

    for (i = 0; i < orderItemscdescriptions.length; i++) {

        orderItemsc.push({
            SheetDescription: orderItemscdescriptions[i],
            Comments: orderItemsccomments[i],
            Amount: orderItemscamounts[i],
            SheetType: 1

        });
    }

}

function renewg() {
    orderItemsg = [];
    orderItemsgdescriptions = [];
    orderItemsgcomments = [];
    orderItemsgamounts = [];

    $("textarea[id='gas_SheetDescriptionz']").map(function () { orderItemsgdescriptions.push((this.value)) });
    $("textarea[id='gas_Commentsz']").map(function () { orderItemsgcomments.push((this.value)) });
    $("input[id='gas_Amountz']").map(function () { orderItemsgamounts.push(parseFloat(this.value)) });

    for (i = 0; i < orderItemsgdescriptions.length; i++) {

        orderItemsg.push({
            SheetDescription: orderItemsgdescriptions[i],
            Comments: orderItemsgcomments[i],
            Amount: orderItemsgamounts[i],
            SheetType: 2

        });
    }

}

function renewo() {
    orderItemso = [];
    orderItemsodescriptions = [];
    orderItemsocomments = [];
    orderItemsoamounts = [];

    $("textarea[id='otr_SheetDescriptionz']").map(function () { orderItemsodescriptions.push((this.value)) });
    $("textarea[id='otr_Commentsz']").map(function () { orderItemsocomments.push((this.value)) });
    $("input[id='otr_Amountz']").map(function () { orderItemsoamounts.push(parseFloat(this.value)) });

    for (i = 0; i < orderItemsodescriptions.length; i++) {

        orderItemso.push({
            SheetDescription: orderItemsodescriptions[i],
            Comments: orderItemsocomments[i],
            Amount: orderItemsoamounts[i],
            SheetType: 3

        });
    }
}


function acting(a) { tipo = "ing"; }

function actcos(a) { tipo = "cos"; }

function actgas(a) { tipo = "gas"; }

function actotr(a) { tipo = "otr"; }

//functiones agregar ing cos gas otr/////////////
/////////////////////
function ingreso() {

    $('.elimi').remove();
    if (orderItemsi.length > 0) {
        $('#orderItemsi').html('<span class="text-danger"></span>');
        $.each(orderItemsi, function (i, val) {
            var $rowi = $('<tr class="elimi"></tr>');

            $rowi.append($('<td style="width: 40%"><textarea id="ing_SheetDescriptionz" Name="ing_SheetDescription" rows="1" class= "panel-info form-control-sm inputForm fc" value="' + val.SheetDescription + '" onkeyup = "valdescb(this)" oninput = "valdescb(this)" onkeypress = "valdescb(this)">' + val.SheetDescription + '</textarea><span class="text-danger"></span></td>'));
            $rowi.append($('<td style="width: 40%"><textarea id="ing_Commentsz" Name="ing_Comments" rows="1" class= "panel-info form-control-sm inputForm fc" value="' + val.Comments + '">' + val.Comments + '</textarea><span class="text-danger"></span></td>'));
            $rowi.append($('<td><input id="ing_Amountz" Name="ing_Amount"  rows="1" class= "panel-info form-control-sm inputForm fc montocentrado" value="' + val.Amount + '"onkeyup = "calcing();calculogral();valamoub(this)",  oninput = "calcing();calculogral();valamoub(this)" onkeypress = "solonumerosptocoma();valamoub(this)"><span class="text-danger"></span></td>'));

            var $removei = $('<a style="color:red; width: 37px; text-align: center;vertical-align: -webkit-baseline-middle;"  onclick="borrarfilaingb(this)"><span class="glyphicon glyphicon-remove"></span></a>');


            $removei.click(function (e) {
                e.preventDefault();
                orderItemsi.splice(i, 1);
                renewi();

                ingreso();
                //CALCULO TOTAL ing
                arraysamountsedit();
                calcing();


                //FIN CALCULO TOTAL ing
                //calculo total gral
                calculogral();
                //fin calculo total gral
            });
            $rowi.append($('<td style="width:2%"></td>').append($removei));
            $('#ingresotabla > tbody:last').append($rowi);
            itextarea();
            //CALCULO TOTAL ing
            arraysamountsedit();
            calcing();

            //FIN CALCULO TOTAL ing
            //calculo total gral
            calculogral();
            //fin calculo total gral
        });
    } else {
        $('#orderItemsi').html('');
    }
}

function costo() {

    $('.elimc').remove();
    if (orderItemsc.length > 0) {
        $('#orderItemsc').html('<span class="text-danger"></span>');
        $.each(orderItemsc, function (i, val) {
            var $rowc = $('<tr class="elimc"  style="background-color: white"></tr>');

            $rowc.append($('<td style="width: 40%"><textarea id="cos_SheetDescriptionz" Name="cos_SheetDescription" rows="1" class= "panel-info form-control-sm inputForm fc" value="' + val.SheetDescription + '" onkeyup = "valdescb(this)" oninput = "valdescb(this)" onkeypress = "valdescb(this)">' + val.SheetDescription + '</textarea><span class="text-danger"></span></td>'));
            $rowc.append($('<td style="width: 40%"><textarea id="cos_Commentsz"  Name="cos_Comments" rows="1" class= "panel-info form-control-sm inputForm fc" value="' + val.Comments + '">' + val.Comments + '</textarea><span class="text-danger"></span></td>'));
            $rowc.append($('<td><input id="cos_Amountz" Name="cos_Amount" rows="1" class= "panel-info form-control-sm inputForm fc montocentrado" value="' + val.Amount + '"onkeyup = "calccos();calculogral();valamoub(this)",  oninput = "calccos();calculogral();valamoub(this)" onkeypress = "solonumerosptocoma();valamoub(this)"><span class="text-danger"></span></td>'));
            var $removec = $('<a style="color:red; width: 37px; text-align: center;vertical-align: -webkit-baseline-middle;"   onclick="borrarfilacosb(this)"><span class="glyphicon glyphicon-remove"></span></a>');
            $removec.click(function (e) {
                e.preventDefault();
                orderItemsc.splice(i, 1);
                renewc();

                costo();
                //CALCULO TOTAL cos
                arraysamountsedit();

                calccos();

                //FIN CALCULO TOTAL cos
                //calculo total gral
                calculogral();
                //fin calculo total gral
            });
            $rowc.append($('<td style="width: 2%"></td>').append($removec));
            $('#costotabla > tbody:last').append($rowc);
            itextarea();

            //CALCULO TOTAL cos
            arraysamountsedit();

            calccos();

            //FIN CALCULO TOTAL cos
            //calculo total gral
            calculogral();
            //fin calculo total gral
        });
    } else {
        $('#orderItemsc').html('');
    }
}

function gasto() {

    $('.elimg').remove();
    if (orderItemsg.length > 0) {
        $('#orderItemsg').html('<span class="text-danger"></span>');
        $.each(orderItemsg, function (i, val) {
            var $rowg = $('<tr class="elimg"  style="background-color: white"></tr>');
            $rowg.append($('<td style="width: 40%"><textarea id="gas_SheetDescriptionz" Name="gas_SheetDescription" rows="1" class= "panel-info form-control-sm inputForm fc" value="' + val.SheetDescription + '" onkeyup = "valdescb(this)" oninput = "valdescb(this)" onkeypress = "valdescb(this)">' + val.SheetDescription + '</textarea><span class="text-danger"></span></td>'));
            $rowg.append($('<td style="width: 40%"><textarea id="gas_Commentsz" Name="gas_Comments" rows="1" class= "panel-info form-control-sm inputForm fc" value="' + val.Comments + '">' + val.Comments + '</textarea><span class="text-danger"></span></td>'));
            $rowg.append($('<td><input id="gas_Amountz" Name="gas_Amount" rows="1" class= "panel-info form-control-sm inputForm fc montocentrado" value="' + val.Amount + '"onkeyup = "calcgas();calculogral();valamoub(this)",  oninput = "calcgas();calculogral();valamoub(this)" onkeypress = "solonumerosptocoma();valamoub(this)"><span class="text-danger"></span></td>'));

            var $removeg = $('<a style="color:red; width: 37px; text-align: center;vertical-align: -webkit-baseline-middle;"  onclick="borrarfilagasb(this)"><span class="glyphicon glyphicon-remove"></span></a>');





            $removeg.click(function (e) {
                e.preventDefault();
                orderItemsg.splice(i, 1);
                renewg();

                gasto();
                //CALCULO TOTAL gas
                arraysamountsedit();

                calcgas();

                //FIN CALCULO TOTAL gas
                //calculo total gral
                calculogral();
                //fin calculo total gral
            });
            $rowg.append($('<td style="width: 2%"></td>').append($removeg));
            $('#gastotabla > tbody:last').append($rowg);
            //CALCULO TOTAL gas
            itextarea();

            arraysamountsedit();

            calcgas();

            //FIN CALCULO TOTAL gas
            //calculo total gral
            calculogral();
            //fin calculo total gral
        });
    } else {
        $('#orderItemsg').html('');
    }
}

function otro() {

    $('.elimo').remove();
    if (orderItemso.length > 0) {
        $('#orderItemso').html('<span class="text-danger"></span>');
        $.each(orderItemso, function (i, val) {
            var $rowo = $('<tr class="elimo"  style="background-color: white"></tr>');

            $rowo.append($('<td style="width: 40%"><textarea id="otr_SheetDescriptionz"  Name="otr_SheetDescription" rows="1" class= "panel-info form-control-sm inputForm fc" value="' + val.SheetDescription + '" onkeyup = "valdescb(this)" oninput = "valdescb(this)" onkeypress = "valdescb(this)">' + val.SheetDescription + '</textarea><span class="text-danger"></span></td>'));
            $rowo.append($('<td style="width: 40%"><textarea id="otr_Commentsz" Name="otr_Comments" rows="1" class= "panel-info form-control-sm inputForm fc" value="' + val.Comments + '">' + val.Comments + '</textarea><span class="text-danger"></span></td>'));
            $rowo.append($('<td><input id="otr_Amountz" Name="otr_Amount" rows="1" class= "panel-info form-control-sm inputForm fc montocentrado" value="' + val.Amount + '"onkeyup = "calcotr();calculogral();valamoub(this)",  oninput = "calcotr();calculogral();valamoub(this)" onkeypress = "solonumerosptocoma();valamoub(this)"><span class="text-danger"></span></td>'));

            var $removeo = $('<a style="color:red; width: 37px; text-align: center;vertical-align: -webkit-baseline-middle;"  onclick="borrarfilaotrb(this)"><span class="glyphicon glyphicon-remove"></span></a>');




            $removeo.click(function (e) {
                e.preventDefault();
                orderItemso.splice(i, 1);
                renewo();

                otro();
                //CALCULO TOTAL otr
                arraysamountsedit();

                calcotr();
                //FIN CALCULO TOTAL otr
                //calculo total gral
                calculogral();
                //fin calculo total gral
            });
            $rowo.append($('<td style="width: 2%"></td>').append($removeo));
            $('#otrotabla > tbody:last').append($rowo);
            //CALCULO TOTAL otr
            itextarea();

            arraysamountsedit();

            calcotr();
            //FIN CALCULO TOTAL otr
            //calculo total gral
            calculogral();
            //fin calculo total gral

        });
    } else {
        $('#orderItemso').html('');
    }
}

//////fin funciones agregar ing cos gas otr///////
//////////////////////////