import { Component, OnInit, AfterViewInit, Input, ElementRef, EventEmitter, Output } from '@angular/core';
import Map from 'ol/Map';
import View from 'ol/View';
import { Tile as TileLayer, Vector as VectorLayer } from 'ol/layer';
import XYZ from 'ol/source/XYZ';
import * as Proj from 'ol/proj';
import GPX from 'ol/format/GPX';
import VectorSource from 'ol/source/Vector';
import { Circle as CircleStyle, Fill, Stroke, Style } from 'ol/style';
import { defaults as defaultControls } from 'ol/control';

export const DEFAULT_HEIGHT = '500px';
export const DEFAULT_WIDTH = '500px';

export const DEFAULT_LAT = 9.936044662798473;
export const DEFAULT_LON = -84.10458433436264;

export const DEFAULT_ZOOM = 12;

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit, AfterViewInit {

  @Input() lat: number = DEFAULT_LAT;
  @Input() lon: number = DEFAULT_LON;
  @Input() zoom: number = DEFAULT_ZOOM;
  @Input() width: string | number = DEFAULT_WIDTH;
  @Input() height: string | number = DEFAULT_HEIGHT;

  @Output() movestart = new EventEmitter<any>();
  @Output() moveend = new EventEmitter<any>();

  map!: Map;

  private mapEl!: HTMLElement;

  profiledata = [{
    "name":"Ariana",
    "last_name": "Solano Rodriguez",
    "birthdate":"12-06-1998",
    "nationality":"Canadian",
    "age":"24",
    "followers": "243",
    "following":"87",
    "activities":"155",
    "image":"https://m.media-amazon.com/images/I/31LtVzDD8AL._SL500_.jpg",

  },]

  activitydata = [{
    "name" : "Ariana",
    "last_name" : "Solano",
    "no_activity":"72347634",
    "type": "Cycling",
    "time":"1:38 PM",
    "date":"24-05-2022",
    "duration":"76",
    "distance": "85.39",
    "elevation": "1.324",
    "image" : "https://m.media-amazon.com/images/I/31LtVzDD8AL._SL500_.jpg",
    "gpx":"src/assets/gpx/1.gpx",
  },]


  constructor(private elementRef: ElementRef) { }

  ngOnInit(): void {
    this.mapEl = this.elementRef.nativeElement.querySelector('#map');
    this.setSize();
  }

  ngAfterViewInit(): void {
    const style: any = {
      'Point': new Style({
        image: new CircleStyle({
          fill: new Fill({
            color: '#FF3333',
          }),
          radius: 5,
          stroke: new Stroke({
            color: '#FF3333',
            width: 1,
          }),
        }),
      }),
      'LineString': new Style({
        stroke: new Stroke({
          color: '#FF3333',
          width: 3,
        }),
      }),
      'MultiLineString': new Style({
        stroke: new Stroke({
          color: '#FF3333',
          width: 3,
        }),
      }),
    };

    var vectorSource = new VectorSource({
      url: '../../assets/gpx/route9.gpx',
      format: new GPX(),
    });

    this.map = new Map({
      target: 'map',
      layers: [
        new TileLayer({
          source: new XYZ({
            url: 'https://{a-c}.tile.openstreetmap.org/{z}/{x}/{y}.png'
          })
        }),
        new VectorLayer({
          source: vectorSource,

          style: (feature) => {
            return style[feature.getGeometry()!.getType()];
          },
        })
      ],
      view: new View({
        center: Proj.fromLonLat([this.lon, this.lat]),
        zoom: this.zoom
      }),
      controls: defaultControls().extend([])
    })


  }

  private setSize() {
    if (this.mapEl) {
      const styles = this.mapEl.style;
      styles.height = coerceCssPixelValue(this.height) || DEFAULT_HEIGHT;
      styles.width = coerceCssPixelValue(this.width) || DEFAULT_WIDTH;
    }
  }

}

const cssUnitsPattern = /([A-Za-z%]+)$/;

function coerceCssPixelValue(value: any): string {
  if (value == null) {
    return '';
  }
  return cssUnitsPattern.test(value) ? value : `${value}px`;
}


