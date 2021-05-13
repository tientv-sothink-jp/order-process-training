(function(){
    'use strict';

    angular
        .module('app')
        .controller('productController', productController)

    productController.$inject = ['$location', 'productService'];

    function productController($location, productService) {
        /* jshint validthis:true */
        var vm = this;
        vm.products;

        activate();

        function activate() {
            productService.getData().then(
                (response) => {
                    vm.products = response.data;
                },
                (error) => {
                    console.log(errror);
                }
            );
         }
    }
})();   