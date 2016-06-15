'use strict';

var eshopApp = angular.module('eshopApp', ['ngResource', 'ngRoute'])
    .config(function($routeProvider) {
        $routeProvider.when('/newProduct',
        {
            templateUrl: 'NewProduct.cshtml',
            controller: 'EditProductController'
        })
    });
