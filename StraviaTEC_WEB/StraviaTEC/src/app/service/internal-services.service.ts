import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { distance } from 'ol/coordinate';

export interface Options {
  position: number;
  data: string;
}

export interface Activities {
  position: number;
  type: string;
  distance: number;
  altitude: number;
}

@Injectable({
  providedIn: 'root',
})
export class InternalServicesService {
  url = 'https://straviaapi.azurewebsites.net';

  tempSource: Options[] = [];
  tempSource2: Options[] = [];
  tempSource3: Options[] = [];
  tempSource4: Activities[] = [];

  t_sponsors: number = 0;
  t_categories: number = 0;
  t_accounts: number = 0;
  t_activities: number = 0;

  constructor(private httpclient: HttpClient) {}

  setCategories(newCategory: any): Observable<Options[]> {
    this.t_categories = this.t_categories + 1;
    this.tempSource2.push({ position: this.t_categories, data: newCategory });
    return this.httpclient.post<Options[]>(
      `${this.url}/Activity/reply`,
      this.tempSource2
    );
  }
  setSponsors(newSponsor: any): Observable<Options[]> {
    this.t_sponsors = this.t_sponsors + 1;
    this.tempSource3.push({ position: this.t_sponsors, data: newSponsor });
    return this.httpclient.post<Options[]>(
      `${this.url}/Activity/reply`,
      this.tempSource3
    );
  }

  setAccounts(newAccount: any): Observable<Options[]> {
    this.t_accounts = this.t_accounts + 1;
    this.tempSource.push({ position: this.t_accounts, data: newAccount });
    return this.httpclient.post<Options[]>(
      `${this.url}/Activity/reply`,
      this.tempSource
    );
  }

  setActivities(newActivity: Activities): Observable<Activities[]> {
    this.t_activities = this.t_activities + 1;
    this.tempSource4.push({
      position: this.t_activities,
      type: newActivity.type,
      distance: newActivity.distance,
      altitude: newActivity.altitude,
    });
    return this.httpclient.post<Activities[]>(
      `${this.url}/Activity/reply/challenge`,
      this.tempSource4
    );
  }
}
