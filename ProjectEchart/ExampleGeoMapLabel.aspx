<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExampleGeoMapLabel.aspx.cs" Inherits="ProjectEchart.ExampleGeoMapLabel" %>

<!DOCTYPE html>

<html>
    <head>
        <meta charset="utf-8">
        <script src="js/esl.js"></script>
        <script src="js/config.js"></script>
        <script src="js/jquery.min.js"></script>
    </head>
    <body>
        <style>
            html, body, #main {
                width: 100%;
                height: 100%;
                margin: 0;
            }
        </style>
        <div id="main"></div>
        <script>

            require([
                'echarts'
            ], function (echarts) {
                $.get('../map/json/china.json', function (chinaJson) {
                    if (typeof chinaJson === 'string') {
                        chinaJson = eval('(' + chinaJson + ')');
                    }
                    echarts.registerMap('china', chinaJson);
                    var placeList1 = [
                    <% =jsstirng%>                                                      
                    ];
                    var placeList2 = [
                    <% =jsli%>                  
                     ];
                    var chart = echarts.init(document.getElementById('main'), null, {

                    });

                    var data = [];
                    var data2 = [];
                    var len = placeList1.length; 
                    var len2 = placeList2.length; 
                    var randomValue = function (geoCoord) {
                        return [
                            geoCoord[0],
                            geoCoord[1],
                            0.5
                        ];
                    };

                    while(len--) {
                        var geoCoord = placeList1[len % placeList1.length].geoCoord;
                        data.push({
                            name: placeList1[len % placeList1.length].name,
                            value: randomValue(geoCoord)
                        });

                    }
                    while (len2--) {
                        var geoCoord = placeList2[len2 % placeList2.length].geoCoord;
                      
                        data2.push({
                            name: placeList2[len2 % placeList2.length].name,
                            value: randomValue(geoCoord)
                        });
                    }
                    chart.setOption({
                        legend: {
                            data: ['唐人', '李世民父子']
                        },
                        geo: [{
                            map: 'china',
                            roam: true,
                            left: 550, //地图在网页上的位置
                            width: 300,
                            zoom: 4,//地图初始的放大系数
                            scaleLimit: {
                                min: 1.5,
                                max: 4
                            }
                        }],
                        tooltip: {
                            trigger: 'item',                           
                            formatter: function (params) {
                                return params.name ; //图标显示名字
                            }
                        },
                        series: [
                                           
                           {
                            coordinateSystem: 'geo',
                            name: '唐人',
                            type: 'scatter',
                            symbolSize: function (val) {
                                return val[2] * 20;
                            },
                            data: data
                        }, {
                            coordinateSystem: 'geo',
                            name: '李世民父子',
                            type: 'scatter',
                            symbolSize: function (val) {
                                return val[2] * 20;
                            },
                            data: data2
                        }]
                    });

                });
            });

        </script>
    </body>
</html>