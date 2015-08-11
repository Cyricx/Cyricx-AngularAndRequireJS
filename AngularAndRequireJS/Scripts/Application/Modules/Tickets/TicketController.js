angular.module("TicketApp").controller("TicketController", [
    '$scope',
    'TicketService',
    function ($scope, TicketService) {
        $scope.quickTest = "Tickets coming soon!";
        $scope.tickets = TicketService.getList();

        $scope.showClosed = false;
        $scope.orderColumn = "SprintDate";

        $scope.changeOrder = function (column) {
            if ($scope.orderColumn == column) {
                $scope.orderColumn = '-' + column;
            } else {
                $scope.orderColumn = column;
            }
        };

        $scope.updateTicket = function (ticket) {
            TicketService.updateItem(ticket);
        }
    }
]);