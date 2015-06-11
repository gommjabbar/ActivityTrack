﻿(function () {
    var app = angular.module("activityTrack");
    app.controller("displayProjectsController", ['$scope', 'projectService',

         function ($scope, projectService) {
            
             $scope.getProjects = function () {
                 $.ajax(
                 {
                     url: '/api/projects',
                     type: 'get',
                 }).done(function (data) {
                     $scope.Projects = data.result;
                     $scope.$apply();
                 })
             }
             $scope.getProjects();
         }]);
})();