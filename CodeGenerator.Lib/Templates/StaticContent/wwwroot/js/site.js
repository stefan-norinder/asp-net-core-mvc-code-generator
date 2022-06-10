$(document).ready(function () {
    $('#iconLanguageId').on('click', function () {
        $('#changeLanguageFormId').submit();
    })
});

$(document).ready(function () {
    $('#iconLanguageId').on('click', function () {
        $('#changeLanguageFormId').submit();
    })

    $.get("resources/tablelang", function (json) {
        let data = JSON.parse(json);
        $('.data-table').DataTable({
            'language': {
                'url': data.TableLang
            },
            "paging": false,
            dom: 'Bfrtip',
            buttons: [
                { extend: 'copy',  className: 'btn btn-secondary btn-sm table-button' },
                { extend: 'excel', className: 'btn btn-secondary btn-sm table-button' },
                { extend: 'csv',   className: 'btn btn-secondary btn-sm table-button' },
                { extend: 'print', className: 'btn btn-secondary btn-sm table-button' }
            ],
            initComplete: function () {
                $(".table-button").removeClass("buttons-html5").removeClass("buttons-copy").removeClass("dt-button");
            },

        });
    });
});