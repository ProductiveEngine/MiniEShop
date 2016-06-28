'use strict';

eshopApp.controller('ProductController',
    function ProductController($scope, $state, ProductData) {
        $scope.sortorder = 'productName';
        $scope.allProducts = ProductData.query();
        $scope.refreshProductsList = function ()
        {
            $scope.allProducts = ProductData.query();
            
        };
        $scope.$watch('liveSearch', function () {
            $scope.allProducts = ProductData.query();
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

//function RouteCtrl($route) {

//    var self = this;

//    $route.when('/products', { template: 'tpl/welcome.html' });

//    $route.when('/products/:productId', { template: 'tpl/product-details.html', controller: ProductDetailCtrl });

//    $route.otherwise({ redirectTo: '/products' });

//    $route.onChange(function () {
//        self.params = $route.current.params;
//    });

//    $route.parent(this);

//    this.addProduct = function () {
//        window.location = "#/products/add";
//    };

//}

//function ProductListCtrl(Product) {

//    this.products = Product.query();

//}

//function ProductDetailCtrl(Product) {

//    this.product = Product.get({ productId: this.params.productId });


//    this.saveProduct = function () {
//        if (this.product.id > 0)
//            this.product.$update({ productId: this.product.id });
//        else
//            this.product.$save();
//        window.location = "#/products";
//    }

//    this.deleteProduct = function () {
//        this.product.$delete({ productId: this.product.id }, function () {
//            alert('Product ' + product.name + ' deleted')
//            window.location = "#/products";
//        });
//    }

//}


