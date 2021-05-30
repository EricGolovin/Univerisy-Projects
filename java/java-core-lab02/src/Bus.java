import java.util.ArrayList;
import java.util.UUID;

public class Bus implements Runnable {
    private String name;
    private Road currentRoad;
    private Station currentStation;
    private ArrayList<UUID> historyOfStation = new ArrayList<UUID>();
    private UUID id = UUID.randomUUID();

    public Bus(String name, Road currentRoad) {
        this.name = name;
        this.currentRoad = currentRoad;
    }

    public UUID getId() {
        return id;
    }

    public UUID getLastStationId() throws Exception {
        if (historyOfStation.isEmpty()) { throw new Exception("Station history is empty"); }
        return historyOfStation.get(historyOfStation.size() - 1);
    }

    public synchronized void setCurrentRoad(Road road) {
        this.currentRoad = road;
    }

    public synchronized void setCurrentStation(Station station) {
        this.currentStation = station;
        historyOfStation.add(station.getId());
    }

    public void startGoing() {
        System.out.println(String.format("-> -> -> %s started", name));
        sleepThread();
        requestToStop();
    }

    public void waitForTheStop() {
        System.out.println(String.format("-> -> %s waiting", name));
        startGoing();
    }

    public void processTheStop() {
        System.out.println(String.format("-> %s stopped", name));
        sleepThread();
        currentStation.removeBus(this);
        currentStation = null;
        startGoing();
    }

    public void endTheTrip() {
        System.out.println(String.format("^ %s ended the Trip", name));
        currentRoad = null;
    }

    private void sleepThread() {
        try {
            Thread.sleep((long) ((Math.random() * ((500 - 200) + 1)) + 200));
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
    }

    private void requestToStop() {
        currentRoad.processStopRequestOfBus(this);
    }

    @Override
    public void run() {
        startGoing();
    }
}
