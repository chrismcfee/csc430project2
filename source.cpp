#include <iostream>
#include "dynamic.h"
#include <stdlib.h>

using namespace std;
typedef int ttype;

void olddata(dyarray& x,const dyarray old);

void main()
{
	dyarray x,old;
	bool ending=true;
	int choice, index, i;
	ttype ttypeindex;
	int* isearch;
	
	cout << "\t===== CSC326 | Assignment 1 | Dynamic Array & Pointer =====";
/*
	do
	{
	
	cout << "\n\nOPTIONS: \n"
			<< endl << "\t(1) Integer" <<endl
			<< endl << "\t(2) Real Number (Double)" <<endl
			<< endl << "\t(3) Charater" <<endl
			<< endl << "\t(4) Sentence (String)" <<endl;
	cout << "\nPlease enter the type of data you want to enter: "; cin >> choice;
	
	switch (choice)
	{
		case 1:
			typedef int ttype;
			break;
		case 2:
			typedef double ttype;
			break;
		case 3:
			typedef char ttype;
			break;
		case 4:
			typedef string ttype;
			break;
		default:
			cout << "!Wrong: Please enter again:\n";
	}

	}
	while (ending);
*/
	cout << endl << endl << "Please enter datas for your Dynamic Array:\n\n";
	x.fill();
	
	ttype valindex;
	bool erased=false;

	do
	{
		cout << "\n\nOPTIONS: \n"
			<< endl << "\t(1)  Continue entering process." <<endl
			<< endl << "\t(2)  Display the array information." <<endl
			<< endl << "\t(3)  Show the Capacity." <<endl
			<< endl << "\t(4)  Show Number of Elements." <<endl
			<< endl << "\t(5)  Print the array to screen." <<endl
			<< endl << "\t(6)  Check value of a element." <<endl
			<< endl << "\t(7)  Change value of a element." <<endl
			<< endl << "\t(8)  Erase all storaged value." <<endl
			<< endl << "\t(9)  Search a value." <<endl
			<< endl << "\t(10) EXIT program" <<endl;
		if (erased==true)
			cout << endl << "\t(11) Backup Data..."<< endl;
		cout << "\nPlease make a choice: "; cin >> choice;
		switch(choice)
		{
			case 1:
				x.fill();
				break;
			case 2:
				x.info();
				system("Pause");
				break;
			case 3:
				cout << "The capacity is: " << x.max() << endl;
				system("Pause");
				break;
			case 4:
				if (x.is_empty())
				{
					cout << "[!]The array contains nothing\n";
					cout << "The number of used elements is: " << x.noe() << endl;
					system("Pause");
					break;
				}
				cout << "The number of used elements is: " << x.noe()+1 << endl;
				system("Pause");
				break;
			case 5:
				//x.dyarrayprint();
				cout << x;
				system("Pause");
				break;
			case 6:
				if (x.is_empty())
				{
					cout << "[!]The array contains nothing\n";
					system("Pause");
					break;
				}
				cout << "Enter the position: "; cin >> index;
				x.checkindex(index);
				cout << "Element at position [" << index << "] has value [" 
					<< x.get(index-1) << "]\n";
				system("Pause");
				break;
			case 7: 
				if (x.is_empty())
				{
					cout << "[!]The array contains nothing\n";
					system("Pause");
					break;
				}				
				cout << "Enter the position: "; cin >> index;
				cout << "Enter the value: "; cin >> valindex;
				x.checkindex(index);
				x.set(index-1,valindex);
				cout << "\nNow element at position [" << index << "] has value [" 
					<< x.get(index-1) << "]\n";
				system("Pause");
				break;
			case 8:
				if (x.is_empty())
				{
					cout << "[!]The array contains nothing\n";
					system("Pause");
					break;
				}				
				old=x;
				erased=true;
				x.~dyarray();
				cout << "[!] All the storaged datas has been terminated\n"
					<<"\tBackup data is available to use\n";
				system("Pause");
				break;
			case 9:
				if (x.is_empty())
				{
					cout << "[!]The array contains nothing\n";
					system("Pause");
					break;
				}
				cout << "Enter the value you want to search: ";
				cin >> ttypeindex;
				x.search(ttypeindex,isearch,index);
				if(index==0)
				{cout << "Not found!\n";system("Pause"); break;}
				cout << "The element(s) contains the value is: ";
				for (i=0; i < index; i++)
					cout << "["<< *(isearch+i)+1<< "] ";
				cout << endl;
				system("Pause");
				break;
			case 10:
				cout << "[INFO] Memory has been released, system clossing...\n";
				ending = false;
				break;
				//exit(EXIT_SUCCESS);
			case 11:
				olddata(x,old);
			
			default:
				cout << "! Not in the list, please choose again\n";
				system("Pause");
		}
	}
	while (ending);

	dyarray oldx;
	oldx=x;
	cout << oldx;
	x.~dyarray();
	cout << oldx;

	exit(EXIT_SUCCESS);

}


void olddata(dyarray& x, dyarray old)
{
	bool ending = false;
	int choice;
	do
	{
	cout << endl << "\tBACKUP DATA OPTIONS:" << endl
		<< endl << "\t\t(1) Backup to current data." <<endl
		<< endl << "\t\t(2) Compare with current data." <<endl
		<< endl << "\t\t(3) Print backup data to screen." <<endl
		<< endl << "\t\t(4) Exit" << endl;
	cout << endl << "\nPlease make a choice: "; cin >> choice;
	switch (choice)
	{
		case 1:
			x=old;
			break;
		case 2:
			if (x==old)
				cout << "Current data and backup data are SIMMILAR\t";
			else cout << "Current data and backup data are DIFFERENT\t";
			system("Pause");
			break;
		case 3:
			cout << x;
			system("Pause");
			break;
		case 4:
			ending = true;
			break;
		default:
			cout << "! Not in the list, please choose again\n";
			system("Pause");
	}
	}
	while (ending==false);
}