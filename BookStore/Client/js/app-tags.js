// app-books.js
(function () {
    "use strict";
    // Creating the module
    angular.module("app-tags", ["simpleControls", "ngRoute", "ngSanitize"])
        .config(function ($routeProvider) {

            $routeProvider.when("/", {
                controller: "tagsController",
                controllerAs: "vm",
                templateUrl: "/client/views/tags/tagsView.html"
            });
            $routeProvider.otherwise({ redirectTo: "/" });
        });
        

})();