// ConsoleApplication2.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <iostream>
#include <Windows.h>

#define TOTAL_STATES            31
#define FINAL_STATES            6
#define CURRENT_STATES			6
#define ALPHABET_CHARCTERS      2
#define START_STATES			6

#define UNKNOWN_SYMBOL_ERR      0
#define NOT_REACHED_FINAL_STATE 1
#define REACHED_FINAL_STATE     2

enum DFA_STATES {
	q0, q1, q2, q3, q4, q5, q6, q7, q8, q9, q10,
	q11, q12, q13, q14, q15, q16, q17, q18, q19, q20,
	q21, q22, q23, q24, q25, q26, q27, q28, q29, q30
};   // The set Q
enum input { _0, _1 };

int  g_Accepted_states[FINAL_STATES] = { q5, q10, q15, q20, q25, q30 };     // The set F
char g_alphabet[ALPHABET_CHARCTERS] = { '0', '1' };  // The set Sigma
int  g_Transition_Table[TOTAL_STATES][ALPHABET_CHARCTERS] = {}; // Transition function
int  g_Current_state = q0;
int  g_Current_states[CURRENT_STATES] = { q0, q0, q0, q0, q0, q0 };
int  g_Start_states[START_STATES] = { q1, q6, q11, q16, q21, q26}; //q0; // Start state of FA

void SetDFA_Transitions()
{
	g_Transition_Table[q1][_0] = q2;
	g_Transition_Table[q2][_0] = q2;
	g_Transition_Table[q2][_1] = q3;
	g_Transition_Table[q3][_0] = q4;
	g_Transition_Table[q4][_0] = q4;
	g_Transition_Table[q4][_1] = q5;
	g_Transition_Table[q5][_0] = q5;
	g_Transition_Table[q6][_0] = q7;
	g_Transition_Table[q7][_0] = q8;
	g_Transition_Table[q8][_0] = q8;
	g_Transition_Table[q8][_1] = q9;
	g_Transition_Table[q9][_0] = q9;
	g_Transition_Table[q9][_1] = q10;
	g_Transition_Table[q10][_0] = q10;
	g_Transition_Table[q11][_0] = q11;
	g_Transition_Table[q11][_1] = q12;
	g_Transition_Table[q12][_0] = q12;
	g_Transition_Table[q12][_1] = q13;
	g_Transition_Table[q13][_0] = q14;
	g_Transition_Table[q14][_0] = q15;
	g_Transition_Table[q15][_0] = q15;
	g_Transition_Table[q16][_0] = q16;
	g_Transition_Table[q16][_1] = q17;
	g_Transition_Table[q17][_0] = q18;
	g_Transition_Table[q18][_0] = q18;
	g_Transition_Table[q18][_1] = q19;
	g_Transition_Table[q19][_0] = q20;
	g_Transition_Table[q20][_0] = q20;
	g_Transition_Table[q21][_0] = q22;
	g_Transition_Table[q22][_0] = q22;
	g_Transition_Table[q22][_1] = q23;
	g_Transition_Table[q23][_0] = q23;
	g_Transition_Table[q23][_1] = q24;
	g_Transition_Table[q24][_0] = q25;
	g_Transition_Table[q25][_0] = q25;
	g_Transition_Table[q26][_0] = q26;
	g_Transition_Table[q26][_1] = q27;
	g_Transition_Table[q27][_0] = q28;
	g_Transition_Table[q28][_0] = q29;
	g_Transition_Table[q29][_0] = q29;
	g_Transition_Table[q29][_1] = q30;
	g_Transition_Table[q30][_0] = q30;
}

int DFA(const char current_symbol)
{
	int pos;
	// Если текущее состояние q0, то разветвляемся и принимаем текущие состояния стартовыми
	if (g_Current_state == q0)
		for (int i = 0; i < FINAL_STATES; i++)
			g_Current_states[i] = g_Start_states[i];
	// Проверка на наличие символа в алфавите Сигма		
	for (pos = 0; pos < ALPHABET_CHARCTERS; ++pos)
		if (current_symbol == g_alphabet[pos])
			break;
	// Если символ равен длине алфавита, то ошибка
	if (ALPHABET_CHARCTERS == pos)
		return UNKNOWN_SYMBOL_ERR;
	
	// Меняем текущие состояния на следующие в каждой ветке
	for (int i = 0; i < FINAL_STATES; i++)
	{
		g_Current_states[i] = g_Transition_Table[g_Current_states[i]][pos];
	}
	// Проверяем, достигло ли хотя бы одно состояние из веток конечного состояния
	for (int i = 0; i < FINAL_STATES; i++)
	{
		g_Current_state = g_Current_states[i];
		for (int j = 0; j < FINAL_STATES; j++)
		{
			if (g_Current_state == g_Accepted_states[j])
				return REACHED_FINAL_STATE;
		}
	}
	return NOT_REACHED_FINAL_STATE;
}

int main()
{
	char current_symbol;
	int  result;

	SetDFA_Transitions();    // Fill transition table

	printf("Enter a string with '0' and '1': ");

	while ((current_symbol = getchar()) != '\n' && current_symbol != EOF)
	{	
		result = DFA(current_symbol);
		if (REACHED_FINAL_STATE != result && NOT_REACHED_FINAL_STATE != result)
		{
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

