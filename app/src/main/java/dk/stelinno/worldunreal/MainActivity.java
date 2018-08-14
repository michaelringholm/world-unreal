package dk.stelinno.worldunreal;

import android.Manifest;
import android.animation.ArgbEvaluator;
import android.animation.ObjectAnimator;
import android.animation.ValueAnimator;
import android.content.Context;
import android.content.pm.PackageManager;
import android.graphics.Color;
import android.graphics.drawable.Drawable;
import android.graphics.drawable.PictureDrawable;
import android.graphics.drawable.VectorDrawable;
import android.location.Location;
import android.location.LocationListener;
import android.location.LocationManager;
import android.os.Bundle;
import android.support.annotation.NonNull;
import android.support.design.widget.BottomNavigationView;
import android.support.v4.app.ActivityCompat;
import android.support.v7.app.AppCompatActivity;
import android.view.MenuItem;
import android.view.animation.Animation;
import android.widget.ImageView;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity {

    private TextView mTextMessage;
    private TextView latitude;
    private TextView longitude;
    private ImageView mainImage;

    private BottomNavigationView.OnNavigationItemSelectedListener mOnNavigationItemSelectedListener
            = new BottomNavigationView.OnNavigationItemSelectedListener() {

        @Override
        public boolean onNavigationItemSelected(@NonNull MenuItem item) {
            switch (item.getItemId()) {
                case R.id.navigation_home:
                    mTextMessage.setText(R.string.title_home);
                    return true;
                case R.id.navigation_dashboard:
                    mTextMessage.setText(R.string.title_dashboard);
                    return true;
                case R.id.navigation_notifications:
                    mTextMessage.setText(R.string.title_notifications);
                    return true;
            }
            return false;
        }
    };

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        mTextMessage = findViewById(R.id.message);
        latitude = findViewById(R.id.latitude);
        longitude = findViewById(R.id.longitude);
        mainImage = findViewById(R.id.mainImage);
        BottomNavigationView navigation = (BottomNavigationView) findViewById(R.id.navigation);
        navigation.setOnNavigationItemSelectedListener(mOnNavigationItemSelectedListener);

        // Acquire a reference to the system Location Manager
        LocationManager locationManager = (LocationManager) this.getSystemService(Context.LOCATION_SERVICE);
        // Define a listener that responds to location updates
        LocationListener locationListener = new LocationListener() {
            @Override
            public void onLocationChanged(Location location) {
                latitude.setText(String.valueOf(location.getLatitude()));
                longitude.setText(String.valueOf(location.getLongitude()));
                animText(latitude);
                animText(longitude);

                if(location.getLatitude() == 55.6967093 && location.getLongitude() == 12.4173003)
                    Log("You found an old rusty sword under a pile of rubble!");
                if(location.getLatitude() == 55.6962571 && location.getLongitude() == 12.4173742)
                    Log("You found an small chest buried beneath the dirt!");
                if(location.getLatitude() == 55.6967119 && location.getLongitude() == 12.4173312)
                    Log("A skeleton appear from behind the bushes!");
                if(location.getLatitude() == 55.6967261 && location.getLongitude() == 12.4173368)
                    Log("You found a glowing necklace on the path!");

                //if(location.getLatitude() == 55.5699629 && location.getLongitude() == 12.2714676)
                if((location.getLatitude() >= 55.5699550 && location.getLatitude() <= 55.5699700) && (location.getLongitude() >= 12.2714300 && location.getLongitude() <= 12.2715500)) {
                    Log("You found some lumber, now please go and give it to the innkeeper, hurry!");
                    int resID = getResources().getIdentifier("lumber","drawable", getPackageName());
                    mainImage.setImageResource(resID);
                }

                //if(location.getLatitude() == 55.5698926 && location.getLongitude() == 12.2712468) {
                if((location.getLatitude() >= 55.5698900 && location.getLatitude() <= 55.5699200) && (location.getLongitude() >= 12.2712200 && location.getLongitude() <= 12.2712700)) {
                    Log("The innkeeper greets you, thank you my friend that will come in handy!");
                    int resID = getResources().getIdentifier("innkeeper","drawable", getPackageName());
                    mainImage.setImageResource(resID);
                }
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

        //((TextView)findViewById(R.id.test)).setText("step1");

        // Register the listener with the Location Manager to receive location updates
        long minTime = 10;
        float minDistance = 1;
        if (ActivityCompat.checkSelfPermission(this, Manifest.permission.ACCESS_FINE_LOCATION) != PackageManager.PERMISSION_GRANTED && ActivityCompat.checkSelfPermission(this, Manifest.permission.ACCESS_COARSE_LOCATION) != PackageManager.PERMISSION_GRANTED) {
            ActivityCompat.requestPermissions(this, new String[]{Manifest.permission.ACCESS_COARSE_LOCATION, Manifest.permission.ACCESS_FINE_LOCATION, Manifest.permission.INTERNET}, 10);
            return;
        }
        locationManager.requestLocationUpdates(LocationManager.NETWORK_PROVIDER, minTime, minDistance, locationListener);
        Log("Please find some lumber and give it to the innkeeper!");
    }

    @Override
    public void onRequestPermissionsResult(int requestCode, String[] permissions, int[] grantResults) {

    }

    private void Log(String message) {
        TextView description = (TextView) findViewById(R.id.description);
        description.setText(message);
        animText(description);
    }

    private void animText(TextView textView) {
        ObjectAnimator anim = ObjectAnimator.ofInt(textView, "backgroundColor", Color.WHITE, Color.RED, Color.WHITE);
        anim.setDuration(1500);
        anim.setEvaluator(new ArgbEvaluator());
        anim.setRepeatMode(1);
        //anim.setRepeatCount(Animation.INFINITE);
        anim.start();
    }


}
