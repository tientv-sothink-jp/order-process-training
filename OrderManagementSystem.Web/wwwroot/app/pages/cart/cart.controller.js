(function(){
    'use strict';

    angular
        .module('app')
        .controller('cartController', cartController)

    cartController.$inject = ['$location', 'cartService', 'productService'];

    function cartController($location, cartService) {
        /* jshint validthis:true */
        var vm = this;

        // function
        // vm.remove = remove;
        vm.displayTotalPrice = displayTotalPrice;
        // vm.updateQuantity = updateQuantity;
        // vm.goToCheckoutPage = goToCheckoutPage;

        activate();

        function activate() {
            getCartInfo();
        }

        function displayTotalPrice() {
            return cartService.getTotalPrice(vm.cart);
        }

        function getCartInfo() {
            cartService.getCart().then((response) => {
                vm.cart = response.data.result;
            }, (error) => {
                console.log(error);
            })
        }

        // function remove(productId) {
        //     cartService.removeProduct(productId);
        //     getCartInfo();
        // }

        // function goToCheckoutPage() {
        //     $location.path("/checkout");
        // }

        // function updateQuantity(item) {
        //     cartService.addProduct(item.id, item.quantity);
        //     getCartInfo();
        // }
    }
})();