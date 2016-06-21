'use strict';

var eshopApp = angular.module('eshopApp', ['ngResource', 'ngRoute'])
    .config(function($routeProvider) {
        $routeProvider.
        when('/newProduct',
        {
            templateUrl: 'Product/NewProduct',
            controller: 'EditProductController'
        }).
        when('/products/:productId',
        {
            templateUrl: 'Edit',
            controller: 'EditProductController'
        });
    });
