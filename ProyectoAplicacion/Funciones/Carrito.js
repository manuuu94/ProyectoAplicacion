$(document).ready(function () {
    $('#tbCarro').DataTable(
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
