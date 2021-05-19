(function () {
    'use strict';

    angular
        .module('app')
        .controller('productController', productController)

    productController.$inject = ['$location', 'productService', 'cartService'];

    function productController($location, productService, cartService) {
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

        function AddToCart(productId) {
            alert('Thêm giỏ hàng thành công!');
            cartService.addProduct(productId);
        }
    }
})();