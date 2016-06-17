'use strict';

var eshopApp = angular.module('eshopApp', ['ngResource', 'ngRoute'])
    .config(function($routeProvider) {
        $routeProvider.when('/newProduct',
        {
            templateUrl: 'Product/NewProduct',
            controller: 'EditProductController'
        });
    });
