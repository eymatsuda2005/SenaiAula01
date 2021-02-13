import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CidadeComponent } from './cidade/cidade.component';
import { HomeComponent } from './home/home.component';
import { MedicoComponent } from './medico/medico.component';
import { PerfilComponent } from './perfil/perfil.component';

const routes: Routes = [
  {path: 'medicos', component:MedicoComponent},
  {path: 'cidades', component:CidadeComponent},
  {path: '', redirectTo:'home', pathMatch:'full'},
  {path:'home', component:HomeComponent},
  {path: 'perfil', component:PerfilComponent}

  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }