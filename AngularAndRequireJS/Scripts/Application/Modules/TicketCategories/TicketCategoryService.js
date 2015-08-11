angular.module("TicketCategoryApp").service('TicketCategoryService', [
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