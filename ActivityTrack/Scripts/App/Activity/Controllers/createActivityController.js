(function() {
    var app = angular.module("activityTrack");
    app.controller("newActivityController", ['$scope','activityService','projectService',

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
                 startDate: new Date(),
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
                     data: $scope.activity //angular.toJson($scope.activity)
                         //{
                         //    startDate: new Date(),
                         //    endDate: new Date(),
                         //    description: 'test',
                         //    id: 1,
                         //    project : { id: 1, name: 'test'}
                         //}
                 }).done(function (data) {
                     //$scope.activity.push(data);
                     $scope.$apply();
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