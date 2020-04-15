//
//  main.cpp
//  PR-lab02-03-forMary
//
//  Created by Eric Golovin on 07.04.2020.
//  Copyright © 2020 Eric Golovin. All rights reserved.
//

#include "BaseClass.cpp"

class CardDeck: public Base<Card> {
    private:
        //vector<Card> cards;
    public:
        string name;
        Manufacturer manufacturer;
        int numberOfCards;

        void printManufactureNameLocation() {
            stringstream convertStrStream;
            convertStrStream << manufacturer.location.buildingNumber;
            string outputArguments[4] = {manufacturer.name, manufacturer.location.city, manufacturer.location.street, convertStrStream.str()};
            printWithStrArguments("Manufacturer name: ~ \nManufaturer location(city: ~, street: ~, building: ~)", outputArguments, 4);
        }

        void printNumberCardsOfSuit(CardSuit suit) {
            int result = 0;

            for (int i = 0; i < numOfElements(); i++) {
                if (getCardByIndex(i).suit == suit) {
                    ++result;
                }
            }

            int argumentsForPrinting[1] = {result};
            printWithArguments("There are ~ of cards of specified suit", argumentsForPrinting, 1);
        }

        void addCard(Card newCard) {
            int allowToAdd = 1;
            for (int i = 0; i < numOfElements(); i++) {
                if (newCard.id == getCardByIndex(i).id && newCard.suit == getCardByIndex(i).suit) {
                    allowToAdd = 0;
                }
            }
            if (allowToAdd) {
                addElement(newCard);
                print("Added Card");
            } else {
                print("Card cannot be added, it already exists");
            }
        }

        void deleteCard(CardID id, CardSuit suit) {
            int deleted = 0;
            for (int i = 0; i < numOfElements(); i++) {
                if (id == getCardByIndex(i).id && suit == getCardByIndex(i).suit) {
                    deleteElementByIndex(i);
                    deleted = 1;
                }
            }

            if (deleted) {
                print("Deleted Card");
            }
        }

        void calculateNumberOfCardsIds() {
            int kings = 0, queens = 0, jacks = 0, aces = 0;
            int ones = 0, twos = 0, threes = 0, fours = 0, fives = 0, sixs = 0, sevens = 0, eights = 0, nines = 0, tens = 0;

            for (int i = 0; i < numOfElements(); i++) {
                switch (getCardByIndex(i).id) {
                    case king:
                        ++kings;
                        break;
                    case queen:
                        ++queens;
                        break;
                    case jack:
                        ++jacks;
                        break;
                    case ace:
                        ++aces;
                        break;
                    case one:
                        ++ones;
                        break;
                    case two:
                        ++twos;
                        break;
                    case three:
                        ++threes;
                        break;
                    case four:
                        ++fours;
                        break;
                    case five:
                        ++fives;
                        break;
                    case six:
                        ++sixs;
                        break;
                    case seven:
                        ++sevens;
                        break;
                    case eight:
                        ++eights;
                        break;
                    case nine:
                        ++nines;
                        break;
                    case ten:
                        ++tens;
                        break;
                    default:
                        cout << "Error: No Card ID (index#" << i << ")" << endl;
                        break;
                }
            }

            int printingArguments[14] = {kings, queens, jacks, aces, ones, twos, threes, fours, fives, sixs, sevens, eights, nines, tens};
            printWithArguments("kingS: ~, queenS: ~, jackS: ~, aceS: ~\noneS: ~, twoS: ~, threeS: ~, fourS: ~, fiveS: ~, sixS: ~, sevenS: ~, eightS: ~, nineS: ~, tenS: ~", printingArguments, 14);
        }

        void printNumberOfMissingCards() {
            int printingArguments[1] = {numberOfCards - numOfElements()};
            printWithArguments("Number of missing cards: ~", printingArguments, 1);
        }

        void printPercentageOfExistingCards() {
            int printingArguments[1] = {numOfElements() * 100 / numberOfCards};
            printWithArguments("Number of missing cards: ~", printingArguments, 1); 
        }
};

int main(int argc, const char * argv[]) {

    CardDeck someDeck;

    Manufacturer someManufacture;
    someManufacture.location.city = "Kharkiv";
    someManufacture.location.street = "Klochkivska";
    someManufacture.location.buildingNumber = 11;

    someDeck.manufacturer = someManufacture;
    someDeck.name = "My Deck";
    someDeck.numberOfCards = 20;

    CardSuit suit = clubs;
    for (int i = 0; i < 4; ++i) {
        switch (i) {
            case 1:
                suit = diamonds;
                break;
            case 2:
                suit = hearts;
                break;
            case 3:
                suit = spades;
                break;
            default:
                break;
        }
        for (int index = 0; index < 5; index++) {
            Card card;
            card.suit = suit;
            switch (index) {
                case 0:
                    card.id = king;
                    someDeck.addCard(card);
                    break;
                case 1:
                    card.id = queen;
                    someDeck.addCard(card);
                    break;
                case 2:
                    card.id = jack;
                    someDeck.addCard(card);
                    break;
                case 3:
                    card.id = ace;
                    someDeck.addCard(card);
                    break;
                case 4:
                    card.id = ten;
                    someDeck.addCard(card);
                    break;
                default:
                    break;
            }
        }
    }

    someDeck.printManufactureNameLocation();
    cout << endl;

    someDeck.printNumberCardsOfSuit(hearts);
    cout << endl;

    someDeck.deleteCard(ten, diamonds);
    someDeck.deleteCard(ace, diamonds);
    someDeck.deleteCard(king, spades);
    someDeck.deleteCard(jack, spades);
    cout << endl;

    someDeck.calculateNumberOfCardsIds();
    cout << endl;

    someDeck.printNumberOfMissingCards();
    cout << endl;

    someDeck.printPercentageOfExistingCards();
    cout << endl;

    return 0;
}
