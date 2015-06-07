(function () {
    var app = angular.module("activityTrack");
    app.controller("createActivityController", ['$scope', 'activityService',

         function ($scope, $location, activityService) {

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
                     window.location.replace("/Activity/Index");
                 }).error(function (error) {
                     alert(error)
                 })
             }

         }]);
})();