angular.module('collection').controller('RegisterController', RegisterController);

RegisterController.$inject = ['$scope', 'collectionService'];
function RegisterController($scope, collectionService) {
    var app = this;
    
    $scope.warningMessage = '';
    $scope.successMessage = '';
    $scope.search = '';
    $scope.collections = [];
    
    $scope.addCollection = function () {
    	
    };
}