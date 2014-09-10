#include "dynamic.h"
#include <cassert>
#include <iostream>
#include <iomanip>

using namespace std;
typedef int ttype;

dyarray::dyarray()
{
		p = new ttype [10];
		capacity = 10;
		used = 0;
}

dyarray::dyarray(int cap)
{
	assert(cap>=0);
	capacity=cap;
	p = new ttype [capacity];
}

void dyarray::fill()
{
	cout << "\t !Enter \"-99\" to STOP entering\n";
	while (!is_full())
	{
		if (used == 0)
		{
			
			filltext(used);
			cin >> *(p+used);
		if(*(p+used)==-99)
		{
				delete p;
				break;
		}
			used++;
			filltext(used);
			cin >> *(p+used);
		if(*(p+used)==-99)
		{
				used--;
				break;
		}
			
		}
		else
		{
		used++;
		if(is_full())
			extend();
		filltext(used);
		cin >> *(p+used);
		}
		if(is_full())
			extend();
		if(*(p+used)==-99)
			{
				used--;
				break;
		}
    }

}

void dyarray::checkindex(int& index)
{
	if (index > used+1)
		{
			index = used+1;
			cout << "!The entered number passed the last position -> it will be the last position ["
				<< used+1 << "]\n";
			
	}

	if (index < 1)
		{
			index = 1;
			cout << "!The number is less than 0 -> it will be the first number\n";
			
	}
}

ttype dyarray::get(int index)
{
	return *(p+index);	
}

void dyarray::set(int index, ttype value)
{
	*(p+index)=value;
}

void dyarray::dyarraycpy(ttype* sourceindex, ttype*& index)
{
	int i;
	index = new ttype [capacity];
	for (i=0;i<=used;i++)
	{
		*(index+i) = *(sourceindex+i);
	}
}

void dyarray::extend()
{
	
	ttype* index;
	index = p;
	capacity = capacity * 10;
	p = new ttype [capacity];
	dyarraycpy(index,p);

	cout << "\n[INFO] Passed the CAPACITY ["
	<< capacity/10 << "] -> extend to CAPACITY [" << capacity << "]" << endl << endl;
}

void dyarray::info()
{
	if (is_empty())
	{
		cout << "The Dynamic Array now has [" << used 
		<< "] elements of capacity [" << capacity << "]"<< endl;
		return;
	}
	cout << "The Dynamic Array now has [" << used+1 
		<< "] elements of capacity [" << capacity << "]"<< endl;
}

void dyarray::dyarrayprint()
{
			if (is_empty())
		{
			cout << "[!]The array contains nothing\n";
			return;
		}
	int i,t=10,x=10,h=-1;
	for (i=0;i<= used;i++)
	{	if((i%x-9)==0)
		{
			t--;
			h++;
			x=x*10;
		}
		cout << "Position [" << i+1 << "]"<< setw(t-6) << "=" << setw(t+h) << *(p+i) << endl;
	}
	info();
}

void dyarray::filltext(int index)
{
	cout << "Entering position number [" << index+1 << "]" << " : ";
}

dyarray::~dyarray()
{
	delete [] p;
	p = new ttype [10];
    capacity = 10;
	used = 0;
}

void dyarray::search(const ttype index, int*& list, int& j)
{
	int i;
	j=0;
	list = new int[capacity];
	for (i=0;i<=used;i++)
	if(get(i) == index)
		{
			*(list + j) = i;
			j++;
		}
	
}

std::ostream& operator << (std::ostream& outs, const dyarray index)
{
	if (index.is_empty())
		{
			outs << "[!]The array contains nothing\n";
			return outs;
		}
	int i,t=10,x=10,h=-1;
	for (i=0;i<= index.used;i++)
	{	if((i%x-9)==0)
		{
			t--;
			h++;
			x=x*10;
		}
		outs << "Position [" << i+1 << "]"<< setw(t-6) << "=" << setw(t+h) << *(index.p+i) << endl;
	}
	return outs;
}

bool dyarray::operator == (dyarray index)
{
	int i;
	bool ttypeequal = true;
	if (max()!=index.max())
		ttypeequal = false;
	else
		if (noe()!=index.noe())
			ttypeequal = false;
		else for (i=0;i<=used;i++)
			if(*(p+i)!=*(index.takep()+i))
			{
				ttypeequal = false;
				break;
			}
	return ttypeequal;
}

void dyarray::operator = (dyarray& index)
{
	capacity = index.capacity;
	used = index.used;
	p= new ttype[capacity];
	dyarraycpy(index.p,p);
}

/*void dyarray::dyarrayprint2(std::ostream& outs)
{
			if (is_empty())
		{
			outs << "[!]The array contains nothing\n";
			return;
		}
	int i,t=10,x=10,h=-1;
	for (i=0;i<= used;i++)
	{	if((i%x-9)==0)
		{
			t--;
			h++;
			x=x*10;
		}
		outs << "Position [" << i+1 << "]"<< setw(t-6) << "=" << setw(t+h) << *(p+i) << endl;
	}
}*/
