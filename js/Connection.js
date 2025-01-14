var Connection = {

    httpGetRequest: function(url) {

    },

    httpPostRequest: async function(url, body) {
        var response = await fetch(url, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: {
                "Email": body.Email,
                "Password": body.Password
            }
        });

        if (!response.ok) {
            return "Erro na requisição";
        }

        return await response.json();
    }

};