app.service("AuthenticationService", function ($http) {
    this.auth = function () {
        debugger;
        return $http.get("/home/index");
    };
});