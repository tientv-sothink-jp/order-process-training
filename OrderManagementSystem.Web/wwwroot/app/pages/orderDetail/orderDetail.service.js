(function(){
    'use strict';

    angular
        .module('app')
        .service('orderDetailService', orderDetailService)

    orderDetailService.$inject = ['$http'];

    function orderDetailService($http) {
        this.getOrderDetail = getOrderDetail;
        this.addOrderDetail = addOrderDetail;

        function getOrderDetail(orderId) {
            return $http.get(`api/OrderDetails/${orderId}`, {
                headers: { Authorization: `Bearer ${JSON.parse(localStorage.getItem('user')).token}` }
            })
         }

         function addOrderDetail(orderId, cartId, cartDetails) {
            var orderDetailItems = _.chain(cartDetails).map((x) => {
                x.OrderId = orderId
                return x;
            }).value();
            return $http.post(`api/OrderDetails/${cartId}`, orderDetailItems,{
                headers: { Authorization: `Bearer ${JSON.parse(localStorage.getItem('user')).token}` }
            })
         }
    }
})();