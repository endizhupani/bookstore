//trips-controller.js
(function () {
    "use strict";

    // Getting the existing module
    angular.module("app-bookstore")
        .controller("booksController", booksController)
        .controller("bookDetailsController", bookDetailsController);

    function booksController($http) {
        //the object that is returned by the controller
        var vm = this;
        vm.books = [];        
        vm.errorMessage = "";
        vm.isBusy = true;

        $http.get("/api/books")
            .then(function (response) {
                //Success
                angular.copy(response.data, vm.books);
                
            }, function (error) {
                //Failure
                vm.errorMessage = "Failed to load data " + error;
            })
            .finally(function () {
                vm.isBusy = false;
            });
    }

    function bookDetailsController($http, $routeParams) {
        var vm = this;
        vm.bookId = $routeParams.bookId;
        vm.book = {};
        vm.errorMessage = "";
        vm.isBusy = true;

        $http.get("/api/books/" + vm.bookId)
            .then(function (response) {
                //Success
                angular.copy(response.data, vm.book);

            }, function (error) {
                //Failure
                vm.errorMessage = "Failed to load data " + error;
            })
            .finally(function () {
                vm.isBusy = false;
            });
    }

})();