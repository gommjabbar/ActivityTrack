(function () {
    var app = angular.module("activityTrack");
    app.controller("createActivityController", ['$scope', 'activityService',

         function ($scope, activityService) {

             $scope.activity = {
                 project: $scope.Projects,
                 startDate: new Date().toISOString(),
                 endDate: undefined,
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

         }]);
})();