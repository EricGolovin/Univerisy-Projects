#include <iostream>
#include <fstream>
#include <sstream>
#include <string>
using namespace std;

typedef struct ZNAK {
    string nameAndSurname;
    string zodiacSign;
    int birthDate[3];
} ZNAK;

string readFileData(string fileName, int *numberOfSignes) {
    fstream outFile;
    stringstream stringStream;
    
    outFile.open(fileName, ios_base::in);
    
    if (outFile.is_open()) {
        string fileContent;
        
        while (outFile.good()) {
            getline(outFile, fileContent);
            stringStream << "-" << fileContent << endl;
            *numberOfSignes += 1;
        }
        
        outFile.close();
    }
    
    return stringStream.str();
}

string findName(string nameToFind, ZNAK inArray[], int numOfElements) {
    stringstream outputStringStream;

    for (int i = 0; i < numOfElements; i++) {
        string lowercasedName = inArray[i].nameAndSurname;
        string lowercasedSearch = nameToFind;
        transform(lowercasedName.begin(), lowercasedName.end(), lowercasedName.begin(), ::tolower);
        transform(lowercasedSearch.begin(), lowercasedSearch.end(), lowercasedSearch.begin(), ::tolower);

        if (lowercasedName.find(lowercasedSearch) != string::npos) {
            outputStringStream << "Name: " << inArray[i].nameAndSurname << endl;
            outputStringStream << "Zodiac Sign: " << inArray[i].zodiacSign << endl;
            for (int index = 0; index < 2; index++) {
                outputStringStream << inArray[i].birthDate[index] << "/";
            }
            outputStringStream << inArray[i].birthDate[2] << endl << endl;
        }
    }
    
    if (outputStringStream.str() == "") {
        return "This person does not exist.\n";
    } else {
        return outputStringStream.str();
    }
}

int main(int argc, char *argv[]) {
    int totalSignes = 0;
    string fileData = readFileData("inputTestFile.txt", &totalSignes);
    ZNAK arrayOfSignes[totalSignes];
    
    // adding data to array
    for (int i = 0; i < totalSignes; i++) {
        string buffer;
        ZNAK someZNAK;
        int birthIndex = 0;
        
        for (int index = 0, flag = 0, indexer = 0; index < fileData.length() - 1; index++) {
            if (fileData[index] == '{') {
                flag = 1;
                indexer++;
                continue;
            } else if (fileData[index] == '}') {
                flag = 0;
                if (birthIndex == 2) {
                        stringstream universalStream;
                        universalStream << buffer;
                        universalStream >> someZNAK.birthDate[birthIndex];
                        birthIndex += 1;
                        buffer = "";
                }
                continue;
            }
            if (flag) {
                if (indexer == 1) {
                    someZNAK.nameAndSurname += fileData[index];
                } else if (indexer == 2) {
                    someZNAK.zodiacSign += fileData[index];
                } else if (indexer == 3) {
                    if (fileData[index] == '/') {
                        stringstream universalStream;
                        universalStream << buffer;
                        universalStream >> someZNAK.birthDate[birthIndex];
                        birthIndex += 1;
                        buffer = "";
                    } else if (birthIndex == 0) {
                        buffer += fileData[index];
                    } else if (birthIndex == 1) {
                        buffer += fileData[index];
                    } else if (birthIndex == 2) {
                        buffer += fileData[index];
                    }
                }
            }
        }
        arrayOfSignes[i] = someZNAK;
        fileData.erase(fileData.find('N'), fileData.find('\n'));
    }

    // sorting of array

    for (int i = 0; i < totalSignes - 1; i++) {
        for (int index = 0; index < totalSignes - 1 - i; index++) {
            if (arrayOfSignes[index].birthDate[2] > arrayOfSignes[index + 1].birthDate[2]) {
                ZNAK temp = arrayOfSignes[index];
                arrayOfSignes[index] = arrayOfSignes[index + 1];
                arrayOfSignes[index + 1] = temp;
            } else if (arrayOfSignes[index].birthDate[2] == arrayOfSignes[index + 1].birthDate[2]) {
                if (arrayOfSignes[index].birthDate[1] > arrayOfSignes[index + 1].birthDate[1]) {
                    ZNAK temp = arrayOfSignes[index];
                    arrayOfSignes[index] = arrayOfSignes[index + 1];
                    arrayOfSignes[index + 1] = temp;
                } else if (arrayOfSignes[index].birthDate[1] == arrayOfSignes[index + 1].birthDate[1]) {
                    if (arrayOfSignes[index].birthDate[0] > arrayOfSignes[index + 1].birthDate[0]) {
                        ZNAK temp = arrayOfSignes[index];
                        arrayOfSignes[index] = arrayOfSignes[index + 1];
                        arrayOfSignes[index + 1] = temp;
                    }
                }
            }
        }
    }
    
    // searching for name 

    string searchParameter;
    ofstream outputFile("outputFile.txt");
    
    while (1) {
        cout << "Enter Name or Surname: ";
        cin >> searchParameter;
        cout << endl;
            
        outputFile << findName(searchParameter, arrayOfSignes, totalSignes);
        cout << findName(searchParameter, arrayOfSignes, totalSignes) << endl;

        string exitOption;
        cout << endl << "stop or next: ";
        cin >> exitOption;
        cout << endl;

        if (exitOption == "stop" || exitOption == "Stop") {
            break;
        }
    }
    
    outputFile.close();
    
    return 0;
}
