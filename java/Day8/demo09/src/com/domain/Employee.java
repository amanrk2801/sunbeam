package com.domain;

public class Employee implements Comparable<Employee>{
	private int id; 
	private String name; 
	private double salary; 
	public Employee() {
		// TODO Auto-generated constructor stub
	}
	public Employee(int id, String name, double salary) {
		super();
		this.id = id;
		this.name = name;
		this.salary = salary;
	}
	public int getId() {
		return id;
	}
	public void setId(int id) {
		this.id = id;
	}
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public double getSalary() {
		return salary;
	}
	public void setSalary(double salary) {
		this.salary = salary;
	}
	@Override
	public String toString() {
		return String.format("%-20d%-15s%10.2f",this.id,this.name,this.salary); 
	}
	@Override
	public int compareTo(Employee o) {
		return this.id - o.id; 
	}
	
	
}
