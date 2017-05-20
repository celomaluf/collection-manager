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
    Insert a collection
    */
    service.insertCollection = function (collection, callback) {
        $http.post(BACKEND_CFG.url + 'api/collection/', collection)
        .success(function (response) {
            callback(response);
        }).error(function (error) {
            throw ('Error: ' + error.Message);	
        });
    };

    /*
    Update a given collection
    */
    service.updateCollection = function (collection, callback) {
        $http.put(BACKEND_CFG.url + 'api/collection/', {
            CdCollection: collection.CdCollection,
            Available: collection.Available,
            Type: collection.Type,
            Description: collection.Description,
            Location: collection.Location,
            User : {
                Name: collection.User.Name,
                Contact: collection.User.Contact
            }
        })
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