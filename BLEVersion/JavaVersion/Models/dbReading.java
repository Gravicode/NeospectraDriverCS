package com.gravicode.neospectralib.Models;

import java.io.Serializable;
import java.util.Arrays;

/**
 *
 */

public class dbReading implements Serializable {
    private double[] yReading, xReading;

    public dbReading() {
    }

    public double[] getXReading() {
        return xReading;
    }

    public double[] getYReading() {
        return yReading;
    }

    public void setReading(double[] yReading, double[] xReading) {
        this.yReading = yReading;
        this.xReading = xReading;
    }

    @Override
    public String toString() {
        return "dbReading{" +
                "yReading=" + Arrays.toString(yReading) +
                ", xReading=" + Arrays.toString(xReading) +
                '}';
    }
}
