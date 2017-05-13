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
	return service;
}