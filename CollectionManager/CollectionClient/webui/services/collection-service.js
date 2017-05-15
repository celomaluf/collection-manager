angular.module('collection').service('collectionService', collectionService);
collectionService.$inject =['$http', 'BACKEND_CFG'];

function collectionService ( $http, BACKEND_CFG) {
	var service = this;          

    service.listCollection = function (callback) {
        $http.get(BACKEND_CFG.url + 'api/collection')
			.success(function (response) {
			callback(response);
        }).error (function (error) {
            callback(error);	
        });
    };

    service.saveCollection = function (collection, callback) {
        $http.post(BACKEND_CFG.url + 'api/collection', collection)
            .success(function (response) {
            callback(response);
        }).error(function (error) {
            callback(error);
        });
    };
	
    service.deleteCollection = function (cdCollection, callback) {
        $http.delete(BACKEND_CFG.url + 'api/collection/' + cdCollection)
            .success(function (response) {
            callback(response);
        }).error(function (error) {
            console.log('Error: ' + error.details.message);
        });
    };

    service.updateCollection = function (cdCollection, callback) {
        $http.put(BACKEND_CFG.url + 'api/collection/' + cdCollection)
            .success(function (response) {
            callback(response);
        }).error(function (error) {
            console.log('Error: ' + error.details.message);
        });
    };
	return service;
}