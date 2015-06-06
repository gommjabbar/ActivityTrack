(function () {
    var app = angular.module("activityTrack");
    app.controller("createProjectController", ['$scope', 'projectService',

         function ($scope, projectService) {
             $scope.newProjectButtonText = 'Add';
             $scope.showNewProject = false;

             $scope.newProject = {
                 id: -1,
                 name: "",
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
})();