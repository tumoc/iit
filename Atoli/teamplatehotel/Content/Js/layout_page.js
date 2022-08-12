$(document).ready(function () {
    $(window).scroll(function(){
        if ($(window).scrollTop() >= 300 ) {
            $("#style-navbar").addClass('bar-menu-header');
        } else {
            $("#style-navbar").removeClass('bar-menu-header');
          
        }
    });
    //$(function () {
    //    $(".datepicker-12").datepicker();
    //});
    ////tab
    //$(function () {
    //    $("#tabs").tabs({
    //        collapsible: true
    //    });
    //});
    //    $(function () {
    //        $("#accordion").accordion({
    //            header: "> div > h3"
    //        }).sortable({
    //              axis: "y",
    //              handle: "h3",
    //              stop: function (event, ui) {
    //                  // IE doesn't register the blur when sorting
    //                  // so trigger focusout handlers to remove .ui-state-focus
    //                  ui.item.children("h3").triggerHandler("focusout");

    //                  // Refresh accordion to handle new order
    //                  $(this).accordion("refresh");
    //              }
    //          });
    //    });

       
        //$("#owl-demo1").owlCarousel({
        //    loop: true,
        //    margin: 10,
        //    responsiveClass: true,
        //    autoplay: true,
        //    items: 1, //10 items above 1000px browser width
        //    responsive: {
                
        //    }
        //});
        $("#owl-banner").owlCarousel({
            loop: true,
            margin: 0,
            responsiveClass: true,
            autoplay: true,
            items: 1
           
        });
        
        $(".room-detail_img").owlCarousel({
            loop: true,
            margin: 0,
            responsiveClass: true,
            autoplay: true,
            items: 1
        });
        $("#owl1").owlCarousel({
            loop: true,
            margin: 10,
            responsiveClass: true,
            autoplay:true,
            //autoplayTimeout:1000,
            //autoplayHoverPause:true,
            items: 3, //10 items above 1000px browser width
            responsive: {
                0: {
                    items: 1
                },
                600: {
                    items: 2
                },
                1000: {
                    items: 3
                }
            }
        });
        $(".owl-other").owlCarousel({
            loop: true,
            margin: 10,
            responsiveClass: true,
            autoplay: true,
            //autoplayTimeout:1000,
            //autoplayHoverPause:true,
            items: 3, //10 items above 1000px browser width
            responsive: {
                0: {
                    items: 1
                },
                600: {
                    items: 2
                },
                1000: {
                    items: 3
                }
            }
        });
    //// Custom Navigation Events
    //    $(".customNavigation li #next1").click(function () {
    //        owl.trigger('#next1');
    //    });
    //    $(".customNavigation li #prev1").click(function () {
    //        owl.trigger('#prev1');
    //    });
  
    //    //$(".disabled .owl-prev").text("").addClass("glyphicon-menu-left");
    //    //$(".disabled .owl-next").text("").addClass("glyphicon-menu-right");



    //// external js: isotope.pkgd.js

    //// init Isotope
    //    var $grid = $('.grid').isotope({
    //        itemSelector: '.element-item',
    //        layoutMode: 'fitRows',
    //        masonry: {
    //            columnWidth: '.grid-sizer'
    //        }
    //    });
    //// filter functions
    //    var filterFns = {
    //        // show if number is greater than 50
    //        numberGreaterThan50: function () {
    //            var number = $(this).find('.number').text();
    //            return parseInt(number, 10) > 50;
    //        },
    //        // show if name ends with -ium
    //        ium: function () {
    //            var name = $(this).find('.name').text();
    //            return name.match(/ium$/);
    //        }
    //    };
    //// bind filter button click
    //    $('.filters-button-group').on('click', 'button', function () {
    //        var filterValue = $(this).attr('data-filter');
    //        // use filterFn if matches value
    //        filterValue = filterFns[filterValue] || filterValue;
    //        $grid.isotope({ filter: filterValue });
    //    });
    //// change is-checked class on buttons
    //    $('.button-group').each(function (i, buttonGroup) {
    //        var $buttonGroup = $(buttonGroup);
    //        $buttonGroup.on('click', 'button', function () {
    //            $buttonGroup.find('.is-checked').removeClass('is-checked');
    //            $(this).addClass('is-checked');
    //        });
    //    });

    //    $(document).on('click', '[data-toggle="lightbox"]', function (event) {
    //        event.preventDefault();
    //        $(this).ekkoLightbox();
    //    });

    /////slider room detail
    //    $(window).load(function () {
    //        // The slider being synced must be initialized first
    //        $('#carousel').flexslider({
    //            animation: "slide",
    //            controlNav: false,
    //            animationLoop: false,
    //            slideshow: false,
    //            itemWidth: 136,
    //            itemMargin: 5,
    //            item:6,
    //            asNavFor: '#slider'
    //        });

    //        $('#slider').flexslider({
    //            animation: "slide",
    //            controlNav: false,
    //            slideshowSpeed: 3000,
    //            animationSpeed: 600,
    //            animationLoop: true,
    //            slideshow: true,
    //            sync: "#carousel",
    //        });
    //    });
         
    //     $(".ui-datepicker .ui-datepicker-header .ui-datepicker-prev").addClass("glyphicon glyphicon-arrow-left");
    //     $(".ui-datepicker .ui-datepicker-header .ui-datepicker-next").addClass("glyphicon glyphicon-arrow-right");



    ////price
     
    //     var priceinput = document.getElementsByName('price-input')[0];
    //     $("#price-input").keyup(function () {
    //         if (priceinput.value >= 0 && priceinput.value <= 10) { $(".price-cm").text("10"); }
    //         else if (priceinput.value >= 11 && priceinput.value <= 20) { $(".price-cm").text("20"); }
    //         else if (priceinput.value >= 21 && priceinput.value <= 50) { $(".price-cm").text("50"); }
    //         else if (priceinput.value >= 51 && priceinput.value <= 200) { $(".price-cm").text("100"); }
    //         else if (priceinput.value >= 201 && priceinput.value <= 500) { $(".price-cm").text("200"); }
    //         else { $(".price-cm").text(""); }
             
    //     });
           
         $("#tabbed-nav").zozoTabs({
             position: "top-left",
             theme: "white",
             rounded: false,
             shadows: true,
             size: "large",
             orientation: "horizontal",
             responsive: true,
             minWindowWidth: 480,
             maxRows: 3,
             style: "clean",
             animation: {
                 easing: "easeInOutExpo",
                 duration: 400,
                 effects: "slideH"
             }
         });
        
       
        
});