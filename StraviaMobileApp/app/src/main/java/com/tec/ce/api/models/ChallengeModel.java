package com.tec.ce.api.models;

public class ChallengeModel {

    private String noChallenge;
    private String oUsername;
    private String cName;
    private String finalDate;

    public String getNoChallenge() {
        return noChallenge;
    }

    public void setNoChallenge(String noChallenge) {
        this.noChallenge = noChallenge;
    }

    public String getoUsername() {
        return oUsername;
    }

    public void setoUsername(String oUsername) {
        this.oUsername = oUsername;
    }

    public String getcName() {
        return cName;
    }

    public void setcName(String cName) {
        this.cName = cName;
    }

    public String getFinalDate() {
        return finalDate;
    }

    public void setFinalDate(String finalDate) {
        this.finalDate = finalDate;
    }
}
