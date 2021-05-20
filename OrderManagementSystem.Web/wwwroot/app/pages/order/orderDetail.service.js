(function(){
    'use strict';

    angular
        .module('app')
        .service('orderDetailService', orderDetailService)

    orderDetailService.$inject = ['$http'];

    function orderDetailService($http) {
        this.getOrderDetail = getOrderDetail;
        this.addOrderDetail = addOrderDetail;

        function getOrderDetail() {
            return $http.get(`api/OrderDetails`, {
                headers: { Authorization: `Bearer ${JSON.parse(localStorage.getItem('user')).token}` }
            })
         }

         function addOrderDetail(orderDetailItems) {
            return $http.post(`api/OrderDetails`, orderDetailItems,{
                headers: { Authorization: `Bearer ${JSON.parse(localStorage.getItem('user')).token}` }
            })
         }
    }
})();