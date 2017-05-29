(function () {
// setup nav bar
$('.ui.menu a.item')
    .on('click', function() {
            $(this)
                .addClass('active')
                .siblings()
                .removeClass('active');
});
})()

$('.shape').shape();

$('.special.cards .image').dimmer({
    on: 'hover'
});

$('.column.card').each(function () {
    $(this).find('.custom.image').popup({
        position: 'right center',
        hoverable: true,
        popup: $(this).find('.custom.popup'),
        on: 'hover',
        transition: "fade up"

    })
});

$('.ui.dropdown.item')
  .dropdown({
      maxSelections: 3
  });

$('.message .close')
  .on('click', function () {
      $(this)
        .closest('.message')
        .transition('fade')
      ;
  });