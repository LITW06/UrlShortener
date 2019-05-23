$(() => {
    $("#shorten-button").on('click', function () {
        const url = $("#url").val();
        $.post('/home/shortenurl', { originalUrl: url }, result => {
            $("#shortened-url").html(`<a href='${result.shortUrl}'>${result.shortUrl}</a>`);
            $("#shortened-url").slideDown();
        });
    });
});