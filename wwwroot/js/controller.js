var app = angular.module('myApp', ['ngDialog']);

app.controller('myCtrl', function ($scope, $http, ngDialog) {

    $scope.pict = true
    var myObject = {

        Text: "1",
        Level: 1,
        Signature: "با تشکر",
        Effect: 3
    }
    var lastimg = '';

    var myJSONObject = {
        TextFather: '',
        SigFather: '',
        TextSale: '',
        SigSale:'',
    };

    //var myJSONObjectf = {
    //    Edittt: '',
    //    Editss: ''
    //};



    $scope.sendrequestcartpostal = function () {
        $scope.saleno = false;
        $scope.shref = false;

        $http({ method: "POST", url: "api/Bot/Post", data: myObject, cache: false }).then(function (resp) {
            $scope.imgResult = resp.data.link;

            lastimg = resp.data.name.replace(".jpg","");
            $scope.pict = false;
            $scope.secound = true;
        }).catch(function (err) {
            console.log(err);
        });


    };

    $scope.sendrequestcartpostalBirithDay = function () {
        $scope.saleno = false;
        $scope.shref = false;

        $http({ method: "POST", url: "api/Bot/Postb", data: myObject, cache: false }).then(function (resp) {
            $scope.imgResult = resp.data.link;

            lastimg = resp.data.name.replace(".jpg", "");
            $scope.pict = false;
            $scope.sec = true;
        }).catch(function (err) {
            console.log(err);
        });

    };



    $scope.openConfirmWithPreCloseCallbackInlinedWithNestedConfirm = function () {
        $scope.saleno = false;
        $scope.shref = false;
        ngDialog.openConfirm({
            template: 'dialogWithNestedConfirmDialogId',
            className: 'ngdialog-theme-default',
            data: myJSONObject,
            preCloseCallback: function (value) {
                var nestedConfirmDialog = ngDialog.openConfirm({
                    template: `
                                    <p style="padding-top:10px;font-size:20px">آیا از بستن این پنجره مطمئن هستید؟</p> 
                                    <div class="ngdialog-buttons"> 
                                        <button type="button" class="ngdialog-button ngdialog-button-secondary" ng-click="closeThisDialog(0)">خیر 
                                        <button type="button" class="ngdialog-button ngdialog-button-primary" ng-click="confirm(1)">بله 
                                    </button></div>`,
                    plain: true,
                    className: 'ngdialog-theme-default'
                });
                return nestedConfirmDialog;
            },
            scope: $scope
        })
            .then(function (res) {

                if (res===undefined) {
                    eT = "1";
                    eS = "با تشکر";
                } else {
                    eT = res.TextFather;
                    eS = res.SigFather;
                    myJSONObject.TextFather = res.TextFather;
                    myJSONObject.SigFather = res.SigFather;
                }

                myObject.Text = eT;
                myObject.Signature = eS;

                $http({ method: "POST", url: "api/Bot/Post", data: myObject, cache: false }).then(function (resp) {

                    $scope.imgResult = resp.data.link;

                    lastimg = resp.data.name.replace(".jpg","");
                    $scope.pict = false;
                    $scope.secound = true;
                }).catch(function (err) {
                    console.log(err);
                });


            }, function (value) {
                console.log('rejected:' + value);
            });
    };
    $scope.openConfirmWithPreCloseCallbackInlinedWithNestedConfirmbrti = function () {
        $scope.saleno = false;
        $scope.shref = false;
        ngDialog.openConfirm({
            template: 'dialogWithNestedConfirmDialogIdbrt',
            className: 'ngdialog-theme-default',
            data: myJSONObject,
            preCloseCallback: function (value) {
                var nestedConfirmDialog = ngDialog.openConfirm({
                    template: `
                                    <p style="padding-top:10px;font-size:20px">آیا از بستن این پنجره مطمئن هستید؟</p> 
                                    <div class="ngdialog-buttons"> 
                                        <button type="button" class="ngdialog-button ngdialog-button-secondary" ng-click="closeThisDialog(0)">خیر 
                                        <button type="button" class="ngdialog-button ngdialog-button-primary" ng-click="confirm(1)">بله 
                                    </button></div>`,
                    plain: true,
                    className: 'ngdialog-theme-default'
                });
                return nestedConfirmDialog;
            },
            scope: $scope
        })
            .then(function (res) {
                if (res === undefined) {
                    eT = "1";
                    eS = "با تشکر";
                } else {
                    eT = res.TextSale;
                    eS = res.SigSale;
                    myJSONObject.TextSale = res.TextSale;
                    myJSONObject.SigSale = res.SigSale;
                }

                myObject.Text = eT;
                myObject.Signature = eS;

                $http({ method: "POST", url: "api/Bot/Postb", data: myObject, cache: false }).then(function (resp) {
                    $scope.imgResult = resp.data.link;

                    lastimg = resp.data.name.replace(".jpg","");
                    $scope.pict = false;
                    $scope.sec = true;
                }).catch(function (err) {
                    console.log(err);
                });


            }, function (value) {
                console.log('rejected:' + value);
            });
    };


    $scope.ShowNgDialog = function () {
        $scope.saleno = false;
        $scope.shref = false;
        ngDialog.openConfirm({
            template: 'themepopup',
            scope: $scope
        }).then(function (value) {
            console.log(value);
            myObject.Level = value;

            $http({ method: "POST", url: "api/Bot/Post", data: myObject, cache: false }).then(function (resp) {

                $scope.imgResult = resp.data.link;

                lastimg = resp.data.name.replace(".jpg","");
                $scope.pict = false;
                $scope.secound = true;
            }).catch(function (err) {
                console.log(err);
            });

        }, function (reject) {
            console.log(reject);


        });
    };

    $scope.Showb = function () {
        $scope.saleno = false;
        $scope.shref = false;
        ngDialog.openConfirm({
            template: 'them',
            scope: $scope
        }).then(function (value) {
            console.log(value);
            myObject.Level = value;

            $http({ method: "POST", url: "api/Bot/Postb", data: myObject, cache: false }).then(function (resp) {
                $scope.imgResult = resp.data.link;

                lastimg = resp.data.name.replace(".jpg","");
                $scope.pict = false;
                $scope.sec = true;
            }).catch(function (err) {
                console.log(err);
            });

        }, function (reject) {
            console.log(reject);


        });
    };


    $scope.backmain = function () {

        myObject.Text = "1";
        myObject.Level = 1;
        myObject.Signature = "با تشکر";
        myObject.Effect = 3;

        myJSONObject.SigSale = '';
        myJSONObject.TextSale = '';
        myJSONObject.SigFather = '';
        myJSONObject.TextFather = '';

        $scope.pict = true;
        $scope.sec = false;
        $scope.secound = false;
        $scope.saleno = false;
        $scope.shref = false;
    };


    $scope.share = function () {
        openProtoUrl(lastimg).then(function() {
            $scope.pict = false;
            $scope.sec = true;
        });


    };

    $scope.shareb = function () {

        openProtoUrl(lastimg);
            $scope.pict = false;
            $scope.sec = true;
        };



});

