var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Pojistnik/GetAll"           
        },
        "columns": [
            { "data": "jmeno", "width": "8%" }, //camel case - první písmeno malé!
            { "data": "prijmeni", "width": "10%" },
            { "data": "adresa", "width": "22%" },            
            { "data": "telefonCislo", "width": "15%" },
            { "data": "pojisteniId", "width": "15%" }, //za tečkou se píše malé písmeno!
            {
                "data": "pojistnikId",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a href="/Admin/Pojistnik/Upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">
                                    <i class="fas fa-edit"></i>
                                </a>
                                <a onclick=Delete("/Admin/Pojistnik/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer">
                                    <i class="fas fa-trash-alt"></i>
                                </a>
                            </div>`;
                }, "width": "30%"
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