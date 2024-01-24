$(document).ready(function () {
    // Pobierz identyfikator studenta z atrybutu data-id
    var studentId = $("#marks").data("id");

    // Funkcja do wczytywania i renderowania ocen
    function loadMarks() {
        // Wywo�aj AJAX, aby pobra� oceny dla danego studenta
        $.ajax({
            url: "/Student/" + studentId + "/Mark", // Dostosuj �cie�k� URL do Twojej konfiguracji routingu
            method: "GET",
            success: function (data) {
                console.log(data);
                renderMarks(data);
            },
            error: function () {
                console.error("B��d podczas pobierania ocen");
            }
        });
    }

    function renderMarks(marks) {
        // Wyczy�� istniej�ce oceny przed ponownym renderowaniem
        $("#marks").empty();

        // Stw�rz tabel� Bootstrapa
        var tableElement = $("<div>").addClass("table-responsive");
        var table = $("<table>").addClass("table table-bordered");
        var thead = $("<thead>").append("<tr><th scope='col'>Subject</th><th scope='col'>Mark</th></tr>");
        var tbody = $("<tbody>");
        var groupedMarks = {};
        marks.forEach(function (mark) {

            var subjectName = mark.subjectName;
            var markValue = mark.value || "Brak ocen";

            // Je�li przedmiot nie istnieje w obiekcie, utw�rz go
            if (!groupedMarks[subjectName]) {
                groupedMarks[subjectName] = [markValue];
            } else {
                // Je�li przedmiot ju� istnieje, dodaj ocen� do istniej�cej tablicy
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

    // Wczytaj i zrenderuj oceny po za�adowaniu strony
    loadMarks();

    // Dodaj obs�ug� dla formularza edycji
    $("#addMarkModal form").submit(function (event) {
        event.preventDefault();
        var form = $(this);

        $.ajax({
            url: form.attr('action'),
            type: form.attr('method'),
            data: form.serialize(),
            success: function (data) {
                toastr["success"]("Dodano ocen�");
                // Po dodaniu oceny ponownie wczytaj i zrenderuj oceny
                loadMarks();
            },
            error: function () {
                toastr["error"]("Co� posz�o nie tak");
            }
        });
    });
});