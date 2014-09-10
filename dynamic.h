#ifndef DYNAMIC_H
#define DYNAMIC_H
#include <iostream>

class dyarray
{
public:
	typedef int ttype;
	dyarray();
	dyarray(int cap);
	void fill();
	bool is_full() const {return used==capacity;}
	bool is_empty() const {return used==0;}
	int max() const {return capacity;}
	int noe() const {return used;}
	void checkindex(int& index);
	ttype get(int index);
	void set(int index, ttype value);
//	void add();
	void dyarraycpy(ttype* sourceindex, ttype*& index);
	void extend();
	void info();
	void dyarrayprint();
	void filltext(int index);
	~dyarray();
	void search(const ttype index,int*& list,int& j);
	friend std::ostream& operator << (std::ostream& outs, const dyarray index);
	ttype* takep(){return p;}
	bool operator == (dyarray index);
	void operator = (dyarray& index);
	void operator += (const dyarray index);
	
	
//	void dyarray::dyarrayprint2(std::ostream& outs);

private:
	ttype* p;
	int used;
	int capacity;
};

#endif




