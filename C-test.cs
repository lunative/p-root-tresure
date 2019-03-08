using System;
using System.Collections.Generic;
using System.Linq;

public struct Point
{
    public int x, y;
    public Point(int x, int y) { this.x = x; this.y = y; }
}

public class Hello{
    public static void Main(){
        // 自分の得意な言語で
        // Let's チャレンジ！！

        string line=System.Console.ReadLine();
        // お宝の総数
        int tresure_count=int.Parse(line);

        // 位置と原点からの距離のリスト
        var pointTable=new SortedDictionary<double, Point>();

        // お宝リスト
        for (int tresure_num=0; tresure_num<tresure_count; tresure_num++){
            string line_next=System.Console.ReadLine();
            string[] tresure_posi=line_next.Split(' ');
            Point tresure_point=new Point(int.Parse(tresure_posi[0]), int.Parse(tresure_posi[1]));
            double distance=Math.Sqrt(Math.Pow(tresure_point.x, 2)+Math.Pow(tresure_point.y, 2));
            pointTable.Add(distance, tresure_point);
        }

        // 次の原点
        Point nextPoint=new Point(0, 0);
        // 原点からの移動距離
        KeyValuePair<double, Point> firstPair=pointTable.First();
        Console.WriteLine(firstPair.Value.x+" "+firstPair.Value.y);
        nextPoint.x=firstPair.Value.x;
        nextPoint.y=firstPair.Value.y;
        pointTable.Remove(firstPair.Key);

        for (int tresure_num=1; tresure_num<tresure_count; tresure_num++) {
            // 毎回nextPointTableを作成
            var nextPointTable=new SortedDictionary<double, Point>();
            // 原点からの距離を再計算
            foreach(KeyValuePair<double, Point> pair in pointTable) {
                int diffX=pair.Value.x-nextPoint.x;
                int diffY=pair.Value.y-nextPoint.y;
                nextPointTable.Add(Math.Sqrt(Math.Pow(diffX, 2)+Math.Pow(diffY, 2)), pair.Value);
            }
            // 次に近い点を表示
            KeyValuePair<double, Point> nextPair=nextPointTable.First();
            Console.WriteLine(nextPair.Value.x+" "+nextPair.Value.y);
            nextPoint.x=nextPair.Value.x;
            nextPoint.y=nextPair.Value.y;
            // 最初に見つけた同じValueのKeyを削除
            var item=pointTable.First(kvp=>kvp.Value.x==nextPair.Value.x);
            pointTable.Remove(item.Key);
            nextPointTable.Clear();
        }
    }
}
