//this file not only creates a module, but it would be best to "chain" on to this.
//it needs angular to start though
define([
    'angular'
], function (angular) {
    var ticketCatApp = angular.module('TicketCategoryApp', ['ngResource']);

    //we could provide special configurations here!

    //finally, returning the variable so other files can "chain from it"
    return ticketCatApp;
});