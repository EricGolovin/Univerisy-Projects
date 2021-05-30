import java.util.ArrayList;
import java.util.UUID;

public class Station {
    private String name;
    private int maxNumberOfBuses;
    private ArrayList<Bus> stoppedBuses = new ArrayList<Bus>();
    private UUID id = UUID.randomUUID();

    public Station(String name, int maxNumberOfBuses) {
        this.name = name;
        this.maxNumberOfBuses = maxNumberOfBuses;
    }

    public UUID getId() {
        return id;
    }

    public synchronized void addBus(Bus bus) throws Exception {
        if (stoppedBuses.size() == maxNumberOfBuses) { throw new Exception(String.format("!!! %s - Cannot fit more buses", name)); }
        stoppedBuses.add(bus);
    }

    public synchronized void removeBus(Bus bus) {
        for (int i = 0; i < stoppedBuses.size(); i++) {
            if (stoppedBuses.get(i).getId() == bus.getId()) {
                stoppedBuses.remove(i);
            }
        }
    }
}
