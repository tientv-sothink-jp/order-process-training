(function(){
    'use strict';

    angular
        .module('app')
        .controller('cartController', cartController)

    cartController.$inject = ['$location', 'cartService'];

    function cartController($location, cartService) {
        /* jshint validthis:true */
        var vm = this;
        vm.cart;
        vm.totalPrice;

        // function
        vm.remove = remove;
        vm.updateTotalPrice = updateTotalPrice;
        vm.goToCheckoutPage = goToCheckoutPage;

        activate();

        function activate() {
            vm.cart = cartService.getList();
            vm.totalPrice = cartService.getPriceTotal(vm.cart);
        }

        function remove(productId) {
            cartService.remove(productId);
            vm.totalPrice = cartService.getPriceTotal(vm.cart);
        }

        function updateTotalPrice(item) {
            if(item.Quantity == 0)
            {
                cartService.remove(item.Id);
                vm.totalPrice = cartService.getPriceTotal(vm.cart);
            }
            vm.totalPrice = cartService.getPriceTotal(vm.cart);
            cartService.update(vm.cart);
        }

        function goToCheckoutPage() {
            $location.path("/checkout");
        }
    }
})();