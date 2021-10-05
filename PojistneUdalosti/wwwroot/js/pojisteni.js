var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Pojisteni/GetAll"           
        },
        "columns": [
            { "data": "typPojisteni", "width": "20%" },
            { "data": "podminky", "width": "50%" },
            { "data": "zaloha", "width": "10%" },
            {
                "data": "pojisteniId",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/Admin/Pojisteni/Upsert/$(data)" class="btn btn-success text-white" style="cursor:pointer">
                                    <i class="fas fa-edit"></i>
                                </a>
                                <a class="btn btn-danger text-white" style="cursor:pointer">
                                    <i class="fas fa-trash-alt"></i>
                                </a>
                            </div>`;
                }, "width": "20%"
            }
        ]
    });
}