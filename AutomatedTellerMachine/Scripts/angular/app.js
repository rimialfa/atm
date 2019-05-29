var app = angular.module('myApp', []);

app.service('AuthenticationService', function ($http) {
    this.getResponse = function (card) {
        return $http({
            method: 'POST',
            url: '/home/index',
            data: card
        });
    }
});

app.controller('authCtrl', function ($scope, AuthenticationService) {
    $scope.responce = 0;
    $scope.card = {};
    $scope.submitForm = function () {
        debugger;
        var r = AuthenticationService.getResponse($scope.card);
        r.then(function (auth) {
            $scope.message = auth.data.Message;
        }, function () {
            $scope.message = 'Data not found';
        });
    };
});
