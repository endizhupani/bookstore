//books-controller.js
(function () {
    "use strict";

    // Getting the existing module
    angular.module("app-books")
        .controller("booksController", booksController)
        .controller("bookDetailsController", bookDetailsController)
        .controller("bookEditorController", bookEditorController);

    function booksController($http) {
        //the object that is returned by the controller
        var vm = this;
        vm.books = [];
        vm.errorMessage = "";
        vm.message = "";
        vm.isBusy = true;
        vm.deleteBook = deleteBook;
        $http.get("/api/books")
            .then(function (response) {
                //Success
                angular.copy(response.data, vm.books);
                vm.books.forEach(function (item) {
                    if (item.description.length > 50) {
                        item.description = item.description.substr(0, 50) + '...';
                    }
                });
            }, function (error) {
                //Failure
                vm.errorMessage = "Failed to load data " + error;
            })
            .finally(function () {
                vm.isBusy = false;
            });

        function deleteBook(index) {

            var bookToDelete = vm.books[index];
            if (confirm('Are you sure you want to delete ' + bookToDelete.title + '?')) {
                $http.delete('/api/books/' + bookToDelete.bookId)
                    .then(function () {
                            vm.books.splice(index, 1);
                            vm.message = "Book deleted sucessfully";
                            vm.emptyMessage = emptyMessage;
                    },
                    function (error) {
                        vm.errorMessage = "Failed to delete book";
                    })
                    .finally(function () {
                        vm.isBusy = false;
                    });
            } else {
                vm.isBusy = false;
            }
        }

        function emptyMessage() {
            vm.message = "";
        }

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

    function bookEditorController($http, $routeParams, $window) {
        var vm = this;
        vm.isBusy = true;
        vm.book = {};
        vm.errorMessage = "";
        vm.tags = [];

        
        vm.tagTransform = tagTransform;
        vm.addTag = addTag;


        
        $http.get("/api/tags/")
            .then(function (response) {
                //Success

                angular.copy(response.data, vm.tags);

            }, function (error) {
                //Failure
                vm.errorMessage = "Failed to get tags " + error;
            });


        $('.datepicker').datepicker({
            showOtherMonths: false,
            selectOtherMonths: false
        });

        if (!isNaN($routeParams.bookId)) {
            
            vm.updateBook = updateBook;
            $http.get("/api/books/" + $routeParams.bookId)
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

        } else {
            vm.addBook = addBook;
            vm.title = "Create a new book";
            vm.isBusy = false;
        }



        function addBook() {
            vm.isBusy = true;
            $http.post('/api/books', vm.book)
                .then(function () {
                    $window.location.href = "#!/";
                }, function () {
                    vm.errorMessage = "Failed to add book.";
                })
                .finally(function () {
                    vm.isBusy = false;
                });
        }

        function updateBook() {
            vm.isBusy = true;
            $http.put('/api/books', vm.book)
                .then(function () {
                    $window.location.href = "#!/";
                }, function () {
                    vm.errorMessage = "Failed to update book.";
                })
                .finally(function () {
                    vm.isBusy = false;
                });
        }

        function addTag(item, model) {
            if (item.hasOwnProperty('isTag')) {
                delete item.isTag;
                vm.tags.push(item);
            }
        }

        function tagTransform (newTag) {
            var item = {
                name: newTag,
            };
            return item;
        };
    }

})();