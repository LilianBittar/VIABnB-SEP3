package dk.viabnb.sep3.group6.dataserver.rest.t3.models;

public class GuestAuthenticationRequest {
    private String email;
    private String password;

    public GuestAuthenticationRequest(String email, String password){
        this.email = email;
        this.password = password;
    }

    public String getEmail() {
        return email;
    }

    public String getPassword() {
        return password;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public void setPassword(String password) {
        this.password = password;
    }
}
