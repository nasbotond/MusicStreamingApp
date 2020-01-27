/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package models;

import java.util.*;
/**
 *Song name and album is given as a parameters and then the endpoint returns five random countries where the song charted
 * @author root
 */
public class Song {
    String name;
    String artist;
    String chartedCountry;
    
    public Song(){
        
    }
    
    public Song(String name, String album){
        this.name = name;
        this.artist = album;
    }

    public String getName() {
        return name;
    }

    public String getArtist() {
        return artist;
    }

    public String getChartedCountry() {
        return chartedCountry;
    }    
    

    public void setName(String name) {
        this.name = name;
    }

    public void setArtist(String artist) {
        this.artist = artist;
    }

    public void setChartedCountry(String chartedCountry) {
        this.chartedCountry = chartedCountry;
    }  
    
    public static List<Song> chartedSongsInCountries(String name, String artist){
        List<Song> songList = new ArrayList<>();
        Song one = new Song(name, artist);
        one.setChartedCountry(generateRandomCountry());
        Song two = new Song(name, artist);
        two.setChartedCountry(generateRandomCountry());
        Song three = new Song(name, artist);
        three.setChartedCountry(generateRandomCountry());
        Song four = new Song(name, artist);
        four.setChartedCountry(generateRandomCountry());
        Song five = new Song(name, artist);
        five.setChartedCountry(generateRandomCountry());
        
        songList.add(one);
        songList.add(two);
        songList.add(three);
        songList.add(four);
        songList.add(five);
        
        return songList;
        
    }
    
    
    public static String generateRandomCountry(){
        List<String> listOfCountries = new ArrayList<>();
        listOfCountries.add("Hungary");
        listOfCountries.add("Germany");
        listOfCountries.add("China");
        listOfCountries.add("France");
        listOfCountries.add("UK");
        listOfCountries.add("USA");
        listOfCountries.add("Mexico");
        listOfCountries.add("Egypt");
        listOfCountries.add("India");
        listOfCountries.add("Australia");
        listOfCountries.add("Canada");
        listOfCountries.add("Austria");
        listOfCountries.add("Italy");
        listOfCountries.add("Russia");
        listOfCountries.add("Japan");
        listOfCountries.add("South Korea");
        
        Random rand = new Random();
        
        int country = rand.nextInt(listOfCountries.size());
        
        return listOfCountries.get(country);    
              
    }    
    
    
}