(function(){
    'use strict';

    angular
        .module('app')
        .service('productService', productService)

    productService.$inject = ['$http'];

    function productService($http) {
        this.getProductList = getProductList;
        this.getProducts = getProducts

        var headerRequest = {
            headers: { Authorization: `Bearer ${JSON.parse(localStorage.getItem('user')).token}` }
        }

        function getProductList() {
            return $http.get(
                'api/Products', headerRequest);
        }
        
        function getProducts(id) {
            return $http.get(
                `api/Products/${encodeURIComponent(id)}`, headerRequest);
         }
    }
})();