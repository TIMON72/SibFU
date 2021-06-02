{-# LANGUAGE EmptyDataDecls, RankNTypes, ScopedTypeVariables #-}

module App(del1, delall, replace) where {

import Prelude ((==), (/=), (<), (<=), (>=), (>), (+), (-), (*), (/), (**),
  (>>=), (>>), (=<<), (&&), (||), (^), (^^), (.), ($), ($!), (++), (!!), Eq,
  error, id, return, not, fst, snd, map, filter, concat, concatMap, reverse,
  zip, null, takeWhile, dropWhile, all, any, Integer, negate, abs, divMod,
  String, Bool(True, False), Maybe(Nothing, Just));
import qualified Prelude;

del1 :: forall a. (Eq a) => a -> [a] -> [a];
del1 x [] = [];
del1 x (y : ys) = (if y == x then ys else y : del1 x ys);

delall :: forall a. (Eq a) => a -> [a] -> [a];
delall x [] = [];
delall x (y : ys) = (if y == x then delall x ys else y : delall x ys);

replace :: forall a. (Eq a) => a -> a -> [a] -> [a];
replace x y [] = [];
replace x y (z : zs) = (if z == x then y else z) : replace x y zs;

}
