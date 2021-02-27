app.controller("myCntrl", function ($scope, myService) {
    GetAllBatches();

    function GetAllBatches() {
        var getData = myService.GetAllBatches();
        getData.then(function (batches) {
            $scope.batches = batches.data;

            console.log($scope.batches);
        }, function () {
            alert('Error in getting records');
        });
    }
});