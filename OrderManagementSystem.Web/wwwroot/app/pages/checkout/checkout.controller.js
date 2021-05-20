(function(){
    'use strict';

    angular
        .module('app')
        .controller('checkoutController', checkoutController)

    checkoutController.$inject = ['$location', 'checkoutService', 'orderService', 'orderDetailService'];

    function checkoutController($location, checkoutService, orderService, orderDetailService) {
        /* jshint validthis:true */
        var vm = this;
        vm.userInfo;

        // function
        vm.checkout = checkout;

        activate();

        function activate() {
            checkoutService.getUserInfo(JSON.parse(localStorage.getItem('user')).id).then((response) => 
            {
                vm.userInfo = response.data.result;
                console.log(vm.userInfo);
            }).catch((error) => {
                console.log('checkout', error);
            })
         }

         function checkout() {

             orderService.addOrder().then((response)=>
             {
                 console.log(response);
             }, (error)=> {
                 console.log(error);
             });
             $location.path("/order");
         }
    }
})();