(function () {
    var app = angular.module("activityTrack");
    app.controller("displayActivitiesController", ['$scope', 'activityService',

         function ($scope, activityService) {
             $scope.reverse = true;

             $scope.order = function (predicate) {
                 $scope.reverse = ($scope.predicate === predicate) ? !$scope.reverse : true;
                 $scope.predicate = predicate;
             };

             $scope.selectedRow = null;  
             $scope.setClickedRow = function (id) {  
                 $scope.selectedRow = id;
             }

             $scope.setProject = function (project) {
                 $scope.selectedProject = project;
                 $scope.activity.project = project;
             }

             $scope.StartButton = 'Start';
             $scope.PauseButton = 'Pause';
             $scope.EndButton = 'End';
             $scope.ResumeButton = 'Resume';

             $scope.startActivity = function (item) {
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
                     $.ajax(
                     {
                         url: '/api/activities/end',
                         type: 'put',
                         data: item
                     }).done(function (data) {
                         $scope.$apply();
                         $scope.getActivities();
                     })
                     $.ajax(
                     {
                         url: '/api/activities/clone',
                         type: 'post',
                         data: item
                     }).done(function (data) {
                         $scope.$apply();
                         $scope.getActivities();
                     }).error(function (error) {
                         alert(error)
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
                     $scope.Activities = data.result;
                     $scope.$apply();
                 })
             }
             $scope.getActivities();

         }]);
})();