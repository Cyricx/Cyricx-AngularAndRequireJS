//to create a module pass the name and an array for anything it depends on.
//Our module now depends on the route module, which is named ngRoute
angular.module("MainApp", ['ngRoute', 'TicketApp', 'TicketCategoryApp']);

//The below works WITHOUT minification. If minified it breaks the depenency injection
//Angular no longer finds a parameter called $scope.
//angular.module("MainApp").controller("TestController", function ($scope) {
//    $scope.test = "This is the beginning of client side awesomeness!";
//});

//To allow angular to process minified versions, it allows you to pass an array as the
//second parameter. It will assume the last item in the array is the function for the controller.
//Anything that comes before that function will be directly wired up to the parameters 
//in the function in the order encountered.
angular.module("MainApp").controller("TestController",
    [
        '$scope',
        function ($scope) {
            $scope.test = "This is a beginning of client side awesomeness!";
        }
    ]
);

//To setup routes you must alter the way the module is configured.
angular.module("MainApp").config([
    '$routeProvider',
    function ($routeProvider) {
        $routeProvider.when('/', {
            templateUrl: '../../Scripts/Application/TestView.html'
        });
        $routeProvider.when('/tickets', {
            templateUrl: '../../Scripts/Application/Modules/Tickets/Tickets.html'
        });
        $routeProvider.when('/tickets/create', {
            templateUrl: '../../Scripts/Application/Modules/Tickets/ManageTicket.html'
        });
        $routeProvider.when('/tickets/:id', {
            templateUrl: '../../Scripts/Application/Modules/Tickets/ManageTicket.html'
        });
    }
]);