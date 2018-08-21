package dk.stelinno.worldunreal;

public class SimpleLogService implements LogService {

    private static LogService _instance = new SimpleLogService();
    private StringBuilder _cache;
    private String _logEndPoint;

    private SimpleLogService() {
        _logEndPoint = System.getProperty("log.endpoint");
        _cache = new StringBuilder();
        new Thread(() -> {syncLog();}).start();
    }

    public static LogService getInstance() {
        return _instance;
    }

    private synchronized void syncLog() {
        while(true) {
            try {
                _cache.insert(0, "{\"message\":");
                _cache.append("}");
                HttpService.getInstance().postHttpData(_logEndPoint, _cache.toString());
                _cache.delete(0, _cache.length());
            } catch (Exception e) {
                e.printStackTrace();
            }
            try {
                Thread.sleep(5000);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
    }

    @Override
    public synchronized void LogMessage(String message) {
        _cache.append(message);
        _cache.append("\r\n");
    }
}
