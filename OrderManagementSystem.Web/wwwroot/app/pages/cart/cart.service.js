(function () {
    'use strict';

    angular
        .module('app')
        .service('cartService', cartService)

    cartService.$inject = ['$http'];

    function cartService($http) {
        this.getCart = getCart;
        this.insertCart = insertCart;
        this.updateCart = updateCart;
        this.addProduct = addProduct;
        this.removeProduct = removeProduct;
        this.getTotalPrice = getTotalPrice;
        this.getTotalQuantity = getTotalQuantity;

        this.productList = [];

        /*
        [{
            id: string, //product id
            quantity: number
        }]
        */

        function getCart() {
            return $http.get(
                'api/Carts/' + JSON.parse(localStorage.getItem('user')).id,
                {
                    headers: { Authorization: 'Bearer ' + JSON.parse(localStorage.getItem('user')).token }
                });
        }

        function insertCart(productItem) {
            var cartItem = {
                Id: "",
                UserId: JSON.parse(localStorage.getItem('user')).id,
                ProductId: productItem.id,
                ProductImageUrl: productItem.imageUrl,
                ProductName: productItem.name,
                ProductPrice: productItem.price,
                Quantity: productItem.quantity,
                CreatedTime: new Date(),
                UpdatedTime: new Date().getUTCDate()
            };
            // console.log([cartItem]);
            return $http.post('api/Carts', [cartItem], {
                headers: { Authorization: 'Bearer ' + JSON.parse(localStorage.getItem('user')).token }
            }).then((response) => {
                console.log(response);
            }, (error) => {
                console.log(error);
            })
        }

        function updateCart(cartItem) {
            return $http.put('api/Carts' + cartItem.id, [cartItem] , {
                headers: { Authorization: 'Bearer ' + JSON.parse(localStorage.getItem('user')).token }
            })
        }

        function addProduct(productItem, quantity) {
            this.getCart().then((response) => {
                var cart = response.data.result;
                var cartItem = _.find(cart, x => x.productId == productItem.id);
                if (cartItem) {
                    if (!quantity) {
                        cartItem.quantity + 1;
                    }
                    else {
                        cartItem.quantity = quantity;
                    }
                    this.updateCart(cartItem)
                }
                else {
                    productItem.quantity = 1;
                    this.insertCart(productItem);
                }

            }, (error) => {
                console.log(error);
            })
            // var product = _.find(cart, x => x.id == productId);

            // if (product) product.quantity = quantity ? quantity : product.quantity + 1;
            // else cart.push({ id: productId, quantity: quantity ? quantity : 1 })

            // this.setCart(cart);
        }

        function removeProduct(productId) {
            var cart = getCart();
            cart = _.filter(cart, x => !(x.id.indexOf(productId) > -1));
            this.setCart(cart);
        }

        function getTotalQuantity() {
            var cart = getCart();
            return _.chain(cart).map(x => x.quantity).sum().value();
        }

        function getTotalPrice(carts) {
            return _.chain(carts)
                .map((e) => {
                    return e.quantity * e.productPrice;
                })
                .sum()
                .value();
        }
    }
})();