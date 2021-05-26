(function(){
    'use strict';

    angular
        .module('app')
        .service('productService', productService)

    productService.$inject = ['$http'];

    function productService($http) {
        // this.getProductList = getProductList;
        this.getProducts = getProducts;
        this.getProductById = getProductById;
        // this.searchProduct = searchProduct;

        var headerRequest = {
            headers: { Authorization: `Bearer ${JSON.parse(localStorage.getItem('user')).token}` }
        }

        function getProducts(query) {
            return $http.get(
                `api/Products${query}`, headerRequest);
        }

        // getProducts();
        // getProducts(`/${id}`);
        // getProducts(`/pagin??keyword=${keyword}&pageIndex=${pageIndex}&pageSize=${pageSize}`);
        
        function getProductById(id) {
            return $http.get(
                `api/Products/${encodeURIComponent(id)}`, headerRequest);
         }

        //  function searchProduct(keyword, pageIndex, pageSize) {
        //      return $http.get(`api/Products/Paging?keyword=${keyword}&pageIndex=${pageIndex}&pageSize=${pageSize}`, headerRequest);
        //  }
    }
})();