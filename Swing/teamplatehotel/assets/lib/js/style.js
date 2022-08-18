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
$('#CheckIn').on("change", function () {
    var temp1 = new Date($('#CheckIn').val());
    var temp2 = new Date($('#CheckOut').val());
    if (temp2 <= temp1) {
        var now = new Date();
        var dem = Math.ceil((temp1.getTime() - now.getTime()) / 86400000) + 1;
        $('#CheckOut').datepicker('setDate', '+' + dem);
    }
    const ins = $('#CheckIn').val().split("/");
    const outs = $('#CheckOut').val().split("/");
    $('#in').val(ins[1] + "/" + ins[0] + "/" + ins[2]);
    $('#out').val(outs[1] + '/' + outs[0] + '/' + outs[2]);
});
$('#CheckOut').on("change", function () {
    var temp1 = new Date($('#CheckOut').val());
    var temp2 = new Date($('#CheckIn').val());
    if (temp2 >= temp1) {
        var now = new Date();
        var dem = Math.ceil((temp1.getTime() - now.getTime()) / 86400000);
        if (dem == 0) {
            $('#CheckIn').datepicker('setDate', '+0');
            $('#CheckOut').datepicker('setDate', '+1');
        } else {
            dem = dem - 1;
            $('#CheckIn').datepicker('setDate', '+' + dem);
        }
    }
    const ins = $('#CheckIn').val().split("/");
    const outs = $('#CheckOut').val().split("/");
    $('#in').val(ins[1] + "/" + ins[0] + "/" + ins[2]);
    $('#out').val(outs[1] + '/' + outs[0] + '/' + outs[2]);
});



$(document).ready(function() {




    $('.couter').counterUp({
        delay: 10,
        time: 2000
    });

    $(function() {
        $("#date1").datepicker();
        $("#date2").datepicker();
    });

    $("#menu-toggle").click(function() {
        $(this).toggleClass("show-menu");
        $(".menu").toggleClass("show-menu");
    });
    $(".menu-link").click(function() {
        $(this).parent(".menu-item").toggleClass("show-menu");
        $(".menu-item.show-menu > .submenu").toggleClass("show-menu");

    });
    $(".menu.show-menu .menu-link").click(function() {
        $(this).toggleClass("show-menu");
        $(".submenu").toggleClass("show-menu");
    });

    // /* menu mobile */
    // new Mmenu(document.querySelector("#menu"));

    // document.addEventListener("click", function(evnt) {
    //     var anchor = evnt.target.closest('a[href="#/"]');
    //     if (anchor) {
    //         alert("Thank you for clicking, but that's a demo link.");
    //         evnt.preventDefault();
    //     }
    // });
    // /* end menu mobile */

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

    $('.room-slide').owlCarousel({
        loop: true,
        // center: true,
        items: 4,
        nav: false,
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
            576: {
                items: 2
            },

            767: {
                items: 4
            }
        }

    })


    // $('.gallery-slide').owlCarousel({
    //     loop: true,
    //     // center: true,
    //     items: 4,
    //     nav: false,
    //     navText: ['<i class="fa-solid fa-chevron-left"></i>', '<i class="fa-solid fa-chevron-right"></i>'],
    //     dots: true,
    //     // statePadding: 30,
    //     addClassActive: true,
    //     slideSpeed: 300,
    //     paginationSpeed: 400,
    //     responsive: {
    //         0: {
    //             items: 1
    //         },
    //         767: {
    //             items: 3
    //         },
    //         991: {
    //             items: 4
    //         }
    //     }

    // })


    // $('.packages-list').owlCarousel({
    //     loop: true,
    //     // center: true,
    //     items: 1,
    //     nav: false,
    //     navText: ['<i class="fa-solid fa-chevron-left"></i>', '<i class="fa-solid fa-chevron-right"></i>'],
    //     dots: true,
    //     // statePadding: 30,
    //     addClassActive: true,
    //     slideSpeed: 300,
    //     paginationSpeed: 400,
    //     // responsive: {
    //     //     0: {
    //     //         items: 1
    //     //     },
    //     //     540: {
    //     //         items: 2
    //     //     },
    //     //     991: {
    //     //         items: 3
    //     //     }



    //     // }

    // })

    // $('.testimonial-list').owlCarousel({
    //     loop: true,
    //     // center: true,
    //     items: 2,
    //     nav: false,
    //     navText: ['<i class="fa-solid fa-chevron-left"></i>', '<i class="fa-solid fa-chevron-right"></i>'],
    //     dots: true,
    //     // statePadding: 30,
    //     addClassActive: true,
    //     slideSpeed: 300,
    //     paginationSpeed: 400,
    //     responsive: {
    //         0: {
    //             items: 1
    //         },
    //         1200: {
    //             items: 2
    //         }



    //     }

    // })


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