(function(){
    'use strict';

    angular
        .module('app')
        .service('productService', productService)

    productService.$inject = ['$http'];

    function productService($http) {
        this.getProductList = getProductList;

        function getProductList() {
            return $http.get(
                'api/Products', 
                { headers: 
                    { Authorization: 'Bearer '+ JSON.parse(localStorage.getItem('user')).Token }
                });
         }
    }
})();