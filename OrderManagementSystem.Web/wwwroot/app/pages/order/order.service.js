(function(){
    'use strict';

    angular
        .module('app')
        .service('orderService', orderService)

    orderService.$inject = ['$http'];

    function orderService($http) {
        this.getOrder = getOrder;
        this.addOrder = addOrder;
        this.editOrder = editOrder;

        var headerRequest = {
            headers: { Authorization: `Bearer ${JSON.parse(localStorage.getItem('user')).token}` }
        }

        function getOrder() {
            return $http.get(`api/Orders`, headerRequest)
         }

         function addOrder(discount, orderStautusId) {
             var orderitem = {
                // DateDelivered: new Date(),
                Discount: discount,
                OrderStautusId: orderStautusId,
                // CreatedTime: new Date(),
                // UpdatedTime: new Date()
             }
             return $http.post(`api/Orders`, [orderitem], headerRequest)
         }

         function editOrder(orderItems) {
             return $http.put(`api/Orders`, orderItems, headerRequest)
         }
    }
})();