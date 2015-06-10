(function () {
    var app = angular.module("activityTrack");
    app.controller("displayActivitiesController", ['$scope', 'activityService',

         function ($scope, activityService) {
             $scope.reverse = true;
             $scope.order = function (predicate) {
                 $scope.reverse = ($scope.predicate === predicate) ? !$scope.reverse : true;
                 $scope.predicate = predicate;
             };

             $scope.StartButton = 'Start';
             $scope.PauseButton = 'Pause';
             $scope.EndButton = 'End';

             $scope.startActivity = function (item) {
                 $.ajax(
                 {
                     url: '/api/activities/start',
                     type: 'put',
                     data: item
                 }).done(function (data) {
                     $scope.$apply();
                     $scope.getActivities();
                     //$scope.StartShowHide();
                     
                 })
             }

             $scope.pauseActivity = function (item) {
                 $.ajax(
                 {
                     url: '/api/activities/pause',
                     type: 'put',
                     data: item
                 }).done(function (data) {
                     $scope.$apply();
                     $scope.getActivities();
                     //$scope.StartShowHide();
                 })
             }

             $scope.endActivity = function (item) {
                 $.ajax(
                 {
                     url: '/api/activities/end',
                     type: 'put',
                     data: item
                 }).done(function (data) {
                     $scope.$apply();
                     $scope.getActivities();
                    // $scope.StartShowHide();
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
                     data: item
                 }).done(function (data) {
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