(function(){
    'use strict';

    angular
        .module('app')
        .filter('pagination', pagination)

    function pagination(){

        return paginationFilterFilter;

        function paginationFilterFilter(){

            return function (data, start) {
                return data.slice(start);
            }
        }
    }

}());