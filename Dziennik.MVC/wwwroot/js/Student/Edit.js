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

    // Funkcja do renderowania ocen
    function renderMarks(marks) {
        // Wyczy�� istniej�ce oceny przed ponownym renderowaniem
        $("#marks").empty();

        // Iteruj przez oceny i dodaj je do elementu o id "marks"
        marks.forEach(function (mark) {
            var markElement = $("<div>").text("Subject: " + mark.subjectId + ", Value: " + mark.value);
            $("#marks").append(markElement);
        });
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