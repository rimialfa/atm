
app.controller('authCtrl', function ($scope, ServiceRequester, $window) {
    $scope.responce = 0;
    $scope.card = {};
    $scope.submitForm = function () {
        var request = ServiceRequester.getResponse("POST", "/Auth/Index", $scope.card);
        request.then(function (auth) {

            if (auth.data.Status) {
                $window.location.href = '/Account/MainMenu';
            }
            $scope.message = auth.data.Message;
        }, function () {
            $scope.message = 'Data not found';
        });
    };
});



app.controller('withdrawCtrl', function ($scope, ServiceRequester) {
    
    $scope.amount = 0;
    $scope.retrieve = "disabled";
    //$scope.error = "The value should not exceeds the balance";
    $scope.getDenominators = function (isValid) {
        if (isValid) {
            if ($scope.account.Balance < $scope.amount) {
                $scope.error = "The value should not exceeds the balance";
                $scope.records = {};
            } else {
                var request = ServiceRequester.getResponse("POST", "/Withdraw/Index", { id: $scope.amount });
                request.then(function (denoms) {
                    $scope.error = "A denoiminator is required";
                    $scope.records = JSON.parse(denoms.data.Message);
                });
            }

        } else {
            $scope.error = "Choose an amount that is divisable by 10";
            $scope.records = {};
        }

    };
    $scope.enableRetrieve = function (status) {
        debugger;
        $scope.retrieve = "";
    };

});
app.controller('withdrawPresetCtrl', function ($scope, ServiceRequester) {
    $scope.prevValue = $scope.value;
    $scope.checkBalance = function (value) {
        var request = ServiceRequester.getResponse("GET", "/Account/GetAccount");
        request.then(function (response) {
            var account = JSON.parse(response.data.Message);
            if (parseInt(value) <= parseInt(account.Balance)) {
                $scope.value = $scope.prevValue;
                $scope.message = "The value should not exceeds the balance";
            } else {
                $scope.message = "";
                //TODO: Dispense the amount
            }
        });

    };

});


app.controller('accountCtrl', function ($scope, ServiceRequester) {
    $scope.account = {};
    var request = ServiceRequester.getResponse("GET", "/Account/GetAccount");
    request.then(function (response) {
        var account = JSON.parse(response.data.Message);
        if (account != undefined) {
            $scope.account = account;
        } else {
            $scope.account = "n/a";
        }
    });

});