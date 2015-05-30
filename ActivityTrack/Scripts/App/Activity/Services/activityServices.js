(function() {
    var app = angular.module("activityTrack");

    app.service("activityService", function () {
        return {
            addNewActivity: function (data) {
                return $.ajax(
                {
                    url: '/api/activities',
                    type: 'post',
                    data: data
                });
            },
            displayActivities: function(data){
                return $.ajax(
                {
                    url: '/api/activities',
                    type: 'get',
                    data: data
                });
            }
        }
    });
})();