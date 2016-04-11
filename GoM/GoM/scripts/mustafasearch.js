$(document).ready(function () {
    $("#SearchText").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/Products/AutoCompleteArtist",
                type: "POST",
                dataType: "json",
                data: { term: request.term },
                success: function (data) {
                    response($.map(data, function (item) {
                        return { label: "Artist: " + item.Artist + " Title: " + item.Title + " Price: $" + item.Price, value: item.Artist };
                    }))

                }
            })
        },
        messages: {
            noResults: "", results: ""
        }
    });
})