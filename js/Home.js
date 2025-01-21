var Home = {

    Initialize: function() {
        Home.validateToken();
    },

    validateToken: function() {
        var token = localStorage.getItem("token");

        if (!token && window.location.href == "http://127.0.0.1:5500/home.html")
        {
            window.location.href = "http://127.0.0.1:5500/unauthorized.html";
            return new Error("Não foi passado token");
        };
    }

};

$(document).ready(function() {
    Home.Initialize();
});