eshopApp.factory('productData', function ($resource) {
    var resource = $resource('/api/products/:id', { id: '@_id' }, {
                        update: {
                            method: 'PUT' // this method issues a PUT request
                        }
                    });

    return {
        getAllProducts: function() {
             return resource.query();
        }
    }
});

//eshopApp.factory('productData', function ($resource) {
//    //var resource = $resource('/data/product/:id', { id: '@id' }, { "getAll": { method: "GET", isArray: true, params: { something: "foo" } } });
//    //return {
//    //    getproduct: function (productId) {
//    //        return resource.get({ id: productId });
//    //    },
//    //    save: function (product) {
//    //        product.id = 999;
//    //        return resource.save(product);
//    //    },
//    //    getAllProducts: function () {
//    //        return resource.query();
//    //    }
//    //};
  
//});

//eshopApp.service('productData', function ($resource) {
//    return $resource('api/products/:productId', {}, {
//        update: { method: 'PUT' }
//    });
//});