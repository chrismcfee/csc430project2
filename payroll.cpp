//#include "payroll.h"
#include <iostream>
#include <string>

using namespace std;

int main(int argc, char **argv){
string input;
bool tocontinue = true;
cout << "Payroll Program" << endl;
cout << "Please select an option from the following menu: " << endl;
cout << "A - Add an employee to the payroll" << endl;
cout << "M - Modify employee data" << endl;
cout << "D - Remove employee from the payroll" << endl;
cout << "V - View the data of an employee" << endl;
cout << "P - Select an employee to check if the pay method is paper check or direct deposit" << endl;
cout << "H - Show this menu again" << endl;
cout << "X - Exit the program safely, saving changes to the database" << endl;
cin >> input;
while ((tocontinue == true) && ((input != "A") || (input != "a") || (input != "M") || (input != "m") || (input != "D") || (input != "d") || (input != "P") || (input != "p") || (input != "X") || (input != "x"))){
if (input == "A" || input == "a"){
cout << "You have slected to add an employee to the payroll" << endl;
tocontinue = false;
}
else if (input == "M" || input == "m"){
cout << "You have selected to modify an employee's data" << endl;
tocontinue = false;
}
else if (input == "D" || input == "d"){
cout << "You have chosen to delete an employee from the payroll" << endl;
tocontinue = false;
}
else if (input == "P" || input == "p"){
cout << "You have chosen to see an employee's pay method." << endl;
tocontinue = false;
}
else if (input == "X" || input == "x"){
cout << "You have chosen to exit the program. Goodbye." << endl;
tocontinue = false;
}
else if (input == "V" || input == "v"){
cout << "You have chosen to view an employee's information." << endl;
tocontinue = false;
}
else if (input == "H" || input == "h"){
cout << "Payroll Program" << endl;
cout << "Please select an option from the following menu: " << endl;
cout << "A - Add an employee to the payroll" << endl;
cout << "M - Modify employee data" << endl;
cout << "D - Remove employee from the payroll" << endl;
cout << "P - Select an employee to check if the pay method is paper check or direct deposit" << endl;
cout << "H - Show this menu again" << endl;
cout << "X - Exit the program safely, saving changes to the database" << endl;
cin >> input;
}
else{
cout << "Invalid option selected. Please enter a valid option." << endl;
cin >> input;
}
}
return 0;
}
