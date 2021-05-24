(function(){
    'use strict';

    angular
        .module('app')
        .service('checkoutService', checkoutService)

    checkoutService.$inject = ['$http'];

    function checkoutService($http) {

        this.getUserInfo = getUserInfo;
        this.checkoutAndOrder = checkoutAndOrder;

        var headerRequest = {
            headers: { Authorization: `Bearer ${JSON.parse(localStorage.getItem('user')).token}` }
        }

        function getUserInfo(userId) { 
            return $http.get(`api/Users/${userId}`, headerRequest);
        }

        function checkoutAndOrder(stringCartDetailId) {
            return $http.post(`api/Carts/Order/${stringCartDetailId}`, {}, headerRequest);
        }
    }
})();