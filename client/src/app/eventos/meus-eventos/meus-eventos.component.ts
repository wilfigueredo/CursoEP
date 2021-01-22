import { Component, OnInit } from '@angular/core';

import { Evento } from "../models/evento";
import { EventoService } from "../services/evento.service";

@Component({
  selector: 'app-meus-eventos',
  templateUrl: './meus-eventos.component.html'
})
export class MeusEventosComponent implements OnInit {
public eventos: Evento[];
public errorMessage: string = "";

  constructor(public eventoService: EventoService) { 
  }

  ngOnInit() {
    this.eventoService.obterMeusEventos()
      .subscribe(
        eventos => this.eventos = eventos,
        error => this.errorMessage
      );
  }
}

