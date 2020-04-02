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

string readFileData(string fileName, int *numOfFlights) {
    fstream outFile;
    stringstream stringStream;
    
    outFile.open(fileName, ios_base::in);
    
    if (outFile.is_open()) {
        cout << "File opened successfuly." << endl << endl;
        string fileContent;
        
        while (outFile.good()) {
            getline(outFile, fileContent);
            stringStream << "-" << fileContent << endl;
            *numOfFlights += 1;
        }
        
        outFile.close();
    }
    
    return stringStream.str();
}

string findByCityName(string nameToFind, ZNAK inArray[], int numOfElements) {
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
    int totalFlights = 0;
    string fileData = readFileData("inputTestFile.txt", &totalFlights);
    ZNAK arrayOfFlights[totalFlights];
    
    // adding data to array
    for (int i = 0; i < totalFlights; i++) {
        stringstream stringDateStream, stringMonthStream, stringYearStream;
        string buffer;
        ZNAK someZNAK;
        int birthIndex = 0;
        
        for (int index = 0, flag = 0, parameterNumber = 0; index < fileData.length() - 1; index++) {
            if (fileData[index] == '{') {
                flag = 1;
                parameterNumber++;
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
                if (parameterNumber == 1) {
                    someZNAK.nameAndSurname += fileData[index];
                } else if (parameterNumber == 2) {
                    someZNAK.zodiacSign += fileData[index];
                } else if (parameterNumber == 3) {
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
        arrayOfFlights[i] = someZNAK;
        fileData.erase(fileData.find('N'), fileData.find('\n'));
    }

    // sorting of array

    for (int i = 0; i < totalFlights - 1; i++) {
        for (int index = 0; index < totalFlights - 1 - i; index++) {
            if (arrayOfFlights[index].birthDate[2] > arrayOfFlights[index + 1].birthDate[2]) {
                ZNAK temp = arrayOfFlights[index];
                arrayOfFlights[index] = arrayOfFlights[index + 1];
                arrayOfFlights[index + 1] = temp;
            } else if (arrayOfFlights[index].birthDate[2] == arrayOfFlights[index + 1].birthDate[2]) {
                if (arrayOfFlights[index].birthDate[1] > arrayOfFlights[index + 1].birthDate[1]) {
                    ZNAK temp = arrayOfFlights[index];
                    arrayOfFlights[index] = arrayOfFlights[index + 1];
                    arrayOfFlights[index + 1] = temp;
                } else if (arrayOfFlights[index].birthDate[1] == arrayOfFlights[index + 1].birthDate[1]) {
                    if (arrayOfFlights[index].birthDate[0] > arrayOfFlights[index + 1].birthDate[0]) {
                        ZNAK temp = arrayOfFlights[index];
                        arrayOfFlights[index] = arrayOfFlights[index + 1];
                        arrayOfFlights[index + 1] = temp;
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
            
        outputFile << findByCityName(searchParameter, arrayOfFlights, totalFlights);
        cout << findByCityName(searchParameter, arrayOfFlights, totalFlights) << endl;

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
