package com.gravicode.neospectralib.Global;

import android.Manifest;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.os.Build;
import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.core.app.ActivityCompat;
import androidx.localbroadcastmanager.content.LocalBroadcastManager;
import androidx.appcompat.app.AppCompatActivity;
import android.util.Log;
import android.view.animation.Animation;
import android.view.animation.AnimationUtils;
import android.widget.ProgressBar;
import android.widget.TextView;

//import com.gravicode.neospectralib.Activities.ResultsActivity;
import com.gravicode.neospectralib.R;
//import com.gravicode.neospectralib.myViews.MySeekBar;


import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.List;

import static android.os.Environment.getExternalStoragePublicDirectory;


/**
 *
 */

public class MethodsFactory {
    
    public static void showAlertMessage(@NonNull Context mContext, String title, String message){
        androidx.appcompat.app.AlertDialog.Builder myAlert = new androidx.appcompat.app.AlertDialog
                .Builder(mContext);
        myAlert.setTitle(title);
        myAlert.setMessage(message);
        myAlert.setPositiveButton("OK", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(@NonNull DialogInterface dialogInterface, int i) {
                dialogInterface.dismiss();
            }
        });
        myAlert.show();
    }


    public static void logMessage(String tag, String message){
        Log.e("***Debugging", tag + ": " + message);
    }

    public static void sendBroadCast(Context mContext, @NonNull Intent intent) {
        LocalBroadcastManager.getInstance(mContext).sendBroadcast(intent);
        Log.e("SEND BROADCAST ","sendBroadcast " + LocalBroadcastManager.getInstance(mContext));
    }

    public static void rotateProgressBar(Context mContext, ProgressBar progressBar) {
        /*
        Animation rotation = AnimationUtils.loadAnimation(mContext,
                R.anim.clockwise_rotation);

        rotation.setRepeatCount(Animation.INFINITE);
        progressBar.startAnimation(rotation);*/
    }

    public static File getFile(String fileDir , String fileName){
        File file = null;
        try {
            file = new File(getExternalStoragePublicDirectory(fileDir), fileName);
            System.out.println("************************* Path : "+fileDir);
            if (!file.exists())
                file.createNewFile();
        } catch (IOException e) {
            e.printStackTrace();
        }
        return file;
    }

    public static boolean writeGraphFile(double[] x, double[] y, String filePath, String fileName, String header) {

        BufferedWriter writer = null;

        try {
            File file = getFile(filePath, fileName);
            FileWriter fw = new FileWriter(file.getAbsoluteFile());
            writer = new BufferedWriter(fw);
            writer.write(header);
            writer.write("\n");
            int length = x.length < y.length ? x.length : y.length;

            for (int i = 0; i < length; i++) {
                writer.write(Double.toString(x[i]) + "\t" + Double.toString(y[i]));
                writer.write("\n");
            }

            return true;

        } catch (IOException ex) {
            //logger.error(ex.getMessage());
            ex.printStackTrace();
            return false;
        } finally {
            try {
                writer.close();
            } catch (Exception ex) {
                //  logger.error(ex.getMessage());
                ex.printStackTrace();
            }
        }
    }



    public static double[] convertDataToT(double[] data) {
        double[] TArray = new double[data.length];
        for (int i = 0; i < TArray.length; i++) {
            TArray[i] =  data[i]  * 100;
        }
        return TArray;
    }

    public static double[] switch_NM_CM(double[] data) {
        double[] xAxis = new double[data.length];
        for (int i = 0; i < xAxis.length; i++) {
            xAxis[i] = 10000000 / data[i];
        }
        return xAxis;
    }

    public static String formatString(String template, Object... params) {
        return MessageFormat.format(template, params);
    }


}
