package com.gravicode.neospectralib.Global;
using android.Manifest;
using android.content.Context;
using android.content.DialogInterface;
using android.content.Intent;
using android.content.pm.PackageManager;
using android.os.Build;
using androidx.annotation.NonNull;
using androidx.annotation.Nullable;
using androidx.core.app.ActivityCompat;
using androidx.localbroadcastmanager.content.LocalBroadcastManager;
using androidx.appcompat.app.AppCompatActivity;
using android.util.Log;
using android.view.animation.Animation;
using android.view.animation.AnimationUtils;
using android.widget.ProgressBar;
using android.widget.TextView;
// import com.gravicode.neospectralib.Activities.ResultsActivity;
using com.gravicode.neospectralib.R;
// import com.gravicode.neospectralib.myViews.MySeekBar;
using java.io.BufferedWriter;
using java.io.File;
using java.io.FileWriter;
using java.io.IOException;
using java.text.MessageFormat;
using java.util.ArrayList;
using java.util.List;
using static;
android.os.Environment.getExternalStoragePublicDirectory;
public class MethodsFactory {
    
    public static void showAlertMessage() {
    }
    
    Context mContext;
    
    Context String;
    
    Context String;
    
    [Override()]
    public void onClick() {
    }
    
    DialogInterface dialogInterface;
    
    DialogInterface int;
}
UnknownUnknownmyAlert.show();
UnknownNonNull Intent;
intent;
Unknown{LocalBroadcastManager.getInstance(mContext).sendBroadcast(intent);
Log.e("SEND BROADCAST ", ("sendBroadcast " + LocalBroadcastManager.getInstance(mContext)));
UnknownUnknown
    
    public static void logMessage(String tag, String message) {
        Log.e("***Debugging", (tag + (": " + message)));
    }
    
    public static void sendBroadCast(Context mContext) {
    }
    
    public static void rotateProgressBar(Context mContext, ProgressBar progressBar) {
        
    }
    
    public static File getFile(String fileDir, String fileName) {
        File file = null;
        try {
            file = new File(getExternalStoragePublicDirectory(fileDir), fileName);
            System.out.println(("************************* Path : " + fileDir));
            if (!file.exists()) {
                file.createNewFile();
            }
            
        }
        catch (IOException e) {
            e.printStackTrace();
        }
        
        return file;
    }
    
    public static bool writeGraphFile(double[] x, double[] y, String filePath, String fileName, String header) {
        BufferedWriter writer = null;
        try {
            File file = getFile(filePath, fileName);
            FileWriter fw = new FileWriter(file.getAbsoluteFile());
            writer = new BufferedWriter(fw);
            writer.write(header);
            writer.write("\n");
            int length = (x.length < y.length);
            // TODO: Warning!!!, inline IF is not supported ?
            for (int i = 0; (i < length); i++) {
                writer.write((Double.toString(x[i]) + ("\t" + Double.toString(y[i]))));
                writer.write("\n");
            }
            
            return true;
        }
        catch (IOException ex) {
            // logger.error(ex.getMessage());
            ex.printStackTrace();
            return false;
        }
        finally {
            try {
                writer.close();
            }
            catch (Exception ex) {
                //   logger.error(ex.getMessage());
                ex.printStackTrace();
            }
            
        }
        
    }
    
    public static double[] convertDataToT(double[] data) {
        double[] TArray = new double[data.length];
        for (int i = 0; (i < TArray.length); i++) {
            TArray[i] = (data[i] * 100);
        }
        
        return TArray;
    }
    
    public static double[] switch_NM_CM(double[] data) {
        double[] xAxis = new double[data.length];
        for (int i = 0; (i < xAxis.length); i++) {
            xAxis[i] = (10000000 / data[i]);
        }
        
        return xAxis;
    }
    
    public static String formatString(String template, Object...params Unknown) {
        return MessageFormat.format(template, params);
    }
