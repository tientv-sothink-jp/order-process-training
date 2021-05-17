(function () {
    'use strict';

    angular
        .module('app')
        .filter('searchIgnoreVietnameseCharacter', searchIgnoreVietnameseCharacter)


    function searchIgnoreVietnameseCharacter(commonService) {

        return searchIgnoreVietnameseCharacterFilter;

        function searchIgnoreVietnameseCharacterFilter(input, value) {

            return input
                .filter(x => commonService.removeVietnameseTones(x.Name).toLowerCase().indexOf(commonService.removeVietnameseTones(value).toLowerCase()) > -1 ||
                    commonService.removeVietnameseTones(x.Sku.toString()).toLowerCase().indexOf(commonService.removeVietnameseTones(value).toLowerCase()) > -1)
        }
    }

}());