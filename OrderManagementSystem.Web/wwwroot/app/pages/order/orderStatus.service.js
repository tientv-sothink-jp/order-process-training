(function(){
    'use strict';

    angular
        .module('app')
        .service('orderStatusService', orderStatusService)

    orderStatusService.$inject = ['$http'];

    function orderStatusService($http) {
        this.getOrderStatus = getOrderStatus;

        function getOrderStatus() { 
            return $http.get("api/OrderStatus", {
                headers: { Authorization: `Bearer ${JSON.parse(localStorage.getItem('user')).token}` }
            });
        }
    }
})();