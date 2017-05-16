!function(){"use strict";angular.module("app-books",["simpleControls","ngRoute","ui.select","ngSanitize"]).config(["$routeProvider",function(o){o.when("/",{controller:"booksController",controllerAs:"vm",templateUrl:"/client/views/books/booksView.html"}),o.when("/details/:bookId",{controller:"bookDetailsController",controllerAs:"vm",templateUrl:"/client/views/books/bookDetailsView.html"}),o.when("/create/",{controller:"bookEditorController",controllerAs:"vm",templateUrl:"/client/views/books/bookCreateForm.html"}),o.when("/edit/:bookId",{controller:"bookEditorController",controllerAs:"vm",templateUrl:"/client/views/books/bookEditForm.html"}),o.otherwise({redirectTo:"/"})}]).filter("propsFilter",function(){return function(o,e){var r=[];if(angular.isArray(o)){var t=Object.keys(e);o.forEach(function(o){for(var l=!1,n=0;n<t.length;n++){var i=t[n],s=e[i].toLowerCase();if(-1!==o[i].toString().toLowerCase().indexOf(s)){l=!0;break}}l&&r.push(o)})}else r=o;return r}})}();