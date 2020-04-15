#include <iostream>
#include <vector>
#include <sstream>
using namespace std;

enum CardSuit {
    clubs,
    diamonds,
    hearts,
    spades
};

enum CardID {
    king,
    queen,
    jack,
    ace,
    one,
    two,
    three,
    four,
    five,
    six,
    seven,
    eight,
    nine,
    ten
};

typedef struct {
    string city;
    string street;
    int buildingNumber;
} Location;

typedef struct {
    string name;
    Location location;
} Manufacturer;

typedef struct {
    CardSuit suit;
    CardID id;
} Card;

