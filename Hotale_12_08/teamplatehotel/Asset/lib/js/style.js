$(window).scroll(function() {
    // var headerHeight = $(".header").outerHeight();
    // kiểm tra điều kiện > header thì mới addClass 
    if ($(window).scrollTop() > 400) {
        $('.header-main').addClass('fixed');
    } else {
        $('.header-main').removeClass('fixed');
    }
});
/* back to top */
var btn = $('#backtotop');

$(window).scroll(function() {
    if ($(window).scrollTop() > 300) {
        btn.addClass('show');
    } else {
        btn.removeClass('show');
    }
});

btn.on('click', function(e) {
    e.preventDefault();
    $('html, body').animate({
        scrollTop: 0
    }, '1000');
});


$(document).mouseup(function(e) {
    if ($(e.target).closest(".room-form").length ===
        0) {
        $(".room-form").children(".custom-selection__wrap").hide();
    }
    if ($(e.target).closest(".guests-form").length ===
        0) {
        $(".guests-form").children(".custom-selection__wrap").hide();
    }
});

$(document).ready(function() {




    var x = $(".room-form .amount").text();
    $(".plus").click(function() {
        $(".room-form .amount").text(++x);
    });
    $(".minus").click(function() {
        $(".room-form .amount").text(--x);
    });

    var y = $(".amount2").text();
    $(".plus2").click(function() {
        $(".amount2").text(++y);
    });
    $(".minus2").click(function() {
        $(".amount2").text(--y);
    });

    var z = $(".amount3").text();
    $(".plus3").click(function() {
        $(".amount3").text(++z);
    });
    $(".minus3").click(function() {
        $(".amount3").text(--z);
    });



    $('.couter').counterUp({
        delay: 10,
        time: 2000
    });

    $(function() {
        $("#date1").datepicker();
        $("#date2").datepicker();
    });

    $(function () {
        $("#CheckIn").datepicker({
            changeMonth: true,
            changeYear: true,
            minDate: new Date(),
            dateFormat: "mm/dd/yy"
        });
        $("#CheckOut").datepicker({
            changeMonth: true,
            changeYear: true,
            minDate: new Date(),
            dateFormat: "mm/dd/yy"
        });
    });
    $("#menu-toggle").click(function() {
        $(this).toggleClass("show-menu");
        $(".menu").toggleClass("show-menu");
    });
    $(".menu-item .menu-link").click(function() {
        $(this).parent(".menu-item").toggleClass("show-menu");
    });

    $(".form-group").click(function() {
        $(this).children(".custom-selection__wrap").show();
    });
    $(".room-form").click(function() {
        $(this).children(".custom-selection__wrap").show();
        $(".guests-form").children(".custom-selection__wrap").hide();
    });
    $(".guests-form").click(function() {
        $(this).children(".custom-selection__wrap").show();
        $(".room-form").children(".custom-selection__wrap").hide();
    });

    $("#booking-tab1").click(function() {
        $(this).addClass("active");
        $("#booking-tab2").removeClass("active");
        $(".booking-content1").addClass("active");
        $(".booking-content2").removeClass("active");
    });
    $("#booking-tab2").click(function() {
        $(this).addClass("active");
        $("#booking-tab1").removeClass("active");
        $(".booking-content2").addClass("active");
        $(".booking-content1").removeClass("active");
    });

    $(".search-tax__item .label .close-filter").click(function() {
        if ($(this).hasClass('active')) {
            $(this).removeClass('active');
            $(this).parent().parent().children('.filter').show();
        } else {
            $(this).addClass('active');
            $(this).parent().parent().children('.filter').hide();
        }

    });

    $('.banner-slide').owlCarousel({
        loop: true,
        // margin: 30,
        center: true,
        items: 1,
        nav: true,
        navText: ['<i class="fa-solid fa-chevron-left"></i>', '<i class="fa-solid fa-chevron-right"></i>'],
        dots: false,
        statePadding: 30,
        addClassActive: true,
        slideSpeed: 300,
        paginationSpeed: 400,
        autoplay: true,
        autoplayTimeout: 3000,
        autoplayHoverPause: true

    })
    $('.gallery-horizontal-list').owlCarousel({
        loop: true,
        margin: 20,
        items: 4,
        nav: false,
        navText: ['<i class="fa-solid fa-chevron-left"></i>', '<i class="fa-solid fa-chevron-right"></i>'],
        dots: false,
        statePadding: 30,
        addClassActive: true,
        slideSpeed: 300,
        paginationSpeed: 400,
        // autoplay: true,
        // autoplayTimeout: 3000,
        // autoplayHoverPause: true,
        responsive: {
            0: {
                items: 1
            },
            576: {
                items: 2
            },

            991: {
                items: 4
            }
        }

    })

    $('.rooms-slider').owlCarousel({
        loop: true,
        // center: true,
        margin: 40,
        items: 3,
        nav: true,
        navText: ['<i class="fa-solid fa-chevron-left"></i>', '<i class="fa-solid fa-chevron-right"></i>'],
        dots: false,
        // statePadding: 30,
        addClassActive: true,
        slideSpeed: 300,
        paginationSpeed: 400,
        responsive: {
            0: {
                items: 1
            },
            768: {
                items: 2
            },

            991: {
                items: 3
            }
        }

    })


    $('.testi-slide').owlCarousel({
        loop: true,
        // center: true,
        margin: 40,
        items: 2,
        nav: false,
        navText: ['<i class="fa-solid fa-chevron-left"></i>', '<i class="fa-solid fa-chevron-right"></i>'],
        dots: true,
        // statePadding: 30,
        addClassActive: true,
        slideSpeed: 300,
        paginationSpeed: 400,
        responsive: {
            0: {
                items: 1,
                center: true
            },
            768: {
                items: 1,
                center: true
            },
            991: {
                items: 2
            }
        }

    })


    $('.blog-slide').owlCarousel({
        loop: true,
        // center: true,
        items: 3,
        margin: 40,
        nav: true,
        navText: ['<i class="fa-solid fa-chevron-left"></i>', '<i class="fa-solid fa-chevron-right"></i>'],
        dots: false,
        statePadding: 30,
        addClassActive: true,
        slideSpeed: 300,
        paginationSpeed: 400,
        responsive: {
            0: {
                items: 1

            },
            768: {
                items: 2
            },
            991: {
                items: 3
            }
        }
    })

    $('.list-insta-gallery').owlCarousel({
        loop: true,
        // center: true,
        items: 4,
        nav: true,
        navText: ['<i class="fa-solid fa-chevron-left"></i>', '<i class="fa-solid fa-chevron-right"></i>'],
        dots: false,
        // statePadding: 30,
        addClassActive: true,
        slideSpeed: 300,
        paginationSpeed: 400,
        responsive: {
            0: {
                items: 1
            },
            768: {
                items: 2
            },
            991: {
                items: 3
            }
        }

    })


    // $('.room-amenities__details').owlCarousel({
    //     loop: true,
    //     // center: true,
    //     items: 6,
    //     nav: false,
    //     navText: ['<i class="fa-solid fa-chevron-left"></i>', '<i class="fa-solid fa-chevron-right"></i>'],
    //     dots: true,
    //     // statePadding: 30,
    //     addClassActive: true,
    //     slideSpeed: 300,
    //     paginationSpeed: 400,
    //     responsive: {
    //         0: {
    //             items: 4
    //         },
    //         540: {
    //             items: 4
    //         },
    //         991: {
    //             items: 6
    //         }



    //     }

    // })





});

$(document).ready(function() {

    var thumd1 = $("#thumd1");
    var thumd2 = $("#thumd2");
    var slidesPerPage = 5; //globaly define number of elements per page
    var syncedSecondary = true;

    thumd1.owlCarousel({
        items: 1,
        slideSpeed: 2000,
        nav: false,
        navText: ['<i class="fas fa-long-arrow-left"></i>', '<i class="fas fa-long-arrow-alt-right"></i>'],
        autoplay: false,
        dots: false,
        loop: true,
        responsiveRefreshRate: 200,

        autoplay: true,
        autoplayTimeout: 3000,
        autoplayHoverPause: true

    }).on('changed.owl.carousel', syncPosition);

    thumd2
        .on('initialized.owl.carousel', function() {
            thumd2.find(".owl-item").eq(0).addClass("current");
        })
        .owlCarousel({
            items: slidesPerPage,
            dots: false,
            nav: false,
            smartSpeed: 200,
            slideSpeed: 500,


            slideBy: slidesPerPage,
            responsiveRefreshRate: 100,
            // responsive: {
            //     0: {
            //         items: 1
            //     },
            //     540: {
            //         items: 3
            //     }



            // }

        }).on('changed.owl.carousel', syncPosition2);

    function syncPosition(el) {


        var count = el.item.count - 1;
        var current = Math.round(el.item.index - (el.item.count / 2) - .5);

        if (current < 0) {
            current = count;
        }
        if (current > count)  {
            current = 0;
        }

        //end block

        thumd2
            .find(".owl-item")
            .removeClass("current")
            .eq(current)
            .addClass("current");
        var onscreen = thumd2.find('.owl-item.active').length - 1;
        var start = thumd2.find('.owl-item.active').first().index();
        var end = thumd2.find('.owl-item.active').last().index();

        if (current > end) {
            thumd2.data('owl.carousel').to(current, 100, true);
        }
        if (current < start) {
            thumd2.data('owl.carousel').to(current - onscreen, 100, true);
        }
    }

    function syncPosition2(el) {
        if (syncedSecondary) {
            var number = el.item.index;
            thumd1.data('owl.carousel').to(number, 100, true);
        }
    }

    thumd2.on("click", ".owl-item", function(e) {
        e.preventDefault();
        var number = $(this).index();
        sync1.data('owl.carousel').to(number, 300, true);
    });
});