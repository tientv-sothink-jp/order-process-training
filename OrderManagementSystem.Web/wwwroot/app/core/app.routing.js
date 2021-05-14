(function () {
    'use strict';

    angular.module('app')
        .config(appConfig);

    appConfig.inject = ['$routeProvider', '$locationProvider'];

    function appConfig($routeProvider, $locationProvider) {

        $routeProvider
            .when("/", {
                controller: 'homeController',
                controllerAs: 'vm',
                templateUrl: "../app/pages/home/home.view.html"
            })
            .when("/login", {
                controller: 'loginController',
                controllerAs: 'vm',
                templateUrl: "../app/pages/login/login.view.html"
            })
            .when("/product", {
                controller: 'productController',
                controllerAs: 'vm',
                templateUrl: "../app/pages/product/product.view.html"
            })
            .when("/cart", {
                controller: 'cartController',
                controllerAs: 'vm',
                templateUrl: "../app/pages/cart/cart.view.html"
            });
    }
})();