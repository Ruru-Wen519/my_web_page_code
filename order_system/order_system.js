angular.module('myApp', [])
    .controller('MyCtrl', ['$scope', '$http', function ($scope, $http) {
        // $scope.account_input = "";
        // $scope.password_input = "";
        $scope.sayHello = function () {
            alert('Hello!');
        };

        $scope.login = function () {
            const account_input = document.getElementById('account').value;
            const password_input = document.getElementById('password').value;

            fetch('https://my-web-page-code.onrender.com', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json'},
                body: JSON.stringify({account_input, password_input })
            })
                .then(response => response.json())
                .then(data => {
                    document.getElementById('result').textContent = JSON.stringify(data, null, 2);
                })
                .catch(err => {
                    document.getElementById('result').textContent = '發生錯誤：' + err;
                });
            // $http.get('http://192.168.0.143:5000/api/data')
            //     .then(function (response) {
            //         $scope.data = response.data;
            //         console.log('API 回傳的資料:', $scope.data);
            //     })
            //     .catch(function (error) {
            //         console.error('API 呼叫失敗:', error);
            //     });
        };
    }]);