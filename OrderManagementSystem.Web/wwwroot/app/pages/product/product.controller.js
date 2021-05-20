(function () {
    'use strict';

    angular
        .module('app')
        .controller('productController', productController)

    productController.$inject = ['$location', 'productService', 'cartService', 'cartDetailService'];

    function productController($location, productService, cartService, cartDetailService) {
        /* jshint validthis:true */
        var vm = this;
        vm.products = [];
        vm.searchInput = '';

        // vm.displayOrderQuantity = cartService.getTotalQuantity;

        // Function
        vm.AddToCart = AddToCart;

        activate();

        function activate() {
            productService.getProductList().then(
                (response) => {
                    vm.products = response.data.result;
                },
                (error) => {
                    console.log(error);
                }
            );
        }

        function AddToCart(product) {
            alert('Thêm giỏ hàng thành công!');
            cartService.getCart().then((response) => {
                var cart = response.data.result;
                if (!cart) {
                    cartService.insertCart();
                }
                cartDetailService.getCartDetail(cart.id).then((response) => {
                    var cartDetails = response.data.result;
                    var cartDetailItem = _.find(cartDetails, x => x.productId == product.id);
                    if (cartDetailItem) {
                        cartDetailItem.quantity += 1;
                        cartDetailService.updateProduct(cartDetailItem.id, cart.id, product.id, product.price, cartDetailItem.quantity)
                    } else {
                        cartDetailService.insertProduct(cart.id, product.id, product.price, 1)
                    }
                })
            })
        }
    }
})();