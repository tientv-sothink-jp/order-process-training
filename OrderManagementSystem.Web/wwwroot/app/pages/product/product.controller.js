(function () {
    'use strict';

    angular
        .module('app')
        .controller('productController', productController)

    productController.$inject = ['$location', 'productService', 'cartService'];

    function productController($location, productService, cartService) {
        /* jshint validthis:true */
        var vm = this;
        vm.products = [];
        vm.searchInput = '';
        
        vm.displayOrderQuantity = displayOrderQuantity;

        // Function
        vm.AddToCart = AddToCart;

        activate();

        function activate() {
            productService.getProductList().then(
                (response) => {
                    vm.products = response.data.Result;
                },
                (error) => {
                    console.log(error);
                }
            );
        }

        function displayOrderQuantity() {
            return cartService.getTotalQuantity();
        }

        function AddToCart(productId) {
            cartService.addProduct(productId);
        }
    }
})();