$(document).ready(function(){
    $('.main__review').owlCarousel({
        singleItem: true,
        loop: true,
        nav: false,
        dots: true,
        autoplay:true,
        autoplayTimeout:3000,
        margin: 30,
        responsive: {
            0:{
                items: 1
            },
            414: {
                items: 1
            },
            768:{
                items: 2
            },
            820: {
                items: 2
            },
            1200:{
                items: 3
            }
        }
    })

    $('.slider__list__services').owlCarousel({
        singleItem: true,
        loop: true,
        nav: false,
        dots: false,
        // autoplay:true,
        // autoplayTimeout:3000,
        margin: 30,
        responsive: {
            0:{
                items: 1
            },
            414: {
                items: 1
            },
            768:{
                items: 2
            },
            820: {
                items: 2
            },
            1200:{
                items: 3
            }
        }
    })

    $('.slider__image__services').owlCarousel({
        singleItem: true,
        loop: true,
        nav: false,
        dots: false,
        autoplay:true,
        autoplayTimeout:3000,
        margin: 30,
        responsive: {
            0:{
                items: 1
            },
            414: {
                items: 1
            },
            820: {
                items: 1
            },
            1200:{
                items: 1
            }
        }
    })

    $('.slider__our__room').owlCarousel({
        singleItem: true,
        loop: true,
        nav: false,
        dots: true,
        autoplay:true,
        autoplayTimeout:3000,
        margin: 30,
        responsive: {
            0:{
                items: 1
            },
            414: {
                items: 1
            },
            820: {
                items: 2
            },
            1200:{
                items: 3
            }
        }
    })



    $('.slider__testimonials').owlCarousel({
        singleItem: true,
        loop: true,
        nav: false,
        dots: true,
        // autoplay:true,
        // autoplayTimeout:3000,
        margin: 30,
        responsive: {
            0:{
                items: 1
            },
            414: {
                items: 1
            },
            820: {
                items: 1
            },
            1200:{
                items: 1
            }
        }
    })


    $('.image__room__detail').owlCarousel({
        singleItem: true,
        loop: true,
        nav: true,
        dots: false,
        autoplay:true,
        autoplayTimeout:3000,
        navText: ["<i class='fa-solid fa-angle-left'></i>","<i class='fa-solid fa-angle-right'></i>"],
        margin: 20,
        responsive: {
            0:{
                items: 1
            },
            414: {
                items: 1
            },
            820: {
                items: 1
            },
            1200:{
                items: 1
            }
        }
    })
})


//language
$('.choose__language').click(function(){
    $('.list__language').toggleClass('open__language');
    $('.choose__language i').toggleClass('rotate__icon');
    $('.list__language').toggleClass('index__lg');
})
$('.choose__person').click(function(){
    $('.list__person__number').toggleClass('open__choose__person');
    $('.person__number i').toggleClass('rotate__icon');
})

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

$(function () {
    $("#check-in-hotel").datepicker({
        changeMonth: true,
        changeYear: true,
        minDate: new Date()
});
    $("#check-out-hotel").datepicker({
        changeMonth: true,
        changeYear: true,
        minDate: new Date()
});
    $('#check-in-hotel').datepicker({ dateFormat: "mm dd yy", changeMonth: true, changeYear: true }).
    datepicker('setDate', '+0d');
    $('#check-out-hotel').datepicker({ dateFormat: "mm dd yy", changeMonth: true, changeYear: true }).
    datepicker('setDate', '+1d');

    $("#check-in-time").datepicker({
        changeMonth: true,
        changeYear: true,
        minDate: new Date()
});
    $("#check-out-time").datepicker({
        changeMonth: true,
        changeYear: true,
        minDate: new Date()
});
    $('#check-in-time').datepicker({ dateFormat: "mm dd yy", changeMonth: true, changeYear: true }).
    datepicker('setDate', '+0d');
    $('#check-out-time').datepicker({ dateFormat: "mm dd yy", changeMonth: true, changeYear: true }).
    datepicker('setDate', '+1d');

    $("#check-in-booking").datepicker({
        changeMonth: true,
        changeYear: true,
        minDate: new Date()
});
    $("#check-out-booking").datepicker({
        changeMonth: true,
        changeYear: true,
        minDate: new Date()
});
    $('#check-in-booking').datepicker({ dateFormat: "mm dd yy", changeMonth: true, changeYear: true }).
    datepicker('setDate', '+0d');
    $('#check-out-booking').datepicker({ dateFormat: "mm dd yy", changeMonth: true, changeYear: true }).
    datepicker('setDate', '+1d');

    $("#check-in-booking-sheet").datepicker({
        changeMonth: true,
        changeYear: true,
        minDate: new Date()
});
    $("#check-out-booking-sheet").datepicker({
        changeMonth: true,
        changeYear: true,
        minDate: new Date()
});
    $('#check-in-booking-sheet').datepicker({ dateFormat: "mm dd yy", changeMonth: true, changeYear: true }).
    datepicker('setDate', '+0d');
    $('#check-out-booking-sheet').datepicker({ dateFormat: "mm dd yy", changeMonth: true, changeYear: true }).
    datepicker('setDate', '+1d');                                  
});



$(window).scroll(function () {
    if ($(this).scrollTop() >= 600) {
        $('.btn-active').addClass('animate');
    }
    else {
        $('.btn-active').removeClass('animate');
    }
})

$('.btn-active').click(function () {
    $('html').animate({
        scrollTop: 0
    }, 500);
})


$('.menu__bars').click(function(){
    $('.menu__mobile').animate({
        height: 'toggle'
    })
    $('.menu__bars i').toggleClass('fa-x');
})


$('.sub__menu__mobile .menu__mobile__title').click(function(){
    $(this).parent('.sub__menu__mobile').toggleClass('show__menu__child');
    $('.sub__menu__mobile').not($(this).parent('.sub__menu__mobile')).removeClass('show__menu__child');
    $('.menu__mobile__title i').toggleClass('fa-minus');
})




$('[data-fancybox]').fancybox({
    buttons: [
        'close'
    ],
    wheel: false,
    transitionEffect: "slide",
    // thumbs          : false,
    // hash            : false,
    loop: false,
    // keyboard        : true,
    toolbar: true,
    // animationEffect : false,
    // arrows          : true,
    clickContent: false,
    hash: false
});



//home
$(window).scroll(function () {
    if ($(this).scrollTop() >= 150) {
        $('.navbar__home').css("position","fixed");
        $('.navbar__home').css("top","0px");
        $('.navbar__home').css("width","100%");
        $('.navbar__home').css("border-radius","0");
    }
    else {
        $('.navbar__home').css("top","15px");
        $('.navbar__home').css("width","99%");
        $('.navbar__home').css("border-radius","15px");
    }
})


$('.choose__person__booking').click(function(){
    $('.list__person__number__booking').toggleClass('open__choose__person');
    $('.person__number__booking i').toggleClass('rotate__icon');
    $('.choose__person__booking').toggleClass('index__choose');
})


$('.sub__title__question .question').click(function(){
    $(this).next('.dropdown__answer').slideToggle();
    $(this).parent('.sub__title__question').toggleClass("show__list__answer").slideDown();
    // $('.sub__title__question').not($(this).parent('.sub__title__question')).removeClass("show__list__answer");
    
})


// $('.question').click(function (e) {
//     $(this).next('.dropdown__answer').slideToggle();
//     var target = e.target;
//     if (!$(target).is('.question') && !$(target).parents().is('.question')){
//         $('.dropdown__answer').slideUp();
//     }
// });


$(document).ready(function () {
    $('.tab ul.tabs').addClass('active').find('> li:eq(0)').addClass('current');
    $('.tab ul.tabs li a').click(function (g) {
        var tab = $(this).closest('.tab'),
            index = $(this).closest('li').index();

        tab.find('ul.tabs > li').removeClass('current');
        $(this).closest('li').addClass('current');

        tab.find('.tab_content').find('div.tabs_item').not('div.tabs_item:eq(' + index + ')').slideUp();
        tab.find('.tab_content').find('div.tabs_item:eq(' + index + ')').slideDown();
        g.preventDefault();
    })
})

       


$('.choose__person__number').click(function(){
    $('.dropdown__person').toggleClass('open__choose__persons');
    $('.person__number__booking__sheet i').toggleClass('rotate__icon__person');
})
 

$('.choose__room__number').click(function(){
    $('.dropdown__room').toggleClass('open__choose__rooms');
    $('.room__number__booking__sheet i').toggleClass('rotate__icon__room');
})

$(".drop-down .selected a").click(function () {
    $(".drop-down .options ul").toggle();
});

$(".drop-down .options ul li a").click(function () {
    var text = $(this).html();
    $(".drop-down .selected a span").html(text);
    $("#Adult").val(text);
    $(".drop-down .options ul").hide();
});


$(document).bind('click', function (e) {
    var $clicked = $(e.target);
    if (!$clicked.parents().hasClass("drop-down"))
        $(".drop-down .options ul").hide();
});
/////////////
$(".drop-down1 .selected a").click(function () {
    $(".drop-down1 .options ul").toggle();
});

$(".drop-down1 .options ul li a").click(function () {
    var text = $(this).html();
    $(".drop-down1 .selected a span").html(text);
    $("#Child").val(text);
    $(".drop-down1 .options ul").hide();
});


$(document).bind('click', function (e) {
    var $clicked = $(e.target);
    if (!$clicked.parents().hasClass("drop-down1"))
        $(".drop-down1 .options ul").hide();
});