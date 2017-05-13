var collectionWebModule = angular.module('collection');
collectionWebModule.config(['$routeProvider', function ($routeProvider){
	$routeProvider        
        	.when('/list', {
        		controller: 'ListController',
	            templateUrl: 'webui/views/collection/list.html',
	            controllerAs: 'ListController'
        	})
        	.when('/register', {
        		controller: 'RegisterController',
                templateUrl: 'webui/views/collection/register.html',
                controllerAs: 'RegisterController'
        	})
        .otherwise({ redirectTo: '/list' });
    }
]);
