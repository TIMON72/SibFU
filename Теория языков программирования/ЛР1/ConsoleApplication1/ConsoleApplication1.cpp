// ConsoleApplication1.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <iostream>
#include <Windows.h>

#define TOTAL_STATES            4
#define FINAL_STATES            1
#define ALPHABET_CHARCTERS      2

#define UNKNOWN_SYMBOL_ERR      0
#define NOT_REACHED_FINAL_STATE 1
#define REACHED_FINAL_STATE     2

enum DFAstates { q0, q1, q2, q3 };   // Состояния
enum States { _0 , _1 }; // Переходы 

int  acceptedStates[FINAL_STATES] = { q3 };     // Конечное состояние
char alphabet[ALPHABET_CHARCTERS] = { 'a', 'b' };  // Сигма
int  transitionTable[TOTAL_STATES][ALPHABET_CHARCTERS] = {}; // Таблица переходов
int  currentState = q0; // Начальное состояние

/// Таблица связей
void DefineDFA()
{
	transitionTable[q0][_1] = q1;
	transitionTable[q0][_0] = q0;
	transitionTable[q1][_1] = q2;
	transitionTable[q1][_0] = q1;
	transitionTable[q2][_1] = q3;
	transitionTable[q2][_0] = q2;
	transitionTable[q3][_1] = q1;
	transitionTable[q3][_0] = q3;
}

int DFA(const char currentSymbol)
{
	int i, pos;
	bool check = false;
	// проверка символа на принадлежность Сигме
	for (pos = 0; pos < ALPHABET_CHARCTERS; pos++)
	{
		if (currentSymbol == alphabet[pos] || currentSymbol == '\n')
		{
			check = true;
			break;
		}
		else
			check = false;
	}
	if (!check)
		return UNKNOWN_SYMBOL_ERR;
	// Если текущий символ не конец строки, то переводим состояние
	if (currentSymbol == '\n')
	{
		currentState = transitionTable[currentState][0];
		for (i = 0; i<FINAL_STATES; i++)
		// Если текущие состояние конечное или нет
			if (currentState == acceptedStates[i])
			return REACHED_FINAL_STATE;
		else
			return NOT_REACHED_FINAL_STATE;
	}
	
	currentState = transitionTable[currentState][1];
}

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	char currentSymbol;
	int  result;
	DefineDFA();
	printf("Enter a string with 'a' and 'b': ");
	while (true)
	{
		currentSymbol = getchar();
		result = DFA(currentSymbol);
		if (REACHED_FINAL_STATE == result || NOT_REACHED_FINAL_STATE == result)
			break;
		else if (result == UNKNOWN_SYMBOL_ERR)
		{
			printf("Symbol error\n");
			break;
		}
	}
	if (REACHED_FINAL_STATE == result)
	{
		printf("Accepted\n");
	}
	else
	{
		printf("Rejected\n");
	}
	system("pause");
	return 0;
}

