!function(){"use strict";function o(o){function t(t){var s=n.books[t];confirm("Are you sure you want to delete "+s.title+"?")?o.delete("/api/books/"+s.bookId).then(function(){n.books.splice(t,1),n.message="Book deleted sucessfully",n.emptyMessage=e},function(o){n.errorMessage="Failed to delete book"}).finally(function(){n.isBusy=!1}):n.isBusy=!1}function e(){n.message=""}var n=this;n.books=[],n.errorMessage="",n.message="",n.isBusy=!0,n.deleteBook=t,o.get("/api/books").then(function(o){angular.copy(o.data,n.books),n.books.forEach(function(o){o.description.length>50&&(o.description=o.description.substr(0,50)+"...")})},function(o){n.errorMessage="Failed to load data "+o}).finally(function(){n.isBusy=!1})}function t(o,t){var e=this;e.bookId=t.bookId,e.book={},e.errorMessage="",e.isBusy=!0,o.get("/api/books/"+e.bookId).then(function(o){angular.copy(o.data,e.book)},function(o){e.errorMessage="Failed to load data "+o}).finally(function(){e.isBusy=!1})}function e(o,t,e){function n(){r.isBusy=!0,o.post("/api/books",r.book).then(function(){e.location.href="#!/"},function(){r.errorMessage="Failed to add book."}).finally(function(){r.isBusy=!1})}function s(){r.isBusy=!0,o.put("/api/books",r.book).then(function(){e.location.href="#!/"},function(){r.errorMessage="Failed to update book."}).finally(function(){r.isBusy=!1})}function a(o,t){o.hasOwnProperty("isTag")&&(delete o.isTag,r.tags.push(o))}function i(o){return{name:o}}var r=this;r.isBusy=!0,r.book={},r.errorMessage="",r.tags=[],r.tagTransform=i,r.addTag=a,o.get("/api/tags/").then(function(o){angular.copy(o.data,r.tags)},function(o){r.errorMessage="Failed to get tags "+o}),$(".datepicker").datepicker({showOtherMonths:!1,selectOtherMonths:!1}),isNaN(t.bookId)?(r.addBook=n,r.title="Create a new book",r.isBusy=!1):(r.updateBook=s,o.get("/api/books/"+t.bookId).then(function(o){angular.copy(o.data,r.book)},function(o){r.errorMessage="Failed to load data "+o}).finally(function(){r.isBusy=!1}))}o.$inject=["$http"],t.$inject=["$http","$routeParams"],e.$inject=["$http","$routeParams","$window"],angular.module("app-books").controller("booksController",o).controller("bookDetailsController",t).controller("bookEditorController",e)}();