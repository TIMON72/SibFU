	switch (t->back) {
	default: Uerror("bad return move");
	case  0: goto R999; /* nothing to undo */

		 /* PROC :init: */

	case 3: // STATE 1
		;
		now.array[0] = trpt->bup.oval;
		;
		goto R999;

	case 4: // STATE 2
		;
		now.array[1] = trpt->bup.oval;
		;
		goto R999;

	case 5: // STATE 3
		;
		now.array[2] = trpt->bup.oval;
		;
		goto R999;

	case 6: // STATE 4
		;
		now.array[3] = trpt->bup.oval;
		;
		goto R999;

	case 7: // STATE 5
		;
		now.array[4] = trpt->bup.oval;
		;
		goto R999;

	case 8: // STATE 6
		;
		((P3 *)_this)->i = trpt->bup.oval;
		;
		goto R999;
;
		;
		
	case 10: // STATE 8
		;
		now.sort1[ Index(((P3 *)_this)->i, 16) ] = trpt->bup.oval;
		;
		goto R999;

	case 11: // STATE 9
		;
		now.sort2[ Index(((P3 *)_this)->i, 16) ] = trpt->bup.oval;
		;
		goto R999;

	case 12: // STATE 10
		;
		now.sort3[ Index(((P3 *)_this)->i, 16) ] = trpt->bup.oval;
		;
		goto R999;

	case 13: // STATE 11
		;
		((P3 *)_this)->i = trpt->bup.oval;
		;
		goto R999;

	case 14: // STATE 17
		;
		;
		delproc(0, now._nr_pr-1);
		;
		goto R999;

	case 15: // STATE 18
		;
		;
		delproc(0, now._nr_pr-1);
		;
		goto R999;

	case 16: // STATE 19
		;
		;
		delproc(0, now._nr_pr-1);
		;
		goto R999;
;
		;
		
	case 18: // STATE 25
		;
		((P3 *)_this)->i = trpt->bup.ovals[1];
		((P3 *)_this)->result[0] = trpt->bup.ovals[0];
		;
		ungrab_ints(trpt->bup.ovals, 2);
		goto R999;

	case 19: // STATE 27
		;
		((P3 *)_this)->_4_6_isPassed = trpt->bup.oval;
		;
		goto R999;
;
		;
		
	case 21: // STATE 29
		;
		((P3 *)_this)->result[ Index(((P3 *)_this)->i, 16) ] = trpt->bup.oval;
		;
		goto R999;

	case 22: // STATE 43
		;
		((P3 *)_this)->i = trpt->bup.ovals[1];
		((P3 *)_this)->_4_6_isPassed = trpt->bup.ovals[0];
		;
		ungrab_ints(trpt->bup.ovals, 3);
		goto R999;
;
		;
		
	case 24: // STATE 32
		;
		((P3 *)_this)->result[ Index(((P3 *)_this)->i, 16) ] = trpt->bup.oval;
		;
		goto R999;

	case 25: // STATE 43
		;
		((P3 *)_this)->i = trpt->bup.ovals[1];
		((P3 *)_this)->_4_6_isPassed = trpt->bup.ovals[0];
		;
		ungrab_ints(trpt->bup.ovals, 3);
		goto R999;
;
		;
		
	case 27: // STATE 35
		;
		((P3 *)_this)->result[ Index(((P3 *)_this)->i, 16) ] = trpt->bup.oval;
		;
		goto R999;

	case 28: // STATE 43
		;
		((P3 *)_this)->i = trpt->bup.ovals[1];
		((P3 *)_this)->_4_6_isPassed = trpt->bup.ovals[0];
		;
		ungrab_ints(trpt->bup.ovals, 3);
		goto R999;

	case 29: // STATE 38
		;
		((P3 *)_this)->_4_6_isPassed = trpt->bup.oval;
		;
		goto R999;
;
		;
		
	case 31: // STATE 43
		;
		((P3 *)_this)->i = trpt->bup.oval;
		;
		goto R999;
;
		
	case 32: // STATE 49
		goto R999;

	case 33: // STATE 50
		;
		p_restor(II);
		;
		;
		goto R999;

		 /* PROC Sort3 */

	case 34: // STATE 2
		;
		((P2 *)_this)->i = trpt->bup.oval;
		;
		goto R999;

	case 35: // STATE 4
		;
		((P2 *)_this)->j = trpt->bup.oval;
		;
		goto R999;
;
		;
		
	case 37: // STATE 6
		;
		((P2 *)_this)->temp = trpt->bup.oval;
		;
		goto R999;

	case 38: // STATE 7
		;
		now.sort3[ Index(((P2 *)_this)->j, 16) ] = trpt->bup.oval;
		;
		goto R999;

	case 39: // STATE 8
		;
		now.sort3[ Index((((P2 *)_this)->j+((P2 *)_this)->step), 16) ] = trpt->bup.oval;
		;
		goto R999;

	case 40: // STATE 9
		;
		((P2 *)_this)->j = trpt->bup.oval;
		;
		goto R999;

	case 41: // STATE 17
		;
		((P2 *)_this)->i = trpt->bup.oval;
		;
		goto R999;

	case 42: // STATE 23
		;
		((P2 *)_this)->step = trpt->bup.oval;
		;
		goto R999;

	case 43: // STATE 31
		;
		now.isSorted3 = trpt->bup.oval;
		;
		goto R999;
;
		;
		
	case 45: // STATE 33
		;
		p_restor(II);
		;
		;
		goto R999;

		 /* PROC Sort2 */

	case 46: // STATE 1
		;
		((P1 *)_this)->i = trpt->bup.oval;
		;
		goto R999;
;
		;
		
	case 48: // STATE 3
		;
		((P1 *)_this)->temp = trpt->bup.oval;
		;
		goto R999;

	case 49: // STATE 4
		;
		((P1 *)_this)->_2_2_j = trpt->bup.oval;
		;
		goto R999;
;
		;
		
	case 51: // STATE 6
		;
		now.sort2[ Index(((P1 *)_this)->_2_2_j, 16) ] = trpt->bup.oval;
		;
		goto R999;

	case 52: // STATE 7
		;
		((P1 *)_this)->_2_2_j = trpt->bup.oval;
		;
		goto R999;

	case 53: // STATE 12
		;
		now.sort2[ Index(((P1 *)_this)->_2_2_j, 16) ] = trpt->bup.oval;
		;
		goto R999;

	case 54: // STATE 16
		;
		((P1 *)_this)->i = trpt->bup.oval;
		;
		goto R999;

	case 55: // STATE 22
		;
		now.isSorted2 = trpt->bup.oval;
		;
		goto R999;
;
		;
		
	case 57: // STATE 24
		;
		p_restor(II);
		;
		;
		goto R999;

		 /* PROC Sort1 */

	case 58: // STATE 1
		;
		((P0 *)_this)->i = trpt->bup.oval;
		;
		goto R999;

	case 59: // STATE 3
		;
		((P0 *)_this)->j = trpt->bup.oval;
		;
		goto R999;
;
		;
		;
		;
		
	case 62: // STATE 6
		;
		((P0 *)_this)->temp = trpt->bup.oval;
		;
		goto R999;

	case 63: // STATE 7
		;
		now.sort1[ Index(((P0 *)_this)->j, 16) ] = trpt->bup.oval;
		;
		goto R999;

	case 64: // STATE 8
		;
		now.sort1[ Index((((P0 *)_this)->j+1), 16) ] = trpt->bup.oval;
		;
		goto R999;

	case 65: // STATE 13
		;
		((P0 *)_this)->j = trpt->bup.oval;
		;
		goto R999;

	case 66: // STATE 13
		;
		((P0 *)_this)->j = trpt->bup.oval;
		;
		goto R999;

	case 67: // STATE 19
		;
		((P0 *)_this)->i = trpt->bup.oval;
		;
		goto R999;

	case 68: // STATE 25
		;
		now.isSorted1 = trpt->bup.oval;
		;
		goto R999;
;
		;
		
	case 70: // STATE 27
		;
		p_restor(II);
		;
		;
		goto R999;
	}

