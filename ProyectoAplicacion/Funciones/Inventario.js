﻿$(document).ready(function () {
    $('#tbInventario').DataTable(
        {
            "bFilter": true,
            "bInfo": true,
            "bLengthChange": true,
            dom: 'Bfrtip',
            buttons: [
                'copy', 'excel', 'pdf'
            ]
        }
    );
});



function validar() {
    var number = $('#ID_SERVICIO').val();

    if(number == 1) {
        return true;
    }
    if (number == 2) {
        return true;
    }
    MostrarAlerta("1=LAVADO ; 2=TIENDA", 'error');
    //alert("1=LAVADO ; 2=TIENDA");
    return false;
}
