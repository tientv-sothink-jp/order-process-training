(function(){
    'use strict';

    angular
        .module('app')
        .service('checkoutService', checkoutService)

    checkoutService.$inject = ['$http'];

    function checkoutService($http) {
        this.getData = getData;

        function getData() { }
    }
})();