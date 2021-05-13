(function(){
    'use strict';

    angular
        .module('app')
        .controller('homeController', homeController)

    homeController.$inject = ['$location'];

    function homeController($location) {
        /* jshint validthis:true */
        var vm = this;

        vm.title = "This is home page";

        activate();

        function activate() { }
    }
})();