theory lab4
imports Main

begin
  
thm conjI
thm conjunct1
thm conjunct2
thm disjI1
thm conjE
(* Тест *)  
lemma "A \<and> B \<Longrightarrow> B \<and> A" (* когда верно A \<and> B, верно и B \<and> A *)
proof - (* proof - доказательство через Isar, "-" отключить автоматическое доказательство *)
  assume ab: "A \<and> B" (* предположим A \<and> B верно, запишем это в ab*)
  from ab have a: "A" by (rule conjunct1) (* из ab получим a (истина) по правилу A \<and> B \<Longrightarrow> A *)
  from ab have b: "B" by (rule conjunct2) (*  из ab получим b (истина) по правилу A \<and> B \<Longrightarrow> B *)
  from b a show "B \<and> A" by (rule conjI) (* из b и a получается "B \<and> A" (истина) по правилу 
B \<Longrightarrow> A \<Longrightarrow> B \<and> A *)
qed
(* Вариант 1 *)
lemma "\<lbrakk>A; B\<rbrakk> \<Longrightarrow> A \<and> B"
proof -
assume a: "A" and b: "B"
from a b show "A \<and> B" by (rule conjI)
qed
(* Вариант 2 *)  
lemma "A \<Longrightarrow> A \<or> B"
proof -
  assume a: "A"
  from a show "A \<or> B" by (rule disjI1) (* A \<Longrightarrow> A \<or> B *)
qed
(* Вариант *)
lemma "\<lbrakk>A \<and> B;\<lbrakk>A;B\<rbrakk> \<Longrightarrow> C\<rbrakk> \<Longrightarrow> C"
proof -
  assume a: "A" and b: "B"
  from a b have ab: "A \<and> B" by (rule conjI) 
  from ab have x: "A" by (rule )
  (* from a b x1 show "\<lbrakk>A \<and> B;\<lbrakk>A;B\<rbrakk> \<Longrightarrow> C\<rbrakk> \<Longrightarrow> C" by (rule conjE) *)
  (* from x2 x1 have c: "\<lbrakk>A \<and> B;\<lbrakk>A;B\<rbrakk> \<Longrightarrow> C\<rbrakk> \<Longrightarrow> C" by (rule conjE) *)
  from x2 x1 show "\<lbrakk>A \<and> B;\<lbrakk>A;B\<rbrakk> \<Longrightarrow> C\<rbrakk> \<Longrightarrow> C" by (rule conjE)
qed
      
end