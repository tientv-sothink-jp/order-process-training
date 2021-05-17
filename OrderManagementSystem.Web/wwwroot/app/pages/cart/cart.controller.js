(function(){
    'use strict';

    angular
        .module('app')
        .controller('cartController', cartController)

    cartController.$inject = ['$location', 'cartService', 'productService'];

    function cartController($location, cartService, productService) {
        /* jshint validthis:true */
        var vm = this;

        // function
        vm.remove = remove;
        vm.displayTotalPrice = displayTotalPrice;
        vm.updateQuantity = updateQuantity;
        vm.goToCheckoutPage = goToCheckoutPage;

        activate();

        function activate() {
            getCartInfo();
        }

        function displayTotalPrice() {
            return cartService.getTotalPrice(vm.cart);
        }

        function getCartInfo() {
            vm.cart = cartService.getCart();
            productService.getProducts(_.map(vm.cart, x => x.id).join(',')).then((res) => {
                vm.cart = _.chain(res.data.Result)
                    .filter(x => {
                        var product = _.chain(vm.cart).find(c => c.id == x.Id).value();
                        x.quantity = product ? product.quantity : null;
                        return x.quantity ? x.quantity : false;
                    })
                    .value();
            });
        }

        function remove(productId) {
            cartService.removeProduct(productId);
            getCartInfo();
        }

        function goToCheckoutPage() {
            $location.path("/checkout");
        }

        function updateQuantity(item) {
            cartService.addProduct(item.Id, item.quantity);
            getCartInfo();
        }
    }
})();