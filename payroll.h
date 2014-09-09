#include <iostream>
#include <string>

using namespace std;

class Employee {
    private:
    string name;
    string benefitDescription;
    double tax;
    double grossIncome;
  public:
    void setName(string);
    void getName();
    void getBenefits(string);
    void setBenefits();
    void setTaxes(double);
    void getTaxes();
    void setGrossIncome(double);
    void getGrossIncome();
    //function for alg change goes here
    //function for alg change goes here
};

/*void Employee::setName (char newName[]) {
  name = newName;
  }*/
