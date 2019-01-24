<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExampleWordCloud.aspx.cs" Inherits="ProjectWordSegmenter.ExampleWordCloud" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<script src="js/jquery.min.js"></script>
<script src='js/echarts.simple.js'></script>
<script src='js/echarts-wordcloud.js'></script>
    <title></title>
</head>
    <body>
        <style>
            html, body, #main {
                width: 100%;
                height: 100%;
                margin: 0;
            }
        </style>
        <div id='main'></div>
        <script type = "text/javascript" > 
            var Url = "userinfo.json";  
           // var Url = "test.json";  
            $.getJSON(Url, function (data) {
                console.dir(data)
                  //显示处理后的数据 
            var chart = echarts.init(document.getElementById('main'));
            var option = {
                tooltip: {},
                series: [ {
                    type: 'wordCloud',
                    gridSize: 2,
                    sizeRange: [12, 50],
                    rotationRange: [-90, 90],
                    shape: 'pentagon',
                    width: 600,
                    height: 400,
                    drawOutOfBound: true,
                    textStyle: {
                        normal: {
                            color: function () {
                                return 'rgb(' + [
                                    Math.round(Math.random() * 160),
                                    Math.round(Math.random() * 160),
                                    Math.round(Math.random() * 160)
                                ].join(',') + ')';
                            }
                        },
                        emphasis: {
                            shadowBlur: 10,
                            shadowColor: '#333'
                        }
                    },                  
                    data: data 
                } ]
            };
            chart.setOption(option);
            window.onresize = chart.resize;
            }) 
        </script>
    </body>
</html>
