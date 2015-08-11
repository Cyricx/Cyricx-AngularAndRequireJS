//setup basic require structure
define([
    //? Things we need! 
    //here we are JUST defining the script files that must be loaded first
    'angular',
    './MainApp.routes',// need the array this return
    'angularRoute',
    'angularResource',
    //We still need to wire up the modules..
    './Modules/TicketCategories/index',
    './Modules/Tickets/index'
], function (angular, routes) {
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

            angular.forEach(routes, function (route) {
                $routeProvider.when(route.path, {
                    templateUrl: route.template
                });
            })

            //$routeProvider.when('/', {
            //    templateUrl: '../../Scripts/Application/TestView.html'
            //});
            //$routeProvider.when('/tickets', {
            //    templateUrl: '../../Scripts/Application/Modules/Tickets/Tickets.html'
            //});
            //$routeProvider.when('/tickets/create', {
            //    templateUrl: '../../Scripts/Application/Modules/Tickets/ManageTicket.html'
            //});
            //$routeProvider.when('/tickets/:id', {
            //    templateUrl: '../../Scripts/Application/Modules/Tickets/ManageTicket.html'
            //});
        }
    ]);
});