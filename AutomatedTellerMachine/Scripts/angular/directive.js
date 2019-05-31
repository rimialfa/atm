app.directive('divisibleBy10', function () {
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
