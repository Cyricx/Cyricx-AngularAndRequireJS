//common convention is to separate routes into a separate file
define([
], function () {
    //you can return ANY javascript object, you can even join arrays from several files
    return [
        { path: '/', template: '../../Scripts/Application/TestView.html' },
        { path: '/tickets', template: '../../Scripts/Application/Modules/Tickets/Tickets.html' },
        { path: '/tickets/create', template: '../../Scripts/Application/Modules/Tickets/ManageTicket.html' },
        { path: '/tickets/:id', template: '../../Scripts/Application/Modules/Tickets/ManageTicket.html' }
    ];
});