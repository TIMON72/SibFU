$(document).ready(function(){
	$(window).scroll(function(){
		var top = $(document).scrollTop();
		if (top > 150) 
		{
			$('ul.headline').css({position: 'fixed', top: '0px'});
			$('.toTop').css({display: 'inline'});
		}
		else
		{
			$('ul.headline').css({position: 'relative'});
			$('.toTop').css({display: 'none'});
		}
	});
});