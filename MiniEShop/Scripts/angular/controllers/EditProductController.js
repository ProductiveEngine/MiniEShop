'use strict';

eshopApp.controller('EditProductController',
    function EditProductController($scope, productData) {

        $scope.product = {};

        $scope.saveProduct = function (product, newProductForm) {
            if (newProductForm.$valid) {
                productData.save(product)
                    .$promise
                    .then(function (response) { console.log('success', response) })
                    .catch(function (response) { console.log('failure', response) });
            }
        };

        $scope.cancelProduct = function () {
            window.location = '/ProductDetails.html';
        }

    }
);