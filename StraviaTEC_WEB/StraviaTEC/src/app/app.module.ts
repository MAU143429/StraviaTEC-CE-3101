import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule} from '@angular/common/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule , ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatFormFieldModule } from '@angular/material/form-field'
import { MatInputModule } from '@angular/material/input';
import {MatAutocompleteModule} from '@angular/material/autocomplete';
import { AgmCoreModule } from '@agm/core';
import {MatTableModule } from '@angular/material/table'


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { UnavbarComponent } from './components/unavbar/unavbar.component';
import { UserLoginComponent } from './components/user-login/user-login.component';
import { UserDashboardComponent } from './components/user-dashboard/user-dashboard.component';
import { RegisterComponent } from './components/register/register.component';
import { AdminLoginComponent } from './components/admin-login/admin-login.component';
import { AnavbarComponent } from './components/anavbar/anavbar.component';
import { TrainingComponent } from './components/training/training.component';
import { ChallengesComponent } from './components/challenges/challenges.component';
import { ProfileComponent } from './components/profile/profile.component';
import { SearchComponent } from './components/search/search.component';
import { RacesComponent } from './components/races/races.component';
import { GroupComponent } from './components/group/group.component';
import { CreateRaceComponent } from './components/create-race/create-race.component';
import { InscriptionsComponent } from './components/inscriptions/inscriptions.component';
import { CreateChallengeComponent } from './components/create-challenge/create-challenge.component';
import { CreateGroupsComponent } from './components/create-groups/create-groups.component';
import { ReportsComponent } from './components/reports/reports.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    UnavbarComponent,
    UserLoginComponent,
    UserDashboardComponent,
    RegisterComponent,
    AdminLoginComponent,
    AnavbarComponent,
    TrainingComponent,
    ChallengesComponent,
    ProfileComponent,
    SearchComponent,
    RacesComponent,
    GroupComponent,
    CreateRaceComponent,
    InscriptionsComponent,
    CreateChallengeComponent,
    CreateGroupsComponent,
    ReportsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    NgbModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    HttpClientModule,
    MatAutocompleteModule,
    ReactiveFormsModule,
    MatTableModule,
    AgmCoreModule.forRoot({
      apiKey: 'AIzaSyBFKjVcAp2IaLbppDBHF9aIliBBW7wH13Y'
    }),

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
