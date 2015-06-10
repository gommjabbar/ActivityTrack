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
             $scope.ResumeButton = 'Resume';

             $scope.startActivity = function (item) {
                 $scope.timerActive = true;
                 $scope.timerRunning = true;
                 $.ajax(
                {
                    url: '/api/activities/start',
                    type: 'put',
                    data: item
                }).done(function (data) {
                    $scope.$apply();
                    $scope.getActivities();
                })
             };

             $scope.pauseActivity = function (item) {
                 $scope.timerRunning = false;
                     $.ajax(
                     {
                         url: '/api/activities/pause',
                         type: 'put',
                         data: item
                     }).done(function (data) {
                         $scope.$apply();
                         $scope.getActivities();
                     })
             };

             $scope.resumeActivity = function (item) {
                 $scope.timerRunning = true;
                     $.ajax(
                     {
                         url: '/api/activities/start',
                         type: 'put',
                         data: item
                     }).done(function (data) {
                         $scope.$apply();
                         $scope.getActivities();
                     })
             };

             $scope.endActivity = function (item)
             {
                 $scope.timerActive = false;
                     $.ajax(
                     {
                         url: '/api/activities/end',
                         type: 'put',
                         data: item
                     }).done(function (data) {
                         $scope.$apply();
                         $scope.getActivities();
                     })
             };

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