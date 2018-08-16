package dk.stelinno.worldunreal;

public interface LocationService {
    SimpleLocation currentLocation();
    boolean isAtLocation(double currentLat, double currentLon, double expectedLat, double expectedLon);
    void start();
}