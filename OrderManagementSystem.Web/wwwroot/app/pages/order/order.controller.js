(function(){
    'use strict';

    angular
        .module('app')
        .controller('orderController', orderController)

    orderController.$inject = ['$location', 'orderService', 'orderStatusService'];

    function orderController($location, orderService, orderStatusService) {
        /* jshint validthis:true */
        var vm = this;
        vm.orders = [];
        vm.orderStatus = [];

        // function
        vm.goToOrderDetailPage = goToOrderDetailPage;

        activate();

        function activate() {
           

            orderStatusService.getOrderStatus().then((response) => {
                vm.orderStatus = response.data.result;
                return orderService.getOrder();
            }).then((response) => {
                    vm.orders = response.data.result;
                    vm.dataSource = _.chain(vm.orders)
                    .map((x) => {
                        var orderStatus = _.find(vm.orderStatus, e => e.id == x.orderStatusId);
                        x.orderStatusName = orderStatus.name;
                        return x;
                    }).value();
                    console.log(vm.dataSource);
            })
            .catch((error) => 
            {
                console.log(error);
            })
         }

         function goToOrderDetailPage(orderId) {
             $location.path(`/orderDetail/${orderId}`)
         }
    }
})();