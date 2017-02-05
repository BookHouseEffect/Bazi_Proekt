$(function () {
    $('.birthday-datetimepicker').each(function (index, item) {
        var text = $(item.children).val()
        
        $(this).datetimepicker({
            maxDate: new Date(),
            viewMode: 'decades',
            showClose: true,
            format: 'DD/MM/YYYY',
            date: new Date(text)
        }); 
    });
        

    $('.date-of-issue-datetimepicker').each(function (index, item) {
        var text = $(item.children).val()
        
        $(this).datetimepicker({
            maxDate: new Date(),
            viewMode: 'years',
            showClose: true,
            format: 'DD/MM/YYYY',
            date: new Date(text)
        }); 
    });

    $('.date-of-expire-datetimepicker').each(function (index, item) {
        var text = $(item.children).val()

        $(this).datetimepicker({
            minDate: new Date(),
            viewMode: 'years',
            showClose: true,
            format: 'DD/MM/YYYY',
            date: new Date(text)
        });
    });

    $(".date-of-issue-datetimepicker").on("dp.change", function (e) {
        $('.date-of-expire-datetimepicker').data("DateTimePicker").minDate(e.date);
    });

    $(".date-of-expire-datetimepicker").on("dp.change", function (e) {
        $('.date-of-issue-datetimepicker').data("DateTimePicker").maxDate(e.date);
    });
});