(function () {
    "use strict";

    angular.module('app').controller("LandPropertiesCtrl", [
        '$scope', LandPropertiesCtrl]);

    function LandPropertiesCtrl($scope) {
        var vm = this;
        vm.properties = [{
            "Id": 1,
            "Area": "Mladost",
            "UPI": 21213123,
            "imageUrl": "http://openclipart.org/image/300px/svg_to_png/58471/garden_cart.png"
        }, {
            "Id": 2,
            "Area": "Drujba",
            "UPI": 5675756,
            "imageUrl": "http://openclipart.org/image/300px/svg_to_png/26215/Anonymous_Leaf_Rake.png"
        }, {
            "Id": 3,
            "Area": "Dianabad",
            "UPI": 434535435,
            "imageUrl": "http://openclipart.org/image/300px/svg_to_png/73/rejon_Hammer.png"
        }];
    }
})();