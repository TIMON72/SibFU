theory lab2b
imports Main

begin
  
(* Поиск контрпримеров *)
lemma "hd (xs @ ys) = hd xs"
apply (induct_tac xs)
using [[simp_trace]]
apply auto
nitpick
oops
value "hd ([] @ [a1])"
  
lemma "hd (xs @ ys) = hd xs"
nitpick
oops
    
lemma "hd (xs @ ys) = hd xs"
quickcheck
oops

end