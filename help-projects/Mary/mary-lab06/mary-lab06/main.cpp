//
//  main.cpp
//  mary-lab06
//
//  Created by Eric Golovin on 25.05.2020.
//  Copyright © 2020 com.ericgolovin. All rights reserved.
//

#include <iostream>
#include <sstream>
#include <string>
#include <fstream>
#include <vector>
#include <map>
#include <iterator>
using namespace std;

string convertCharToString(char array[]) {
    string resultString = "";
    for (int i = 0; array[i] != 0; i++) {
        resultString += string(1, array[i]);
    }
    return resultString;
}

string getWordsFromWordsArray(char words[][20], int count) {
    stringstream resultStringStream;
    
    for (int i = 0; i < count; i++) {
        string word = convertCharToString(words[i]);
        
        resultStringStream << word << " - from the exceptional list" << endl;
    }
    
    resultStringStream << endl;
    
    return resultStringStream.str();
}

string performLetterCalculation(vector<string> words, char exceptionalWords[][20], int exceptionalCount) {
    stringstream resultStringStream;
    map<string, vector<string>> letters;
    bool flag = false;
    
    for (int i = 0; i < words.size(); i++) {
        string word = words[i];
        transform(word.begin(), word.end(), word.begin(), ::tolower);
        word.erase(remove(word.begin(), word.end(), '.'), word.end());
        
        for (int q = 0; q < exceptionalCount; q++) {
            string exceptional = convertCharToString(exceptionalWords[q]);
            
            if (exceptional == word) {
                cout << "Found exceptional Word: " << word << endl;
                flag = true;
                break;
            }
        }
        
        if (flag) {
            flag = false;
            continue;
        }
        
        string firstLetter = string(1, word.at(0));
        
        if (letters.find(firstLetter) == letters.end()) {
            vector<string> wordsByLetter;
            wordsByLetter.push_back(words[i]);
            
            letters.insert(pair<string, vector<string>>(firstLetter, wordsByLetter));
        } else {
            letters.find(firstLetter)->second.push_back(word);
        }
    }
    
    for (auto pair = letters.begin(); pair != letters.end(); ++pair) {
        resultStringStream <<  pair->first << " -> ";
        for (int q = 0; q < pair->second.size(); q++) {
            resultStringStream << pair->second[q] << " ";
        }
        resultStringStream << "(" << pair->second.size() << ")" << endl << endl;
    }
    
    return resultStringStream.str();
}

int main(int argc, const char * argv[]) {
    
    ifstream inputFile("/Users/ericgolovin/Developer/c_c++/Univerisy-Projects/help-projects/Mary/mary-lab06/mary-lab06/inputFile.txt");
    ofstream output("/Users/ericgolovin/Developer/c_c++/Univerisy-Projects/help-projects/Mary/mary-lab06/mary-lab06/outputFile.txt");
    istream_iterator<string> start(inputFile), end;
    
    vector<string> wordsFromFile(start, end);
    
    char exceptionalWords[][20] = {"it", "me", "but", "so", "do"};
    
    output << getWordsFromWordsArray(exceptionalWords, 5);
    
    output << performLetterCalculation(wordsFromFile, exceptionalWords, 5);
    
    output.close();
    
    return 0;
}
