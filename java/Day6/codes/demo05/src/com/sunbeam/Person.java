package com.sunbeam;

public class Person implements Cloneable {
	private String name; 
	private int height; 
	private int weight; 
	private Date birth;
	public Person() {
		// TODO Auto-generated constructor stub
	}
	public Person(String name, int height, int weight, Date birth) {
		this.name = name;
		this.height = height;
		this.weight = weight;
		this.birth = birth;
	}
	
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public int getHeight() {
		return height;
	}
	public void setHeight(int height) {
		this.height = height;
	}
	public int getWeight() {
		return weight;
	}
	public void setWeight(int weight) {
		this.weight = weight;
	}
	public Date getBirth() {
		return birth;
	}
	public void setBirth(Date birth) {
		this.birth = birth;
	}
	@Override
	protected Object clone() throws CloneNotSupportedException {
		Person temp = (Person) super.clone();
		temp.birth = (Date) this.birth.clone(); // deep copy   
		return temp; 
	}
	@Override
	public String toString() {
		return "Person [name=" + name + ", height=" + height + ", weight=" + weight + ", birth=" + birth + "]";
	}
	
	
}	
