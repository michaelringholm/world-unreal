package dk.stelinno.worldunreal;

import android.Manifest;
import android.annotation.SuppressLint;
import android.content.pm.PackageManager;
import android.location.Location;
import android.location.LocationListener;
import android.location.LocationManager;
import android.os.Bundle;
import android.support.v4.app.ActivityCompat;

import java.util.Observable;

public class SimpleLocationService extends Observable implements LocationService {
    private LocationManager _locationManager;
    private LocationListener _locationListener;

    public SimpleLocationService(LocationManager locationManager) {
        _locationManager = locationManager;

        _locationListener = new LocationListener() {
            @Override
            public void onLocationChanged(Location location) {
                SimpleLocation simpleLocation = new SimpleLocation(location.getLatitude(),location.getLongitude());
                notifyObservers(simpleLocation);
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

    @SuppressLint("MissingPermission")
    public void start() {
        //locationManager.requestLocationUpdates(LocationManager.NETWORK_PROVIDER, minTime, minDistance, locationListener);
        long minTime = 0;
        float minDistance = 0;
        _locationManager.requestLocationUpdates(LocationManager.GPS_PROVIDER, minTime, minDistance, _locationListener);
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
