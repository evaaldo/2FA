var QrCode = {

    initialize: async function() {
        await QrCode.createImage();
    },

    generateQrCode: async function() {
        var email = localStorage.getItem("emailQrCode");

        return await Connection.httpGetRequest(`https://localhost:7059/generateQr/${email}`, "Text");
    },

    createImage: async function() {
        var image = await QrCode.generateQrCode();

        $("#qrCode").attr("src", image);
    }

};

$(document).ready(function() {

    QrCode.initialize();

});