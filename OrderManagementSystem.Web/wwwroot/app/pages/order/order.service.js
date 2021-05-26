(function(){
    'use strict';

    angular
        .module('app')
        .service('orderService', orderService)

    orderService.$inject = ['$http'];

    function orderService($http) {
        this.getOrders = getOrders;
        this.addOrder = addOrder;
        this.updateOrder = updateOrder;

        var headerRequest = {
            headers: { Authorization: `Bearer ${JSON.parse(localStorage.getItem('user')).token}` }
        }

        function getOrders() {
            return $http.get(`api/Orders`, headerRequest)
         }

         function addOrder(discount, orderStautusId) {
             var orderitem = {
                Discount: discount,
                OrderStautusId: orderStautusId,
             }
             return $http.post(`api/Orders`, [orderitem], headerRequest)
         }

        function updateOrder(orderItems) {
             return $http.put(`api/Orders/${orderItems.id}`, [orderItems], headerRequest)
         }
    }
})();