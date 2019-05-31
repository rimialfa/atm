app.service('ServiceRequester', function ($http) {
    this.getResponse = function (method, endpoint, payload = {}) {
        if (angular.lowercase(method) == 'get') {
            return $http({
                method: method,
                url: endpoint
            });
        }
        return $http({
            method: method,
            url: endpoint,
            data: payload
        });
    }
});