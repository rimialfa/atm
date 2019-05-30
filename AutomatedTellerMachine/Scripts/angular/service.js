app.service('ServiceRequester', function ($http) {
    this.getResponse = function (method,endpoint,payload) {
        return $http({
            method: method,
            url: endpoint,
            data: payload
        });
    }
});