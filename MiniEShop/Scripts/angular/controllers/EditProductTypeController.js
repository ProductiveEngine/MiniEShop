'use strict';
eshopApp.controller('EditProductTypeController',
        function EditProductTypeController($scope, $stateParams, ProductTypeData, $log) {
            $scope.addMode = false;
            $scope.toggleAddMode = function() {
                $scope.addMode = !$scope.addMode;
            };

            $scope.toggleEditMode = function (productType) {
                if ($scope.allProductTypes != undefined) {
                    $scope.allProductTypes.forEach(function(entry) {

                        if (entry.ProductTypeID === productType.ProductTypeID) {                            
                            entry.EditMode = !productType.EditMode;                            
                        }
                    });
                }                
            };

            $scope.allProductTypes = ProductTypeData.query();

            $scope.saveProductType = function () {
                if ($scope.editProductTypeForm.$valid) {
                    //$log.info('Form is valid');
                    $scope.ProductType.CreatedDate = new Date();

                    ProductTypeData.save($scope.ProductType)
                        .$promise
                        .then(function (response) {
                            //console.log('success', response);                                                        
                        })
                        .catch(function (response) { console.log('failure', response) });
                }
            };

            $scope.deleteProductType = function (ProductType) {
                ProductType.$delete(function () {
                });             
            };

            $scope.updateProductType = function (ProductType) {

                if (ProductType != null) {
                    if (ProductType.ProductTypeID > 0) {
                        ProductType.$update(function () {
                        });
                    } else {
                        ProductType.CreatedDate = new Date();

                        ProductTypeData.save(ProductType)
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