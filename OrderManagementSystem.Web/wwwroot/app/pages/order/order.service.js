(function(){
    'use strict';

    angular
        .module('app')
        .service('orderService', orderService)

    orderService.$inject = ['$http'];

    function orderService($http) {
        this.getData = getData;

        function getData() { }
    }
})();