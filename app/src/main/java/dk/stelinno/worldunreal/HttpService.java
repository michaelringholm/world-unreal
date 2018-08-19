package dk.stelinno.worldunreal;

import java.io.ByteArrayOutputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.concurrent.CompletableFuture;
import java.util.concurrent.Future;

import static android.provider.ContactsContract.CommonDataKinds.Website.URL;

public class HttpService {
    private static HttpService _instance = new HttpService();

    private HttpService() {

    }

    public static HttpService getInstance() {
        return _instance;
    }

    public void postData2(String endpoint, String data) {
        /*HttpClient httpclient = new DefaultHttpClient();
        HttpResponse response = httpclient.execute(new HttpGet(URL));
        StatusLine statusLine = response.getStatusLine();
        if(statusLine.getStatusCode()==HttpStatus.SC_OK)

        {
            ByteArrayOutputStream out = new ByteArrayOutputStream();
            response.getEntity().writeTo(out);
            String responseString = out.toString();
            out.close();
            //..more logic
        } else

        {
            //Closes the connection.
            response.getEntity().getContent().close();
            throw new IOException(statusLine.getReasonPhrase());
        }*/
    }

    public void postHttpDataAsync(String endpoint, String data) throws Exception {
        //CompletableFuture future = new CompletableFuture();
        new Thread(() -> postHttpData(endpoint, data)).start();

    }
    // https://requestbin.fullcontact.com/15jhhdb1?inspect
    private void postHttpData(String endpoint, String data)  {
        HttpURLConnection con = null;
        DataOutputStream out = null;
        try {
            java.net.URL url = new URL(endpoint);
            con = (HttpURLConnection) url.openConnection();
            con.setRequestMethod("POST");
            con.setConnectTimeout(1000);
            con.setRequestProperty("Content-Type", "application/json");
            con.setDoOutput(true);
            out = new DataOutputStream(con.getOutputStream());
            out.writeBytes(data);
            out.flush();
        }
        catch(Exception ex) {
            ex.printStackTrace();
        }
        finally {
            if(out != null) {
                try {out.close();} catch (IOException e) {e.printStackTrace();}
            }
            if(con != null)
                con.disconnect();
        }
    }
}
