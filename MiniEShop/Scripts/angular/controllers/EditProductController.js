'use strict';
eshopApp.controller('EditProductController',
        function EditProductController($scope, $stateParams, ProductData, ProductTypeData, $log, notificationFactory) {
            
            $scope.product = ProductData.get({
                id: ($stateParams.id === undefined) ? 0 : $stateParams.id
            });
            
            $scope.hasProductType = function(product) {
                return product.ProductTypeID > 0;
            };

            $scope.saveProduct = function () {
                if ($scope.editProductForm.$valid) {
                    //$log.info('Form is valid');
                    $scope.product.CreatedDate = new Date();

                    ProductData.save($scope.product)
                        .$promise
                        .then(function(response) {
                            notificationFactory.success();
                        })
                        .catch(function(response) {
                            notificationFactory.error();
                        });
                }
            };

            $scope.deleteProduct = function (product) {                
                product.$delete(function () {
                    notificationFactory.success();
                });            
                //ProductData.delete(product)
                //    .$promise
                //    .then(function(response) {
                //        $log.info('deletion success', response);
                //    })
                //    .catch(function(response) { $log.info('failure', response) });
            };

            $scope.updateProduct = function (product) {

                if (product != null ) {
                    if (product.ProductID > 0) {
                        product.$update(function () {
                            notificationFactory.success();
                        });
                    } else {
                        product.CreatedDate = new Date();

                        ProductData.save(product)
                        .$promise
                        .then(function (response) {
                            notificationFactory.success();
                        })
                        .catch(function(response) {
                            notificationFactory.error();
                            });
                    }
                }
            };

            $scope.productTypes = ProductTypeData.query();
        }
);