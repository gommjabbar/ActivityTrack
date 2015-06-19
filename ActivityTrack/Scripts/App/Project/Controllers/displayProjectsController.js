(function () {
    var app = angular.module("activityTrack");
    app.controller("displayProjectsController", ['$scope', 'projectService',

         function ($scope, projectService) {
             $scope.order = function (predicate) {
                 $scope.reverse = ($scope.predicate === predicate) ? !$scope.reverse : true;
                 $scope.predicate = predicate;
             };

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