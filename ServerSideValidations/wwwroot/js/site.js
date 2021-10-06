$('.submit').on('click', () => {
    $('span').text('');
    $.ajax(
        {
            url: '/Student/Submit',
            data: $('#StudentForm').serialize(),
            success: function (response) {
                alert(response);
            },
            error: function (xhr) {
                let validationErrors = xhr.responseJSON;
                for (var i = 0; i < validationErrors.length; i++) {
                    $('span[data-valmsg-for="' + validationErrors[i].key + '"]').text(validationErrors[i].errors[0]);
                }
            }
        });
});