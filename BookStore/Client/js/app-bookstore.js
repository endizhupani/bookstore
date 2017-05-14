// app-bookstore.js
(function () {
    "use strict";
    // Creating the module
    angular.module("app-bookstore", ["simpleControls","ngRoute"])
        .config(function ($routeProvider) {

            $routeProvider.when("/", {
                controller: "booksController",
                controllerAs: "vm",
                templateUrl: "/client/views/booksView.html"
            });
            $routeProvider.when("/details/:bookId",
            {
                controller: "bookDetailsController",
                controllerAs: "vm",
                templateUrl: "/client/views/bookDetailsView.html"
            });
            $routeProvider.otherwise({ redirectTo: "/" });

        });

})();