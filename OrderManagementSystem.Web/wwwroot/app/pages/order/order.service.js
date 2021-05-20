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

        function getOrder() {
            return $http.get(`api/Orders`, {
                headers: { Authorization: `Bearer ${JSON.parse(localStorage.getItem('user')).token}` }
            })
         }

         function addOrder(discount, orderStautusID) {
             var orderitem = {
                DateDelivered: new Date(),
                Discount: discount,
                OrderStautusID: orderStautusID,
                CreatedTime: new Date(),
                UpdatedTime: new Date()
             }
             return $http.post(`api/Orders`, [orderitem], {
                headers: { Authorization: `Bearer ${JSON.parse(localStorage.getItem('user')).token}` }
             })
         }

         function editOrder(orderItems) {
             return $http.put(`api/Orders`, orderItems, {
                headers: { Authorization: `Bearer ${JSON.parse(localStorage.getItem('user')).token}` }
             })
         }
    }
})();