#                                               -*- Autoconf -*-
# Process this file with autoconf to produce a configure script.

AC_PREREQ([2.69])
AC_INIT([server], [VERSION], [BUG-REPORT-ADDRESS])
AC_CONFIG_SRCDIR([src/server.c])
# AC_CONFIG_HEADERS([config.h])

# Checks for programs.
AC_PROG_CC
AM_INIT_AUTOMAKE
AC_CONFIG_FILES([Makefile src/Makefile])
# Checks for libraries.

# Checks for header files.
AC_CHECK_HEADERS([netinet/in.h stdlib.h string.h sys/socket.h unistd.h])

# Checks for typedefs, structures, and compiler characteristics.

# Checks for library functions.
AC_FUNC_MALLOC
AC_CHECK_FUNCS([bzero socket])

AC_OUTPUT
