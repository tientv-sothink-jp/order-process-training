(function(){
    'use strict';

    angular
        .module('app')
        .controller('orderDetailController', orderDetailController)

    orderDetailController.$inject = ['$location', '$routeParams', 'orderDetailService', 'productService'];

    function orderDetailController($location, $routeParams, orderDetailService, productService) {
        /* jshint validthis:true */
        var vm = this;
        vm.orderDetails;

        activate();

        function activate() { 
            orderDetailService.getOrderDetail($routeParams.id).then((response) => {
                vm.orderDetails = response.data.result;
                return productService.getProducts(vm.orderDetails.map(x => x.productId));
            })
            .then((response) => {
                vm.products = response.data.result;
                vm.dataSource = _.chain(vm.orderDetails)
                .map((x) => {
                    var product = _.find(vm.products, e => e.id == x.productId);
                    x.productId = product.id;
                    x.productImageUrl = product.imageUrl;
                    x.productName = product.name;
                    x.productOrigin = product.origin;
                    x.productSku = product.sku;
                    return x;
                }).value();
            })
            .catch((error) => 
            {
                console.log(error);
            })
        }
    }
})();