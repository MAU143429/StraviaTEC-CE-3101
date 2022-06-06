package com.tec.ce.tools;

import android.location.Location;

import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.List;

public class GPXWriter {
    private static final String TAG = GPXWriter.class.getName();

    private static File file;

    public static void writePath(String n, List<Location> points) {

        String header = "<?xml version=\"1.0\" encoding=\"UTF-8\" <gpx version=\"1.1\">\n";
        String name = "<name>" + n + "</name><trkseg>\n";

        StringBuilder segments = new StringBuilder();
        DateFormat df = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ssZ");
        for (Location l : points) {
            segments.append("<trkpt lat=\"").append(l.getLatitude()).append("\" lon=\"").append(l.getLongitude()).append("\"><time>").append(df.format(new Date(l.getTime()))).append("</time></trkpt>\n");
        }

        String footer = "</trkseg></trk></gpx>";

        try {
            FileWriter writer = new FileWriter(file, false);
            writer.append(header);
            writer.append(name);
            writer.append(segments.toString());
            writer.append(footer);
            writer.flush();
            writer.close();
//            if (Config.isDEBUG())
//                Log.i(TAG, "Saved " + points.size() + " points.");
        } catch (IOException e) {
            // TODO Auto-generated catch block
            //Log.e(TAG, "Error Writting Path",e);
            e.printStackTrace();
        }
    }
}
