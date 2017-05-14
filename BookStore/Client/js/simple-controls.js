// simple-controls.js
(function () {
    "use strict";
    angular.module("simpleControls", [])
        .directive("waitCursor", waitCursor);

    function waitCursor() {
        return {
            restrict: "E",
            scope: {
                show: "=displayWhen"
            },
            templateUrl: "/Client/views/waitCursor.html"
        };
    }
})();