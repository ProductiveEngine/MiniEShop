'use strict';
eshopApp.controller('EditProductController',
        function EditProductController($scope, $stateParams, productData, $log) {
            
            $scope.product = productData.get({
                id: ($stateParams.id === undefined) ? 0 : $stateParams.id
            });

            $scope.saveProduct = function () {
                if ($scope.editProductForm.$valid) {
                    $log.info('Form is valid');

                    productData.save($scope.product)
                        .$promise
                        .then(function(response) {
                            console.log('success', response);                                                        
                        })
                        .catch(function (response) { console.log('failure', response) });
                }
            };

            $scope.deleteProduct = function (product) {
                console.log(product);
                product.$delete(function () {
                        $window.location.href = '';
                    });
                

                //productData.delete(product)
                //    .$promise
                //    .then(function(response) {
                //        $log.info('deletion success', response);
                //    })
                //    .catch(function(response) { $log.info('failure', response) });
            };
        }
);



//ngRoute

//eshopApp.controller('EditProductController',
//        function EditProductController($scope, $routeParams, productData) {

//            $scope.product = productData.get({
//                productId: ($routeParams.params === undefined) ? 0 : $routeParams.params.productId              
//            });

//        $scope.saveProduct = function (product, newProductForm) {
//            if (newProductForm.$valid) {
//                productData.save(product)
//                    .$promise
//                    .then(function (response) { console.log('success', response) })
//                    .catch(function (response) { console.log('failure', response) });
//            }
//        };

//        $scope.cancelProduct = function () {
//            window.location = '/ProductDetails.html';
//        }

//    }
//);