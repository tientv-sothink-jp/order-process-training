(function(){
    'use strict';

    angular
        .module('app')
        .service('checkoutService', checkoutService)

    checkoutService.$inject = ['$http'];

    function checkoutService($http) {
        this.getUserInfo = getUserInfo;

        function getUserInfo(userId) { 
            return $http.get(`api/Users/${userId}`, {
                headers: { Authorization: `Bearer ${JSON.parse(localStorage.getItem('user')).token}` }
            });
        }
    }
})();