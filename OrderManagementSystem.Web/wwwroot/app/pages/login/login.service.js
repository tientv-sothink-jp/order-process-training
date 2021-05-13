(function(){
    'use strict';

    angular
        .module('app')
        .service('loginService', loginService)

    loginService.$inject = ['$http', '$rootScope'];

    function loginService($http, $rootScope) {
        this.getData = getData;

        function getData(request) {
            return $http.post('api/Users/Login', request);
         }
    }
})();