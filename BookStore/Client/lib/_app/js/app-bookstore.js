!function(){"use strict";angular.module("app-bookstore",["simpleControls","ngRoute"]).config(["$routeProvider",function(o){o.when("/",{controller:"booksController",controllerAs:"vm",templateUrl:"/views/booksView.html"}),o.otherwise({redirectTo:"/"})}])}();