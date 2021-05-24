(function(){
    'use strict';

    angular
        .module('app')
        .service('orderStatusService', orderStatusService)

    orderStatusService.$inject = ['$http'];

    function orderStatusService($http) {
        this.getOrderStatus = getOrderStatus;

        var headerRequest = {
            headers: { Authorization: `Bearer ${JSON.parse(localStorage.getItem('user')).token}` }
        }

        function getOrderStatus() { 
            return $http.get("api/OrderStatus", headerRequest);
        }
    }
})();