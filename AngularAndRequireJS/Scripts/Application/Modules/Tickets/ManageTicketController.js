angular.module("TicketApp").controller("ManageTicketController", [
    '$scope',
    '$route',
    'TicketService',
    'TicketCategoryService',
    '$location',
    function ($scope, $route, TicketService, TicketCategoryService, $location) {
        var id = $route.current.params.id;
        if (id) {
            $scope.title = "Manage Ticket #" + id;

            //$scope.item = TicketService.getItem(id);

            //Fix to parse json dates
            TicketService.getItem(id).$promise.then(function (response) {
                response.SprintDate = new Date(response.SprintDate);
                $scope.item = response;
            });
        } else {
            $scope.item = { IsClosed: false };
        }


        $scope.categories = TicketCategoryService.getList();

        $scope.submitTicket = function (item) {
            if (id) {
                //remove nested ticket category object so .net doesn't freak out!
                item.TicketCategory = undefined;
                TicketService.updateItem(item).then(function () {
                    $location.path('/tickets');
                    $route.reload();//similar to re-databinding
                });
            } else {
                TicketService.createItem(item).$promise.then(function () {
                    $location.path('/tickets');
                    $route.reload();//similar to re-databinding
                });
            }
        }
    }
]);