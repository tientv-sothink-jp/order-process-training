(function(){
    'use strict';

    angular
        .module('app')
        .controller('checkoutController', checkoutController)

    checkoutController.$inject = ['$location', 'checkoutService', 'orderService', 'orderDetailService', 'cartDetailService'];

    function checkoutController($location, checkoutService, orderService, orderDetailService, cartDetailService) {
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
            }).catch((error) => {
                console.log('checkout', error);
            })
         }

         function checkout() {

            checkoutService.checkoutAndOrder(localStorage.getItem('stringCartDetailId')).then(
                (response) => {
                    $location.path('/cart');
                },
                (error) => {
                    console.log(error);
                }
            )
            //  orderService.addOrder(1, 0).then((response)=>
            //  {
            //      vm.order = response.data.result;
            //      return cartDetailService.getCartDetail(JSON.parse(localStorage.getItem('cart')).id);
            //  }).then((response) => {
            //      vm.cartDetails = response.data.result;
            //      return orderDetailService.addOrderDetail(vm.order.id, JSON.parse(localStorage.getItem('cart')).id, vm.cartDetails);
            //  }).then((response) => 
            //  {
            //     $location.path("/order");
            //  })
            //  .catch((error) => 
            //  {
            //      console.log(error)
            //  }
            //  );
             
         }
    }
})();