//หน้าเชื่อม Controller กับหน้า js หลัก
app.service("CENTER_SV", function ($http) {
    //var token = "ecYYRiBaXH6pytoPPuuUTgUU";
    //var url = "https://apres.fda.moph.go.th/POST_CENTER_SERVICE/";
    var url = "http://localhost:61382/";

    this.GET_SET_FULL_MODEL = function (chk_access) { //เรียก Full model
        var response = $http({
            method: "post",
            url: "../Gateway/SET_FULL_MODEL",
            dataType: "json",
            params: {
                chk_access: chk_access
            }
        });
        return response;
    };

    this.GET_NOVEL = function (model) { //เรียก Full model
        var response = $http({
            method: "post",
            url: "https://asia-southeast2-mynovel01.cloudfunctions.net/product/FETCH-PRODUCTS-EBOOK-ALL",
            dataType: "json"
        });
        return response;
    };


    this.GET_ALL = function (model) { //เรียก Full model
        var response = $http({
            method: "post",
            url: "https://asia-southeast2-mynovel01.cloudfunctions.net/product/FETCH-PRODUCTS-JSON-ALL", //FETCH-PRODUCTS-JSON-ALL
            dataType: "json"
        });
        return response;
    };

    //this.GET_HISTORY = function (model) { //เรียก Full model
    //    var response = $http({
    //        method: "post",
    //        url: "http://localhost:5001/mynovel01/asia-southeast2/user/FETCH-HISTORY-ALL",
    //        dataType: "json"
    //    });
    //    return response;
    //};


    this.INSERT_DATA = function (model) { //เรียก Full model
        var response = $http({
            method: "post",
            url: "../Gateway/INSERT_DATA",
            dataType: "json",
            data: {
                MODEL: JSON.stringify(model)
            }
        });
        return response;
    };


});