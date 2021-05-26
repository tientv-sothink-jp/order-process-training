(function () {
    'use strict';

    angular
        .module('app')
        .controller('productController', productController)

    productController.$inject = ['$location', 'productService', 'cartService', 'cartDetailService', '$routeParams'];

    function productController($location, productService, cartService, cartDetailService, $routeParams) {
        /* jshint validthis:true */
        var vm = this;
        vm.searchInput;
        vm.products = [];
        vm.pageIndex;
        vm.pageSize;
        vm.totalPage;
        vm.totalPageArray = [];

        // vm.displayOrderQuantity = cartService.getTotalQuantity;

        // Function
        vm.AddToCart = AddToCart;
        vm.loadProductPage = loadProductPage;
        vm.loadPage = loadPage;
        vm.search = search;

        activate();

        function activate() {
            ($routeParams.pageIndex) ? vm.pageIndex = parseInt($routeParams.pageIndex) : vm.pageIndex = 1;
            ($routeParams.keyword) ? vm.searchInput = $routeParams.keyword : vm.searchInput = '';
            ($routeParams.pageSize) ? vm.pageSize = parseInt($routeParams.pageSize) : vm.pageSize = 15;
            productService.getProducts(`/paging?keyword=${decodeURIComponent(vm.searchInput)}&pageIndex=${vm.pageIndex}&pageSize=${vm.pageSize}`).then(
                (response) => {
                    vm.products = response.data.result.source;
                    vm.totalPage = response.data.result.totalPage;
                    vm.loadPage(vm.pageIndex);
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
                    cartService.insertCart().then((response) => {
                        var newCart = response.data.result;
                        cartDetailService.insertProduct(newCart.id, product.id, product.price, 1)
                    })
                } else {
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
                }
            })
        }

        function loadProductPage(page) {
            $location.search({"keyword": vm.searchInput, "pageIndex": page, "pageSize": vm.pageSize});

        }

        function search() {
            $location.search({"keyword": vm.searchInput, "pageIndex": 1, "pageSize": vm.pageSize});
        }

        function loadPage(page) {
            if (page < 1 || page > vm.totalPage)
                return;
            vm.totalPageArray = [];

            if (page < 4) {
                vm.totalPageArray = _.range(1, 6);
                vm.totalPageArray.push('...');
            } else if (page + 3 > vm.totalPage) {
                vm.totalPageArray.push('...');
                _.range(vm.totalPage - 4, vm.totalPage + 1).forEach(x => {
                    vm.totalPageArray.push(x);
                });
            } else {
                vm.totalPageArray.push('...');
                _.range(page - 2, page + 3).forEach(x => {
                    vm.totalPageArray.push(x);
                })
                vm.totalPageArray.push('...');
            }
        }
    }
})();