'use strict';
eshopApp.controller('EditProductTypeController',
        function EditProductTypeController($scope, $stateParams, ProductTypeData, $log, notificationFactory) {
            // PRIVATE FUNCTIONS 
            //-----------------------------------------------
            var requestSuccess = function () {                
                notificationFactory.success();
            }

            var isDirty = function (productType) {
                return productType.Name != productType.ServerName;
            }
            //-----------------------------------------------
            $scope.newItem = { Name: '' };

            $scope.addMode = false;
            $scope.toggleAddMode = function() {
                $scope.addMode = !$scope.addMode;
                $scope.newItem.Name = '';
            };

            $scope.toggleEditMode = function (productType) {

                if ($scope.allProductTypes != undefined) {
                    productType.EditMode = !productType.EditMode;

                    if (!productType.EditMode) {
                        productType.Name = productType.ServerName;
                    } else {
                        productType.ServerName = productType.Name;

                        $scope.allProductTypes.forEach(function (entry) {
                            if (productType.ProductTypeID != entry.ProductTypeID && entry.EditMode) {
                                entry.Name = entry.ServerName;
                                entry.EditMode = false;
                            }                                
                        });      
                    }                    
                }                
            };

            $scope.allProductTypes = ProductTypeData.query();

            $scope.saveProductType = function () {                
                if ($scope.addForm.$valid) {

                    $scope.newItem.CreatedDate = new Date();

                    ProductTypeData.save($scope.newItem)
                        .$promise
                        .then(function (response) {
                            $scope.allProductTypes.unshift(response);
                            $scope.toggleAddMode();
                            requestSuccess();
                        })
                        .catch(function (response) { console.log('failure', response) });
                }
            };

            $scope.deleteProductType = function (productType) {                
                productType.$delete(function () {
                    var index = $scope.allProductTypes.indexOf(productType);
                    $scope.allProductTypes.splice(index, 1);
                    
                });             
            };

            $scope.updateProductType = function (form, productType) {
                
                if (form != undefined && form.$valid && productType != null) {
                    productType.EditMode = false;

                    if (productType.ProductTypeID > 0 && isDirty(productType)) {
                        productType.$update(function () {
                            requestSuccess();
                        });

                    } else {
                        productType.CreatedDate = new Date();

                        ProductTypeData.save(productType)
                        .$promise
                        .then(function (response) {
                            requestSuccess();
                        })
                        .catch(function(response) {
                            notificationFactory.error(response);
                            });
                    }
                }
            };            
        }
);