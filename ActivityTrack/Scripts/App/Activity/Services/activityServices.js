(function() {
    var app = angular.module("activityTrack");

    app.service("activityService", function () {
        return {
            addNewActivity: function (data) {
                return $.ajax(
                {
                    url: '/activities',
                    type: 'post',
                    data: data
                });
            }
        }
    });
})();