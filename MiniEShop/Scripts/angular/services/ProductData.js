//eshopApp.factory('productData', function ($resource) {
//    return $resource('/api/products/:productId', { id: '@id' },
//    {
//        update: {
//            method: 'PUT' // this method issues a PUT request
//        },
//        getAllProducts: function () {
//            return resource.query();
//        }
//    });

//});

//eshopApp.factory('productData', function ($resource) {
//    var resource = $resource('/api/products/:id', { id: '@id' }, { "getAll": { method: "GET", isArray: true, params: { something: "foo" } } });
//    return {
//        getproduct: function (productId) {
//            console.log('aaaa' + productId);
//            return resource.query({ productId: productId });
//        },
//        save: function (product) {
//            product.id = 999;
//            return resource.save(product);
//        },
//        getAllProducts: function () {
//            return resource.query();
//        }
//    };
  
//});

eshopApp.service('productData', function ($resource) {
    console.log('in delete' );
    return $resource('/api/products/:id', { id: '@ProductID' }, {
        update: {
            method: 'PUT' // this method issues a PUT request
        }
    });

});
//Default function
//get()
//query()
//save()
//remove()
//delete()