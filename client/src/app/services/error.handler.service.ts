import { Injectable } from "@angular/core";
import { HttpInterceptor, HttpHandler, HttpEvent, HttpRequest, HttpErrorResponse } from "@angular/common/http";
import { Router } from "@angular/router";

import { Observable } from "rxjs/Observable";
import 'rxjs/add/operator/catch';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

    constructor(private router: Router){}

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        
        return next.handle(req).catch(err => {
            
            if(err instanceof HttpErrorResponse) {
                if(err.status === 401){
                    localStorage.removeItem('eio.token');
                    localStorage.removeItem('eio.user');
                    this.router.navigate(['/entrar']);
                }
                if (err.status === 403) {
                    this.router.navigate(['/acesso-negado']);
                }
                if (err.status === 404) {
                    this.router.navigate(['/nao-encontrado']);
                }
            }

            return Observable.throw(err);
        });
    }    
}