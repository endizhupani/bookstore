//tags-controller.js
(function () {
    "use strict";

    // Getting the existing module
    angular.module("app-tags")
        .controller("tagsController", tagsController);

    function tagsController($http) {
        //the object that is returned by the controller
        var vm = this;
        vm.tags = [];
        vm.tag = {};
        vm.errorMessage = "";
        vm.message = "";
        vm.isBusy = true;
        vm.deleteTag = deleteTag;
        vm.addTag = addTag
        $http.get("/api/tags")
            .then(function (response) {
                //Success
                angular.copy(response.data, vm.tags);
            }, function (error) {
                //Failure
                vm.errorMessage = "Failed to load data " + error;
            })
            .finally(function () {
                vm.isBusy = false;
            });

        function deleteTag(index) {

           

            var tagToDelete = vm.tags[index];
            var tagNameDecoded = decodeHtml(tagToDelete.name);
            if (confirm('Are you sure you want to delete ' + tagNameDecoded + '? This tag will be removed from all the books associated with it.')) {
                
                var url = '/api/tags/?name=' + window.encodeURIComponent(tagNameDecoded);
                $http.delete(url)
                    .then(function () {
                        vm.tags.splice(index, 1);
                        vm.message = "Tag deleted sucessfully";
                        vm.emptyMessage = emptyMessage;
                    },
                    function (error) {
                        vm.errorMessage = "Failed to delete tag";
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

        function addTag() {
            vm.isBusy = true;
            $http.post('/api/tags', vm.tag)
                .then(function () {
                    vm.tags.push(vm.tag);
                    $window.location.href = "#!/";
                }, function () {
                    vm.errorMessage = "Failed to add tag.";
                })
                .finally(function () {
                    vm.isBusy = false;
                });
        }
        
    }

   

})();