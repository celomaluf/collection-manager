angular.module('collection').controller('ListController', ListController);
ListController.$inject = ['$scope', 'collectionService'];

function ListController($scope, collectionService) {
    var app = this;
    $scope.collections = [];
    app.listCollection = function () {
        collectionService.listCollection( function (response) {
            $scope.collections = response;
    	}, function ( error) {
    		console.log(error);
    	});
    };
    app.listCollection();
}