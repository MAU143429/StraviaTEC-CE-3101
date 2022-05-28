import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { UserLoginComponent } from './components/user-login/user-login.component';
import { AdminLoginComponent } from './components/admin-login/admin-login.component';
import { UserDashboardComponent } from './components/user-dashboard/user-dashboard.component';
import { ChallengesComponent } from './components/challenges/challenges.component';
import { TrainingComponent } from './components/training/training.component';
import { ProfileComponent } from './components/profile/profile.component';
import { SearchComponent } from './components/search/search.component';
import { RegisterComponent } from './components/register/register.component';
import { RacesComponent } from './components/races/races.component';
import { GroupComponent } from './components/group/group.component';

const routes: Routes = [

  {path: '', component: HomeComponent},
  {path: 'user-login', component: UserLoginComponent},
  {path: 'admin-login', component: AdminLoginComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'dashboard', component: UserDashboardComponent},
  {path: 'challenges', component: ChallengesComponent},
  {path: 'races', component: RacesComponent},
  {path: 'profile', component: ProfileComponent},
  {path: 'training', component: TrainingComponent},
  {path: 'search', component: SearchComponent},
  {path: 'groups', component: GroupComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }


