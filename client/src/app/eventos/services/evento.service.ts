import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import { Observable } from "rxjs/Observable";

import { BaseService } from "../../services/base.service";
import { Evento, Categoria, Endereco } from "../models/evento";

@Injectable()
export class EventoService extends BaseService {

  constructor(private http: HttpClient) { super(); }

  obterCategorias(): Observable<Categoria[]> {
      return this.http
          .get<Categoria[]>(this.UrlServiceV1 + "eventos/categorias")
          .catch(super.serviceError);
  };

  registrarEvento(evento: Evento): Observable<Evento> {
      
      let response = this.http
          .post(this.UrlServiceV1 + "eventos", evento, super.ObterAuthHeaderJson())
          .map(super.extractData)
          .catch(super.serviceError);

      return response;
  };

  obterTodos(): Observable<Evento[]> {
      return this.http
          .get<Evento[]>(this.UrlServiceV1 + "eventos")
          .catch(super.serviceError);
  }

  obterEvento(id: string): Observable<Evento> {
      return this.http
          .get<Evento>(this.UrlServiceV1 + "eventos/" + id)
          .catch(super.serviceError);
  }

  obterMeuEvento(id: string): Observable<Evento> {
      return this.http
          .get(this.UrlServiceV1 + "eventos/meus-eventos/" + id, super.ObterAuthHeaderJson())
          .map(super.extractData)
          .catch(super.serviceError);
  }

  obterMeusEventos(): Observable<Evento[]> {
      return this.http
          .get<Evento[]>(this.UrlServiceV1 + "eventos/meus-eventos", super.ObterAuthHeaderJson())
          .catch(super.serviceError);
  };

  atualizarEvento(evento: Evento): Observable<Evento> {
      let response = this.http
          .put(this.UrlServiceV1 + "eventos", evento, super.ObterAuthHeaderJson())
          .map(super.extractData)
          .catch((super.serviceError));
      return response;
  };

  excluirEvento(id: string): Observable<Evento> {
      let response = this.http
          .delete(this.UrlServiceV1 + "eventos/" + id, super.ObterAuthHeaderJson())
          .map(super.extractData)
          .catch((super.serviceError));
      return response;
  };

  adicionarEndereco(endereco: Endereco): Observable<Endereco> {
      let response = this.http
          .post(this.UrlServiceV1 + "endereco", endereco, super.ObterAuthHeaderJson())
          .map(super.extractData)
          .catch((super.serviceError));
      return response;
  };

  atualizarEndereco(endereco: Endereco): Observable<Endereco> {
      let response = this.http
          .put(this.UrlServiceV1 + "endereco", endereco, super.ObterAuthHeaderJson())
          .map(super.extractData)
          .catch((super.serviceError));
      return response;
  };
}


