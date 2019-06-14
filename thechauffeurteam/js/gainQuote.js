
$(document).ready(function () {

    $('#from_places').click(function () {

        $('#from_places').val('');
        $('#GetQuote').show();
        $('#BookNow').hide();
      
        $('#LoginPopShow').hide();
        $('#priceMileMain').hide();
        $('#Prices').html('');

 });


    $('#to_places').click(function () {

        $('#to_places').val('');
        $('#GetQuote').show();
        $('#BookNow').hide();
        $('#LoginPopShow').hide();
        $('#priceMileMain').hide();
        $('#Prices').html('');

   });



});