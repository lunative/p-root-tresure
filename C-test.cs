using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public struct Point
{
    public int x, y;
    public Point(int x, int y) { this.x = x; this.y = y; }
}

public class Permutation {
    public IEnumerable<T[]> Enumerate<T>(IEnumerable<T> items) {
        if (items.Count() == 1) {
            yield return new T[] { items.First() };
            yield break;
        }
        foreach (var item in items) {
            var leftside = new T[] { item };
            var unused = items.Except(leftside);
            foreach (var rightside in Enumerate(unused)) {
                yield return leftside.Concat(rightside).ToArray();
            }
        }
    }
}

public class Hello{
    public static void Main(){
        string line=System.Console.ReadLine();
        // お宝の総数
        int tresure_count=int.Parse(line);
        // 位置のリスト
        var pointList=new List<Point>();
        
        // 位置リストを完成させる
        for (int tresure_num=0; tresure_num<tresure_count; tresure_num++){
            string line_next=System.Console.ReadLine();
            string[] tresure_posi=line_next.Split(' ');
            pointList.Add(new Point(int.Parse(tresure_posi[0]), int.Parse(tresure_posi[1])));
        }

        // N個の宝物の位置の順序の総数はN!(N*N-1...*2*1)
        var perm = new Permutation();
        double minDistance=0;
        var minPointList=new List<Point>();
        foreach (var n in perm.Enumerate(pointList)) {
            int posX=0, posY=0;
            double distance=0;
            foreach (var x in n) {
                //Console.Write("{0} {1}  ", x.x, x.y);
                distance+=(Math.Sqrt(Math.Pow(x.x-posX,2)+Math.Pow(x.y-posY,2)));
                posX=x.x;
                posY=x.y;
            }
            // 距離
            //Console.WriteLine(distance);
            if (minDistance==0 || minDistance>distance) {
                minDistance=distance;
                minPointList.Clear();
                foreach (var x in n) {
                    minPointList.Add(new Point(x.x,x.y));
                }
            }
            // 改行
            //Console.WriteLine();
        }
        //Console.WriteLine(minDistance);
        foreach (var i in minPointList) {
            Console.WriteLine("{0} {1}", i.x, i.y);
        }
    }
}