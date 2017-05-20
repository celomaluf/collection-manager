angular.module('collection').controller('CollectionController', CollectionController);

CollectionController.$inject = ['$scope', 'collectionService', '$routeParams'];
function CollectionController($scope, collectionService, $routeParams) {
    var app = this;
    var resetForm = false;

    $scope.warningMessage = '';
    $scope.successMessage = '';
    $scope.collection = {};
    $scope.isDisabled = false;

    app.insertCollection = function () {
        collectionService.insertCollection($scope.collection, function (response) {
            app.manageResponse(response);
        });
    };

    app.updateCollection = function () {
        collectionService.updateCollection($scope.collection, function (response) {
            app.manageResponse(response);
        });
    };

    $scope.deleteCollection = function (cdCollection) {
        $scope.isDisabled = true;
        resetForm = false;
        collectionService.deleteCollection(cdCollection, function (response) {
            app.manageResponse(response);
        });
    };

    $scope.save = function () {
        $scope.successMessage = '';
        $scope.warningMessage = '';
        $scope.isDisabled = true;
        resetForm = $scope.collection.CdCollection > 0; //update
        if (resetForm) {
            app.updateCollection();
            return;
        }
        app.insertCollection();
    };
        
    app.manageResponse = function (response) {
        var isSuccess = response[0];
        var message = response[1];
        $scope.isDisabled = false;
        if (isSuccess) {
            if (!resetForm) {
                $scope.collection = {};
                $scope.form.$setPristine(true);
            }
            return $scope.successMessage = message;
        }
        $scope.warningMessage = message;
    };

    if ($routeParams.collection) {
        $scope.collection = angular.fromJson($routeParams.collection);
    }
}
