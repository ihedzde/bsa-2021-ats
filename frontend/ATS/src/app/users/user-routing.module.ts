import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { HomeComponent } from './components/home/home.component';
import { ResetPasswordComponent } from './components/reset-password/reset-password.component';
import { ResetPasswordGuard } from './guards/reset-password.guard';
import { ConfirmEmailComponent } from './components/confirm-email/confirm-email.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  {
    path: 'login',
    pathMatch: 'full',
    component: LoginComponent,
  },
  { path: 'registration', component: RegistrationComponent },
  { path: 'reset-password', component: ResetPasswordComponent, canActivate: [ResetPasswordGuard] },
  { path: 'confirm-email', component: ConfirmEmailComponent},
];

@NgModule({
  declarations: [],
  exports: [RouterModule],
  imports: [CommonModule, RouterModule.forChild(routes)],
})
export class UserRoutingModule {}
