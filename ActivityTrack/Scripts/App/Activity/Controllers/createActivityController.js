(function() {
    var app = angular.module("activityTrack");
    app.controller("createActivityController", ['$scope','activityService','projectService',

         function ($scope, activityService, projectService) {
             $scope.newProjectButtonText = 'Add';
             $scope.showNewProject = false;
             $scope.newProject = {
                 id: -1,
                 name: 'Enter project'
             }
             $scope.allProjects = [
                 { id: 1, name: "ActivityTrack" },
                 { id: 2, name: "Other" },
                 { id: 3, name: "NextOne" }
             ]
             
             $scope.activity = {
                 project: $scope.allProjects[0],
                 startDate: new Date().toISOString(),
                 endDate: undefined,
                 description: "test"
             }

             $scope.saveProject = function () {
                 var data = JSON.stringify($scope.newProject);
                 projectService.addNewProject(data)
                     .done(function (data) {
                     $scope.allProjects.push(data);
                     $scope.$apply();
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