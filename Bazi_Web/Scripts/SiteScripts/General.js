$(function () {
    $('.birthday-datetimepicker').each(function (index, item) {
        var text = $(item.children).val()
        
        $(this).datetimepicker({
            maxDate: new Date(),
            viewMode: 'decades',
            showClose: true,
            format: 'YYYY-MM-DD',
            date: new Date(text)
        }); 
    });
        

    $('.date-of-issue-datetimepicker').each(function (index, item) {
        var text = $(item.children).val()
        
        $(this).datetimepicker({
            maxDate: new Date(),
            viewMode: 'years',
            showClose: true,
            format: 'YYYY-MM-DD',
            date: new Date(text)
        }); 
    });

    $('.date-of-expire-datetimepicker').each(function (index, item) {
        var text = $(item.children).val()

        $(this).datetimepicker({
            minDate: new Date(),
            viewMode: 'years',
            showClose: true,
            format: 'YYYY-MM-DD',
            date: new Date(text)
        });
    });

    $(".date-of-issue-datetimepicker").on("dp.change", function (e) {
        $('.date-of-expire-datetimepicker').data("DateTimePicker").minDate(e.date);
    });

    $(".date-of-expire-datetimepicker").on("dp.change", function (e) {
        $('.date-of-issue-datetimepicker').data("DateTimePicker").maxDate(e.date);
    });

    $('.flight-date-picker').each(function (index, item) {
        var text = $(item.children).val()

        $(this).datetimepicker({
            minDate: new Date(),
            viewMode: 'days',
            showClose: true,
            format: 'YYYY-MM-DD',
            date: new Date(text)
        });
    });
});