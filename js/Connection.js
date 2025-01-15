var Connection = {

    httpGetRequest: async function(url, devolve) {
        var requestConfig = {
            method: "GET",
            headers: {
                "Content-Type": "application/json"
            }            
        };

        var response = await fetch(url,requestConfig);
        console.log(response);

        if (!response.ok) {
            return "Erro na requisição";
        }

        var responseHandlers = {
            "JSON": () => response.json(),
            "Text": () => response.text()
        }

        if (responseHandlers[devolve]) {
            return await responseHandlers[devolve]();
        } else {
            console.log("Erro na requisição");
        }
    },

    httpPostRequest: async function(url, body, devolve) {
        var requestConfig = {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            }            
        };

        if (body) {
            requestConfig.body = JSON.stringify(body);
        }

        var response = await fetch(url,requestConfig);
        console.log(response);

        if (!response.ok) {
            return "Erro na requisição";
        }

        var responseHandlers = {
            "JSON": () => response.json(),
            "Text": () => response.text()
        }

        if (responseHandlers[devolve]) {
            return await responseHandlers[devolve]();
        } else {
            console.log("Erro na requisição");
        }
    }

};