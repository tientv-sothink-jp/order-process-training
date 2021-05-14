(function () {
    'use strict';

    angular
        .module('app')
        .controller('productController', productController)

    productController.$inject = ['$location', 'productService', 'cartService'];

    function productController($location, productService, cartService) {
        /* jshint validthis:true */
        var vm = this;
        vm.products;
        vm.cart;

        // Function
        vm.AddToCart = AddToCart;

        activate();

        function activate() {
            vm.cart = cartService.getList();

            productService.getProductList().then(
                (response) => {
                    vm.products = response.data.Result;
                    cartService.productList = response.data.Result;
                },
                (error) => {
                    console.log(error);
                }
            );
        }

        function AddToCart(productId) {
            cartService.add(productId);
        }
        
        function removeFromCart(productId) {
            cartService.remove(productId);
        }
    }
})();