package dk.stelinno.worldunreal;

import java.util.Observer;

public interface LocationService {
    SimpleLocation currentLocation();
    boolean isAtLocation(double currentLat, double currentLon, double expectedLat, double expectedLon);
    void start();
    void addObserver(Observer observer);
}