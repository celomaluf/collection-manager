angular.module('collection').controller('CollectionController', CollectionController);

CollectionController.$inject = ['$scope', 'collectionService'];
function CollectionController($scope, collectionService) {
    var app = this;
    
    $scope.warningMessage = '';
    $scope.successMessage = '';
    $scope.collection = {};
    
    $scope.save = function () {
        collectionService.saveCollection($scope.collection, function (response) {
            $scope.message = response.result
        });
    };
}