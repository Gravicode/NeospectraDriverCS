package com.gravicode.neospectralib.ImageConversion;
using android.graphics.Bitmap;
using android.graphics.BitmapFactory;
using android.util.Base64;
using java.io.ByteArrayOutputStream;
public class ImageUtil {
    
    public static Bitmap convert(String base64Str) {
        byte[] decodedBytes = Base64.decode(base64Str.substring((base64Str.indexOf(",") + 1)), Base64.DEFAULT);
        return BitmapFactory.decodeByteArray(decodedBytes, 0, decodedBytes.length);
    }
    
    public static String convert(Bitmap bitmap) {
        ByteArrayOutputStream outputStream = new ByteArrayOutputStream();
        bitmap.compress(Bitmap.CompressFormat.PNG, 100, outputStream);
        return Base64.encodeToString(outputStream.toByteArray(), Base64.DEFAULT);
    }
}
