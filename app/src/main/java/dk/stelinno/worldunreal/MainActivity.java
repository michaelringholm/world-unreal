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
import android.widget.ScrollView;
import android.widget.TextView;

import java.io.DataOutputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.net.HttpURLConnection;
import java.net.URL;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.GregorianCalendar;
import java.util.Observable;
import java.util.Observer;

public class MainActivity extends AppCompatActivity implements Observer {

    private TextView mTextMessage;
    public TextView latitude;
    public TextView longitude;
    private TextView _logView;
    private ScrollView _logScrollView;
    public ImageView mainImage;
    private LocationService _locationService;

    private static MainActivity _instance = null;
    public static MainActivity getCurrent() {
        if(_instance != null)
            return _instance;
        else
            return null;
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        _instance = this;
        setContentView(R.layout.activity_main);

        mTextMessage = findViewById(R.id.message);
        latitude = findViewById(R.id.latitude);
        longitude = findViewById(R.id.longitude);
        mainImage = findViewById(R.id.mainImage);
        BottomNavigationView navigation = (BottomNavigationView) findViewById(R.id.navigation);
        navigation.setOnNavigationItemSelectedListener(mOnNavigationItemSelectedListener);
        _logScrollView = findViewById(R.id.logScrollView);
        _logView = findViewById(R.id.logView);
        _logView.setEnabled(false);
        writeToFile("log.txt", "this is sample log contents!");

        if (ActivityCompat.checkSelfPermission(this, Manifest.permission.ACCESS_FINE_LOCATION) != PackageManager.PERMISSION_GRANTED && ActivityCompat.checkSelfPermission(this, Manifest.permission.ACCESS_COARSE_LOCATION) != PackageManager.PERMISSION_GRANTED) {
            ActivityCompat.requestPermissions(this, new String[]{Manifest.permission.ACCESS_COARSE_LOCATION, Manifest.permission.ACCESS_FINE_LOCATION, Manifest.permission.INTERNET}, 10);
            return;
        }
        _locationService = new SimpleLocationService((LocationManager)this.getSystemService(Context.LOCATION_SERVICE));
        _locationService.addObserver(this);
        // Register the listener with the Location Manager to receive location updates
        _locationService.start();
        Log("Please find some lumber and give it to the innkeeper!");
    }

    @Override
    public void onRequestPermissionsResult(int requestCode, String[] permissions, int[] grantResults) {
        Log("This was what the user chose!");
        _locationService.start();
    }


    @Override
    public void update(Observable o, Object arg) {
        Log("received update event!");
        if(arg != null && arg instanceof SimpleLocation) {
            SimpleLocation location = (SimpleLocation)arg;

            latitude.setText(String.valueOf(location.getLatitude()));
            longitude.setText(String.valueOf(location.getLongitude()));
            animText(latitude);
            animText(longitude);

            Log("pos=" + location.getLatitude() + ";" + location.getLongitude());
            if (_locationService.isAtLocation(location.getLatitude(), location.getLongitude(),  55.6967093, 12.4173003))
                Log("You found an old rusty sword under a pile of rubble!");
            else if (_locationService.isAtLocation(location.getLatitude(), location.getLongitude(),  55.6967093, 12.4173003))
                Log("You found an small chest buried beneath the dirt!");
            else if (_locationService.isAtLocation(location.getLatitude(), location.getLongitude(),  55.6967093, 12.4173003))
                Log("A skeleton appear from behind the bushes!");
            else if (_locationService.isAtLocation(location.getLatitude(), location.getLongitude(),  55.6967093, 12.4173003))
                Log("You found a glowing necklace on the path!");

            else if (_locationService.isAtLocation(location.getLatitude(), location.getLongitude(),  55.6967093, 12.4173003)) {
                Log("You found some lumber, now please go and give it to the innkeeper, hurry!");
                int resID = getResources().getIdentifier("lumber", "drawable", getPackageName());
                mainImage.setImageResource(resID);
            }

            else if (_locationService.isAtLocation(location.getLatitude(), location.getLongitude(),  55.6967093, 12.4173003)) {
                Log("The innkeeper greets you, thank you my friend that will come in handy!");
                int resID = getResources().getIdentifier("innkeeper", "drawable", getPackageName());
                mainImage.setImageResource(resID);
            }
            else {
                Log("Nothing happens at this location!");
            }
        }
    }

    private static SimpleDateFormat _sdf = new SimpleDateFormat("HH:mm:ss.SSS");
    //private static Calendar _cal = new GregorianCalendar();
    public void Log(String message) {
        String now = _sdf.format(new Date());
        _logView.append(now);_logView.append(" ");_logView.append(message);_logView.append("\r\n");
        _logScrollView.computeScroll();
        _logScrollView.scrollTo(0,_logScrollView.getMaxScrollAmount());
        try {
            HttpService.getInstance().postHttpDataAsync("http://requestbin.fullcontact.com/15jhhdb1", now.concat(" ").concat(message));
        } catch (Exception e) {
            e.printStackTrace();
            //now = _sdf.format(new Date());
            //_logView.append(now);_logView.append(" ");_logView.append(e.getMessage());_logView.append("\r\n");
            //_logScrollView.computeScroll();
            //_logScrollView.scrollTo(0,_logScrollView.getMaxScrollAmount());
        }
        //logView.setText(message);
        //animText(logView);
    }

    public void animText(TextView textView) {
        ObjectAnimator anim = ObjectAnimator.ofInt(textView, "backgroundColor", Color.WHITE, Color.RED, Color.WHITE);
        anim.setDuration(1500);
        anim.setEvaluator(new ArgbEvaluator());
        anim.setRepeatMode(1);
        //anim.setRepeatCount(Animation.INFINITE);
        anim.start();
    }

    public void writeToFile(String filename, String contents) {
        FileOutputStream outputStream = null;
        Log("Writing to file...");
        try {
            outputStream = openFileOutput(filename, Context.MODE_PRIVATE);
            outputStream.write(contents.getBytes());
            outputStream.close();
            Log("Done writing file!");
        } catch (Exception e) {
            e.printStackTrace();
            Log(e.getMessage());
        }
        finally{
            if(outputStream != null) {
                try {
                    outputStream.close();
                } catch (IOException e) {
                    Log(e.getMessage());
                }
            }
        }
    }

    private BottomNavigationView.OnNavigationItemSelectedListener mOnNavigationItemSelectedListener = new BottomNavigationView.OnNavigationItemSelectedListener() {
        @Override
        public boolean onNavigationItemSelected(@NonNull MenuItem item) {
            switch (item.getItemId()) {
                case R.id.navigation_home:
                    mTextMessage.setText(R.string.title_home);
                    //setContentView(R.layout.activity_main);

                    return true;
                case R.id.navigation_dashboard:
                    mTextMessage.setText(R.string.title_dashboard);
                    setContentView(R.layout.activity_home);
                    return true;
                case R.id.navigation_notifications:
                    mTextMessage.setText(R.string.title_notifications);
                    setContentView(R.layout.sample_table_layout);
                    return true;
            }
            return false;
        }
    };
}
