import { NgModule } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

// modules
import { MyDatePickerModule } from 'mydatepicker';

// components
import { EventoComponent } from "./evento.component";
import { ListaEventosComponent } from './lista-eventos/lista-eventos.component';
import { AdicionarEventoComponent } from "./adicionar-evento/adicionar-evento.component";
import { EditarEventoComponent } from './editar-evento/editar-evento.component';
import { MeusEventosComponent } from './meus-eventos/meus-eventos.component';
import { DetalhesEventoComponent } from './detalhes-evento/detalhes-evento.component';
import { ExcluirEventoComponent } from './excluir-evento/excluir-evento.component';

// services
import { SeoService } from '../services/seo.service';
import { EventoService } from "./services/evento.service";
import { OrganizadorService } from "../services/organizador.service";
import { AuthService } from "./services/auth.service";
import { ErrorInterceptor } from '../services/error.handler.service';

// config
import { eventosRouterConfig } from "./evento.routes";

// my modules
import { SharedModule } from "../shared/shared.module";

@NgModule({
    imports: [
        SharedModule,
        CommonModule,
        FormsModule,
        RouterModule.forChild(eventosRouterConfig),
        FormsModule,
        HttpClientModule,
        ReactiveFormsModule,
        MyDatePickerModule,
    ],
    declarations: [
        EventoComponent,
        ListaEventosComponent,
        AdicionarEventoComponent,
        EditarEventoComponent,
        MeusEventosComponent,
        DetalhesEventoComponent,
        ExcluirEventoComponent
    ],
    providers: [
        Title,
        SeoService,
        EventoService,
        OrganizadorService,
        AuthService,        
        {
            provide: HTTP_INTERCEPTORS,
            useClass: ErrorInterceptor,
            multi: true
          }
    ],
    exports: [RouterModule]
})

export class EventosModule { }