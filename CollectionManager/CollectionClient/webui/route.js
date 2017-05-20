var collectionWebModule = angular.module('collection');
collectionWebModule.config(['$routeProvider', function ($routeProvider){
	$routeProvider        
        .when('/list', {
            controller: 'ListController',
            templateUrl: 'webui/views/collection/list.html',
            controllerAs: 'ListController'
        })

        .when('/add', {
            controller: 'CollectionController',
            templateUrl: 'webui/views/collection/collection.html',
            controllerAs: 'CollectionController'
        })

        .when('/edit/:collection', {
            controller: 'CollectionController',
            templateUrl: 'webui/views/collection/collection.html',
            controllerAs: 'CollectionController'
        })
        .otherwise({ redirectTo: '/list' });
    }
]);
