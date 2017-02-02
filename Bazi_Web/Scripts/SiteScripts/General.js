$(function () {
    $('#birthday-datetimepicker').datetimepicker({
        maxDate: new Date(),
        viewMode: 'decades',
        format: 'DD/MM/YYYY',
        showClose: true,
    });

    $('#date-of-issue-datetimepicker').datetimepicker({
        maxDate: new Date(),
        viewMode: 'years',
        format: 'DD/MM/YYYY',
        showClose: true
    });

    $('#date-of-expire-datetimepicker').datetimepicker({
        minDate: new Date(),
        useCurrent: false,
        viewMode: 'years',
        format: 'DD/MM/YYYY',
        showClose: true,
    })

    $("#date-of-issue-datetimepicker").on("dp.change", function (e) {
        $('#date-of-expire-datetimepicker').data("DateTimePicker").minDate(e.date);
    });

    $("#date-of-expire-datetimepicker").on("dp.change", function (e) {
        $('#date-of-issue-datetimepicker').data("DateTimePicker").maxDate(e.date);
    });
});