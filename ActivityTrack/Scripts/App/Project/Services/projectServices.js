(function() {
    var app = angular.module("activityTrack");

    app.service("projectService", function () {
        return {
            addNewProject: function (data) {
                debugger;
                return $.ajax(
                {
                    url: 'api/projects',
                    type: 'post',
                    data: data
                });
            }
        }
    });
})();