// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



function show_scroll() {
    var a = document.getElementById("scroll-menu");
    var b = document.getElementById("simg");
    var c = document.getElementById("s1");

    a.style.position = "fixed";
    a.style.left = "0";
    a.style.right = "0";
    a.style.margin = "0 auto";
    a.style.zIndex = "999";
    a.style.top = "0";
    a.style.transition = "all 500ms linear";
    a.style.height = "5rem";
    b.style.height = "5rem";
    c.style.height = "5rem";
    //   alert("haha");
}

$(document).ready(function () {
    $(window).scroll(function (event) {
        //h_img
        var pos_body = $("html,body").scrollTop();
        console.log(pos_body);
        //  $(".scroll-menu").addClass("co-dinh-menu");
        if (pos_body > 129) {
            $(".scroll-menu").addClass("co-dinh-menu");
            $("#s1").addClass("h_img");
            $(".menu_Ao_list").addClass("menu1");
        }
        else {
            $(".scroll-menu").removeClass("co-dinh-menu");
            $("#s1").removeClass("h_img");
            $(".menu_Ao_list").removeClass("menu1");
        }

        if (pos_body > 569) {
            $('.back-to-top').addClass('back-top-hide');
        }
        else {
            $('.back-to-top').removeClass('back-top-hide');
        }
    });
    $('.back-to-top').click(function (event) {
        $('html,body').animate({ scrollTop: 0 }, 1400);
    });
});
$(document).ready(function () {
    $(".carousel").carousel();
});
$(document).ready(function () {
    $(".demo").owlCarousel({
        items: 1,
        lazyLoad: true,
        navigation: true
    });
});
$('.carousel').carousel();
$(document).ready(function () {
    $(window).scroll(function (event) {
        var pos_body = $("html,body").scrollTop();
        if (pos_body > 165) {
            $(".t111").addClass("t22");
            $(".t222").addClass("t11");
            $(".t333").addClass("t33");
            $(".t444").addClass("t44");
        }
        else {
            $(".t111").removeClass("t22");
            $(".t222").removeClass("t11");
            $(".t333").removeClass("t33");
            $(".t444").removeClass("t44");
        }
    });
});
$('.dropdown-item').click(function () {
    var name = $(this).text();
    $('.dropdown-toggle').text("" + name + "");
})

///
setTimeout(function () {
    animation_check();
}, 100);
function animation_check() {
    var scrollTop = $(window).scrollTop() - 300;
    $('.animation-tran').each(function () {
        if ($(this).offset().top < scrollTop + $(window).height()) {
            $(this).addClass('active');
        }
    })
}
$(window).scroll(function () {
    //setTimeout(function(){
    animation_check();
    //}, 500);
});



$(document).ready(function () {
    $(".count-holder").click(function () {
        $('#site-overlay').addClass("active");
        $('#site-nav--mobile').addClass("active");
    });
    //
    $("#site-overlay").click(function () {
        $('#site-overlay').removeClass("active");
        $('#site-nav--mobile').removeClass("active");
    });

    $(".hamburger-menu").click(function () {
        $('#site-nav--mobile').addClass("active");
        $('#site-nav--mobile').removeClass("show-cart");
        $('#site-overlay').addClass("active");
    });
});
// click chuyển ảnh
$(".product-gallery__thumb img").click(function () {
    $(".product-gallery__thumb").removeClass('active');
    $(this).parents('.product-gallery__thumb').addClass('active');
    var img_thumb = $(this).data('image');

    $('html, body').animate({
        scrollTop: $("#sliderproduct img[src='" + img_thumb + "']").offset().top
    }, 1000);


});
$(".product-gallery__thumb").first().addClass('active');

$(document).ready(function () {
    $(document).ready(function () {
        var vl = $('#add-item-form .swatch .color input').val();
        $('#add-item-form .swatch .color input').parents(".swatch").find(".header span").html(vl);
        $("#add-item-form .select-swap .color").hover(function () {
            var value = $(this).data("value");
            $(this).parents(".swatch").find(".header span").html(value);
        }, function () {
            var value = $("#add-item-form .select-swap .color label.sd span").html();
            $(this).parents(".swatch").find(".header span").html(value);
        });
    });

    $(".product-thumb a").click(function (e) {
        e.preventDefault();
        $(".product-thumb").removeClass('checked');
        $(this).parent().addClass('checked');
        $(".product-image-feature").attr("src", $(this).attr("data-image"));
    });
    //  hamburger-menu
    $(".policy-item h4").off("click").click(function () {
        // thêm và xóa 1 class luân phiên nhau
        //if (!$(this).find(".icon-open").hasClass("active"))
        //    $(this).find(".icon-open").addClass("active");
        //else
        //    $(this).find(".icon-open").removeClass("active");
        $(this).find(".icon-open").toggleClass("active");
        $(this).next().slideToggle();

        // icon-subnav
    });
    $(".icon-subnav").click(function () {
        // thêm và xóa 1 class luân phiên nhau
        $(this).parent().toggleClass("active");
        $(this).next().slideToggle();

        // footer-title
    });
    $(".footer-title").click(function () {
        // thêm và xóa 1 class luân phiên nhau
        $(this).toggleClass("active");
        $(this).next().slideToggle();

        // footer-title
    });

});

//$("#variant-swatch-0 .select-swap .swatch-element.checked .lbSwatch").css("background-image").replace('url("', '').replace('")','')

$(document).ready(function () {
    // check size và sl
    $("#variant-swatch-1 .select-swap .swatch-element").click(function () {
        if (!$(this).hasClass("soldout")) {
            $("#variant-swatch-1 .select-swap .swatch-element").removeClass("checked");
            $(this).addClass("checked");
        }

    });
    $("#variant-swatch-0 .select-swap .swatch-element").click(function () {
        if (!$(this).hasClass("soldout")) {
            $(".select-swap .swatch-element").removeClass("checked");
            $(this).addClass("checked");
        }
        var i = $(".id_check_idsp").html();
        var l = $("#variant-swatch-0 .select-swap .swatch-element.checked").attr("data-value");
        check_Id(i, l);
    });
    $(".plus").off("click").click(function () {
        $("#quantity").val(parseInt($("#quantity").val()) + 1);
    });
    $(".minus").off("click").click(function () {
        if (parseInt($("#quantity").val()) < 1)
            $("#quantity").val(1);
        else {
            $("#quantity").val(parseInt($("#quantity").val()) - 1);
            if (parseInt($("#quantity").val()) < 1)
                $("#quantity").val(1);
        }
    });
});

// show_sp
$(document).ready(function () {
    Show_Cart();
    $(".count-holder").click(function () {
        Show_Cart();
    });
    $("#add-to-cart").off("click").click(function () {
        if ($("#variant-swatch-0 .select-swap .swatch-element.checked").hasClass("checked") != true || $("#variant-swatch-1 .select-swap .swatch-element.checked").hasClass("checked") != true)
            alert("Xin bạn vui lòng chọn sản phẩm và size yêu thích nha !");
        else {
            var id_SP1 = $("span.sku-number").html();
            var name_SP1 = $("div.product-title h1").html();
            var price_SP1 = $("div#price-preview .pro-price").html().replace(',', '').replace('₫', '');
            var sl1 = $("#quantity").val();
            var image_sp1 = $("#variant-swatch-0 .select-swap .swatch-element.checked .lbSwatch").css("background-image").replace('url("', '').replace('")', '');
            var size1 = $("#variant-swatch-1 .select-swap .swatch-element.checked").attr("data-value");
            var loai_SP1 = $("#variant-swatch-0 .select-swap .swatch-element.checked").attr("data-value");
            Test_Cart(id_SP1, name_SP1, price_SP1, sl1, image_sp1, size1, loai_SP1);
            $('#site-overlay').addClass("active");
            $('#site-nav--mobile').addClass("active");
        }


    });


});










// show
function Show_Cart() {
    var params = {
        type: 'POST',
        url: '/cart/show_sp',
        data: {},
        dataType: 'json',
        success: function (response) {
            console.log(response);
            $("span.count").html(response.sum);
            $("table#cart-view tbody tr").remove();
            var sum = 0;
            if (response.sum == 0) {
                $("table#cart-view tbody").append('<tr><td>Hiện chưa có sản phẩm</td></tr>');
            }
            else {
                for (var i = 0; i < response.sum; i++) {
                    //  console.log(response.cart[i].price_SP);
                    var stt = response.cart[i].stt;
                    var id_SP = response.cart[i].id_SP;
                    var name_SP = response.cart[i].name_SP;
                    var price_SP = response.cart[i].price_SP;
                    var sl = response.cart[i].sl;
                    var image_sp = response.cart[i].image_sp;
                    var size = response.cart[i].size;
                    var loai_SP = response.cart[i].loai_SP;
                    console.log(stt);
                    console.log(image_sp);
                    console.log(loai_SP);
                    var sp = '<tr id=' + stt + ' class="item_2"><td class="img"><a title="' + name_SP + '"><img src=' + image_sp + ' alt="' + name_SP + '"></a></td><td><a class="pro-title-view" title="' + name_SP + '">' + name_SP + '</a> <span class="variant">' + loai_SP + '/' + size + '</span><span class="pro-quantity-view">' + sl + '</span><span class="pro-price-view">' + price_SP + '₫</span><span class="remove_link remove-cart"><a href="javascript:void(0);" onclick="deleteCart(' + i + ')"><i class="fa fa-times"></i></a></span></td></tr>';
                    $("table#cart-view tbody").append(sp);
                    sum = sum + parseInt(response.cart[i].sl) * parseInt(response.cart[i].price_SP);
                }
            }
            $("#total-view-cart").html("" + sum + "₫");
        }

    };
    jQuery.ajax(params);
}

// update
function Update_Cart(i, si, l, s, id_sp) {
    var params = {
        type: 'POST',
        url: '/cart/Update_sp',
        data: { id: i, sl: s, size: si, loai: l, idsp: id_sp },
        dataType: 'json',
        success: function (response) {
            console.log(response);
        }

    };
    jQuery.ajax(params);
}

// add
function Add_Cart(i, n, p, s, im, si, l) {
    var params = {
        type: 'POST',
        url: '/cart/Add_sp',
        data: { id: i, name: n, price: p, sl: s, image: im, size: si, loai: l },
        dataType: 'json',
        success: function (response) {
            console.log(response);
            //if (response.sum == 0) {

            //}
            //else {
            //    for (var i = 0; i < response.sum; i++) {



            //    }
            //}
        }

    };
    jQuery.ajax(params);
}

// Test
function Test_Cart(i, n, p, s, im, si, l) {
    var params = {
        type: 'POST',
        url: '/cart/Test_sp',
        data: { id: i, size: si, loai: l },
        dataType: 'json',
        success: function (response) {
            console.log(response);

            if (response.result == true) {

                console.log(response.cart[0].sl);
                var sl_sum = parseInt(response.cart[0].sl) + parseInt($("#quantity").val());
                Update_Cart(i, si, l, sl_sum, response.cart[0].stt);
                Show_Cart();

            }
            else {
                Add_Cart(i, n, p, s, im, si, l);
                Show_Cart();
            }
        }

    };
    jQuery.ajax(params);
}

// Delete
function Delete_Cart(i) {
    var params = {
        type: 'POST',
        url: '/cart/Delete_sp',
        data: { id: i },
        dataType: 'json',
        success: function (response) {
            console.log(response);

            if (response.result == true) {

            }
            else {
            }
        }

    };
    jQuery.ajax(params);
}

// delete_cart_table
function deleteCart(a) {
    console.log($("table#cart-view tbody tr.item_2:eq(" + a + ")").attr('id'));
    // lấy theo vị trí
    var id_sp_delete = parseInt($("table#cart-view tbody tr.item_2:eq(" + a + ")").attr('id'));
    $("table#cart-view tbody tr.item_2")[a].remove();
    var i = 0;
    $("span.remove-cart a").each(function () {
        $(this).attr('onclick', 'deleteCart(' + i + ')');
        console.log(i);
        if (i == parseInt($("span.remove-cart a").length) - 1)
            i = 0;
        i++;
    });
    Delete_Cart(id_sp_delete);
    //  $("span.remove-cart a").attr('onclick', 'deleteCart(a)')
}

// chekc id
function check_Id(i, l) {
    var params = {
        type: 'POST',
        url: '/ThongSo_SP/Check_Id',
        data: { id: i, loai: l },
        dataType: 'json',
        success: function (response) {
            console.log(response.cart);
            if (response.result == true) {
                $("span.sku-number").html(response.cart);
                check_sl(response.cart);
                check_size_null(i, response.cart);
            }
            else {
                //   $("span.sku-number").html(id);
            }
        }

    };
    jQuery.ajax(params);
}

// chekc sl
function check_sl(i) {
    var params = {
        type: 'POST',
        url: '/ThongSo_SP/Check_sl',
        data: { id: i },
        dataType: 'json',
        success: function (response) {
            console.log(response.cart);
            $("#variant-swatch-1 .select-swap .swatch-element").removeClass("soldout");
            if (response.result == true) {
                for (var i = 0; i < response.cart.length; i++) {
                    if (response.cart[i].sl == 0) {
                        //soldout
                        $("div.swatch-element." + response.cart[i].size + "").addClass("soldout");
                    }

                }
            }
            else {
                //   $("span.sku-number").html(id);
            }
        }

    };
    jQuery.ajax(params);
}

// check size
// chekc sl
function check_size_null(i, s) {
    var params = {
        type: 'POST',
        url: '/ThongSo_SP/Check_Size_Null',
        data: { id: i, id_sp: s },
        dataType: 'json',
        success: function (response) {
            console.log(response);
            if (response.result == true) {
                for (var i = 0; i < response.cart.length; i++) {
                    //soldout
                    $("div.swatch-element." + response.cart[i] + "").addClass("soldout");

                }
            }
            else {
                //   $("span.sku-number").html(id);
            }
        }

    };
    jQuery.ajax(params);
}


$(document).ready(function () {
    $('.owl-carousel').owlCarousel({
        loop: true,
        margin: 10,
        nav: true,
        responsive: {
            0: {
                items: 3
            },
            600: {
                items: 3
            },
            1000: {
                items: 5
            }
        }
    });
    for (var i = 0; i < 609; i++) {
        if ($(".total")[i].innerText.length == 0)
            $(".total")[i].append("1000 sản phẩm của 1 loại");
    }
});

















