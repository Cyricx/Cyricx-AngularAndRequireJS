//bootstrap is a term meant to imply putting your boots on and has no relation to the bootstrap library

//all files written to be used for require follow a pattern of
//define([array of files and dependencies], function (parameters from files) { stuff });
define([
    'jquery',
    //'testing'
    'angular',
    './MainApp'
], function (jq, ang) {
    //since we don't need test to access anything and it doesn't create a variable, nothing to access
    //we can disregard it!
    jq('body').css('backgroundColor', 'lightblue');//no errors!!

    //this file is responsible for applying our ngApp attribute... dynamically!
    ang.bootstrap(document, ['MainApp']);
    //however, we can't attach something until it is created, so let's tell this file that
    //before it runs, it neds to run the MainApp.js file
});