package hr.algebra.models;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;

@XmlAccessorType(XmlAccessType.FIELD)
public class Beer {
    @XmlElement(name = "id")
    private int id;

    @XmlElement(name = "name")
    private String name;

    @XmlElement(name = "tagline")
    private String tagline;

    @XmlElement(name = "first_brewed")
    private String firstBrewed;

    @XmlElement(name = "description")
    private String description;

    @XmlElement(name = "image_url")
    private String imageUrl;

    @XmlElement(name = "abv")
    private int abv;

    @XmlElement(name = "ibu")
    private int ibu;

    @XmlElement(name = "target_fg")
    private int targetFg;

    @XmlElement(name = "target_og")
    private int targetOg;

    @XmlElement(name = "ebc")
    private int ebc;

    @XmlElement(name = "srm")
    private int srm;

    @XmlElement(name = "ph")
    private int ph;

    @XmlElement(name = "attenuation_level")
    private int attenuationLevel;

    // Constructors, getters, and setters

    public Beer() {
    }

    public Beer(int id, String name, String tagline, String firstBrewed, String description, String imageUrl,
                int abv, int ibu, int targetFg, int targetOg, int ebc, int srm, int ph, int attenuationLevel) {
        this.id = id;
        this.name = name;
        this.tagline = tagline;
        this.firstBrewed = firstBrewed;
        this.description = description;
        this.imageUrl = imageUrl;
        this.abv = abv;
        this.ibu = ibu;
        this.targetFg = targetFg;
        this.targetOg = targetOg;
        this.ebc = ebc;
        this.srm = srm;
        this.ph = ph;
        this.attenuationLevel = attenuationLevel;
    }

    // Getters and setters

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

    public String getTagline() {
        return tagline;
    }

    public void setTagline(String tagline) {
        this.tagline = tagline;
    }

    public String getFirstBrewed() {
        return firstBrewed;
    }

    public void setFirstBrewed(String firstBrewed) {
        this.firstBrewed = firstBrewed;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public String getImageUrl() {
        return imageUrl;
    }

    public void setImageUrl(String imageUrl) {
        this.imageUrl = imageUrl;
    }

    public int getAbv() {
        return abv;
    }

    public void setAbv(int abv) {
        this.abv = abv;
    }

    public int getIbu() {
        return ibu;
    }

    public void setIbu(int ibu) {
        this.ibu = ibu;
    }

    public int getTargetFg() {
        return targetFg;
    }

    public void setTargetFg(int targetFg) {
        this.targetFg = targetFg;
    }

    public int getTargetOg() {
        return targetOg;
    }

    public void setTargetOg(int targetOg) {
        this.targetOg = targetOg;
    }

    public int getEbc() {
        return ebc;
    }

    public void setEbc(int ebc) {
        this.ebc = ebc;
    }

    public int getSrm() {
        return srm;
    }

    public void setSrm(int srm) {
        this.srm = srm;
    }

    public int getPh() {
        return ph;
    }

    public void setPh(int ph) {
        this.ph = ph;
    }

    public int getAttenuationLevel() {
        return attenuationLevel;
    }

    public void setAttenuationLevel(int attenuationLevel) {
        this.attenuationLevel = attenuationLevel;
    }
}
