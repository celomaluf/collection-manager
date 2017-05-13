var unl = angular.module('collection');

/* 
 * @WEB_URL
 */

unl.constant('BACKEND_CFG',  {
    url: 'http://localhost:51920/',
    setupHttp: function(http) {
        http.defaults.useXDomain = true;
        http.defaults.withCredentials = true;
    }
});

