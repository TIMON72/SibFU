/*! \file    test.cpp
*  \brief   Library of functions to operate on sets.
*
*  \details Unit-testing for library of functions to operate on sets.
*           CUnit library to be linked ($g++ <filename> -lcunit).
*/
#include <stdio.h>
#include <stdlib.h>
#include <sys/types.h>
#include <signal.h>
#include <sys/wait.h>
#include <unistd.h>

#include <iostream>
#include <string>
#include <vector>
#include <cstdlib>
#include <CUnit/CUnit.h>
#include <CUnit/Console.h>
#include <CUnit/Basic.h>

using namespace std;

/*! \brief Binary search in ordered array.
*
*  \details Binary search in vector of integers.
*
*  \param   arr		Ordered list of integers.
*  \param   key		Number which we will search.
*
*  \return  index of the element if found.
*           -1, otherwise. Index of nearest element via posBefore parameter.
*/
int BinarySearch(vector<int>& arr, int key)
{
	int l = 0;
	int u = arr.size() - 1;

	while (l <= u)
	{
		int m = (l + u) / 2;
		if (arr[m] < key)
		{
			l = m + 1;
		}
		if (arr[m] > key)
		{
			u = m - 1;
		}
		if (arr[m] == key)
		{
			return m;
		}
	}
	return -1;
}
/*! \brief Interpolation search in ordered array.
*
*  \details Interpolation search in vector of integers.
*
*  \param   arr		Ordered list of integers.
*  \param   key		Number which we will search.
*
*  \return  index of the element if found.
*           -1, otherwise. Index of nearest element via posBefore parameter.
*/
int InterpolationSearch(vector<int>& arr, int key)
{
	int l = 0;
	int u = arr.size() - 1;

	if (arr[l] == key)
	{
		return l;
	}
	while (arr[l] < key && arr[u] >= key)
	{
		int m = l + ((u - l) * (key - arr[l])) / (arr[u] - arr[l]);
		if (key < arr[m])
		{
			u = m - 1;
		}
		if (key > arr[m])
		{
			l = m + 1;
		}
		if (key == arr[m])
		{
			return m;
		}
	}
	return -1;
}
/*! \brief Unit test for binary searching. */
void test11()
{
	vector<int> arr(3);
	arr[0] = 1;
	arr[1] = 2;
	arr[2] = 3;
	int key = 3;
	int result = BinarySearch(arr, key);
	if (result == 2)
	{
		CU_ASSERT(1);
	}
	else
	{
		CU_ASSERT(0);
	}
}
/*! \brief Unit test for interpolation searching. */
void test12()
{
	vector<int> arr(3);
	arr[0] = 1;
	arr[1] = 2;
	arr[2] = 3;
	int key = 2;	
	int result = InterpolationSearch(arr, key);
	if (result == 1)
	{
		CU_ASSERT(1);
	}
	else
	{
		CU_ASSERT(0);
	}
}
/*! \brief Main function
*  \return Unit testing error code
*/
int main()
{	
	CU_pSuite suite;
	CU_initialize_registry();
	suite = CU_add_suite("main_suite", NULL, NULL);
	CU_ADD_TEST(suite, test11);
	CU_ADD_TEST(suite, test12);
	CU_console_run_tests();
	CU_cleanup_registry();
	return 0;
}