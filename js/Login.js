var Login = {

    Authenticate: async function() {
        await Login.validateToken() ? console.log("mudar de tela") : console.log("nao mudar de tela");
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

        return response == "Token válido";
    }

}