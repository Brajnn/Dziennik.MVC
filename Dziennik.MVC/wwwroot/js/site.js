// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const RenderMarks = (marks, container) => {
    container.empty();

    for (const mark of marks) {
        container.append(`
                    <div class="container mt-4" style="max-width:200px">
                        <div class="card">
                            <div class="card-body">
                                <h5 class="card-title">${mark.studentId}</h5>
                                <p class="card-text">${mark.Value}</p>
                            </div>
                        </div>
                    </div>
                `)
        }
    }


const LoadMarks = () => {
    const container = $("#marks")
    const studentId = container.data('id');

    $.ajax({
        url: `Student/${studentId}/Mark`,
        type: 'get',
        success: function (data) {

            if (!data.length) {
                container.html("There are no marks for this student")
            } else {
                RenderMarks(data, container)
            }
        },
        error: function () {
            toastr["error"]("Something went wrong");
        }
    })
}