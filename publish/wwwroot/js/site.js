//consulta movil

var listaMoviles;
function ObtenerMoviles() {
	
	let zona = $('#zona').val()
    $.ajax({
        url: "/Moviles/getMoviles?zona=" +zona,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
			console.log(response)
			listaMoviles = response.moviles;
			console.log("moviles",listaMoviles)
            ArmarTabla();
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    })
}
function ArmarTabla() {
	$('#zona').val('')
    $("#tablaMoviles").remove();
    var tabla = $('<table id="tablaMoviles" class="table"></table>');
	tabla.append("<thead><td>Fecha</td><td>Hora</td><td>Barrio</td><td>Servicio</td><td>Zona</td><td>Telefono</td></thead>");
    var body = $('<tbody></tbody>');
    var linea;
    // var inicio = (nroPagina * cantRegistrosPagina);
    // var fin = inicio + cantRegistrosPagina;
    // for (var i = inicio; i < fin; i++) {
	for (var i = 0; i < listaMoviles.length; i++) {
		var fechaFormat= new Date(listaMoviles[i].fecha).toLocaleDateString();
		var timeFormat= new Date(listaMoviles[i].hora).toLocaleTimeString();
        linea = $('<tr></tr>')
        linea.append("<td>" + fechaFormat + "</td>");
        linea.append("<td>" + timeFormat + "</td>");
        linea.append("<td>" + listaMoviles[i].barrio + "</td>");
        linea.append("<td>" + listaMoviles[i].servicio + "</td>");
        linea.append("<td>" + listaMoviles[i].zona + "</td>");
        linea.append("<td>" + listaMoviles[i].telefono + "</td>");
        body.append(linea);
    };
    tabla.append(body);
    $("#divTablaMoviles").append(tabla);
    
}
//alert
$(document).ready(function(){
	$("#altaTurno").click(function(){
		swal("Turno Reservado", "You clicked the button!", "success");
	});
	
}); 

//template
!(function($) {
	"use strict";
  
	// Preloader
	$(window).on('load', function() {
	  if ($('#preloader').length) {
		$('#preloader').delay(100).fadeOut('slow', function() {
		  $(this).remove();
		});
	  }
	});
  
	// Smooth scroll for the navigation menu and links with .scrollto classes
	var scrolltoOffset = $('#header').outerHeight() - 1;
	$(document).on('click', '.nav-menu a, .mobile-nav a, .scrollto', function(e) {
	  if (location.pathname.replace(/^\//, '') == this.pathname.replace(/^\//, '') && location.hostname == this.hostname) {
		var target = $(this.hash);
		if (target.length) {
		  e.preventDefault();
  
		  var scrollto = target.offset().top - scrolltoOffset;
  
		  if ($(this).attr("href") == '#header') {
			scrollto = 0;
		  }
  
		  $('html, body').animate({
			scrollTop: scrollto
		  }, 1500, 'easeInOutExpo');
  
		  if ($(this).parents('.nav-menu, .mobile-nav').length) {
			$('.nav-menu .active, .mobile-nav .active').removeClass('active');
			$(this).closest('li').addClass('active');
		  }
  
		  if ($('body').hasClass('mobile-nav-active')) {
			$('body').removeClass('mobile-nav-active');
			$('.mobile-nav-toggle i').toggleClass('icofont-navigation-menu icofont-close');
			$('.mobile-nav-overly').fadeOut();
		  }
		  return false;
		}
	  }
	});
  
	// Activate smooth scroll on page load with hash links in the url
	$(document).ready(function() {
	  if (window.location.hash) {
		var initial_nav = window.location.hash;
		if ($(initial_nav).length) {
		  var scrollto = $(initial_nav).offset().top - scrolltoOffset;
		  $('html, body').animate({
			scrollTop: scrollto
		  }, 1500, 'easeInOutExpo');
		}
	  }
	});
  
	// Navigation active state on scroll
	var nav_sections = $('section');
	var main_nav = $('.nav-menu, .mobile-nav');
  
	$(window).on('scroll', function() {
	  var cur_pos = $(this).scrollTop() + 200;
  
	  nav_sections.each(function() {
		var top = $(this).offset().top,
		  bottom = top + $(this).outerHeight();
  
		if (cur_pos >= top && cur_pos <= bottom) {
		  if (cur_pos <= bottom) {
			main_nav.find('li').removeClass('active');
		  }
		  main_nav.find('a[href="#' + $(this).attr('id') + '"]').parent('li').addClass('active');
		}
		if (cur_pos < 300) {
		  $(".nav-menu ul:first li:first, .mobile-nav ul:first li:first").addClass('active');
		}
	  });
	});
  
	// Mobile Navigation
	if ($('.nav-menu').length) {
	  var $mobile_nav = $('.nav-menu').clone().prop({
		class: 'mobile-nav d-lg-none'
	  });
	  $('body').append($mobile_nav);
	  $('body').prepend('<button type="button" class="mobile-nav-toggle d-lg-none"><i class="icofont-navigation-menu"></i></button>');
	  $('body').append('<div class="mobile-nav-overly"></div>');
  
	  $(document).on('click', '.mobile-nav-toggle', function(e) {
		$('body').toggleClass('mobile-nav-active');
		$('.mobile-nav-toggle i').toggleClass('icofont-navigation-menu icofont-close');
		$('.mobile-nav-overly').toggle();
	  });
  
	  $(document).on('click', '.mobile-nav .drop-down > a', function(e) {
		e.preventDefault();
		$(this).next().slideToggle(300);
		$(this).parent().toggleClass('active');
	  });
  
	  $(document).click(function(e) {
		var container = $(".mobile-nav, .mobile-nav-toggle");
		if (!container.is(e.target) && container.has(e.target).length === 0) {
		  if ($('body').hasClass('mobile-nav-active')) {
			$('body').removeClass('mobile-nav-active');
			$('.mobile-nav-toggle i').toggleClass('icofont-navigation-menu icofont-close');
			$('.mobile-nav-overly').fadeOut();
		  }
		}
	  });
	} else if ($(".mobile-nav, .mobile-nav-toggle").length) {
	  $(".mobile-nav, .mobile-nav-toggle").hide();
	}
	// Toggle .header-scrolled class to #header when page is scrolled
	$(window).scroll(function() {
	  if ($(this).scrollTop() > 100) {
		$('#header').addClass('header-scrolled');
		$('#topbar').addClass('topbar-scrolled');
	  } else {
		$('#header').removeClass('header-scrolled');
		$('#topbar').removeClass('topbar-scrolled');
	  }
	});
  
	if ($(window).scrollTop() > 100) {
	  $('#header').addClass('header-scrolled');
	  $('#topbar').addClass('topbar-scrolled');
	}
	// Back to top button
	$(window).scroll(function() {
	  if ($(this).scrollTop() > 100) {
		$('.back-to-top').fadeIn('slow');
	  } else {
		$('.back-to-top').fadeOut('slow');
	  }
	});
  
	$('.back-to-top').click(function() {
	  $('html, body').animate({
		scrollTop: 0
	  }, 1500, 'easeInOutExpo');
	  return false;
	});
  
	// jQuery counterUp
	// $('[data-toggle="counter-up"]').counterUp({
	//   delay: 10,
	//   time: 1000
	// });
  
	// Testimonials carousel (uses the Owl Carousel library)
	// $(".testimonials-carousel").owlCarousel({
	//   autoplay: true,
	//   dots: true,
	//   loop: true,
	//   responsive: {
	// 	0: {
	// 	  items: 1
	// 	},
	// 	768: {
	// 	  items: 1
	// 	},
	// 	900: {
	// 	  items: 2
	// 	}
	//   }
	// });
  
	// Initiate the venobox plugin
	// $(document).ready(function() {
	//   $('.venobox').venobox();
	// });
  
	// Initiate the datepicker plugin
	// $(document).ready(function() {
	//   $('.datepicker').datepicker({
	// 	autoclose: true
	//   });
	// });
  
  })(jQuery); 


        
