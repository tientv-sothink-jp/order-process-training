(function(){
    'use strict';

    angular
        .module('app')
        .controller('checkoutController', checkoutController)

    checkoutController.$inject = ['$location'];

    function checkoutController($location) {
        /* jshint validthis:true */
        var vm = this;

        activate();

        function activate() { }
    }
})();