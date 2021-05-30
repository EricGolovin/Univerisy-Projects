public class Main {
    public static void main(String[] args) {
        Road mainRoad = new Road("Main Road");

        addStationsToRoad(mainRoad, 3);
        addBussesToRoad(mainRoad, 7);

        mainRoad.startTheRace();
    }

    static void addStationsToRoad(Road road, int numberOfStations) {
        for (int i = 0; i < numberOfStations; i++) {
            Station newStation = new Station(String.format("Station|%d|", i + 1), i % 2 == 0 ? 1 : 3);
            road.addStation(newStation);
        }
    }

    static void addBussesToRoad(Road road, int numberOfBasses) {
        for (int i = 0; i < numberOfBasses; i++) {
            Bus newBus = new Bus(String.format("Bus_%d_", i + 1), road);
            road.addBus(newBus);
        }
    }
}
