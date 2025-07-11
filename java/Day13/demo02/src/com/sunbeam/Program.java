package com.sunbeam;

import java.io.DataInput;
import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.util.ArrayList;
import java.util.List;

public class Program {

	public static void main(String[] args) {
		//writeMovies( ); 
		readMovies( ); 
	}

	

	public static void writeMovies() {
		List<Movie> list = new ArrayList<>();
		list.add(new Movie(1, "Star Wars", 7.5));
		list.add(new Movie(2, "Godfather", 8.0));
		list.add(new Movie(3, "Hidden Figures", 7.0));
		list.add(new Movie(4, "Bruce Almighty", 6.5));
		list.add(new Movie(5, "Forest Gump", 8.5));
		try(FileOutputStream fout = new FileOutputStream("movies.db")){
			try(ObjectOutputStream oout = new ObjectOutputStream(fout)){
				  oout.writeObject(list);
			}//oout.close(); 
			System.out.println("Movies saved..");
		}//fout.close(); 
		catch (Exception e) {
			e.printStackTrace();
		}
		
		
	}
	private static void readMovies() {
		List<Movie> list = new ArrayList<Movie>();
		try(FileInputStream fin = new FileInputStream("movies.db")){
			try(ObjectInputStream oin = new ObjectInputStream(fin)){
				list = (List<Movie>) oin.readObject(); 
			}//oin.close(); 
		}//fin.close(); 
		catch (Exception e) {
			e.printStackTrace();
		}
		System.out.println("Movies : ");
		list.forEach(e -> System.out.println(e));
	}

}




