'use strict';

var eshopApp = angular.module('eshopApp', ['ngResource', 'ui.router']);

eshopApp.config(function($stateProvider, $urlRouterProvider) {
   
    $stateProvider
        // HOME STATES AND NESTED VIEWS ========================================
        .state('productEdit',
        {
            url: '/product/:productId',
            templateUrl: 'Edit',
            controller: 'EditProductController'
        })

        // ABOUT PAGE AND MULTIPLE NAMED VIEWS =================================
        .state('about',
        {
            // we'll get to this in a bit       
        
        });

});



    ////ngRoute (Old way)
    //.config(function ($routeProvider) {
    //    $routeProvider.
    //    when('/newProduct',
    //    {
    //        templateUrl: 'Product/NewProduct',
    //        controller: 'EditProductController'
    //    }).
    //    when('/products/:productId',
    //    {
    //        templateUrl: 'Edit',
    //        controller: 'EditProductController'
    //    });
    //});

//Examples:

//    '/hello/' - Matches only if the path is exactly '/hello/'. There is no special treatment for trailing slashes, and patterns have to match the entire path, not just a prefix.
//    '/user/:id' - Matches '/user/bob' or '/user/1234!!!' or even '/user/' but not '/user' or '/user/bob/details'. The second path segment will be captured as the parameter 'id'.
//    '/user/{id}' - Same as the previous example, but using curly brace syntax.
//    '/user/{id:int}' - The param is interpreted as Integer.
//    Note:

//    Parameter names may contain only word characters (latin letters, digits, and underscore) and must be unique within the pattern (across both path and search parameters).

// will only match a contactId of one to eight number characters
//url: "/contacts/{contactId:[0-9]{1,8}}"

//You can also specify parameters as query parameters, following a '?':

//url: "/contacts?myParam"
//// will match to url of "/contacts?myParam=value"
//If you need to have more than one, separate them with an '&':

//url: "/contacts?myParam1&myParam2"
//// will match to url of "/contacts?myParam1=value1&myParam2=wowcool"