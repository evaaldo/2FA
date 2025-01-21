var Utils = {

    clearFields: function() {
        $("input").val("");
    },

    notify: function(type,message) {
        
        toastr.options = {
            "closeButton": false,
            "debug": false,
            "newestOnTop": false,
            "progressBar": false,
            "positionClass": "toast-top-right",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        };
    
        toastr[type](message);
    },

    loadForForm: function(url) {
        $(".form_container").hide();
        $("body").append(`
            <div class="dot-spinner">
                <div class="dot-spinner__dot"></div>
                <div class="dot-spinner__dot"></div>
                <div class="dot-spinner__dot"></div>
                <div class="dot-spinner__dot"></div>
                <div class="dot-spinner__dot"></div>
                <div class="dot-spinner__dot"></div>
                <div class="dot-spinner__dot"></div>
                <div class="dot-spinner__dot"></div>
            </div>    
        `);
    
        setTimeout(() => {
            $(".dot-spinner").remove();
            $(".form_container").show();
            window.location.href = url;
        }, 3000);
    }
    

};