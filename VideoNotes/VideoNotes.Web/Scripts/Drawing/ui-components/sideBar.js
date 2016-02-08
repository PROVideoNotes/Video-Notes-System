(function ($) {
    // Menu Functions
    $(document).ready(function () {
        $('#drawing-tools').on('click', function () {
            console.log("drawing tools button clicked!");
            $("#nav-tools").slideToggle(300);

            $('nav a').click(function () {
                if (!$(this).is('#menuToggle')) {
                    $('.selected').removeClass('selected');
                    $(this).addClass('selected');
                }
            });
        });
    });
}(jQuery));