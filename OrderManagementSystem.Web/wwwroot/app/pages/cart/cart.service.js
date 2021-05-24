(function () {
    'use strict';

    angular
        .module('app')
        .service('cartService', cartService)

    cartService.$inject = ['$http'];

    function cartService($http) {
        this.getCart = getCart;
        this.insertCart = insertCart;

        this.productList = [];

        var headerRequest = {
            headers: { Authorization: `Bearer ${JSON.parse(localStorage.getItem('user')).token}` }
        }

        function getCart() {
            return $http.get(
                `api/Carts/${JSON.parse(localStorage.getItem('user')).id}`, headerRequest);
        }

        function insertCart() {
            return $http.post(`api/Carts`, [{ userId: JSON.parse(localStorage.getItem('user')).id }], headerRequest)
        }

        // function addProduct(productItem, quantity) {
        //     var product = _.find(cart, x => x.id == productId);

        //     if (product) product.quantity = quantity ? quantity : product.quantity + 1;
        //     else cart.push({ id: productId, quantity: quantity ? quantity : 1 })

        //     this.setCart(cart);
        // }

        // function removeProduct(productId) {
        //     var cart = getCart();
        //     cart = _.filter(cart, x => !(x.id.indexOf(productId) > -1));
        //     this.setCart(cart);
        // }




    }
})();