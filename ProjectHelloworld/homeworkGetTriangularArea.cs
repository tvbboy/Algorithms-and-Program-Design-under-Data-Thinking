/*
 * Liunuowei
 * 下次作业开始改用WebForm，这次暂时Console输入输出！！！
 */
using System;

namespace Solution0312 {
    internal class homeworkGetTriangularArea {
        public static void Main(string[] args){
            // 模拟文本框，改用控制台输
            string numberString = Console.ReadLine();
            string[] str = numberString.Split(' ');
            double a = Convert.ToDouble(str[0]);
            double b = Convert.ToDouble(str[1]);
            double c = Convert.ToDouble(str[2]);

            double cosC = (a * a + b * b - c * c) / (2 * a * b);
            double cosB = (a * a + c * c - b * b) / (2 * a * c);
            double cosA = (b * b + c * c - a * a) / (2 * b * c);

            double p = 0.5 * (a + b + c);
            double S = Math.Sqrt(p * (p - a) * (p - b) * (p - c));


            if (a + b > c && a + c > b && b + c > a){
                if (cosA == cosB && cosA == cosC && cosB == cosC){ // 等边
                    if (cosA == 0 || cosB == 0 || cosC == 0)
                        Console.WriteLine("你输入的三条边组成了一个等边直角三角形，它的面积是{0}", S);
                    else if (cosA < 0 || cosB < 0 || cosC < 0)
                        Console.WriteLine("你输入的三条边组成了一个等边钝角三角形，它的面积是{0}", S);
                    else
                        Console.WriteLine("你输入的三条边组成了一个等边锐角三角形，它的面积是{0}", S);
                }
                else if (cosA == cosB || cosA == cosC || cosB == cosC){ // 等腰
                    if (cosA == 0 || cosB == 0 || cosC == 0)
                        Console.WriteLine("你输入的三条边组成了一个等腰直角三角形，它的面积是{0}", S);
                    else if (cosA < 0 || cosB < 0 || cosC < 0)
                        Console.WriteLine("你输入的三条边组成了一个等腰钝角三角形，它的面积是{0}", S);
                    else
                        Console.WriteLine("你输入的三条边组成了一个等腰锐角三角形，它的面积是{0}", S);
                }
                else{ // 一般
                    if (cosA == 0 || cosB == 0 || cosC == 0)
                        Console.WriteLine("你输入的三条边组成了一个一般直角三角形，它的面积是{0}", S);
                    else if (cosA < 0 || cosB < 0 || cosC < 0)
                        Console.WriteLine("你输入的三条边组成了一个一般钝角三角形，它的面积是{0}", S);
                    else
                        Console.WriteLine("你输入的三条边组成了一个一般锐角三角形，它的面积是{0}", S);
                }
            }
            else{
                Console.WriteLine("你输入的三条边不能构成1个三角形");
            }
        }
    }
}