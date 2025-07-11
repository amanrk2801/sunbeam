package com.sunbeam;

import java.io.BufferedInputStream;
import java.io.BufferedOutputStream;
import java.io.DataInput;
import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.io.PrintStream;
import java.util.ArrayList;
import java.util.List;

public class Program {

	public static void main(String[] args) {
		writeMovies( ); 
		 
	}

	

	public static void writeMovies() {
		List<Movie> list = new ArrayList<>();
		list.add(new Movie(1, "Star Wars", 7.5));
		list.add(new Movie(2, "Godfather", 8.0));
		list.add(new Movie(3, "Hidden Figures", 7.0));
		list.add(new Movie(4, "Bruce Almighty", 6.5));
		list.add(new Movie(5, "Forest Gump", 8.5));
		
		try(FileOutputStream fout = new FileOutputStream("movies.txt")){
			try(PrintStream out = new PrintStream(fout)){
				for (Movie m : list) {
					out.printf("%-10d %-5s %5.2f\n",m.getId(),m.getTitle(),m.getRating());
				}
			}//out.close(); 
			System.out.println("Movies saved..");
		}//fout.close(); 
		catch (Exception e) {
			e.printStackTrace();
		}
		
	}
	

}




