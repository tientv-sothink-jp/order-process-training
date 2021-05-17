(function(){
    'use strict';

    angular
        .module('app')
        .service('loginService', loginService)

    loginService.$inject = ['$http', '$rootScope'];

    function loginService($http, $rootScope) {
        this.login = login;

        function login(request) {
            return $http.post('api/Users/Login', request);
         }
    }
})();