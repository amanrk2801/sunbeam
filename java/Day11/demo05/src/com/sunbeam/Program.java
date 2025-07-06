package com.sunbeam;

import java.util.stream.Stream;

//Input : 1 , 2 , 3 , 4 , 5 , 6 , 7 , 8 , 9 , 10 
//step1 : Square of each number : 1 , 4 , 9 , 16 , 25 , 36 , 49 , 64 , 81 , 100 
//step2 : get all odd numbers : 1 , 9 , 25 , 49 , 81 
//step3 : append "java" :  "java1" , "java9" , "java25" , "java49" , "java81"
// print each element 
// of , map, filter , map , printer 
public class Program {
	
	/* 
	public static void main(String[] args) {
		//A sequence of elements supporting sequential and parallel 
		//aggregate operations
		Stream.of(1,2,3,4,5,6,7,8,9,10)
		.map(n -> n * n )
		.filter(n -> n%2!=0)
		.map(n -> "java"+n)
		.forEach(e -> System.out.println(e));

	}*/ 
	/* 
	public static void main(String[] args) {
		
		Stream<Integer> strm1 = Stream.of(1,2,3,4,5,6,7,8,9,10); 
		//1 , 2 , 3 , 4 , 5 , 6 , 7 , 8 , 9 , 10
		
		Stream<Integer> strm2 = strm1.map(n -> n * n); 
		//1 , 4 , 9 , 16 , 25 , 36 , 49 , 64 , 81 , 100
		
		Stream<Integer> strm3 = strm2.filter(n -> n%2!=0); 
		//1 , 9 , 25 , 49 , 81
		
		Stream<String> strm4 = strm3.map(n -> "java"+n); 
		//"java1" , "java9" , "java25" , "java49" , "java81"
		
		strm4.forEach(e -> System.out.println(e));
		
		strm4.forEach(e -> System.out.println(e));
		// java.lang.IllegalStateException
		//stream has already been operated upon or closed
		
	} 
	*/ 
	public static void main(String[] args) {
		
		Stream.of(1,2,3,4,5,6,7,8,9,10)
		.map(n -> {
		   System.out.println("map() -----" + n);	
		   return n * n; 	
		} )
		.filter(n -> {
			System.out.println("filter() ----" + n);
			return n%2!=0; 
		})
		.sorted((x,y) -> {
			System.out.println("Sorted() ---" + x +"<>" + y);
			return y-x; 
		})
		.map(n -> {
			System.out.println("map() ----" +n);
			return "java"+n; 
		})
		.forEach(e -> {
			System.out.println("for-each()------"+e); 
		});
		//System.out.println("Bye");

	} 

}
