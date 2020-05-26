//
//  main.cpp
//  PR-lab06
//
//  Created by Eric Golovin on 26.05.2020.
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

string formatWord(string word) {
    string mutableWord = word;
    transform(mutableWord.begin(), mutableWord.end(), mutableWord.begin(), ::tolower);
    mutableWord.erase(remove(mutableWord.begin(), mutableWord.end(), '.'), mutableWord.end());
    return mutableWord;
}

int calculateAverageLetterLenght(vector<string> words) {
    int result = 0;
    for (int i = 0; i < words.size(); i++) {
        result += formatWord(words[i]).length();
    }
    return result / words.size();
}

string performWordLengthCalculation(vector<string> words, char exceptionalWords[][20], int exceptionalCount) {
    int averageLength = calculateAverageLetterLenght(words);
    stringstream resultStringStream;
    map<string, double> wordsLengths;
    bool flag = false;
    
    
    resultStringStream << "\t\tAverage Length = " << averageLength << endl;
    for (int i = 0; i < words.size(); i++) {
        string word = formatWord(words[i]);
        
        for (int q = 0; q < exceptionalCount; q++) {
            string exceptionalWord = convertCharToString(exceptionalWords[q]);
            
            if (exceptionalWord == word) {
                cout << "Found exceptional Word: " << word << endl;
                flag = true;
                break;
            }
        }
        
        if (flag) {
            flag = false;
            continue;
        }
        
        if (wordsLengths.find(word) == wordsLengths.end()) {
            wordsLengths.insert(pair<string, double>(word, word.length() / averageLength));
        }
    }
    
    for (auto pair = wordsLengths.begin(); pair != wordsLengths.end(); ++pair) {
        resultStringStream <<  pair->first << " ->_word length to the length of all words_-> ";
        resultStringStream << pair->second << endl;
    }
    
    return resultStringStream.str();
}

int main(int argc, const char * argv[]) {
    
    ifstream inputFile("/Users/ericgolovin/Developer/c_c++/Univerisy-Projects/programming-subject/02semester/PR-lab06/PR-lab06/inputFile.txt");
    ofstream output("/Users/ericgolovin/Developer/c_c++/Univerisy-Projects/programming-subject/02semester/PR-lab06/PR-lab06/outputFile.txt");
    istream_iterator<string> start(inputFile), end;
    
    vector<string> wordsFromFile(start, end);
    
    char exceptionalWords[][20] = {"it", "me", "but", "so", "do"};
    
    output << getWordsFromWordsArray(exceptionalWords, 5);
    
    output << performWordLengthCalculation(wordsFromFile, exceptionalWords, 5);
    
    output.close();
    
    return 0;
}

