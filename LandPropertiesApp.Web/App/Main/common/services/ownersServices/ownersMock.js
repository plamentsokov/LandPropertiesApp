(function () {
    "use strict";

    var ownersMock = angular
                            .module("ownersMock",
                                    ["ngMockE2E"]);

    ownersMock.run(function ($httpBackend) {
        $httpBackend.whenGET(/\.cshtml$/).passThrough();

        var owners = [{
            "Id": 1,
            "FirstName": "Ivan",
            "LastName": "Petrov",
            "OwnerID": 123123213,
            "Address": "Macedonia 21",
            "imageUrl": "http://openclipart.org/image/300px/svg_to_png/58471/garden_cart.png"
        }, {
            "Id": 2,
            "FirstName": "Georgi",
            "LastName": "Georgiev",
            "OwnerID": 898890,
            "Address": "Bukov 45",
            "imageUrl": "http://openclipart.org/image/300px/svg_to_png/26215/Anonymous_Leaf_Rake.png"
        }, {
            "Id": 3,
            "FirstName": "Mitko",
            "LastName": "Kolev",
            "OwnerID": 354345,
            "Address": "Talev 35",
            "imageUrl": "http://openclipart.org/image/300px/svg_to_png/73/rejon_Hammer.png"
        }];

        var ownersUrl = "/api/owners";
        //Get All
        $httpBackend.whenGET(ownersUrl).respond(owners);

        //Get by id
        var editingRegex = new RegExp(ownersUrl + "/[0-9][0-9]*", '');
        $httpBackend.whenGET(editingRegex).respond(function (method, url, data) {
            var owner = { "Id": 0 };
            var parameters = url.split('/');
            var length = parameters.length;
            var id = parameters[length - 1];

            if (id > 0) {
                for (var i = 0; i < owners.length; i++) {
                    if (owners[i].Id == id) {
                        owner = owners[i];
                        break;
                    }
                };
            }
            return [200, owner, {}];
        });

        //Post owner
        $httpBackend.whenPOST(ownersUrl).respond(function (method, url, data) {
            var owner = angular.fromJson(data);

            if (!owner.Id) {
                // new owner Id
                owner.Id = owners[owners.length - 1].Id + 1;
                owners.push(owner);
            }
            else {
                // Updated owner
                for (var i = 0; i < owners.length; i++) {
                    if (owners[i].Id == owner.Id) {
                        owners[i] = owner;
                        break;
                    }
                };
            }
            return [200, owner, {}];
        });

    });
})();