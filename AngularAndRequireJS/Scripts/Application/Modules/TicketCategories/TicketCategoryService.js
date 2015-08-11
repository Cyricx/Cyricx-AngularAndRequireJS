//We need the file that created the ticket category app
define([
    './TicketCategoryApp' //and it returns the module it created
], function (app) {
    //no need to restate the name!
    //angular.module("TicketCategoryApp")

    //just use the value that was returned in the above file and chain onto it!
    app.service('TicketCategoryService', [
    '$resource',
    function ($resource) {
        //later add id and configure
        var resourceAccessObject = $resource('http://localhost:2895/api/ticketcategories');

        return {
            getList: function () {
                return resourceAccessObject.query();
            }
        };

    }
]);

});