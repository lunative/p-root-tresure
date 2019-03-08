using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public struct Point
{
    public int x, y;
    public Point(int x, int y) { this.x = x; this.y = y; }
}

public class Hello{
    // 順列列挙用の関数
    public static IEnumerable<T[]> Enumerate<T>(IEnumerable<T> items) {
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

    public static void Main(){
        // 自分の得意な言語で
        // Let's チャレンジ！！

        string line=System.Console.ReadLine();
        // お宝の総数
        int tresure_count=int.Parse(line);

        // 位置と原点からの距離のリスト
        //var pointTable=new SortedDictionary<double, Point>();
        // 位置のリスト
        var pointList=new List<Point>();
        //IEnumerable<Point> pointList;
        //pointList.AddRange(new Point(0,0));
        pointList.Add(new Point(0,0));
        //Console.WriteLine(pointList[0].x);

        // 位置リストを完成させる
        for (int tresure_num=0; tresure_num<tresure_count; tresure_num++){
            string line_next=System.Console.ReadLine();
            string[] tresure_posi=line_next.Split(' ');
            pointList.Add(new Point(int.Parse(tresure_posi[0]), int.Parse(tresure_posi[1])));
        }

        // N個の宝物の位置の順序の総数はN!(N*N-1...*2*1)
        Enumerate(pointList);

    }
}