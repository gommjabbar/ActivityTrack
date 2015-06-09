(function () {
    var app = angular.module("activityTrack");
    app.controller("createActivityController", ['$scope', 'activityService',

         function ($scope, $location, activityService) {

             $(function () {
                 $('#datepicker').datetimepicker();
             });

             $scope.activity = {
                 endDate: new Date().now,
             }

             $scope.addActivity = function () {
                 $.ajax(
                 {
                     url: '/api/activities',
                     type: 'post',
                     data: $scope.activity
                 }).done(function (data) {
                     $scope.$apply();
                     $scope.getActivities();
                     //window.location.replace("/Activity/Index");
                 }).error(function (error) {
                     alert(error)
                 })
             }

         }]);
})();