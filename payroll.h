#include <iostream>
#include <string>

using namespace std;

class Employee {
    private:
    string name;
    string benefitDescription;
    double tax;
    double grossIncome;
    double netpay;
  public:
    void setName(string);
    void getName();
    void getBenefits(string);
    void setBenefits();
    void setTaxes(double);
    void getTaxes();
    void setGrossIncome(double);
    void getGrossIncome();
    void getNetPay();
    //...
    //function for alg change goes here
    //function for alg change goes here
    //readin function
};

/*void Employee::setName (char newName[]) {
  name = newName;
  }*/
