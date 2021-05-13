(function(){
    'use strict';

    angular
        .module('app')
        .service('productService', productService)

    productService.$inject = ['$http'];

    function productService($http) {
        this.getData = getData;

        function getData() {
            return $http.get('api/Products');
         }
    }
})();