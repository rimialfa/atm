
app.controller('authCtrl', function ($scope, ServiceRequester) {
    $scope.responce = 0;
    $scope.card = {};
    $scope.submitForm = function () {
        debugger;
        var request = ServiceRequester.getResponse("POST", "home/index", $scope.card);
        request.then(function (auth) {
            $scope.message = auth.data.Message;
        }, function () {
            $scope.message = 'Data not found';
        });
    };
});

app.directive('myDirective', function () {
    return {
        require: 'ngModel',
        link: function (scope, element, attr, mCtrl) {
            function isDivisibleBy10(value) {
                if (parseInt(value) % 10 == 0 && parseInt(value) > 0) {
                    mCtrl.$setValidity('divisibleBy10', true);
                } else {
                    mCtrl.$setValidity('divisibleBy10', false);
                }
                return value;
            }
            mCtrl.$parsers.push(isDivisibleBy10);
        }
    };
});

app.controller('denominatorCtrl', function ($scope, ServiceRequester) {
    debugger;
    $scope.amount = 0;
    $scope.getDenominators = function (isValid) {
        if (isValid) {
            var request = ServiceRequester.getResponse("POST", "index", { id: $scope.amount });
            request.then(function (denoms) {
                $scope.records = JSON.parse(denoms.data.Message);
            });
        }
        
    }

});

app.controller('personCtrl', function ($scope) {
    $scope.firstName = "John";
    $scope.lastName = "Doe";
    $scope.fullName = function () {
        return $scope.firstName + " " + $scope.lastName;
    };
})