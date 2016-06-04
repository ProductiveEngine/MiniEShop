'use strict';

eshopApp.filter('stockFilter', function () {
    return function (stock) {

        if (stock > 0 && stock < 5) {
            return "few remaining";
        }
        else if (stock >= 5 && stock < 10) {
            return "good";
        }
        else if (stock >= 10) {
            return "very good";
        } else {
            return "n/a";
        }
    }
})