#!/bin/bash
echo "
:load Driver.hs
\"list l0:\"
l0
\"replace 1 by 2 in list l0:\"
replace 1 2 l0
\"delete one 1 in list l0:\"
del1 1 l0
\"delete all 1 in list l0:\"
delall 1 l0
\"theorem 1\"
\"theorem: delall x (delall y zs) = delall y (delall x zs)\"
let x = 1
let y = 2
\"base: delall x (delall y []) = delall y (delall x [])\"
delall x (delall y []) == delall y (delall x [])
\"inductive step: delall x (delall y l0) = delall y (delall x l0)\"
delall x (delall y l0) == delall y (delall x l0)
\"theorem 2\"
\"theorem: delall y (replace x y xs) = delall x xs\"
\"base: delall y (replace x y []) = delall x []\"
delall y (replace x y []) == delall x []
\"inductive step: delall y (replace x y l0) = delall x l0\"
delall y (replace x y l0) == delall x l0
:quit
" | ghci