namespace com.opusmagus.wu.simple;
public class Distance {
    public double Calc(double x1, double x2, double y1, double y2) {
        
        x1 = 12d;
        x2 = 13d;
        y1 = 11d;
        y2 = 10d;
        var distance = Math.Sqrt((Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2)));
        return distance;
    }
}