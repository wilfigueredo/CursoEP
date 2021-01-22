import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

// bootstrap
import { CollapseModule } from 'ngx-bootstrap/collapse';

// components
import { MenuSuperiorComponent } from './menu-superior/menu-superior.component';
import { FooterComponent } from './footer/footer.component';
import { MenuLoginComponent } from './menu-login/menu-login.component';

@NgModule({
    imports: [
        CommonModule, 
        RouterModule,
        CollapseModule 
        ],
    declarations: [
        MenuSuperiorComponent,
        FooterComponent,
        MenuLoginComponent
        ],
    exports: [
        MenuSuperiorComponent,
        FooterComponent,
        MenuLoginComponent
        ]
})
export class SharedModule { }