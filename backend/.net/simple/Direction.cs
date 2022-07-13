namespace com.opusmagus.wu.simple;
public class Direction {

    public enum DirectionEnum{None=-1,N=0,S=1,E=2,W=3};
    public double x { get; set; }
    public double y { get; set; }
    public DirectionEnum significantHeading { get; set; }
    public static Direction Calc(double x1, double x2, double y1, double y2, double length) {
        //(destinationPos - myPos) giver en 2d vector
        var x=(x2-x1)/length;
        var y=(y2-y1)/length;
        var significantHeading=DirectionEnum.None;
        if(Math.Abs(x)>Math.Abs(y)) if(x>0) significantHeading=DirectionEnum.E; else significantHeading=DirectionEnum.W;
        else if(y>0) significantHeading=DirectionEnum.N; else significantHeading=DirectionEnum.S;
        return new Direction{ x=x, y=y, significantHeading=significantHeading };
    }
}