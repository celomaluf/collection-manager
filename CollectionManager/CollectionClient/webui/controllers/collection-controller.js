angular.module('collection').controller('CollectionController', CollectionController);

CollectionController.$inject = ['$scope', 'collectionService', '$routeParams'];
function CollectionController($scope, collectionService, $routeParams) {
    var app = this;
    var isInsert = false;

    $scope.warningMessage = '';
    $scope.successMessage = '';
    $scope.collection = {};
    $scope.isDisabled = false;

    $scope.save = function () {
        $scope.successMessage = '';
        $scope.warningMessage = '';
        $scope.isDisabled = true;
        app.saveCollection();
    };

    app.saveCollection = function () {
        isInsert = $scope.collection.CdCollection == null;
        collectionService.saveCollection($scope.collection, function (response) {
            app.manageSaveResponse(response);
        });
    };

    app.manageSaveResponse = function (response) {
        var isSuccess = response[0];
        var message = response[1];
        $scope.isDisabled = false;
        if (isSuccess) {
            if (isInsert) {
                $scope.collection = {};
                $scope.form.$setPristine(true);
            }
            return $scope.successMessage = message;
        }
        $scope.warningMessage = message;
    };

    $scope.deleteCollection = function (cdCollection) {
        $scope.isDisabled = true;
        collectionService.deleteCollection(cdCollection, function (response) {
            var isSuccess = response[0];
            var message = response[1];
            $scope.isDisabled = false;
            if (isSuccess) {
                $scope.collection = {};
                return $scope.successMessage = message;                
            }
            $scope.warningMessage = message;
        });
    };
  
    if ($routeParams.collection) {
        $scope.collection = angular.fromJson($routeParams.collection);
    }
}