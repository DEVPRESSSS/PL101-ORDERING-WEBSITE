var dataTable;

$(document).ready(function () {
    try {
        loadDataTable();
    } catch (error) {
        console.error("Error initializing DataTable:", error);
    }
});

function loadDataTable() {
    try {
        dataTable = $('#test').DataTable({ 
            "ajax": {
                url: '/Admin/Product/GetProducts', 
                dataSrc: 'data'
            },
            columns: [
                { data: 'productID', "width": "5%" },
                { data: 'name', "width": "10%" },
                { data: 'description', "width": "20%" },
                { data: 'price', "width": "10%" },
                { data: 'size', "width": "10%" },
                { data: 'stock', "width": "10%" },
                { data: 'categorName', "width": "10%" }, 
                {
                    "data": "images",
                    "render": function (data) {
                        if (data.length > 0) {
                            let imgTags = data.map(img => `<img src="${img}" width="70" height="70" class="img-thumbnail"/>`);
                            return imgTags.join(" ");
                        }
                        return "No Image";
                    },
                    "orderable": false
                },
                { data: 'createdAt', "width": "10%" },

                {
                    data: 'productID',
                    "render": function (data) {
                        return `<div class="d-flex justify-content-center btn-group" role="group">
                                    <a href="/Admin/Product/Edit/${data}" class="btn btn-info">
                                        <i class="bi bi-pencil-square"></i> EDIT
                                    </a>
                                    <a onclick="Delete('/Admin/Product/Delete/${data}')" class="btn btn-danger">
                                        <i class="bi bi-trash3"></i> DELETE
                                    </a>
                                </div>`;
                    },
                    "width": "15%"
                }
            ]
        });
    } catch (error) {
        console.error("Error loading DataTable:", error);
    }
}


function Delete(url) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        toastr.success(data.message);
                    } else {
                        toastr.error(data.message);
                    }
                },
                error: function (xhr, status, error) {
                    toastr.error("Error while deleting record.");
                }
            });
        }
    });
}