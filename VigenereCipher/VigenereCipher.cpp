
#include <iostream>
#include <string>
using namespace std;

string encrypt(string pString, string pKey);

 int main()
{
	string phrase, key, result;
	string choice;
	cout << "Questo programma consente di codificare o decodificare un messaggio con la cifratura a inferriata";
	cout << "Premere C per codifica, D per decodifica\n";
	cin >> choice;
	if (choice == "C") {
		cout << "Inserire la frase da codificare: \n";
		cin >> phrase;
		cout << "Inserire la chiave: \n";
		cin >> key;
		cout << "Il messaggio codificato è: \n" << encrypt(phrase, key);
	}
	return 0;
}

string encrypt(string pString, string pKey) {
	string result;
	int posKey = 0;
	char a, b, c;
	for (int i = 0; i < pString.length(); i++) {
		if (posKey >= pKey.length()) {
			posKey = 0;
		}
		else {
			if (pString.substr(i, 1) == "'") {
				result.substr(i, 1) = "'";
			}
			else {
				pString.substr(i, 1) = a;
				pKey.substr(posKey, 1) = b;
				c = char(int(a) + (int(toupper(b)) - 64));
				result.substr(i, 1) = c;
			}
			posKey = posKey + 1;
		}
	}
	return result;
}
