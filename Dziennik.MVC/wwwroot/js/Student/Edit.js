$(document).ready(function () {

    var studentId = $("#marks").data("id");

    function loadMarks() {

        $.ajax({
            url: "/Student/" + studentId + "/Mark",
            method: "GET",
            success: function (data) {
                console.log(data);
                renderMarks(data);
            },
            error: function () {
                console.error("Error loading grades");
            }
        });
    }

    function renderMarks(marks) {
        $("#marks").empty();

        var tableElement = $("<div>").addClass("table-responsive");
        var table = $("<table>").addClass("table table-bordered");
        var thead = $("<thead>").append("<tr><th scope='col'>Subjects</th><th scope='col'>Grades</th></tr>");
        var tbody = $("<tbody>");
        var groupedMarks = {};
        marks.forEach(function (mark) {

            var subjectName = mark.subjectName;
            var markValue = mark.value || "No Grades";

            if (!groupedMarks[subjectName]) {
                groupedMarks[subjectName] = [markValue];
            } else {
                groupedMarks[subjectName].push(markValue);
            }
        });
         Object.keys(groupedMarks).forEach(function (subjectName) {
        var markValues = groupedMarks[subjectName];
        var markValueString = markValues.join(', ');
        var row = $("<tr>").append("<td>" + subjectName + "</td><td>" + markValueString + "</td>");
        tbody.append(row);
    });


        table.append(thead, tbody);

        tableElement.append(table);
        $("#marks").append(tableElement);
    }




    function loadSubjects() {
        $.ajax({
            url: "/Subject/Index",
            method: "GET",
            success: function (data) {
                console.log("Items array:", data);

                if (Array.isArray(data)) {
                    renderSubjectDropdown(data);
                } else {
                    console.error("Item data is not in array form:", data);
                }
            },
            error: function () {
                console.error("Error loading items");
            }
        });
    }

    function renderSubjectDropdown(subjects) {
        var dropdown = $("#subjectDropdown");

        subjects.forEach(function (subject) {
            var option = $("<option>")
                .val(subject.subjectId)
                .text(subject.name);
            dropdown.append(option);
        });
    }

    loadSubjects();
    loadMarks();

    $("#addMarkModal form").submit(function (event) {
        event.preventDefault();
        var form = $(this);

        $.ajax({
            url: form.attr('action'),
            type: form.attr('method'),
            data: form.serialize(),
            success: function (data) {
                toastr["success"]("Success! Grade Added.");
                loadMarks();
            },
            error: function () {
                toastr["error"]("Something went wrong.");
            }
        });
    });

});