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

        // function
        vm.remove = remove;

        activate();

        function activate() {
            vm.cart = cartService.getList();
        }

        function remove(productId) {
            cartService.remove(productId);
        }
    }
})();