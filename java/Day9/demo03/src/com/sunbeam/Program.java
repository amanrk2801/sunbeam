package com.sunbeam;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.Iterator;
import java.util.List;
import java.util.ListIterator;

public class Program {

	public static void main(String[] args) {
		List<Book> list = new ArrayList<Book>( ); 
		Collections.addAll(list,
		new Book(4, "The Alchemist", "Novel", 493.23),
		new Book(1, "The Archer", "Novel", 723.53),
	    new Book(5, "The Fountainhead", "Novel", 652.73),
	    new Book(2, "Atlas Shrugged", "Novel", 872.94),
	    new Book(6, "Harry Potter", "Novel", 423.68),
	    new Book(3, "Lord of Rings", "Novel", 621.53)		
		); 
		
		
		int index = 3; 
		Book b = list.get(index); 
		System.out.println(b);
		
		System.out.println();
		
		System.out.println("REV : ");
		
		ListIterator<Book> trav = list.listIterator(list.size());
		while(trav.hasPrevious()) {
			Book ele = trav.previous(); 
			System.out.println(ele);
		}
		// searching -- find given element -- indexOf(), lastIndexOf(), contains(), remove(obj)
		//	to function these methods correctly, the element class (like Book) 
		//  must have overridden equals() method
		//	and equals() should compare on desired fields (like id).
		System.out.println();
		int id = 5; 
		Book key = new Book( ); 
		key.setId(id);
		
		
		int idx = list.indexOf(key); 
		if(idx!=-1) {
			Book bk = list.get(idx); 
			System.out.println(bk);
		}
		else 
			System.out.println("Not found");
		
		System.out.println();
		
		Collections.sort(list);// natural ordering 
		
		for (Book b1 : list) {
			System.out.println(b1);
		}
		System.out.println();
		
		class BookNameComparator implements Comparator<Book>{

			@Override
			public int compare(Book x, Book y) {
				return x.getName().compareTo(y.getName()); 
			}
			
		}
		System.out.println("Sorted on Name : ");
		Collections.sort(list,new BookNameComparator());
		for (Book b1 : list) {
			System.out.println(b1);
		}
		System.out.println();
		
		class BookPriceComparator implements Comparator<Book>{

			@Override
			public int compare(Book x, Book y) {
				return (int) (x.getPrice() - y.getPrice()); 
			}
			
		}
		list.sort(new BookPriceComparator());
		System.out.println("Sorted on price : ");
		for (Book b1 : list) {
			System.out.println(b1);
		}
		
		System.out.println("Maximum price : ");
		Book maxPrice = Collections.max(list, new BookPriceComparator()); 
		System.out.println(maxPrice);
	}

}
