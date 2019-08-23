(function ($, document) {
    function BindCarousel() {
        $(".slickslide").unwrap();
        if ($(".slickslide").length > 0) {
            $('.search-result-list').slick({
                slide: ".slickslide",
                infinite: true,
                slidesToShow: 3,
                slidesToScroll: 3,
                arrows: true,
                responsive: [
                    {
                        breakpoint: 480,
                        settings: {
                            slidesToShow: 1,
                            slidesToScroll: 1
                        }
                    }
                ]
            });
    }
}
    $(document).ready(function () {
    XA.component.search.vent.on("results-loaded", BindCarousel);
});
}) (jQuery, document)