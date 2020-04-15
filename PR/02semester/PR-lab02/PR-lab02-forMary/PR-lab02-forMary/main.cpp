//
//  main.cpp
//  PR-lab02-03-forMary
//
//  Created by Eric Golovin on 07.04.2020.
//  Copyright © 2020 Eric Golovin. All rights reserved.
//

#include "BaseClass.cpp"

class CardDeck {
    private:
        vector<Card> cards;
    public:
        string name;
        Manufacturer manufacturer;
        int numberOfCards;

        void printManufactureNameLocation() {
            cout << "Manufacture name: " << manufacturer.name << endl;
            cout << "Manufacure location(city: " << manufacturer.location.city << ", street: " << manufacturer.location.street << ", building: " << manufacturer.location.buildingNumber << ")" << endl;
        }

        void printNumberCardsOfSuit(CardSuit suit) {
            int result = 0;

            for (int i = 0; i < cards.size(); i++) {
                if (cards[i].suit == suit) {
                    ++result;
                }
            }

            cout << "There are " << result << " of cards of specified suit" << endl;
        }

        void addCard(Card newCard) {
            int allowToAdd = 1;
            for (int i = 0; i < cards.size(); i++) {
                if (newCard.id == cards[i].id && newCard.suit == cards[i].suit) {
                    allowToAdd = 0;
                }
            }
            if (allowToAdd) {
                cards.push_back(newCard);
                cout << "Added Card" << endl;
            } else {
                cout << "Cannot add Card, it already exists" << endl;
            }
        }

        void deleteCard(CardID id, CardSuit suit) {
            int deleted = 0;
            for (int i = 0; i < cards.size(); i++) {
                if (id == cards[i].id && suit == cards[i].suit) {
                    cards.erase(cards.begin() + i);
                    deleted = 1;
                }
            }

            if (deleted) {
                cout << "Deleted Card" << endl;
            }
        }

        void calculateNumberOfCardsIds() {
            int kings = 0, queens = 0, jacks = 0, aces = 0;
            int ones = 0, twos = 0, threes = 0, fours = 0, fives = 0, sixs = 0, sevens = 0, eights = 0, nines = 0, tens = 0;

            for (int i = 0; i < cards.size(); i++) {
                switch (cards[i].id) {
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

            cout << "kingS: " << kings << ", queenS: " << queens << ", jackS: " << jacks << ", aceS: " << aces << endl;
            cout << "oneS: " << ones << ", twoS: " << twos << ", threeS: " << threes << ", fourS: " << fours;
            cout << ", fiveS: " << fives << ", sixS: " << sixs << ", sevenS: " << sevens << ", eightS: " << eights;
            cout << ", nineS: " << nines << ", tenS: " << tens << endl;
        }

        void printNumberOfMissingCards() {
            cout << "Number of missing cards: " << numberOfCards - cards.size() << endl;
        }

        void printPercentageOfExistingCards() {
            cout << "Percentage of exisiting cards: " << cards.size() * 100 / numberOfCards << endl;
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
