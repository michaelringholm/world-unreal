package dk.stelinno.worldunreal;

public class SimpleLocation {
    private double _latitude;
    private double _longitude;

    public SimpleLocation(double latitude, double longitude) {
        _latitude = latitude; _longitude = longitude;
    }

    public double getLongitude() {
        return _longitude;
    }

    public void setLongitude(double longitude) {
        _longitude = longitude;
    }

    public double getLatitude() {
        return _latitude;
    }

    public void setLatitude(double latitude) {
        _latitude = latitude;
    }
}
