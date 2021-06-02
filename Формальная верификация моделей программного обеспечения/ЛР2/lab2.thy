theory lab2
imports Main

begin

primrec replace :: "'a \<Rightarrow> 'a \<Rightarrow> 'a list \<Rightarrow> 'a list" where
  "replace x y [] = []" |
  "replace x y (z#zs) = (if z=x then y else z)#(replace x y zs)"
  
value "replace a b (a # [])"
  
primrec del1 :: "'a \<Rightarrow> 'a list \<Rightarrow> 'a list" where
  "del1 x [] = []" |
  "del1 x (y#ys) = (if (y=x) then ys else (y # (del1 x ys)))"
  
value "del1 a (a # b # c # [])"

primrec delall :: "'a \<Rightarrow> 'a list \<Rightarrow> 'a list" where
  "delall x [] = []" |
  "delall x (y#ys) = (if (y=x) then (delall x ys) else (y # (delall x ys)))"
  
value "delall a ( a # a # a # b # a # c # [])"

theorem "delall x (delall y zs) = delall y (delall x zs)" (* удаление всех вхождений
эл-ов списка ZS ассоциативно для любых X и Y *)
using [[simp_trace]]
apply (induct_tac zs)
apply auto
(* 
База - delall x (delall y []) = delall y (delall x []) - удаление всех вхождений
эл-ов пустого списка [] ассоциативно для любых X и Y

Переход - \<And>a list. delall x (delall y list) = delall y (delall x list) \<Longrightarrow> 
  delall x (delall y (a # list)) = delall y (delall x (a # list)) - для любого списка A удаление
всех вхождений Y и после у полученного списка удалив все вхождения X полученный список есть тоже 
самое, что и список, полученный путем удаления всех вхождений X и после у полученного списка удалив 
все вхождения Y 
*)
done
value "delall 1 (delall 2 [])"
value "delall 1 (delall 2 (2 # 1 # 3 # []))"
value "delall 2 (delall 1 (2 # 1 # 3 # []))"
    
theorem "delall y (replace x y xs) = delall x xs" (* замена эл-ов X на Y списка XS с последующим
удалением всех вхождений Y в полученном списке есть тоже самое, что удаление всех вхождений X в 
списке XS *)
using [[simp_trace]]
apply (induct_tac xs)
apply auto
(*
База - delall y (replace x y []) = delall x [] - замена эл-ов X на Y пустого списка [] с последующим
удалением всех вхождений Y в полученном списке есть тоже самое, что удаление всех вхождений X в 
списке XS

Переход - \<And>a list. delall y (replace x y list) = delall x list \<Longrightarrow> 
delall y (replace x y (a # list)) = delall x (a # list) - для любого списка A замена эл-ов X на Y 
с последующим удалением всех вхождений Y в полученном списке есть тоже самое, что удаление всех 
вхождений X в списке A
*) 
nitpick
oops
value "delall 2 (replace 1 2 (1 # []))"
value "delall 1 (2 # [])"
  
(*
База - пустой список
Переход - операция, берущая список и элемент, который далее добавляется в этот список

База связана с функцией с пустым списком, а переход - с функцией, содержащий не пустой список
*)
    
end