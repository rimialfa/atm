
app.controller('authCtrl', function ($scope, ServiceRequester, $window) {
    $scope.responce = 0;
    $scope.card = {};
    $scope.submitForm = function () {
        debugger;
        var request = ServiceRequester.getResponse("POST",  "/Home/Index", $scope.card);
        request.then(function (auth) {

            if (auth.data.Status) {
                $window.location.href = '/Home/MainMenu';
            }
            $scope.message = auth.data.Message;
        }, function () {
            $scope.message = 'Data not found';
        });
    };
});



app.controller('denominatorCtrl', function ($scope, ServiceRequester) {
    debugger;
    $scope.amount = 0;
    $scope.getDenominators = function (isValid) {
        if (isValid) {
            var request = ServiceRequester.getResponse("POST", "/Withdraw/Index", { id: $scope.amount });
            request.then(function (denoms) {
                $scope.records = JSON.parse(denoms.data.Message);
            });
        }
        
    }

});
