$(document).ready(function () {
    $("#SearchText").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/Search/AutoCompleteArtist",
                type: "POST",
                dataType: "json",
                data: { term: request.term },
                success: function (data) {
                    response($.map(data, function (item) {
                        return { label: item.Artist, value: item.Artist };
                    }))

                }
            })
        },
        messages: {
            noResults: "", results: ""
        }
    });
})