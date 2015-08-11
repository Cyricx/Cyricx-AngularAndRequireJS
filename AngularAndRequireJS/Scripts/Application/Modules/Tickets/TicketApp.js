//once again, let's return the created app
define([
    'angular',
    '../TicketCategories/index'//! ALSO needs ticket category!
], function (angular) {
    //I prefer the term module for the return, though it is an app, I like the verbal
    //connection to the kind of object it actually creates.
    //you will see it both ways
    var module = angular.module("TicketApp", ['ngResource', 'TicketCategoryApp']);

    //in more advanced applications you will need to access app.config() which can only be
    //done one time! This gives you an easy way to do so!

    return module;
});