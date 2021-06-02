module Driver where
import App (replace, del1, delall)

l0 = [1, 2, 3, 2, 1]
main = do
     print (replace 1 2 l0)
     print (del1 1 l0)
     print (delall 1 l0)
     let x = 1
     let y = 2
     print (delall x (delall y []) == delall y (delall x []))
     print (delall x l0)