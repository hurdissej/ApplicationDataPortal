   $(document).ready(function () {
        var table = $("#displayTypes").DataTable({
            ajax: {
                url: "/api/DisplayTypes",
                dataSrc: ""
            },
            columns: [
                {
                    data: "description"
                }, {
                    data: "customer.name"
                }, {
                    data: "id",
                    render: function (data) {
                        return "<button class='btn-link js-delete' data-id=" + data + "> Delete </button>";
                    }
                }, {
                    data: "globalDisplayTypeRef"
                }
            ]
        });

        $("#displayTypes").on("click",
            ".js-delete",
            function () {
                var button = $(this);
                bootbox.confirm("Are you sure you want to delete this display type?",
                    function (result) {
                        if (result) {
                            $.ajax({
                                url: "api/DisplayTypes/" + button.attr("data-id"),
                                method: "Delete",
                                success: function () {
                                    toastr.success("The display type has been successfully deleted!");
                                    console.log("Row Deleted");
                                    table.row(button.parents("tr"))
                                        .remove()
                                        .draw();
                                },
                                error: function (response) {
                                    toastr.error("Display Type could not be deleted: " + response.responseJSON.message);
                                }

                            });
                        }
                    });
            });

    });