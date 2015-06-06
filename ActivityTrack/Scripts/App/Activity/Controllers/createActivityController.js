(function() {
    var app = angular.module("activityTrack");
    app.controller("createActivityController", ['$scope','activityService','projectService',

         function ($scope, activityService, projectService) {
             $scope.newProjectButtonText = 'Add';
             $scope.showNewProject = false;

             $scope.getProjects = function () {
                 $.ajax(
                 {
                     url: '/api/projects',
                     type: 'get',
                 }).done(function (projectsList) {
                     $scope.Projects = projectsList;
                     $scope.$apply();
                 })
             }
             $scope.getProjects();

             $scope.newProject = {
                 id: -1,
                 name: "",
             }

             $scope.activity = {
                 project: $scope.Projects,
                 startDate: new Date().toISOString(),
                 endDate: undefined,
             }

             $scope.addProject = function () {
                 $.ajax(
                 {
                     url: '/api/projects',
                     type: 'post',
                     data: $scope.newProject
                 }).done(function (data) {
                     $scope.$apply();
                     $scope.getProjects();
                 }).error(function (error) {
                     alert(error)
                 })
             }

             $scope.addActivity = function () {
                 $.ajax(
                 {
                     url: '/api/activities',
                     type: 'post',
                     data: $scope.activity
                 }).done(function (data) {
                     $scope.$apply();
                 }).error(function (error) {
                     alert(error)
                 })
             }

             $scope.showHide = function () {
                 $scope.showNewProject = !$scope.showNewProject;
                 if ($scope.showNewProject) {
                     $scope.newProjectButtonText = 'Cancel';
                 }
                 else {
                     $scope.newProjectButtonText = 'Add';
                 }
             }
        }]);
         //});
})();