(function () {
    'use strict';

    angular
        .module('app')
        .service('cartService', cartService)

    cartService.$inject = ['$http'];

    function cartService($http) {
        this.getCart = getCart;
        this.setCart = setCart;
        this.addProduct = addProduct;
        this.removeProduct = removeProduct;
        this.getTotalPrice = getTotalPrice;
        this.getTotalQuantity = getTotalQuantity;

        this.productList = [];

        /*
        [{
            id: string, //product id
            quantity: number
        }]
        */

        function getCart() {
            return JSON.parse(localStorage.getItem('cart')) || [];
        }

        function setCart(cart) {
            localStorage.setItem('cart', JSON.stringify(cart));
        }

        function addProduct(productId, quantity) {
            var cart = getCart();

            var product = _.find(cart, x => x.id == productId);

            if (product) product.quantity = quantity ? quantity : 1;
            else cart.push({ id: productId, quantity: quantity ? quantity : 1 })

            this.setCart(cart);
        }

        function removeProduct(productId) {
            var cart = getCart();
            cart = _.filter(cart, x => !(x.id.indexOf(productId) > -1));
            this.setCart(cart);
        }

        function getTotalQuantity() {
            var cart = getCart();

            return _.chain(cart).map(x => x.quantity).sum().value();
        }

        function getTotalPrice(productList) {
            return _.chain(productList)
                .map((e) => {
                    return e.quantity * e.Price;
                })
                .sum()
                .value();
        }
    }
})();