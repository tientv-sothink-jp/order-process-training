(function(){
    'use strict';

    angular
        .module('app')
        .service('productService', productService)

    productService.$inject = ['$http'];

    function productService($http) {
        this.getProductList = getProductList;
        // this.getProducts = getProducts

        function getProductList() {
            return $http.get(
                'api/Products', 
                { headers: 
                    { Authorization: 'Bearer '+ JSON.parse(localStorage.getItem('user')).token }
                });
        }
        
        // function getProducts(id) {
        //     return $http.get(
        //         `api/Products/${encodeURIComponent(id)}`, 
        //         { headers: 
        //             { Authorization: 'Bearer '+ JSON.parse(localStorage.getItem('user')).token }
        //         });
        //  }
    }
})();