import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";

import { Observable } from "rxjs/Observable";

import { Organizador } from "../usuario/models/organizador";
import { BaseService } from "./base.service";


@Injectable()
export class OrganizadorService extends BaseService {

  constructor(private http: HttpClient){ super() }    

    registrarOrganizador(organizador: Organizador) : Observable<Organizador> {

        let response = this.http
            .post(this.UrlServiceV1 + "nova-conta", organizador, super.ObterHeaderJson())
            .map(super.extractData)
            .catch(super.serviceError)

        return response;
    }
    
    login(organizador: Organizador) : Observable<Organizador> {

        let response = this.http
            .post(this.UrlServiceV1 + "conta", organizador, super.ObterHeaderJson())
            .map(super.extractData)
            .catch(super.serviceError)

        return response;
    }
}
