(function () {
    var app = angular.module("activityTrack");
    app.controller("displayActivitiesController", ['$scope', 'activityService',

         function ($scope, activityService) {
             $scope.reverse = true;
             $scope.order = function (predicate) {
                 $scope.reverse = ($scope.predicate === predicate) ? !$scope.reverse : true;
                 $scope.predicate = predicate;
             };

             $scope.editItem = function (item) {
                 item.editing = true;
             }

             $scope.doneEditing = function (item) {
                 item.editing = false;
                 //TODO edit in database
                 //$.ajax(
                 //{
                 //    url: '/api/activities',
                 //    type: 'put',
                 //}).done(function (data) {
                 //    $scope.Activities = data;
                 //    $scope.$apply();
                 //})
             };

             $scope.getActivities = function () {
                 $.ajax(
                 {
                     url: '/api/activities',
                     type: 'get',
                 }).done(function (data) {
                     $scope.Activities = data;
                     $scope.$apply();
                 })
             }
             $scope.getActivities();

         }]);
})();