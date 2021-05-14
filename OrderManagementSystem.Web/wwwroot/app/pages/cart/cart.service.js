(function () {
    'use strict';

    angular
        .module('app')
        .service('cartService', cartService)

    cartService.$inject = ['$http'];

    function cartService($http) {
        this.getList = getList;
        this.add = add;
        this.remove = remove;

        this.productList = [];
        this.cart;

        function getList() {
            this.cart = JSON.parse(localStorage.getItem('cart'));

            if (!this.cart) {
                return this.cart = [];
            }

            return this.cart;
        }

        function add(productId) {
            this.cart = JSON.parse(localStorage.getItem('cart'));
            if (!this.cart) {
                this.cart == [];
            }
            var product = _.find(this.productList, ['Id', productId]);
            var cartItem = _.find(this.cart, ['Id', productId]);

            if (!this.cart) {
                this.cart = [];
            }

            if (cartItem) {
                cartItem.Quantity++;
            }
            else {
                product.Quantity = 1;
                this.cart.push(product);
            }
            localStorage.setItem('cart', JSON.stringify(this.cart));
            console.log(this.cart);
        }

        function remove(productId) {
            var index = this.cart.findIndex(function(item){
                return item.Id == productId;
            })
            if(index !== -1)
            {
                this.cart.splice(index, 1);
                localStorage.setItem('cart', JSON.stringify(this.cart));
            }
            console.log(this.cart)
        }
    }
})();