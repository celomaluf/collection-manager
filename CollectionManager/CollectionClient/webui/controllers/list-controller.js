angular.module('collection').controller('ListController', ListController);
ListController.$inject = ['$scope', 'collectionService'];

function ListController($scope, collectionService) {
    var app = this;

    //Filters
    $scope.searchFilter = '';
    $scope.typeFilter = '';
    $scope.availableFilter = '';

    //Grid
    $scope.collections = [];
    $scope.propertyName = 'Type';
    $scope.reverse = true;

    app.listCollection = function () {
        collectionService.listCollection(function (response) {
            console.log(response);
            $scope.collections = response;
        },function ( error) {
            console.log(error);
        });
    };

    $scope.sortBy = function (propertyName) {
        $scope.reverse = ($scope.propertyName === propertyName) ? !$scope.reverse : false;
        $scope.propertyName = propertyName;
    };

    app.listCollection();
}