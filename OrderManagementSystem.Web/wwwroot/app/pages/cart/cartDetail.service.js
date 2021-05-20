(function(){
    'use strict';

    angular
        .module('app')
        .service('cartDetailService', cartDetailService)

    cartDetailService.$inject = ['$http'];

    function cartDetailService($http) {
        this.getCartDetail = getCartDetail;
        this.insertProduct = insertProduct;
        this.updateProduct = updateProduct;
        this.removeProduct = removeProduct;
        this.getTotalPrice = getTotalPrice;
        this.getTotalQuantity = getTotalQuantity;

        function getCartDetail(cartId) {
            return $http.get(
                `api/CartDetail/GetByCartId/${cartId}`,
                {
                    headers: { Authorization: `Bearer ${JSON.parse(localStorage.getItem('user')).token}` }
                });
        }

        function insertProduct(cartId, productId, productPrice, quantity)
        {
            var cartDetailItem = {
                cartId: cartId,
                productId: productId,
                productPrice: productPrice,
                quantity: quantity,
                createdTime: new Date()
            }
            // console.log('cartDetailItem', cartDetailItem);
            return $http.post(`api/CartDetail`, [cartDetailItem], {
                headers: { Authorization: `Bearer ${JSON.parse(localStorage.getItem('user')).token}` }
            })
        }

        function updateProduct(cartDetailId, cartId, productId, productPrice, quantity) {
            var cartDetailItem = {
                cartId: cartId,
                productId: productId,
                productPrice: productPrice,
                quantity: quantity,
                createdTime: new Date()
            }
            return $http.put(`api/CartDetail/${cartDetailId}`,[cartDetailItem], {
                headers: { Authorization: `Bearer ${JSON.parse(localStorage.getItem('user')).token}` }
            })
        }

        function removeProduct(cartDetailId) {
            return $http.delete(`api/CartDetail/${cartDetailId}`, {
                headers: { Authorization: `Bearer ${JSON.parse(localStorage.getItem('user')).token}` }
            })
        }

        function getTotalPrice(carts) {
            return _.chain(carts)
                .map((e) => {
                    return e.quantity * e.productPrice;
                })
                .sum()
                .value();
        }

        function getTotalQuantity(CartDetails) {
            return _.chain(CartDetails).map(x => x.quantity).sum().value();
        }
    }
})();