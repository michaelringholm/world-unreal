namespace com.opusmagus.wu.simple;
public class Distance {
    public static double Calc(double x1, double x2, double y1, double y2) {
        var distance = Math.Sqrt((Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2)));
        return distance;
    }
}