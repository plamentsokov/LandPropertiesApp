(function () {
    "use strict";

    var propertiresMock = angular
                            .module("landPropertiesMock",
                                    ["ngMockE2E"]);

    propertiresMock.run(function ($httpBackend) {
        $httpBackend.whenGET(/\.cshtml$/).passThrough();

        var properties = [{
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

        var propertiesUrl = "/api/landProperties";
        //Get All
        $httpBackend.whenGET(propertiesUrl).respond(properties);

        //Get by id
        var editingRegex = new RegExp(propertiesUrl + "/[0-9][0-9]*", '');
        $httpBackend.whenGET(editingRegex).respond(function (method, url, data) {
            var landProperty = { "Id": 0 };
            var parameters = url.split('/');
            var length = parameters.length;
            var id = parameters[length - 1];

            if (id > 0) {
                for (var i = 0; i < properties.length; i++) {
                    if (properties[i].Id == id) {
                        landProperty = properties[i];
                        break;
                    }
                };
            }
            return [200, landProperty, {}];
        });

        //Post property
        $httpBackend.whenPOST(propertiesUrl).respond(function (method, url, data) {
            var landProperty = angular.fromJson(data);

            if (!landProperty.Id) {
                // new landProperty Id
                landProperty.Id = properties[properties.length - 1].Id + 1;
                properties.push(landProperty);
            }
            else {
                // Updated landProperty
                for (var i = 0; i < properties.length; i++) {
                    if (properties[i].Id == landProperty.Id) {
                        properties[i] = landProperty;
                        break;
                    }
                };
            }
            return [200, landProperty, {}];
        });

    });
}());