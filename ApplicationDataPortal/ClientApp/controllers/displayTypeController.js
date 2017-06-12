(function() {
    'use strict';
    angular
        .module('dataPortal')
        .controller('displayTypeController', ['$http', '$scope', displayTypeController]);

    function displayTypeController($http, $scope) {
            $scope.data = [];
            $http.get("/api/Customers/").then(function (response) {
                $scope.data = response.data;
                console.log($scope.data);
            });
            
        }

}())