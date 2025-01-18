var Login = {

    Authenticate: async function() {
        await Login.validateToken() ? window.location.href = "http://127.0.0.1:5500/home.html" : Utils.notify("error","Falha ao autenticar");;
    },

    validateUserOnDatabase: async function() {
        var email = $("#email_field").val();
        var password = $("#password_field").val();

        var body = { "Email": email, "Password": password };
        var token = await Connection.httpPostRequest("https://localhost:7059/auth/validateUser",body,"Text");

        console.log(token);

        if (token == null || token == undefined)
        {
            return new Error("Erro no login");
        }

        return token;
    },

    validateToken: async function() {
        var token = await Login.validateUserOnDatabase();

        if (!token)
        {
            return new Error("Não foi passado token");
        }

        var body = { "TokenJwt": token };

        var response = await Connection.httpPostRequest("https://localhost:7059/token/validate",body,"Text");

        if (response == "Token válido")
        {
            localStorage.setItem("token", token);
        };

        return response == "Token válido";
    }

}