
app.controller('authCtrl', function ($scope, ServiceRequester, $window) {
    $scope.responce = 0;
    $scope.card = {};
    $scope.submitForm = function () {
        var request = ServiceRequester.getResponse("POST", "/auth/index", $scope.card);
        request.then(function (auth) {

            if (auth.data.Status) {
                $window.location.href = '/Account/MainMenu';
            }
            $scope.error = auth.data.Message;
        }, function () {
            $scope.error = 'Data not found';
        });
    };
});


app.controller('withdrawCustomCashCtrl', function ($scope, ServiceRequester, $window) {

    $scope.isWithdrawing = true;
    $scope.isPritingReceipt = false;
    $scope.amount = "";
    $scope.retrieve = "disabled";
    $scope.getDenominators = function (isValid) {
        if (isValid) {
            if ($scope.account.Balance < $scope.amount) {
                $scope.error = "The value should not exceeds the balance";
                $scope.records = {};
            } else {
                var request = ServiceRequester.getResponse("POST", "/withdraw/index", { amount: $scope.amount });
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
        $scope.error = "";
        $scope.retrieve = "";
    };
    $scope.submitForm = function () {
        var request = ServiceRequester.getResponse("POST", "/withdraw/dispense", { amount: $scope.amount });
        request.then(function (response) {

            if (response.data.Status) {
                $scope.isWithdrawing = false;
                $scope.isPritingReceipt = true;
            }
        }, function () {
            $scope.error = response.data.Message;
            $scope.isWithdrawing = false;
            $scope.isPritingReceipt = true;
        });
    }

});

app.controller('withdrawQuickCashCtrl', function ($scope, ServiceRequester, $window) {
    $scope.prevValue = $scope.value;
    $scope.isWithdrawing = true;
    $scope.isPritingReceipt = false;
    $scope.checkBalance = function (value) {
        var request = ServiceRequester.getResponse("GET", "/account/getaccount");
        request.then(function (response) {
            var account = JSON.parse(response.data.Message);
            if (parseInt(value) > parseInt(account.Balance)) {
                $scope.value = $scope.prevValue;
                $scope.error = "The value should not exceeds the balance";
            } else {
                $scope.error = "";
                var request = ServiceRequester.getResponse("POST", "/withdraw/dispense", { amount: parseInt(value) });
                request.then(function (response) {

                    if (response.data.Status) {
                        $scope.amount = value;
                        $scope.isWithdrawing = false;
                        $scope.isPritingReceipt = true;
                    }
                }, function () {

                    $scope.error = response.data.Message;
                    $scope.amount = value;
                    $scope.isWithdrawing = false;
                    $scope.isPritingReceipt = true;
                });
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