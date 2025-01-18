var Register = {

    registerCostumer: async function() {
        var body = {
            "CPF": $("#cpf_field").val(),
            "Username": $("#username_field").val(),
            "Email": $("#email_field").val(),
            "Password": $("#password_field").val()
        };

        await Connection.httpPostRequest("https://localhost:7059/costumer/register", body, "JSON");
    }

};