package hr.algebra.models;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import java.util.ArrayList;


@XmlRootElement(name = "beers")
@XmlAccessorType(XmlAccessType.FIELD)
public class Beers {

    @XmlElement(name = "beer")
    private ArrayList<Beer> beers;

    public Beers(){}

    public Beers(ArrayList<Beer> beers) {
        this.beers = beers;
    }

    public ArrayList<Beer> getBeers() {
        return beers;
    }

    public void setBeers(ArrayList<Beer> beers) {
        this.beers = beers;
    }
}
