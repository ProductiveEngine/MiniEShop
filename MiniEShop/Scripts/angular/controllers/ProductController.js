'use strict';

eshopApp.controller('ProductController',
    function ProductController($scope, $state, ProductData, $http) {
        $scope.sortorder = 'productName';
        $scope.allProducts = ProductData.query();
        $scope.refreshProductsList = function ()
        {
            $scope.allProducts = ProductData.query();
            
        };
        $scope.$watch('liveSearch', function () {            

            if (!($scope.liveSearch == undefined || $scope.liveSearch === "")) {
                // Simple GET request example:
                $http({
                        method: 'GET',
                        url: '/api/products/getProducts/filtered/' + $scope.liveSearch
                    })
                    .then(function successCallback(response) {
                            $scope.allProducts = response.data;
                        },
                        function errorCallback(response) {
                            // called asynchronously if an error occurs
                            // or server returns response with an error status.
                        });
            } else {
                $scope.allProducts = ProductData.query();
            }                        
        });
        $scope.newProduct = function () {                      
            $state.go('productEdit', {id: 0});
        }

        //$scope.$watch(function () { return ProductData.query(); },
        //    function(value) {
        //        $scope.allProducts = value;
        //    });
    }
);

