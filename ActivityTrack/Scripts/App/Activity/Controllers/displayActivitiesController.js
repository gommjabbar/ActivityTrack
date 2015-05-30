(function() {
    var app = angular.module("activityTrack");
    app.controller("displayActivitiesController", ['$scope', 'activityService',

         function ($scope, activityService){
             $scope.Activities = [
   { Type: 1, Name: '1st', StartDate: newDate(), EndDate: newDate(), Descritipn: 'test1' },
   { Type: 2, Name: '2nd', StartDate: newDate(), EndDate: newDate(), Descritipn: 'test2' },
   { Type: 3, Name: '3rd', StartDate: newDate(), EndDate: newDate(), Descritipn: 'test3' }
             ];

             $scope.getActivities = function () {
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