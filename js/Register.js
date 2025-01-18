var Register = {

    registerCostumer: async function() {
        var body =
        {
            "CPF": $("#cpf_field").val(),
            "Username": $("#username_field").val(),
            "Email": $("#email_field").val(),
            "Password": $("#password_field").val()
        };

        var response = await Connection.httpPostRequest("https://localhost:7059/costumer/register", body, "Text");
        console.log("Response do register" + response);

        if(response == "Cliente criado com sucesso!")
        {
            Utils.clearFields();
            Utils.notify("success","Você foi cadastrado com sucesso!");
        }
        else
        {
            Utils.notify("error","Falha no cadastro. Tente novamente!");
        }
    }

};