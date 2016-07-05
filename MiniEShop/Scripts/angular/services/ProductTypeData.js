eshopApp.service('ProductTypeData', function ($resource) {
    return $resource('/api/producttypes/:id', { id: '@ProductTypeID' }, {
        update: {
            method: 'PUT' // this method issues a PUT request
        }
    });

});