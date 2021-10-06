var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Udalost/GetAll"           
        },
        "columns": [
            { "data": "foto", "width": "20%" },
            { "data": "popis", "width": "50%" },
            { "data": "potvrzeno", "width": "10%" },
            {
                "data": "udalostId",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a href="/Admin/Udalost/Upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">
                                    <i class="fas fa-edit"></i>
                                </a>
                                <a onclick=Delete("/Admin/Udalost/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer">
                                    <i class="fas fa-trash-alt"></i>
                                </a>
                            </div>`;
                }, "width": "20%"
            }
        ]
    });
}

function Delete(url) {
    swal({
        title: "Opravdu chcete záznam smazat?",
        text: "Data nebude možné obnovit!",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}