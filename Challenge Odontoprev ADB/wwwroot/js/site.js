// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//document.addEventListener("DOMContentLoaded", function () {
//    const deleteButtons = document.querySelectorAll(".delete-button");

//    deleteButtons.forEach(button => {
//        button.addEventListener("click", function (event) {
//            event.preventDefault();
//            const appointmentId = this.getAttribute("data-id");
//            const url = `/Appointments/Delete/${appointmentId}`;

//            if (confirm("Tem certeza que deseja excluir esta consulta?")) {
//                fetch(url, {
//                    method: "DELETE",
//                    headers: {
//                        "X-Requested-With": "XMLHttpRequest",
//                        "X-CSRF-Token": document.querySelector("input[name=__RequestVerificationToken]").value
//                    }
//                })
//                    .then(response => {
//                        if (response.ok) {
//                            window.location.href = "/home/index";
//                        } else {
//                            alert("Falha ao excluir a consulta.");
//                        }
//                    })
//                    .catch(error => console.error("Erro:", error));
//            }
//        });
//    });
//});
