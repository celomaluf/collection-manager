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
        }, function (error) {
            $scope.warningMessage = error;
        });
    };

    app.manageSaveResponse = function (response) {
        var isSucess = response[0];
        var message = response[1];
        $scope.isDisabled = false;
        if (isSucess) {
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
            var isSucess = response[0];
            var message = response[1];
            $scope.isDisabled = false;
            if (isSucess) {
                $scope.collection = {};
                return $scope.successMessage = response;                
            }
            $scope.warningMessage = message;
        }, function (error) {
            $scope.warningMessage = error;
        });
    };
  
    if ($routeParams.collection) {
        $scope.collection = angular.fromJson($routeParams.collection);
    }
}