package com.tec.ce.tools;

import android.location.Location;

import org.w3c.dom.Document;
import org.xml.sax.InputSource;

import java.io.StringReader;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.List;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;

public class GPXWriter {
    private static final String TAG = GPXWriter.class.getName();

    //private static File file;

    public static Document writeString(String n, List<Location> points) {

        String gpxStr;
        String header = "<?xml version=\"1.0\" encoding=\"UTF-8\" <gpx version=\"1.1\">\n";
        String name = "<name>" + n + "</name><trkseg>\n";

        StringBuilder segments = new StringBuilder();
        DateFormat df = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ssZ");
        for (Location l : points) {
            segments.append("<trkpt lat=\"").append(l.getLatitude()).append("\" lon=\"").append(l.getLongitude()).append("\"><time>").append(df.format(new Date(l.getTime()))).append("</time></trkpt>\n");
        }

        String footer = "</trkseg></trk></gpx>";

//        try {
//            FileWriter writer = new FileWriter(file, false);
//            writer.append(header);
//            writer.append(name);
//            writer.append(segments.toString());
//            writer.append(footer);
//            writer.flush();
//            writer.close();
//            if (Config.isDEBUG())
//                Log.i(TAG, "Saved " + points.size() + " points.");
//        } catch (IOException e) {
//            // TODO Auto-generated catch block
//            //Log.e(TAG, "Error Writting Path",e);
//            e.printStackTrace();
//        }
        gpxStr = header + name + segments + footer;
        return convertStringToDocumentXML(gpxStr);
    }

    private static Document convertStringToDocumentXML(String xmlStr) {
        DocumentBuilderFactory factory = DocumentBuilderFactory.newInstance();
        DocumentBuilder builder;
        try
        {
            builder = factory.newDocumentBuilder();
            Document doc = builder.parse( new InputSource( new StringReader( xmlStr ) ) );
            return doc;
        } catch (Exception e) {
            e.printStackTrace();
        }
        return null;
    }
}
