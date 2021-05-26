(function () {
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
        vm.selectedStatus;
        vm.changeOrderStatus = changeOrderStatus;

        // function
        vm.goToOrderDetailPage = goToOrderDetailPage;

        activate();

        function activate() {
            orderService.getOrders().then(
                (response) => {
                    vm.orders = response.data.result;
                }
            )

            orderStatusService.getOrderStatus().then(
                (response) => {
                    vm.orderStatus = response.data.result;
                }
            )
        }

        function changeOrderStatus(item) {
            orderService.updateOrder(item).then(
                (response) => {
                    Notification.requestPermission().then(() => {
                        var notification = new Notification('Thay đỗi trạng thái đơn hàng thành công');
                    });
                },
                (error) => {
                    console.log(error);
                }
            )
        }

        function goToOrderDetailPage(orderId) {
            $location.path(`/orderDetail/${orderId}`)
        }
    }
})();