import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FilmComponent } from './components/film/film.component';
import { ListFilmComponent } from './components/list-film/list-film.component';
import { LoginComponent } from './components/login/login.component';
import { TicketComponent } from './components/ticket/ticket.component';
import { AuthGuard } from './guard/auth.guard';
import { InscriptionComponent } from './inscription/inscription.component';

const routes: Routes = [
    {path:'inscription', component: InscriptionComponent},
    {path:'film/:id', component: FilmComponent},
    {path:'film/:id/ticket', component: TicketComponent , canActivate: [AuthGuard]},
    {path:'login', component: LoginComponent},
    {path:'**', component: ListFilmComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
