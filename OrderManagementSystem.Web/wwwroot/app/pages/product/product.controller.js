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
        vm.cartTotal;
        vm.searchInput;

        // Function
        vm.AddToCart = AddToCart;

        activate();

        function activate() {
            vm.cart = cartService.getList();
            vm.cartTotal = 0;
            vm.cart.forEach(element => {
                vm.cartTotal += element.Quantity;
            });

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
            var cart = cartService.getList();
            vm.cartTotal = 0;
            cart.forEach(element => {
                vm.cartTotal += element.Quantity;
            })
        }
    }
})();