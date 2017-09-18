(function () {


	//= require jquery-ui
	jQuery(function ($) {
		$(".swipebox").swipebox();
	});


	$(document).ready(function () {
		$('#horizontalTab').easyResponsiveTabs({
			type: 'default', //Types: default, vertical, accordion
			width: 'auto', //auto or any width like 600px
			fit: true   // 100% fit in a container
        });


        $('#contactForm').submit(function (e) {

            var formData = new FormData(this);

            $.ajax({
                url: "SubmitMessage",
                type: "POST",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: formData,
                contentType: false,
                processData: false,
                success: function (result) {
                    // here in result you will get your data
                    if (result)
                        alert("Thank you for your time! I will get in touch with you shortly.");
                    else
                        alert("Something went wrong... I will fix it ASAP");
                },
                error: function (result) {
                    if (result)
                        alert("Thank you for your time! I will get in touch with you shortly.");
                    else
                        alert("Something went wrong... I will fix it ASAP");
                }
            });
            e.preventDefault();
        });
	});



}
)();

