import { NgModule } from '@angular/core';
import { APP_BASE_HREF } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { Ng2Bs3ModalModule } from 'ng2-bs3-modal/ng2-bs3-modal';
import { NgxPaginationModule } from 'ngx-pagination';
import { routing } from './app.routing';
import { UserComponent } from './Components/user.component';
import { UserService } from './Service/user.service';
import { PolicyComponent } from './Components/policy.component';
import { PolicyService } from './Service/policy.service';
import { UserFilterPipe } from './Pipes/user.pipe'
import { PolicyFilterPipe } from './Pipes/policy.pipe'
import { SearchComponent } from './Components/search.component';
import { LoginComponent } from './Components/login.component';
import { AuthGuard } from './Guards/auth.guard';
import { AuthService } from './Service/auth.service';
import { MessageService } from './Service/message.service'

@NgModule({
	imports: [BrowserModule, ReactiveFormsModule, HttpModule, routing, NgxPaginationModule, Ng2Bs3ModalModule, FormsModule],
	declarations: [AppComponent, UserComponent, PolicyComponent, UserFilterPipe, PolicyFilterPipe, SearchComponent, LoginComponent],
	providers: [{ provide: APP_BASE_HREF, useValue: '/' }, UserService, PolicyService, AuthGuard, AuthService, MessageService],
	bootstrap: [AppComponent]
})

export class AppModule { }