To participate in a prize draw each one gives his/her firstname.

Each letter of a firstname has a value which is its rank in the English alphabet. A and a have rank 1, B and b rank 2 and so on.

The length of the firstname is added to the sum of these ranks hence a number som.

An array of random weights is linked to the firstnames and each som is multiplied by its corresponding weight to get what they call a winning number.
Example:

names: "COLIN,AMANDBA,AMANDAB,CAROL,PauL,JOSEPH"
weights: [1, 4, 4, 5, 2, 1]

PauL -> som = length of firstname + 16 + 1 + 21 + 12 = 4 + 50 -> 54
The *weight* associated with PauL is 2 so PauL's *winning number* is 54 * 2 = 108.

Now one can sort the firstnames in decreasing order of the winning numbers. When two people have the same winning number sort them alphabetically by their firstnames.
Task:

    parameters: st a string of firstnames, we an array of weights, n a rank

    return: the firstname of the participant whose rank is n (ranks are numbered from 1)

Example:

names: "COLIN,AMANDBA,AMANDAB,CAROL,PauL,JOSEPH"
weights: [1, 4, 4, 5, 2, 1]
n: 4

The function should return: "PauL"

Notes:

    The weight array is at least as long as the number of names, it may be longer.

    If st is empty return "No participants".

    If n is greater than the number of participants then return "Not enough participants".





using System;
using System.Collections.Generic;
using System.Linq;	
public class Rank
{
    public static string NthRank(string st, int[] we, int n)
    {
       Dictionary<string, int> d =  new Dictionary<string, int>();
        if(st.Length < 1 ){
           return "No participants";
        }
		 var fn = st.Split(',');
		 int k= 0;
		 foreach(var i in fn){
		 	var s = 0;
			 foreach(char j in i){
			 	s+= (int)Char.ToLower(j) - 97 + 1 ;
			 }
			 s+=i.Length;
			 d.Add(i,s*we[k]);
			  k += 1;
		 }
		 var list = d.Keys.ToList();
     var ordered = d.Keys.OrderByDescending(l => d[l]).ToList();
		 foreach(KeyValuePair<string, int> a in d.OrderByDescending(key => key.Value))
		  {			 
			 //Console.WriteLine("Key: {0}, Value: {1}", a.Key, a.Value);
		  }
		 if(list.Count< n){
		 	return "Not enough participants";
		 }
		 else {
			 return ordered[n-1];
		 }
		 
    }
}