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

    // Funkcja do renderowania ocen
    function renderMarks(marks) {
        // Wyczyœæ istniej¹ce oceny przed ponownym renderowaniem
        $("#marks").empty();

        // Iteruj przez oceny i dodaj je do elementu o id "marks"
        marks.forEach(function (mark) {
            var markElement = $("<div>").text("Subject: " + mark.subjectId + ", Value: " + mark.value);
            $("#marks").append(markElement);
        });
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