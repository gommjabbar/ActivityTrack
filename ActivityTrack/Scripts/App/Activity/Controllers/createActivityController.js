(function () {
    var app = angular.module("activityTrack");
    app.controller("createActivityController", ['$scope', 'activityService',

         function ($scope, $location, activityService) {

             $(function () {
                 $('#datepicker').datetimepicker();
             });

             $scope.timeUnits = ["Minutes","Hours"]
             $scope.unit = $scope.timeUnits[0];

             $(".estimate").hide();
             $(".showHideEstimate").click(function () {
                 if ($(this).is(":checked")) {
                     $(".estimate").show();
                 } else {
                     $(".estimate").hide();
                 }
             });

             $scope.activity = {    
                 endDate: $scope.endDate,  
             }

             $scope.updateProjectId = function()
             {
                 $scope.activity.projectid = $scope.activity.project.id;
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
                 }).error(function (error) {
                     alert(error)
                 })
             }
         }]);
})();