package dk.stelinno.worldunreal;

import android.annotation.SuppressLint;
import android.location.Location;
import android.location.LocationListener;
import android.location.LocationManager;
import android.os.Bundle;

import java.util.Observable;
import java.util.Observer;

public class SimpleLocationService extends Observable implements LocationService {
    private LocationManager _locationManager;
    private LocationListener _locationListener;

    public SimpleLocationService(LocationManager locationManager) {
        _locationManager = locationManager;

        _locationListener = new LocationListener() {
            @Override
            public void onLocationChanged(Location location) {
                MainActivity.getCurrent().Log("onLocationChanged called!");
                SimpleLocation simpleLocation = new SimpleLocation(location.getLatitude(),location.getLongitude());
                setChanged();
                notifyObservers(simpleLocation);
                int observerCount = SimpleLocationService.super.countObservers();
                MainActivity.getCurrent().Log("[" + observerCount + "] observers have been notified!");
            }

            @Override
            public void onStatusChanged(String provider, int status, Bundle extras) {
            }

            @Override
            public void onProviderEnabled(String provider) {
            }

            @Override
            public void onProviderDisabled(String provider) {
            }
        };
    }

    public void addObserver(Observer observer) {
        super.addObserver(observer);
    }

    @SuppressLint("MissingPermission")
    public void start() {
        MainActivity.getCurrent().Log("start called!");
        long minTime = 0;
        float minDistance = 0;
        _locationManager.requestLocationUpdates(LocationManager.GPS_PROVIDER, minTime, minDistance, _locationListener);
        //_locationManager.requestLocationUpdates(LocationManager.NETWORK_PROVIDER, minTime, minDistance, _locationListener);
        MainActivity.getCurrent().Log("request updates called!");
    }

    public SimpleLocation currentLocation() {
        return null;
    }

    public boolean isAtLocation(double currentLat, double currentLon, double expectedLat, double expectedLon) {
        double tolerance = 0.001;
        if((currentLat >= expectedLat-tolerance && currentLat <= expectedLat+tolerance) && (currentLon >= expectedLon-tolerance && currentLon <= expectedLon+tolerance))
            return true;
        return false;
    }
}
