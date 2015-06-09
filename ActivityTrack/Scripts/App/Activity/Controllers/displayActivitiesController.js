(function () {
    var app = angular.module("activityTrack");
    app.controller("displayActivitiesController", ['$scope', 'activityService',

         function ($scope, activityService) {
             $scope.reverse = true;
             $scope.order = function (predicate) {
                 $scope.reverse = ($scope.predicate === predicate) ? !$scope.reverse : true;
                 $scope.predicate = predicate;
             };

             $scope.pauseActivity = function (item) {
                 $.ajax(
                 {
                     url: '/api/activities/pause',
                     type: 'put',
                 }).done(function (data) {
                     $scope.Activities = data;
                     $scope.$apply();
                 })
             }

             $scope.endActivity = function (item) {
                 $.ajax(
                 {
                     url: '/api/activities/end',
                     type: 'put',
                 }).done(function (data) {
                     $scope.Activities = data;
                     $scope.$apply();
                 })
             }

             $scope.editItem = function (item) {
                 item.editing = true;
             }

             $scope.doneEditing = function (item) {
                 item.editing = false;
                 //TODO update in database
                 $.ajax(
                 {
                     url: '/api/activities',
                     type: 'put',
                     data: $scope.activity
                 }).done(function (data) {
                     $scope.Activities = data;
                     $scope.$apply();
                 })
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