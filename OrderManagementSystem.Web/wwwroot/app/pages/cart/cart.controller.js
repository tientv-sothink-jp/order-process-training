(function () {
    'use strict';

    angular
        .module('app')
        .controller('cartController', cartController)

    cartController.$inject = ['$location', 'cartService', 'productService', 'cartDetailService'];

    function cartController($location, cartService, productService, cartDetailService) {
        /* jshint validthis:true */
        var vm = this;
        vm.dataSource;
        vm.selected;

        // function
        vm.remove = remove;
        vm.displayTotalPrice = displayTotalPrice;
        vm.getCartInfo = getCartInfo;
        vm.updateQuantity = updateQuantity;
        vm.goToCheckoutPage = goToCheckoutPage;
        vm.toggleSelection = toggleSelection;
        vm.existSelection = existSelection;

        activate();

        function activate() {
            getCartInfo();
            vm.selected = [];
        }

        function displayTotalPrice() {
            return cartDetailService.getTotalPrice(vm.dataSource);
        }

        function getCartInfo() {
            cartService.getCart()
                .then((response) => {
                    vm.cart = response.data.result;
                    // console.log('cart', vm.cart);
                    localStorage.setItem('cart', JSON.stringify(vm.cart));
                    return cartDetailService.getCartDetail(vm.cart.id);
                })
                .then((response) => {
                    vm.cartDetail = response.data.result;
                    // console.log('cartDetail', vm.cartDetail);
                    return productService.getProducts(vm.cartDetail.map(x => x.productId));
                })
                .then((response) => {
                    vm.products = response.data.result;
                    // console.log('product', vm.products);
                    vm.dataSource = _.chain(vm.cartDetail)
                        .map((x) => {
                            var product = _.find(vm.products, e => e.id == x.productId);
                            x.productId = product.id;
                            x.productImageUrl = product.imageUrl;
                            x.productName = product.name;
                            x.productOrigin = product.origin;
                            x.productPrice = product.price;
                            x.productSku = product.sku;
                            return x;
                        })
                        .value();
                })
                .catch((error) => {
                    console.log('Runtime error at here', error);
                })
        }

        function remove(cartDetailId) {
            cartDetailService.removeProduct(cartDetailId);
            vm.getCartInfo();
        }

        function goToCheckoutPage() {vm.selected.toString();
            var stringCartDetail = '';
            vm.selected.map((x) => {
                stringCartDetail += x.id + ',';
            });
            localStorage.setItem('stringCartDetailId', stringCartDetail);
            $location.path("/checkout");
        }

        function updateQuantity(cartDetailItem) {
            cartDetailService.updateProduct(cartDetailItem.id, vm.cart.id, cartDetailItem.productId, cartDetailItem.productPrice, cartDetailItem.quantity)
            vm.getCartInfo();
        }

        function toggleSelection(cartDetailItem) {
            var index = vm.selected.indexOf(cartDetailItem);
            if (index > -1) {
                vm.selected.splice(index, 1);
            } else {
                vm.selected.push(cartDetailItem);
            }
            
        }

        function existSelection(cartDetailItem) {
            return vm.selected.indexOf(cartDetailItem) > -1;
        }
    }
})();