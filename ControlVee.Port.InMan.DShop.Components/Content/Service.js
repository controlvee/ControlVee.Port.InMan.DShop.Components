app.service("myService", function ($http) {

    // Get all batches;
    this.GetAllBatches = function () {
        debugger;
        return $http.get("Home/Index");
    };

});