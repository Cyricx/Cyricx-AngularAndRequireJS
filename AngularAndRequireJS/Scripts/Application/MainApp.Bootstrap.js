//bootstrap is a term meant to imply putting your boots on and has no relation to the bootstrap library

//all files written to be used for require follow a pattern of
//define([array of files and dependencies], function (parameters from files) { stuff });
define([
    'jquery',
    //'testing'
], function (jq) {
    //since we don't need test to access anything and it doesn't create a variable, nothing to access
    //we can disregard it!
    jq('body').css('backgroundColor', 'grey');//no errors!!
});