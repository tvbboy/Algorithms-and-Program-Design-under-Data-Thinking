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
         <script type="text/javascript">
             var myChart = echarts.init(document.getElementById('main'));
             //显示处理后的数据                    
             var option = {
                 tooltip: {},
                 series: [{
                     type: 'wordCloud',
                     gridSize: 2,
                     sizeRange: [12, 50],
                     rotationRange: [-90, 90],
                     // Shape can be 'circle', 'cardioid', 'diamond', 'triangle-forward', 'triangle', 'pentagon', 'star'
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
                     }
                 }]
             };
             myChart.setOption(option);
             $.ajax({
                 type: "GET",
                 async: false,
                 url: "test.json",
                 dataType: "json",
                 success: function (result) {
                     console.dir(result)
                     //显示处理后的数据                    
                     var option = {
                         tooltip: {},
                         series: [{                          
                             data: result
                         }]
                     };
                     myChart.setOption(option);
                     window.onresize = chart.resize;
                 },
                 error: function (errorMsg) {
                     alert("图表请求数据失败啦！" + errorMsg);
                     console.log(errorMsg);
                 }
             });
             </script>


    </body>
</html>
