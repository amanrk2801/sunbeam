package com.sunbeam;

import java.util.Scanner;

enum Arithmetic{
	ADDITION , SUBTRACTION,DIVISION,MULTIPLICATION,MODULUS
}


public class Program {

	public static void main(String[] args) {
		Scanner sc = new Scanner(System.in);
		System.out.print("Enter two numbers: ");
		int num1 = sc.nextInt();
		int num2 = sc.nextInt();
		int result;
		
		Arithmetic[] aritVal = Arithmetic.values(); 
		for (Arithmetic ar : aritVal) {
			System.out.println(ar.ordinal() + "." + ar.name());
		}
		
		System.out.println("Enter the choice : ");
		String option = sc.next(); 
		Arithmetic choice = Arithmetic.valueOf(option); 
		
		switch (choice) {
		case ADDITION:	
			result = num1 + num2;
			System.out.println("Result: " + result);
			break;
		case SUBTRACTION:
			result = num1 - num2;
			System.out.println("Result: " + result);
			break;
		case DIVISION:
			result = num1 * num2;
			System.out.println("Result: " + result);
			break;
		case MULTIPLICATION:
			result = num1 / num2;
			System.out.println("Result: " + result);
			break;
		}

	}

}
