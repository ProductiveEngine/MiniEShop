'use strict';
eshopApp.controller('EditProductController',
        function EditProductController($scope, $stateParams, ProductData, $log) {

            $scope.productTypes = [
                { id: 1, name: "Software" },
                { id: 2, name: "Hardware" },
                { id: 3, name: "Console" },
                { id: 4, name: "Mobile" }
            ];
            $scope.product = ProductData.get({
                id: ($stateParams.id === undefined) ? 0 : $stateParams.id
            });            

            $scope.saveProduct = function () {
                if ($scope.editProductForm.$valid) {
                    //$log.info('Form is valid');
                    $scope.product.CreatedDate = new Date();

                    ProductData.save($scope.product)
                        .$promise
                        .then(function(response) {
                            //console.log('success', response);                                                        
                        })
                        .catch(function (response) { console.log('failure', response) });
                }
            };

            $scope.deleteProduct = function (product) {                
                product.$delete(function () {                       
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
                        product.$update(function() {
                        });
                    } else {
                        product.CreatedDate = new Date();

                        ProductData.save(product)
                        .$promise
                        .then(function (response) {
                            //console.log('success', response);                                                        
                        })
                        .catch(function (response) { console.log('failure', response) });
                    }
                }
            };

        }
);