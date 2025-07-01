var app = angular.module('myApp', []);
app.controller('MyCtrl', function($scope) {
  $scope.sayHello = function() {
    alert('Hello!');
  };
});