#define rand	pan_rand
#define pthread_equal(a,b)	((a)==(b))
#if defined(HAS_CODE) && defined(VERBOSE)
	#ifdef BFS_PAR
		bfs_printf("Pr: %d Tr: %d\n", II, t->forw);
	#else
		cpu_printf("Pr: %d Tr: %d\n", II, t->forw);
	#endif
#endif
	switch (t->forw) {
	default: Uerror("bad forward move");
	case 0:	/* if without executable clauses */
		continue;
	case 1: /* generic 'goto' or 'skip' */
		IfNotBlocked
		_m = 3; goto P999;
	case 2: /* generic 'else' */
		IfNotBlocked
		if (trpt->o_pm&1) continue;
		_m = 3; goto P999;

		 /* PROC :init: */
	case 3: // STATE 1 - model.pml:75 - [array[0] = 10] (0:0:1 - 1)
		IfNotBlocked
		reached[3][1] = 1;
		(trpt+1)->bup.oval = now.array[0];
		now.array[0] = 10;
#ifdef VAR_RANGES
		logval("array[0]", now.array[0]);
#endif
		;
		_m = 3; goto P999; /* 0 */
	case 4: // STATE 2 - model.pml:75 - [array[1] = 1] (0:0:1 - 1)
		IfNotBlocked
		reached[3][2] = 1;
		(trpt+1)->bup.oval = now.array[1];
		now.array[1] = 1;
#ifdef VAR_RANGES
		logval("array[1]", now.array[1]);
#endif
		;
		_m = 3; goto P999; /* 0 */
	case 5: // STATE 3 - model.pml:75 - [array[2] = 75] (0:0:1 - 1)
		IfNotBlocked
		reached[3][3] = 1;
		(trpt+1)->bup.oval = now.array[2];
		now.array[2] = 75;
#ifdef VAR_RANGES
		logval("array[2]", now.array[2]);
#endif
		;
		_m = 3; goto P999; /* 0 */
	case 6: // STATE 4 - model.pml:75 - [array[3] = 10] (0:0:1 - 1)
		IfNotBlocked
		reached[3][4] = 1;
		(trpt+1)->bup.oval = now.array[3];
		now.array[3] = 10;
#ifdef VAR_RANGES
		logval("array[3]", now.array[3]);
#endif
		;
		_m = 3; goto P999; /* 0 */
	case 7: // STATE 5 - model.pml:75 - [array[4] = 14] (0:0:1 - 1)
		IfNotBlocked
		reached[3][5] = 1;
		(trpt+1)->bup.oval = now.array[4];
		now.array[4] = 14;
#ifdef VAR_RANGES
		logval("array[4]", now.array[4]);
#endif
		;
		_m = 3; goto P999; /* 0 */
	case 8: // STATE 6 - model.pml:114 - [i = 0] (0:0:1 - 1)
		IfNotBlocked
		reached[3][6] = 1;
		(trpt+1)->bup.oval = ((P3 *)_this)->i;
		((P3 *)_this)->i = 0;
#ifdef VAR_RANGES
		logval(":init::i", ((P3 *)_this)->i);
#endif
		;
		_m = 3; goto P999; /* 0 */
	case 9: // STATE 7 - model.pml:114 - [((i<=(16-1)))] (0:0:0 - 1)
		IfNotBlocked
		reached[3][7] = 1;
		if (!((((P3 *)_this)->i<=(16-1))))
			continue;
		_m = 3; goto P999; /* 0 */
	case 10: // STATE 8 - model.pml:115 - [sort1[i] = array[i]] (0:0:1 - 1)
		IfNotBlocked
		reached[3][8] = 1;
		(trpt+1)->bup.oval = now.sort1[ Index(((P3 *)_this)->i, 16) ];
		now.sort1[ Index(((P3 *)_this)->i, 16) ] = now.array[ Index(((P3 *)_this)->i, 16) ];
#ifdef VAR_RANGES
		logval("sort1[:init::i]", now.sort1[ Index(((P3 *)_this)->i, 16) ]);
#endif
		;
		_m = 3; goto P999; /* 0 */
	case 11: // STATE 9 - model.pml:116 - [sort2[i] = array[i]] (0:0:1 - 1)
		IfNotBlocked
		reached[3][9] = 1;
		(trpt+1)->bup.oval = now.sort2[ Index(((P3 *)_this)->i, 16) ];
		now.sort2[ Index(((P3 *)_this)->i, 16) ] = now.array[ Index(((P3 *)_this)->i, 16) ];
#ifdef VAR_RANGES
		logval("sort2[:init::i]", now.sort2[ Index(((P3 *)_this)->i, 16) ]);
#endif
		;
		_m = 3; goto P999; /* 0 */
	case 12: // STATE 10 - model.pml:117 - [sort3[i] = array[i]] (0:0:1 - 1)
		IfNotBlocked
		reached[3][10] = 1;
		(trpt+1)->bup.oval = now.sort3[ Index(((P3 *)_this)->i, 16) ];
		now.sort3[ Index(((P3 *)_this)->i, 16) ] = now.array[ Index(((P3 *)_this)->i, 16) ];
#ifdef VAR_RANGES
		logval("sort3[:init::i]", now.sort3[ Index(((P3 *)_this)->i, 16) ]);
#endif
		;
		_m = 3; goto P999; /* 0 */
	case 13: // STATE 11 - model.pml:114 - [i = (i+1)] (0:0:1 - 1)
		IfNotBlocked
		reached[3][11] = 1;
		(trpt+1)->bup.oval = ((P3 *)_this)->i;
		((P3 *)_this)->i = (((P3 *)_this)->i+1);
#ifdef VAR_RANGES
		logval(":init::i", ((P3 *)_this)->i);
#endif
		;
		_m = 3; goto P999; /* 0 */
	case 14: // STATE 17 - model.pml:121 - [(run Sort1())] (0:0:0 - 1)
		IfNotBlocked
		reached[3][17] = 1;
		if (!(addproc(II, 1, 0)))
			continue;
		_m = 3; goto P999; /* 0 */
	case 15: // STATE 18 - model.pml:122 - [(run Sort2())] (0:0:0 - 1)
		IfNotBlocked
		reached[3][18] = 1;
		if (!(addproc(II, 1, 1)))
			continue;
		_m = 3; goto P999; /* 0 */
	case 16: // STATE 19 - model.pml:123 - [(run Sort3())] (0:0:0 - 1)
		IfNotBlocked
		reached[3][19] = 1;
		if (!(addproc(II, 1, 2)))
			continue;
		_m = 3; goto P999; /* 0 */
	case 17: // STATE 21 - model.pml:126 - [(((isSorted1&&isSorted2)&&isSorted3))] (0:0:0 - 1)
		IfNotBlocked
		reached[3][21] = 1;
		if (!(((((int)now.isSorted1)&&((int)now.isSorted2))&&((int)now.isSorted3))))
			continue;
		_m = 3; goto P999; /* 0 */
	case 18: // STATE 22 - model.pml:127 - [printf('Sorts are finished\\n')] (0:46:2 - 1)
		IfNotBlocked
		reached[3][22] = 1;
		Printf("Sorts are finished\n");
		/* merge: printf('Result of sorting: ')(46, 23, 46) */
		reached[3][23] = 1;
		Printf("Result of sorting: ");
		/* merge: result[0] = 0(46, 24, 46) */
		reached[3][24] = 1;
		(trpt+1)->bup.ovals = grab_ints(2);
		(trpt+1)->bup.ovals[0] = ((P3 *)_this)->result[0];
		((P3 *)_this)->result[0] = 0;
#ifdef VAR_RANGES
		logval(":init::result[0]", ((P3 *)_this)->result[0]);
#endif
		;
		/* merge: i = 0(46, 25, 46) */
		reached[3][25] = 1;
		(trpt+1)->bup.ovals[1] = ((P3 *)_this)->i;
		((P3 *)_this)->i = 0;
#ifdef VAR_RANGES
		logval(":init::i", ((P3 *)_this)->i);
#endif
		;
		/* merge: .(goto)(0, 47, 46) */
		reached[3][47] = 1;
		;
		_m = 3; goto P999; /* 4 */
	case 19: // STATE 26 - model.pml:130 - [((i<=(16-1)))] (40:0:1 - 1)
		IfNotBlocked
		reached[3][26] = 1;
		if (!((((P3 *)_this)->i<=(16-1))))
			continue;
		/* merge: isPassed = 0(0, 27, 40) */
		reached[3][27] = 1;
		(trpt+1)->bup.oval = ((int)((P3 *)_this)->_4_6_isPassed);
		((P3 *)_this)->_4_6_isPassed = 0;
#ifdef VAR_RANGES
		logval(":init::isPassed", ((int)((P3 *)_this)->_4_6_isPassed));
#endif
		;
		_m = 3; goto P999; /* 1 */
	case 20: // STATE 28 - model.pml:133 - [((sort1[i]==sort2[i]))] (0:0:0 - 1)
		IfNotBlocked
		reached[3][28] = 1;
		if (!((now.sort1[ Index(((P3 *)_this)->i, 16) ]==now.sort2[ Index(((P3 *)_this)->i, 16) ])))
			continue;
		_m = 3; goto P999; /* 0 */
	case 21: // STATE 29 - model.pml:134 - [result[i] = sort1[i]] (0:0:1 - 1)
		IfNotBlocked
		reached[3][29] = 1;
		(trpt+1)->bup.oval = ((P3 *)_this)->result[ Index(((P3 *)_this)->i, 16) ];
		((P3 *)_this)->result[ Index(((P3 *)_this)->i, 16) ] = now.sort1[ Index(((P3 *)_this)->i, 16) ];
#ifdef VAR_RANGES
		logval(":init::result[:init::i]", ((P3 *)_this)->result[ Index(((P3 *)_this)->i, 16) ]);
#endif
		;
		_m = 3; goto P999; /* 0 */
	case 22: // STATE 30 - model.pml:135 - [isPassed = 1] (0:46:3 - 1)
		IfNotBlocked
		reached[3][30] = 1;
		(trpt+1)->bup.ovals = grab_ints(3);
		(trpt+1)->bup.ovals[0] = ((int)((P3 *)_this)->_4_6_isPassed);
		((P3 *)_this)->_4_6_isPassed = 1;
#ifdef VAR_RANGES
		logval(":init::isPassed", ((int)((P3 *)_this)->_4_6_isPassed));
#endif
		;
		if (TstOnly) return 1; /* TT */
		/* dead 2: _4_6_isPassed */  
#ifdef HAS_CODE
		if (!readtrail)
#endif
			((P3 *)_this)->_4_6_isPassed = 0;
		/* merge: .(goto)(46, 41, 46) */
		reached[3][41] = 1;
		;
		/* merge: printf('%d',result[i])(46, 42, 46) */
		reached[3][42] = 1;
		Printf("%d", ((P3 *)_this)->result[ Index(((P3 *)_this)->i, 16) ]);
		/* merge: i = (i+1)(46, 43, 46) */
		reached[3][43] = 1;
		(trpt+1)->bup.ovals[1] = ((P3 *)_this)->i;
		((P3 *)_this)->i = (((P3 *)_this)->i+1);
#ifdef VAR_RANGES
		logval(":init::i", ((P3 *)_this)->i);
#endif
		;
		/* merge: .(goto)(0, 47, 46) */
		reached[3][47] = 1;
		;
		_m = 3; goto P999; /* 4 */
	case 23: // STATE 31 - model.pml:136 - [((sort1[i]==sort3[i]))] (0:0:0 - 1)
		IfNotBlocked
		reached[3][31] = 1;
		if (!((now.sort1[ Index(((P3 *)_this)->i, 16) ]==now.sort3[ Index(((P3 *)_this)->i, 16) ])))
			continue;
		_m = 3; goto P999; /* 0 */
	case 24: // STATE 32 - model.pml:137 - [result[i] = sort1[i]] (0:0:1 - 1)
		IfNotBlocked
		reached[3][32] = 1;
		(trpt+1)->bup.oval = ((P3 *)_this)->result[ Index(((P3 *)_this)->i, 16) ];
		((P3 *)_this)->result[ Index(((P3 *)_this)->i, 16) ] = now.sort1[ Index(((P3 *)_this)->i, 16) ];
#ifdef VAR_RANGES
		logval(":init::result[:init::i]", ((P3 *)_this)->result[ Index(((P3 *)_this)->i, 16) ]);
#endif
		;
		_m = 3; goto P999; /* 0 */
	case 25: // STATE 33 - model.pml:138 - [isPassed = 1] (0:46:3 - 1)
		IfNotBlocked
		reached[3][33] = 1;
		(trpt+1)->bup.ovals = grab_ints(3);
		(trpt+1)->bup.ovals[0] = ((int)((P3 *)_this)->_4_6_isPassed);
		((P3 *)_this)->_4_6_isPassed = 1;
#ifdef VAR_RANGES
		logval(":init::isPassed", ((int)((P3 *)_this)->_4_6_isPassed));
#endif
		;
		if (TstOnly) return 1; /* TT */
		/* dead 2: _4_6_isPassed */  
#ifdef HAS_CODE
		if (!readtrail)
#endif
			((P3 *)_this)->_4_6_isPassed = 0;
		/* merge: .(goto)(46, 41, 46) */
		reached[3][41] = 1;
		;
		/* merge: printf('%d',result[i])(46, 42, 46) */
		reached[3][42] = 1;
		Printf("%d", ((P3 *)_this)->result[ Index(((P3 *)_this)->i, 16) ]);
		/* merge: i = (i+1)(46, 43, 46) */
		reached[3][43] = 1;
		(trpt+1)->bup.ovals[1] = ((P3 *)_this)->i;
		((P3 *)_this)->i = (((P3 *)_this)->i+1);
#ifdef VAR_RANGES
		logval(":init::i", ((P3 *)_this)->i);
#endif
		;
		/* merge: .(goto)(0, 47, 46) */
		reached[3][47] = 1;
		;
		_m = 3; goto P999; /* 4 */
	case 26: // STATE 34 - model.pml:139 - [((sort2[i]==sort3[i]))] (0:0:0 - 1)
		IfNotBlocked
		reached[3][34] = 1;
		if (!((now.sort2[ Index(((P3 *)_this)->i, 16) ]==now.sort3[ Index(((P3 *)_this)->i, 16) ])))
			continue;
		_m = 3; goto P999; /* 0 */
	case 27: // STATE 35 - model.pml:140 - [result[i] = sort2[i]] (0:0:1 - 1)
		IfNotBlocked
		reached[3][35] = 1;
		(trpt+1)->bup.oval = ((P3 *)_this)->result[ Index(((P3 *)_this)->i, 16) ];
		((P3 *)_this)->result[ Index(((P3 *)_this)->i, 16) ] = now.sort2[ Index(((P3 *)_this)->i, 16) ];
#ifdef VAR_RANGES
		logval(":init::result[:init::i]", ((P3 *)_this)->result[ Index(((P3 *)_this)->i, 16) ]);
#endif
		;
		_m = 3; goto P999; /* 0 */
	case 28: // STATE 36 - model.pml:141 - [isPassed = 1] (0:46:3 - 1)
		IfNotBlocked
		reached[3][36] = 1;
		(trpt+1)->bup.ovals = grab_ints(3);
		(trpt+1)->bup.ovals[0] = ((int)((P3 *)_this)->_4_6_isPassed);
		((P3 *)_this)->_4_6_isPassed = 1;
#ifdef VAR_RANGES
		logval(":init::isPassed", ((int)((P3 *)_this)->_4_6_isPassed));
#endif
		;
		if (TstOnly) return 1; /* TT */
		/* dead 2: _4_6_isPassed */  
#ifdef HAS_CODE
		if (!readtrail)
#endif
			((P3 *)_this)->_4_6_isPassed = 0;
		/* merge: .(goto)(46, 41, 46) */
		reached[3][41] = 1;
		;
		/* merge: printf('%d',result[i])(46, 42, 46) */
		reached[3][42] = 1;
		Printf("%d", ((P3 *)_this)->result[ Index(((P3 *)_this)->i, 16) ]);
		/* merge: i = (i+1)(46, 43, 46) */
		reached[3][43] = 1;
		(trpt+1)->bup.ovals[1] = ((P3 *)_this)->i;
		((P3 *)_this)->i = (((P3 *)_this)->i+1);
#ifdef VAR_RANGES
		logval(":init::i", ((P3 *)_this)->i);
#endif
		;
		/* merge: .(goto)(0, 47, 46) */
		reached[3][47] = 1;
		;
		_m = 3; goto P999; /* 4 */
	case 29: // STATE 38 - model.pml:143 - [isPassed = 0] (0:0:1 - 1)
		IfNotBlocked
		reached[3][38] = 1;
		(trpt+1)->bup.oval = ((int)((P3 *)_this)->_4_6_isPassed);
		((P3 *)_this)->_4_6_isPassed = 0;
#ifdef VAR_RANGES
		logval(":init::isPassed", ((int)((P3 *)_this)->_4_6_isPassed));
#endif
		;
		_m = 3; goto P999; /* 0 */
	case 30: // STATE 39 - model.pml:144 - [printf('Voting error for array[%d] = %d | %d | %d\\n',i,sort1[i],sort2[i],sort3[i])] (0:0:0 - 1)
		IfNotBlocked
		reached[3][39] = 1;
		Printf("Voting error for array[%d] = %d | %d | %d\n", ((P3 *)_this)->i, now.sort1[ Index(((P3 *)_this)->i, 16) ], now.sort2[ Index(((P3 *)_this)->i, 16) ], now.sort3[ Index(((P3 *)_this)->i, 16) ]);
		_m = 3; goto P999; /* 0 */
	case 31: // STATE 42 - model.pml:146 - [printf('%d',result[i])] (0:46:1 - 5)
		IfNotBlocked
		reached[3][42] = 1;
		Printf("%d", ((P3 *)_this)->result[ Index(((P3 *)_this)->i, 16) ]);
		/* merge: i = (i+1)(46, 43, 46) */
		reached[3][43] = 1;
		(trpt+1)->bup.oval = ((P3 *)_this)->i;
		((P3 *)_this)->i = (((P3 *)_this)->i+1);
#ifdef VAR_RANGES
		logval(":init::i", ((P3 *)_this)->i);
#endif
		;
		/* merge: .(goto)(0, 47, 46) */
		reached[3][47] = 1;
		;
		_m = 3; goto P999; /* 2 */
	case 32: // STATE 49 - model.pml:148 - [printf('\\nEnd\\n')] (0:50:0 - 3)
		IfNotBlocked
		reached[3][49] = 1;
		Printf("\nEnd\n");
		_m = 3; goto P999; /* 0 */
	case 33: // STATE 50 - model.pml:149 - [-end-] (0:0:0 - 1)
		IfNotBlocked
		reached[3][50] = 1;
		if (!delproc(1, II)) continue;
		_m = 3; goto P999; /* 0 */

		 /* PROC Sort3 */
	case 34: // STATE 1 - model.pml:49 - [((step>0))] (20:0:1 - 1)
		IfNotBlocked
		reached[2][1] = 1;
		if (!((((P2 *)_this)->step>0)))
			continue;
		/* merge: i = 0(0, 2, 20) */
		reached[2][2] = 1;
		(trpt+1)->bup.oval = ((P2 *)_this)->i;
		((P2 *)_this)->i = 0;
#ifdef VAR_RANGES
		logval("Sort3:i", ((P2 *)_this)->i);
#endif
		;
		/* merge: .(goto)(0, 21, 20) */
		reached[2][21] = 1;
		;
		_m = 3; goto P999; /* 2 */
	case 35: // STATE 3 - model.pml:50 - [((i<=((16-1)-step)))] (14:0:1 - 1)
		IfNotBlocked
		reached[2][3] = 1;
		if (!((((P2 *)_this)->i<=((16-1)-((P2 *)_this)->step))))
			continue;
		/* merge: j = i(0, 4, 14) */
		reached[2][4] = 1;
		(trpt+1)->bup.oval = ((P2 *)_this)->j;
		((P2 *)_this)->j = ((P2 *)_this)->i;
#ifdef VAR_RANGES
		logval("Sort3:j", ((P2 *)_this)->j);
#endif
		;
		/* merge: .(goto)(0, 15, 14) */
		reached[2][15] = 1;
		;
		_m = 3; goto P999; /* 2 */
	case 36: // STATE 5 - model.pml:54 - [(((j>=0)&&(sort3[j]>sort3[(j+step)])))] (0:0:0 - 1)
		IfNotBlocked
		reached[2][5] = 1;
		if (!(((((P2 *)_this)->j>=0)&&(now.sort3[ Index(((P2 *)_this)->j, 16) ]>now.sort3[ Index((((P2 *)_this)->j+((P2 *)_this)->step), 16) ]))))
			continue;
		_m = 3; goto P999; /* 0 */
	case 37: // STATE 6 - model.pml:55 - [temp = sort3[j]] (0:0:1 - 1)
		IfNotBlocked
		reached[2][6] = 1;
		(trpt+1)->bup.oval = ((P2 *)_this)->temp;
		((P2 *)_this)->temp = now.sort3[ Index(((P2 *)_this)->j, 16) ];
#ifdef VAR_RANGES
		logval("Sort3:temp", ((P2 *)_this)->temp);
#endif
		;
		_m = 3; goto P999; /* 0 */
	case 38: // STATE 7 - model.pml:56 - [sort3[j] = sort3[(j+step)]] (0:0:1 - 1)
		IfNotBlocked
		reached[2][7] = 1;
		(trpt+1)->bup.oval = now.sort3[ Index(((P2 *)_this)->j, 16) ];
		now.sort3[ Index(((P2 *)_this)->j, 16) ] = now.sort3[ Index((((P2 *)_this)->j+((P2 *)_this)->step), 16) ];
#ifdef VAR_RANGES
		logval("sort3[Sort3:j]", now.sort3[ Index(((P2 *)_this)->j, 16) ]);
#endif
		;
		_m = 3; goto P999; /* 0 */
	case 39: // STATE 8 - model.pml:57 - [sort3[(j+step)] = temp] (0:0:1 - 1)
		IfNotBlocked
		reached[2][8] = 1;
		(trpt+1)->bup.oval = now.sort3[ Index((((P2 *)_this)->j+((P2 *)_this)->step), 16) ];
		now.sort3[ Index((((P2 *)_this)->j+((P2 *)_this)->step), 16) ] = ((P2 *)_this)->temp;
#ifdef VAR_RANGES
		logval("sort3[(Sort3:j+Sort3:step)]", now.sort3[ Index((((P2 *)_this)->j+((P2 *)_this)->step), 16) ]);
#endif
		;
		_m = 3; goto P999; /* 0 */
	case 40: // STATE 9 - model.pml:58 - [j = (j-step)] (0:0:1 - 1)
		IfNotBlocked
		reached[2][9] = 1;
		(trpt+1)->bup.oval = ((P2 *)_this)->j;
		((P2 *)_this)->j = (((P2 *)_this)->j-((P2 *)_this)->step);
#ifdef VAR_RANGES
		logval("Sort3:j", ((P2 *)_this)->j);
#endif
		;
		_m = 3; goto P999; /* 0 */
	case 41: // STATE 17 - model.pml:50 - [i = (i+1)] (0:20:1 - 3)
		IfNotBlocked
		reached[2][17] = 1;
		(trpt+1)->bup.oval = ((P2 *)_this)->i;
		((P2 *)_this)->i = (((P2 *)_this)->i+1);
#ifdef VAR_RANGES
		logval("Sort3:i", ((P2 *)_this)->i);
#endif
		;
		/* merge: .(goto)(0, 21, 20) */
		reached[2][21] = 1;
		;
		_m = 3; goto P999; /* 1 */
	case 42: // STATE 23 - model.pml:64 - [step = (step/2)] (0:28:1 - 3)
		IfNotBlocked
		reached[2][23] = 1;
		(trpt+1)->bup.oval = ((P2 *)_this)->step;
		((P2 *)_this)->step = (((P2 *)_this)->step/2);
#ifdef VAR_RANGES
		logval("Sort3:step", ((P2 *)_this)->step);
#endif
		;
		/* merge: .(goto)(0, 27, 28) */
		reached[2][27] = 1;
		;
		/* merge: .(goto)(0, 29, 28) */
		reached[2][29] = 1;
		;
		_m = 3; goto P999; /* 2 */
	case 43: // STATE 31 - model.pml:69 - [isSorted3 = 1] (0:0:1 - 3)
		IfNotBlocked
		reached[2][31] = 1;
		(trpt+1)->bup.oval = ((int)now.isSorted3);
		now.isSorted3 = 1;
#ifdef VAR_RANGES
		logval("isSorted3", ((int)now.isSorted3));
#endif
		;
		_m = 3; goto P999; /* 0 */
	case 44: // STATE 32 - model.pml:70 - [printf('Sort3 is finished\\n')] (0:0:0 - 1)
		IfNotBlocked
		reached[2][32] = 1;
		Printf("Sort3 is finished\n");
		_m = 3; goto P999; /* 0 */
	case 45: // STATE 33 - model.pml:71 - [-end-] (0:0:0 - 1)
		IfNotBlocked
		reached[2][33] = 1;
		if (!delproc(1, II)) continue;
		_m = 3; goto P999; /* 0 */

		 /* PROC Sort2 */
	case 46: // STATE 1 - model.pml:26 - [i = 1] (0:0:1 - 1)
		IfNotBlocked
		reached[1][1] = 1;
		(trpt+1)->bup.oval = ((P1 *)_this)->i;
		((P1 *)_this)->i = 1;
#ifdef VAR_RANGES
		logval("Sort2:i", ((P1 *)_this)->i);
#endif
		;
		_m = 3; goto P999; /* 0 */
	case 47: // STATE 2 - model.pml:26 - [((i<=(16-1)))] (0:0:0 - 1)
		IfNotBlocked
		reached[1][2] = 1;
		if (!((((P1 *)_this)->i<=(16-1))))
			continue;
		_m = 3; goto P999; /* 0 */
	case 48: // STATE 3 - model.pml:27 - [temp = sort2[i]] (0:0:1 - 1)
		IfNotBlocked
		reached[1][3] = 1;
		(trpt+1)->bup.oval = ((P1 *)_this)->temp;
		((P1 *)_this)->temp = now.sort2[ Index(((P1 *)_this)->i, 16) ];
#ifdef VAR_RANGES
		logval("Sort2:temp", ((P1 *)_this)->temp);
#endif
		;
		_m = 3; goto P999; /* 0 */
	case 49: // STATE 4 - model.pml:29 - [j = i] (0:0:1 - 1)
		IfNotBlocked
		reached[1][4] = 1;
		(trpt+1)->bup.oval = ((P1 *)_this)->_2_2_j;
		((P1 *)_this)->_2_2_j = ((P1 *)_this)->i;
#ifdef VAR_RANGES
		logval("Sort2:j", ((P1 *)_this)->_2_2_j);
#endif
		;
		_m = 3; goto P999; /* 0 */
	case 50: // STATE 5 - model.pml:31 - [(((j>0)&&(temp<sort2[(j-1)])))] (0:0:0 - 1)
		IfNotBlocked
		reached[1][5] = 1;
		if (!(((((P1 *)_this)->_2_2_j>0)&&(((P1 *)_this)->temp<now.sort2[ Index((((P1 *)_this)->_2_2_j-1), 16) ]))))
			continue;
		_m = 3; goto P999; /* 0 */
	case 51: // STATE 6 - model.pml:32 - [sort2[j] = sort2[(j-1)]] (0:0:1 - 1)
		IfNotBlocked
		reached[1][6] = 1;
		(trpt+1)->bup.oval = now.sort2[ Index(((P1 *)_this)->_2_2_j, 16) ];
		now.sort2[ Index(((P1 *)_this)->_2_2_j, 16) ] = now.sort2[ Index((((P1 *)_this)->_2_2_j-1), 16) ];
#ifdef VAR_RANGES
		logval("sort2[Sort2:j]", now.sort2[ Index(((P1 *)_this)->_2_2_j, 16) ]);
#endif
		;
		_m = 3; goto P999; /* 0 */
	case 52: // STATE 7 - model.pml:33 - [j = (j-1)] (0:0:1 - 1)
		IfNotBlocked
		reached[1][7] = 1;
		(trpt+1)->bup.oval = ((P1 *)_this)->_2_2_j;
		((P1 *)_this)->_2_2_j = (((P1 *)_this)->_2_2_j-1);
#ifdef VAR_RANGES
		logval("Sort2:j", ((P1 *)_this)->_2_2_j);
#endif
		;
		_m = 3; goto P999; /* 0 */
	case 53: // STATE 12 - model.pml:37 - [sort2[j] = temp] (0:0:1 - 2)
		IfNotBlocked
		reached[1][12] = 1;
		(trpt+1)->bup.oval = now.sort2[ Index(((P1 *)_this)->_2_2_j, 16) ];
		now.sort2[ Index(((P1 *)_this)->_2_2_j, 16) ] = ((P1 *)_this)->temp;
#ifdef VAR_RANGES
		logval("sort2[Sort2:j]", now.sort2[ Index(((P1 *)_this)->_2_2_j, 16) ]);
#endif
		;
		_m = 3; goto P999; /* 0 */
	case 54: // STATE 16 - model.pml:26 - [i = (i+1)] (0:19:1 - 3)
		IfNotBlocked
		reached[1][16] = 1;
		(trpt+1)->bup.oval = ((P1 *)_this)->i;
		((P1 *)_this)->i = (((P1 *)_this)->i+1);
#ifdef VAR_RANGES
		logval("Sort2:i", ((P1 *)_this)->i);
#endif
		;
		/* merge: .(goto)(0, 20, 19) */
		reached[1][20] = 1;
		;
		_m = 3; goto P999; /* 1 */
	case 55: // STATE 22 - model.pml:40 - [isSorted2 = 1] (0:0:1 - 3)
		IfNotBlocked
		reached[1][22] = 1;
		(trpt+1)->bup.oval = ((int)now.isSorted2);
		now.isSorted2 = 1;
#ifdef VAR_RANGES
		logval("isSorted2", ((int)now.isSorted2));
#endif
		;
		_m = 3; goto P999; /* 0 */
	case 56: // STATE 23 - model.pml:41 - [printf('Sort2 is finished\\n')] (0:0:0 - 1)
		IfNotBlocked
		reached[1][23] = 1;
		Printf("Sort2 is finished\n");
		_m = 3; goto P999; /* 0 */
	case 57: // STATE 24 - model.pml:42 - [-end-] (0:0:0 - 1)
		IfNotBlocked
		reached[1][24] = 1;
		if (!delproc(1, II)) continue;
		_m = 3; goto P999; /* 0 */

		 /* PROC Sort1 */
	case 58: // STATE 1 - model.pml:8 - [i = 1] (0:0:1 - 1)
		IfNotBlocked
		reached[0][1] = 1;
		(trpt+1)->bup.oval = ((P0 *)_this)->i;
		((P0 *)_this)->i = 1;
#ifdef VAR_RANGES
		logval("Sort1:i", ((P0 *)_this)->i);
#endif
		;
		_m = 3; goto P999; /* 0 */
	case 59: // STATE 2 - model.pml:8 - [((i<=(16-1)))] (16:0:1 - 1)
		IfNotBlocked
		reached[0][2] = 1;
		if (!((((P0 *)_this)->i<=(16-1))))
			continue;
		/* merge: j = 0(0, 3, 16) */
		reached[0][3] = 1;
		(trpt+1)->bup.oval = ((P0 *)_this)->j;
		((P0 *)_this)->j = 0;
#ifdef VAR_RANGES
		logval("Sort1:j", ((P0 *)_this)->j);
#endif
		;
		/* merge: .(goto)(0, 17, 16) */
		reached[0][17] = 1;
		;
		_m = 3; goto P999; /* 2 */
	case 60: // STATE 4 - model.pml:9 - [((j<=((16-i)-1)))] (0:0:0 - 1)
		IfNotBlocked
		reached[0][4] = 1;
		if (!((((P0 *)_this)->j<=((16-((P0 *)_this)->i)-1))))
			continue;
		_m = 3; goto P999; /* 0 */
	case 61: // STATE 5 - model.pml:11 - [((sort1[j]>sort1[(j+1)]))] (0:0:0 - 1)
		IfNotBlocked
		reached[0][5] = 1;
		if (!((now.sort1[ Index(((P0 *)_this)->j, 16) ]>now.sort1[ Index((((P0 *)_this)->j+1), 16) ])))
			continue;
		_m = 3; goto P999; /* 0 */
	case 62: // STATE 6 - model.pml:12 - [temp = sort1[j]] (0:0:1 - 1)
		IfNotBlocked
		reached[0][6] = 1;
		(trpt+1)->bup.oval = ((P0 *)_this)->temp;
		((P0 *)_this)->temp = now.sort1[ Index(((P0 *)_this)->j, 16) ];
#ifdef VAR_RANGES
		logval("Sort1:temp", ((P0 *)_this)->temp);
#endif
		;
		_m = 3; goto P999; /* 0 */
	case 63: // STATE 7 - model.pml:13 - [sort1[j] = sort1[(j+1)]] (0:0:1 - 1)
		IfNotBlocked
		reached[0][7] = 1;
		(trpt+1)->bup.oval = now.sort1[ Index(((P0 *)_this)->j, 16) ];
		now.sort1[ Index(((P0 *)_this)->j, 16) ] = now.sort1[ Index((((P0 *)_this)->j+1), 16) ];
#ifdef VAR_RANGES
		logval("sort1[Sort1:j]", now.sort1[ Index(((P0 *)_this)->j, 16) ]);
#endif
		;
		_m = 3; goto P999; /* 0 */
	case 64: // STATE 8 - model.pml:14 - [sort1[(j+1)] = temp] (0:0:1 - 1)
		IfNotBlocked
		reached[0][8] = 1;
		(trpt+1)->bup.oval = now.sort1[ Index((((P0 *)_this)->j+1), 16) ];
		now.sort1[ Index((((P0 *)_this)->j+1), 16) ] = ((P0 *)_this)->temp;
#ifdef VAR_RANGES
		logval("sort1[(Sort1:j+1)]", now.sort1[ Index((((P0 *)_this)->j+1), 16) ]);
#endif
		;
		_m = 3; goto P999; /* 0 */
	case 65: // STATE 10 - model.pml:16 - [(1)] (16:0:1 - 1)
		IfNotBlocked
		reached[0][10] = 1;
		if (!(1))
			continue;
		/* merge: .(goto)(16, 12, 16) */
		reached[0][12] = 1;
		;
		/* merge: j = (j+1)(16, 13, 16) */
		reached[0][13] = 1;
		(trpt+1)->bup.oval = ((P0 *)_this)->j;
		((P0 *)_this)->j = (((P0 *)_this)->j+1);
#ifdef VAR_RANGES
		logval("Sort1:j", ((P0 *)_this)->j);
#endif
		;
		/* merge: .(goto)(0, 17, 16) */
		reached[0][17] = 1;
		;
		_m = 3; goto P999; /* 3 */
	case 66: // STATE 13 - model.pml:9 - [j = (j+1)] (0:16:1 - 3)
		IfNotBlocked
		reached[0][13] = 1;
		(trpt+1)->bup.oval = ((P0 *)_this)->j;
		((P0 *)_this)->j = (((P0 *)_this)->j+1);
#ifdef VAR_RANGES
		logval("Sort1:j", ((P0 *)_this)->j);
#endif
		;
		/* merge: .(goto)(0, 17, 16) */
		reached[0][17] = 1;
		;
		_m = 3; goto P999; /* 1 */
	case 67: // STATE 19 - model.pml:8 - [i = (i+1)] (0:22:1 - 3)
		IfNotBlocked
		reached[0][19] = 1;
		(trpt+1)->bup.oval = ((P0 *)_this)->i;
		((P0 *)_this)->i = (((P0 *)_this)->i+1);
#ifdef VAR_RANGES
		logval("Sort1:i", ((P0 *)_this)->i);
#endif
		;
		/* merge: .(goto)(0, 23, 22) */
		reached[0][23] = 1;
		;
		_m = 3; goto P999; /* 1 */
	case 68: // STATE 25 - model.pml:20 - [isSorted1 = 1] (0:0:1 - 3)
		IfNotBlocked
		reached[0][25] = 1;
		(trpt+1)->bup.oval = ((int)now.isSorted1);
		now.isSorted1 = 1;
#ifdef VAR_RANGES
		logval("isSorted1", ((int)now.isSorted1));
#endif
		;
		_m = 3; goto P999; /* 0 */
	case 69: // STATE 26 - model.pml:21 - [printf('Sort1 is finished\\n')] (0:0:0 - 1)
		IfNotBlocked
		reached[0][26] = 1;
		Printf("Sort1 is finished\n");
		_m = 3; goto P999; /* 0 */
	case 70: // STATE 27 - model.pml:22 - [-end-] (0:0:0 - 1)
		IfNotBlocked
		reached[0][27] = 1;
		if (!delproc(1, II)) continue;
		_m = 3; goto P999; /* 0 */
	case  _T5:	/* np_ */
		if (!((!(trpt->o_pm&4) && !(trpt->tau&128))))
			continue;
		/* else fall through */
	case  _T2:	/* true */
		_m = 3; goto P999;
#undef rand
	}

