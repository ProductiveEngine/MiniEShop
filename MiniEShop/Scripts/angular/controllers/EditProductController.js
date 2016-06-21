'use strict';

eshopApp.controller('EditProductController',
        function EditProductController($scope, $routeParams, productData) {

            $scope.product = productData.get({
                //productId: ($routeParams.params === undefined) ? 0 : $routeParams.params.productId
                productId: 2
            });

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