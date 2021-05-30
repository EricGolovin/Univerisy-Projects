import java.util.ArrayList;
import java.util.UUID;

public class Road {
    private String name;
    private ArrayList<Bus> totalBusses = new ArrayList<Bus>();
    private ArrayList<Station> totalStations = new ArrayList<Station>();

    public Road(String name) {
        this.name = name;
    }

    public synchronized void addBus(Bus bus) {
        totalBusses.add(bus);
    }

    public synchronized void addStation(Station station) {
        totalStations.add(station);
    }

    public void startTheRace() {
        for (Bus bus : totalBusses) {
            new Thread(bus).start();
        }
    }

    public synchronized void processStopRequestOfBus(Bus bus) {
        UUID lastBusStationId = null;
        try {
            lastBusStationId = bus.getLastStationId();
        } catch (Exception exception) {
            System.out.println(exception.getMessage());
            if (totalStations.isEmpty()) { return; }

            Station firstStation = totalStations.get(0);
            try {
                firstStation.addBus(bus);
                bus.setCurrentStation(firstStation);
                bus.processTheStop();
            } catch (Exception exception1) {
                System.out.println(exception1.getMessage());
                bus.waitForTheStop();
            }
        }

        Boolean canStop = false;
        for (int i = 0; i < totalStations.size(); i++) {
            Station iterator = totalStations.get(i);
            if (canStop) {
                try {
                    iterator.addBus(bus);
                    bus.setCurrentStation(iterator);
                    bus.processTheStop();
                } catch (Exception exception) {
                    System.out.println(exception.getMessage());
                    bus.waitForTheStop();
                }
                return;
            }
            if (iterator.getId() == lastBusStationId) {
                canStop = true;
                if (i + 1 == totalStations.size()) {
                    bus.endTheTrip();
                }
            }
        }
    }
}
