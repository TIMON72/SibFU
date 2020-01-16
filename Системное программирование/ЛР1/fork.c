/*! \file fork.c
* \brief Fork, exec and wait process.
*
* \details Forking child process with its executing followed by its waiting. Child process is a list of files via running "./main" command.
*/
#include <stdio.h>
#include <stdlib.h>
#include <sys/types.h>
#include <signal.h>
#include <sys/wait.h>
#include <unistd.h>

/*! \brief Spawn a child process
*
* \details Spawn a child process running a new program, as given by PROGRAM.
*
* \param program The name of the program to runs; the path will be searched for this program.
* \param argList A NULL-terminated list of character strings to be passed as the program's argument list.
* \return Identifier of the spawned process.
*/
int spawn(char* program, char** argList)
{
  // Создание копии процесса процесса
  pid_t childPid;
  childPid = fork();
  if (0 != childPid) //Если процесс не совпадает с родительским */
  {
	return childPid;
  }
  else
  {
    execvp(program, argList);
    fprintf(stderr, "Ошибка в процессе\n");
    abort();
  }
}
/*! \brief Main function
* \return Integer 0 upon exit success
*/
int main()
{
  int childStatus;
  char* argList[] = { NULL };

  //Создание дочернего процесса по заданному пути
  spawn("/home/timon72/LW/lab1/process.out", argList);

  // Ожидание завершения работы дочернего процесса
  wait(&childStatus);
  if(WIFEXITED(childStatus))
  {
    printf("Дочерний процесс завершился благополучно с кодом %d.\n", WEXITSTATUS(childStatus));
  }
  else
  {
    printf("Дочерний процесс завершился неблагополучно\n");
  }
  return 0;
}

