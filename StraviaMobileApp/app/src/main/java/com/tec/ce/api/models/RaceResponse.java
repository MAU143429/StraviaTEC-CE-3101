package com.tec.ce.api.models;

public class RaceResponse {
    private String noRace;
    private String oUsername;
    private String rName;
    private String price;

    public String getNoRace() {
        return noRace;
    }

    public void setNoRace(String noRace) {
        this.noRace = noRace;
    }

    public String getoUsername() {
        return oUsername;
    }

    public void setoUsername(String oUsername) {
        this.oUsername = oUsername;
    }

    public String getrName() {
        return rName;
    }

    public void setrName(String rName) {
        this.rName = rName;
    }

    public String getPrice() {
        return price;
    }

    public void setPrice(String price) {
        this.price = price;
    }
    @Override
    public String toString() {
        return "RaceResponse{" +
                "noRace='" + noRace + '\'' +
                ", oUsername='" + oUsername + '\'' +
                ", rName='" + rName + '\'' +
                ", price='" + price + '\'' +
                '}';
    }


}
