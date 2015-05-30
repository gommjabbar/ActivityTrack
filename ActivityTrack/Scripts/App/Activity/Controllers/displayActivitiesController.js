(function() {
    var app = angular.module("activityTrack");
    app.controller("displayActivities", ['$scope', 'activityService',

         function ($scope, activityService) {
          

             $scope.getActivity = function () {
                 $.ajax(
                 {
                     url: '/api/activities',
                     type: 'get',
                     data: $scope.activity
                 }).done(function (data) {
                     $scope.$apply();
                 })
             }
             
        }]);
         //});
})();