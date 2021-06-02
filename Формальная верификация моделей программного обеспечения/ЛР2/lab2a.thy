theory lab2a
imports Main

begin
  
(*Индуктивное доказательство*)
  
no_notation Nil("[]") and Cons (infix "#" 65) and append (infixr "@" 65)
hide_type list
hide_const rev
datatype 'a list = Nil ("[]") | Cons 'a "'a list" (infixr "#" 65) 

primrec app :: "'a list \<Rightarrow> 'a list \<Rightarrow> 'a list" (infixr "@" 65) where 
  "[] @ ys = ys" | 
  "(x # xs) @ ys = x # (xs @ ys)" (*app.1 — первое уравнение app.2 - второе*)
  
value "(1#2#[]) @ 3#4#[]"
  
primrec rev :: "'a list \<Rightarrow> 'a list" where
  "rev [] = []" |
  "rev (x # xs) = (rev xs) @ (x # [])"
  
value "rev (1#2#3#[])"
value "rev (rev (a # b # c # []))"
 
lemma rev_app [simp]: "rev (xs @ ys) = (rev ys) @ (rev xs)"
using [[simp_trace]]
apply (induct_tac xs)
apply auto
sorry

theorem rev_rev [simp]: "rev (rev xs) = xs" (*первая теорема — свойства rev*)
using [[simp_trace]]
apply (induct_tac xs)
apply auto
done
    
lemma app_Nil2 [simp]: "xs @ [] = xs"
using [[simp_trace]]
apply (induct_tac xs)
apply auto
done
    
lemma app_assoc [simp]: "(xs @ ys) @ zs = xs @ (ys @ zs)"
using [[simp_trace]]
apply (induct_tac xs)
apply auto
done
  
end