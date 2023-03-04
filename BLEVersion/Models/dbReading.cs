package com.gravicode.neospectralib.Models;
using java.io.Serializable;
using java.util.Arrays;
public class dbReading : Serializable {
    
    private double[] yReading;
    
    private double[] xReading;
    
    public dbReading() {
        
    }
    
    public double[] getXReading() {
        return this.xReading;
    }
    
    public double[] getYReading() {
        return this.yReading;
    }
    
    public void setReading(double[] yReading, double[] xReading) {
        this.yReading = this.yReading;
        this.xReading = this.xReading;
    }
    
    [Override()]
    public String toString() {
        return ("dbReading{" + ("yReading=" 
                    + (Arrays.toString(this.yReading) + (", xReading=" 
                    + (Arrays.toString(this.xReading) + '}')))));
    }
}