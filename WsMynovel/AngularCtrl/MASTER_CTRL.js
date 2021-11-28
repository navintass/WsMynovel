var app = angular.module('NOVEL_APP', []);
app.directive('loading', ['$http', function ($http) {
    return {
        restrict: 'A',
        link: function (scope, elm, attrs) {
            scope.isLoading = function () {
                return $http.pendingRequests.length > 0;
            };
            scope.$watch(scope.isLoading, function (v) {
                if (v) {
                    elm.show();
                } else {
                    elm.hide();
                }
            });
        }
    };
}]);

app.controller('MASTER_CTRL', function ($scope, $http, $location, CENTER_SV, $window) {
    GET_SET_FULL_MODEL();
    $scope.show_success = true;
    $scope.show_all_success = true;

    function GET_SET_FULL_MODEL() {
        if ($scope.FULL_MODEL == undefined) {
            var getData = CENTER_SV.GET_SET_FULL_MODEL();
            getData.then(function (datas) {
                $scope.FULL_MODEL = datas.data;
                GET_NOVEL_ALL();
                GET_ALL();
            }, function () {
                //alert("ตรวจสอบการเชื่อมต่อ");
            });
        }
    }

    function GET_NOVEL_ALL() {
            var getData = CENTER_SV.GET_NOVEL();
            getData.then(function (datas) {
                $scope.GET_NOVEL = datas.data;
                $scope.show_success = false;
            }, function () {
                //alert("ตรวจสอบการเชื่อมต่อ");
            });
    }


    function GET_ALL() {
        var getData = CENTER_SV.GET_ALL();
        getData.then(function (datas) {
            $scope.GET_NOVEL_ALL = datas.data;
            $scope.show_all_success = false;
        }, function () {
            //alert("ตรวจสอบการเชื่อมต่อ");
        });
    }




    $scope.GET_HISTORY_LEAD = function () {
        var getData = CENTER_SV.GET_HISTORY();
        getData.then(function (datas) {
            $scope.LIST_HISTORY = datas.data;
            //$scope.show_success = false;
        }, function () {
            //alert("ตรวจสอบการเชื่อมต่อ");
        });
    };

    $scope.save_data = function () {
        $scope.FULL_MODEL.LIST_PRODUCT = $scope.GET_NOVEL;
        var getData = CENTER_SV.INSERT_DATA($scope.FULL_MODEL);
        getData.then(function (datas) {
            alert("Update Success")
        }, function () {
            //alert("ตรวจสอบการเชื่อมต่อ");
        });
    };


    $scope.save_data_all = function () {
        $scope.FULL_MODEL.LIST_PRODUCT = $scope.GET_NOVEL_ALL;
        var getData = CENTER_SV.INSERT_DATA($scope.FULL_MODEL);
        getData.then(function (datas) {
            alert("Update Success")
            $scope.show_all_success = false;
        }, function () {
            //alert("ตรวจสอบการเชื่อมต่อ");
        });
    };

    


});