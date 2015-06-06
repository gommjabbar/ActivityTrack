(function () {
    var app = angular.module("activityTrack");
    app.controller("displayActivitiesController", ['$scope', 'activityService',

         function ($scope, activityService) {
             $scope.reverse = true;
             $scope.order = function (predicate) {
                 $scope.reverse = ($scope.predicate === predicate) ? !$scope.reverse : true;
                 $scope.predicate = predicate;
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