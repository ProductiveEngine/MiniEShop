'use strict';

eshopApp.controller('ProductController',
    function ProductController($scope, productData) {
        $scope.sortorder = 'productName';
        $scope.allProducts = productData.query();        
        $scope.saveProduct = function (product, editProductForm) {
            if (editProductForm.$valid) {
                productData.save(product)
                    .$promise
                    .then(function (response) { console.log('success', response) })
                    .catch(function (response) { console.log('failure', response) });
            }
        };

        $scope.cancelProduct = function () {
            
        }
        //productData.getProduct()
        //    .$promise
        //    .then(function (product) { $scope.product = product; })
        //    .catch(function (response) { console.log(response); }
        //);                
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


