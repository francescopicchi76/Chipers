#include <iostream>
#include <string>
using namespace std;

string encrypt(string pPhrase, string pKey);
string decrypt(string pPhrase, string pKey);

int main()
{
    string phrase, key, choice;
    bool validation = false;

    cout << "This programme enables to encrypt or decrypt a message through the columnar transposition chiper.\n"
        "The English alphabet is used as reference.\n"
        "- For encryption: possible blank spaces in the grid, both between words and after the end of the message\n"
        "as completion of the grid, are encrypted as '*'.\n"
        "- For decryption: if the length of the message is not a multiple of the length of the keyword,\n"
        "the programme automatically arranges the message to completely fill the grid with blank spaces.\n"
        "Possible asterisks are converted into blank spaces in the decryption.\n\n";

    cout << "Press E for encrypt, D for decrypt: ";
    getline(cin >> ws, choice);
    while (choice != "E" && choice != "e" && choice != "D" && choice != "d" || choice.length() > 1) {
        cout << "Invalid input.\nPlease press E for encrypt or D for decrypt: ";
        getline(cin >> ws, choice);
    }

    cout << "Write the keyword: ";
    getline(cin >> ws, key);
    while (validation == false) {
        for (int i = 0; i < key.length(); i++) {
            if (toupper(key[i]) < 65 || toupper(key[i]) > 90) {
                validation = false;
                cout << "Invalid keyword: only alphabet letters (without blank spaces) are admitted.\nWrite the keyword: ";
                getline(cin >> ws, key);
                break;
            }
            else {
                validation = true;
            }
        }
    }

    if (choice == "E" || choice == "e") {
        cout << "Write the message to encrypt: ";
        getline(cin >> ws, phrase);
        cout << "The result of the encryption is: " << encrypt(phrase, key);
    }
    else {
        cout << "Write the message to decrypt: ";
        getline(cin >> ws, phrase);
        cout << "The result of the decryption is: " << decrypt(phrase, key);
    }
    return 0;
}


string encrypt(string eString, string eKey) {
    int resultLength, temp, rows, columns;
    columns = eKey.length();
    string eKeySorted = eKey;
    if (eString.length() % eKey.length() == 0) {    //Assign values to rows and resultLenght, which vary depending on whether
        rows = eString.length() / eKey.length();    //the length of the message is or isn't a multiple of the length of the keyword.
        resultLength = eString.length();
    }
    else {
        rows = eString.length() / eKey.length() + 1;
        resultLength = columns * rows;
    }
    string result(resultLength, '*');               //First initialization of the string result, filled with asterisks.

    for (int i = 0; i < eString.length(); i++) {    //Further initialization of the string result with the letters
        if (eString[i] != ' ') {                    //of the message to encrypt.
            result[i] = eString[i];
        }
    }

    for (int i = 0; i < columns; i++) {             //Sort the keyword alphabetically and store it as eKeySorted.
        for (int j = i + 1; j < columns; j++) {
            if (tolower(eKeySorted[i]) > tolower(eKeySorted[j])) {
                temp = eKeySorted[i];
                eKeySorted[i] = eKeySorted[j];
                eKeySorted[j] = temp;
            }
        }
    }

    string duplicate = result;                  //Letter by letter compare the original keyword with the keyword in alphabetical
    for (int i = 0; i < columns; i++) {         //order: when a match is found, reposition columns of the message according to
        for (int j = 0; j < columns; j++) {     //the position of letters in the keyword in alphabetical order. After a match is found,
            if (eKey[i] == eKeySorted[j]) {     //discard the letter under cosideration from eKeySorted by converting it into
                eKeySorted[j] = '^';            //the symbol '^': this is necessary to handle possible identical consecutive letters.
                for (int k = 0; k < rows; k++) {
                    result[j + (columns * k)] = duplicate[i + (columns * k)];
                }
                break;
            }
        }
    }

    string resultOutput = result;               //Invert rows and columns.
    for (int i = 0; i < columns; i++) {
        for (int j = 0; j < rows; j++) {
            resultOutput[j + i * rows] = result[i + (columns * j)];
        }
    }
    return resultOutput;
}



string decrypt(string dString, string dKey) {
    int resultLength, temp, rows, columns, difference;
    columns = dKey.length();

    if (dString.length() % dKey.length() == 0) { //Assign values to rows and resultLenght, which vary depending on whether
        rows = dString.length() / dKey.length(); //the length of the message is or isn't a multiple of the length of the keyword.
        resultLength = dString.length();
    }
    else {
        rows = dString.length() / dKey.length() + 1;
        resultLength = columns * rows;
    }

    difference = resultLength - dString.length(); //difference is the number of spaces missing to completely fill the grid.
    string result(resultLength, ' ');

    for (int i = 0; i < dString.length(); i++) { //First initialization of the string result.
        if (dString[i] != '*') {
            result[i] = dString[i];
        }
    }

    string dKeySorted = dKey;                   //Sort the keyword alphabetically and store it as dKeySorted.
    for (int i = 0; i < columns; i++) {
        for (int j = i + 1; j < columns; j++) {
            if (tolower(dKeySorted[i]) > tolower(dKeySorted[j])) {
                temp = dKeySorted[i];
                dKeySorted[i] = dKeySorted[j];
                dKeySorted[j] = temp;
            }
        }
    }
    string tempKey = dKeySorted;
    if (difference != 0) {                               //Rearrange the string if the message doesn't completely fill the grid.
        for (int i = 0; i < columns - difference; i++) { //Take tempKey as a duplicate of dKeysorted and discard from it 
            for (int j = 0; j < columns; j++) {          //the letters corresponding to the columns that don't
                if (dKey[i] == tempKey[j]) {             //need any addition of blank spaces. Letters are discarded
                    tempKey[j] = '^';                    //by converting them into the symbol '^'. This is necessary
                    break;                               //to handle possible identical consecutive letters.
                }
            }
        }
        for (int i = columns - difference; i < columns; i++) {//Take the positions of the remaining columns that need an additional
            for (int j = 0; j < columns; j++) {               //blank space: for each column compare the corresponding letter 
                if (dKey[i] == tempKey[j]) {                  //of the original keyword with the letters of the keyword in
                    tempKey[j] = '^';                         //alphabetical order. When a match is found, put an asterisk
                    result[rows * (1 + j) - 1] = '*';         //in the corresponding position of the message.
                    break;
                }
            }
        }
        int j = 0;
        for (int i = 0; i < resultLength; i++) {  //Conclude the rearrangement of the message switching characters onwards
            if (result[i] != '*') {               //every time an asterisk is found. Then convert asterisks into blank spaces.
                result[i] = dString[j];           //This provides the message with as many blank spaces (in the correct position)
                j = j + 1;                        //as needed to completely fill the grid.
            }
            else {
                result[i] = ' ';
            }
        }
    }

    string copyResult = result;             //Invert rows and columns.
    for (int i = 0; i < rows; i++) {
        for (int j = 0; j < columns; j++) {
            result[j + i * columns] = copyResult[i + (rows * j)];
        }
    }

    string resultOutput = result;
    for (int i = 0; i < columns; i++) {         //Letter by letter compare the original keyword with the keyword in alphabetical
        for (int j = 0; j < columns; j++) {     //order: when a match is found, reposition columns of the message according to
            if (dKeySorted[i] == dKey[j]) {     //the position of letters in the original keyword. After a match is found,
                dKey[j] = '^';                   //discard the letter from dKey to handle possible identical consecutive letters.
                for (int k = 0; k < rows; k++) {
                    resultOutput[j + (columns * k)] = result[i + (columns * k)];
                }
                break;
            }
        }
    }
    return resultOutput;
}
