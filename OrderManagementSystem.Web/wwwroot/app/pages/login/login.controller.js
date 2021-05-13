(function () {
    'use strict';

    angular
        .module('app')
        .controller('loginController', loginController)

    loginController.$inject = ['$location', 'loginService'];

    function loginController($location, loginService) {
        /* jshint validthis:true */
        var vm = this;
        vm.showFlagLogin;
        vm.loginNotification;

        // function
        vm.loginFunction = loginFunction;

        activate();

        function activate() {
            vm.username = "user001",
            vm.password = "123"
            vm.showFlagLogin = false;
        }

        function loginFunction() {
            loginService.getData(vm).then(
                (response) => {
                    if(response.data.ErrorCode == 200)
                    {
                        localStorage.setItem('user', JSON.stringify(response.data.Result));
                        $location.path('/');
                    }
                    else 
                    {
                        console.log('abc')
                        vm.showFlagLogin = true;
                        vm.loginNotification = "Đăng nhập thất bại, vui lòng kiểm tra lại tên đang nhập và mật khẩu";
                    }
                },
                (error) => {
                    vm.showFlagLogin = true;
                    vm.loginNotification = "Đăng nhập thất bại, vui lòng kiểm tra lại tên đang nhập và mật khẩu";
                    console.log(error)
                }
            );
        }
    }
})();