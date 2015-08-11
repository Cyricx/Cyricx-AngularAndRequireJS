//setup basic require structure
define([
    //? Things we need! 
    //here we are JUST defining the script files that must be loaded first
    'angular',
    'angularRoute',
    'angularResource'
], function (angular) {
    //the below module definitions must still happen!!
    angular.module("MainApp", ['ngRoute', 'TicketApp', 'TicketCategoryApp']);

    angular.module("MainApp").controller("TestController",
        [
            '$scope',
            function ($scope) {
                $scope.test = "This is a beginning of client side awesomeness!";
            }
        ]
    );
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
});