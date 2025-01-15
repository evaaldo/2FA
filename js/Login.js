var Login = {

    Authenticate: function() {
        Login.validateUserOnDatabase();
    },

    validateUserOnDatabase: async function() {
        var email = $("#email_field").val();
        var password = $("#password_field").val();
        var body = { "Email": email, "Password": password };
        var jsonResponse = await Connection.httpPostRequest("https://localhost:7059/auth/validateUser",body,"JSON");
        
        jsonResponse[0]["Email"] == email ? console.log("deu bao") : console.log("nao deu bao")
    }

}