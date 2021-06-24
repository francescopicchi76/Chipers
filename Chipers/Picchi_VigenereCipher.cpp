
#include <iostream>
#include <string>
using namespace std;

string encrypt(string eString, string eKey);
string decrypt(string dString, string dKey);

int main()
{
	string phrase, key, result;
	string choice;
	bool validation = false;
	
	cout << "This programme enables to encrypt or decrypt a message through the Vigenere chiper.\n"
		"The English alphabet is used as reference.\nThe result is displayed in capital letters.\n\n";
	
	cout << "Type E for encrypt, D for decrypt: ";
	getline(cin >> ws, choice);
	while (choice != "E" && choice != "e" && choice != "D" && choice != "d" || choice.length() > 1) {
		cout << "Invalid input.\nPlease type E for encrypt or D for decrypt: ";
		getline(cin >> ws, choice);
	}

	cout << "Write the message to encrypt/decrypt:";
	getline(cin >> ws, phrase);

	cout << "Write the keyword: ";
	getline(cin >> ws, key);
	while (validation == false) {
		for (int i = 0; i < key.length(); i++) {
			if (toupper(key[i]) < 65 || toupper(key[i]) > 90) {
				validation = false;
				cout << "Invalid keyword: only alphabet letters (without blank spaces) are admitted.\n"
					"Please write a valid keyword: ";
				getline(cin >> ws, key);
				break;
			}
			else {
				validation = true;
			}
		}
	}

	if (choice == "E" || choice == "e") {
		cout << "The result of the encryption is: " << encrypt(phrase, key);
	}
	else {
		cout << "The result of the decryption is: " << decrypt(phrase, key);
	}
	return 0;
}

string encrypt(string eString, string eKey) {
	
	int posString = 0;	//Position of characters in the string
	int posKey = 0;		//Position of characters in the keyword
	char a;				//Variable to store encrypted characters
	string result = eString;	//Initialization

	for (posString = 0; posString < eString.size(); posString++) {
		if (int(toupper(eString[posString])) < 65 || int(toupper(eString[posString])) > 90) {
			posKey= posKey-1;
			// If a character of the string isn't alphabetic, it is left unchanged (no action, initialization value);
			// in this case poskey must remain unchanged too, in order to be used to encrypt the following character of the string.
			// Therefore poskey must be decreased by 1 to compensate its subsequent increase.
		}
		else {
			a = (int(toupper(eString[posString])) + (int(toupper(eKey[posKey])) - 65));
			while (a > 90) {
				a = (a - 90) + 64;
			} 
			result[posString] = a;
			// Using ASCII codes, each alphabetic character of the string is shifted along a number of places
			// equal to the alphabetic position of the corresponding character of the keyword.
			// If the shift gets beyond Z (char 90), it continues from A.
		}
		if (posKey == (eKey.size() - 1)) {
			posKey = 0;
		} // if poskey is the last position of the keyword, the next one to be used must be the first one, i.d. position [0];
		// otherwise the next position to be used in the keyword is the following one.
		else {
			posKey = posKey + 1;
		}
	}
	return result;
}


string decrypt(string dString, string dKey) {
	//Inverse algorithm.
	int posString = 0;
	int posKey = 0;
	char a;
	string result = dString;

	for (posString = 0; posString < dString.size(); posString++) {
		if (int(toupper(dString[posString])) < 65 || int(toupper(dString[posString])) > 90) {
			posKey = posKey - 1;  
		}
		else {
			a = (int(toupper(dString[posString])) - (int(toupper(dKey[posKey])) - 65));
			while (a < 65) {
				a = 90 - (64 - a);
			}
			result[posString] = a;
		}
		if (posKey == (dKey.size() - 1)) {
			posKey = 0;
		}
		else {
			posKey = posKey + 1;
		}
	}
	return result;
}