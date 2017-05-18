angular.module('collection').service('collectionService', collectionService);
collectionService.$inject =['$http', 'BACKEND_CFG'];

function collectionService ( $http, BACKEND_CFG) {
	var service = this;          

    /*
    List all collections 
    */
    service.listCollection = function (callback) {
        $http.get(BACKEND_CFG.url + 'api/collection')
			.success(function (response) {
			callback(response);
        }).error (function (error) {
            throw ('Error: ' + error.Message);	
        });
    };

    /*
    Insert/Update a collection
    */
    service.saveCollection = function (collection, callback) {
        $http.post(BACKEND_CFG.url + 'api/collection/', collection)
            .success(function (response) {
            callback(response);
        }).error(function (error) {
            throw ('Error: ' + error.Message);	
        });
    };
    
    /*
    Delete a given collection
    */	
    service.deleteCollection = function (cdCollection, callback) {
        $http.delete(BACKEND_CFG.url + 'api/collection/'+ cdCollection)
            .success(function (response) {
            callback(response);
        }).error(function (error) {
             throw('Error: ' + error.Message);	
        });
    };
	return service;
}