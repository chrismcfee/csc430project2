#include <iostream>

class Employee {
    char name[];
    char benefitDescription[];
    double tax;
    double grossIncome;
  public:
    //todo: make prototypes for these functions; these are simply placeholders for now.
    //also change the set into private funcs
    void setName();
    void getName();
    void getBenefits();
    void setBenefits();
    void setTaxes(double);
    void getTaxes();
    void setGrossIncome();
    void getGrossIncome();
    //function for alg change goes here
    //function for alg change goes here
};

void Employee::setName (char newName[]) {
  name = newName;
  }
