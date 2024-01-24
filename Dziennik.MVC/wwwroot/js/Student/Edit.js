$(document).ready(function () {
    // Pobierz identyfikator studenta z atrybutu data-id
    var studentId = $("#marks").data("id");

    // Funkcja do wczytywania i renderowania ocen
    function loadMarks() {
        // Wywo³aj AJAX, aby pobraæ oceny dla danego studenta
        $.ajax({
            url: "/Student/" + studentId + "/Mark", // Dostosuj œcie¿kê URL do Twojej konfiguracji routingu
            method: "GET",
            success: function (data) {
                console.log(data);
                renderMarks(data);
            },
            error: function () {
                console.error("B³¹d podczas pobierania ocen");
            }
        });
    }

    function renderMarks(marks) {
        // Wyczyœæ istniej¹ce oceny przed ponownym renderowaniem
        $("#marks").empty();

        // Stwórz tabelê Bootstrapa
        var tableElement = $("<div>").addClass("table-responsive");
        var table = $("<table>").addClass("table table-bordered");
        var thead = $("<thead>").append("<tr><th scope='col'>Subject</th><th scope='col'>Mark</th></tr>");
        var tbody = $("<tbody>");
        var groupedMarks = {};
        marks.forEach(function (mark) {

            var subjectName = mark.subjectName;
            var markValue = mark.value || "Brak ocen";

            // Jeœli przedmiot nie istnieje w obiekcie, utwórz go
            if (!groupedMarks[subjectName]) {
                groupedMarks[subjectName] = [markValue];
            } else {
                // Jeœli przedmiot ju¿ istnieje, dodaj ocenê do istniej¹cej tablicy
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

    // Wczytaj i zrenderuj oceny po za³adowaniu strony
    loadMarks();

    // Dodaj obs³ugê dla formularza edycji
    $("#addMarkModal form").submit(function (event) {
        event.preventDefault();
        var form = $(this);

        $.ajax({
            url: form.attr('action'),
            type: form.attr('method'),
            data: form.serialize(),
            success: function (data) {
                toastr["success"]("Dodano ocenê");
                // Po dodaniu oceny ponownie wczytaj i zrenderuj oceny
                loadMarks();
            },
            error: function () {
                toastr["error"]("Coœ posz³o nie tak");
            }
        });
    });
});